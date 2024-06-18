using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rb = null;
        [SerializeField] private float moveSpeed = 10f;
        [SerializeField] private float jumpspeed = 5f;
        [SerializeField] private float climbSpeed = 5f;
        [SerializeField] private Animator playerAnimator = null;
        [SerializeField] private BoxCollider2D playerFeetBoxCollider = null;
        [SerializeField] private CapsuleCollider2D playerBodyCapsuleCollider = null;
        [SerializeField] private PlayerInput playerInput = null;
        [SerializeField] private SpriteRenderer playerSpriteRenderer = null;
        //refactor and make more classes
        [SerializeField] private GameObject projectile = null;
        [SerializeField] private Transform projectileSpawnPoint = null;


        private Vector2 moveInput;
        private float playerDefaultGravity;

        public static Action OnPlayerDeath;

        private void Start()
        {
            playerDefaultGravity = rb.gravityScale;
            playerInput.ActivateInput();
            
        }

        void Update()
        {
            Run();
            FlipSprite();
            Climb();
        }

        private void OnMove(InputValue inputValue)
        {
            moveInput = inputValue.Get<Vector2>();
        }

        private void OnJump(InputValue inputValue)
        {
            if (inputValue.isPressed && playerFeetBoxCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpspeed);
            }
        }

        /// <summary>
        /// Moves the character on the x-axis and play the appropriate animation
        /// </summary>
        private void Run()
        {
            Vector2 runInput = new Vector2(moveInput.x * moveSpeed, rb.velocity.y);
            rb.velocity = runInput;

            playerAnimator.SetBool("isRunning", moveInput.x != 0); 
        }

        /// <summary>
        /// Flips the character depending if the A or D key was pressed
        /// </summary>
        private void FlipSprite()
        {
            if (moveInput.x < 0)
                transform.localScale = new Vector3(-1,1, 1);
            else if (moveInput.x > 0)
            transform.localScale = new Vector3(1, 1, 1);
        }

        private void Climb()
        {
            if (moveInput.y != 0 && playerFeetBoxCollider.IsTouchingLayers(LayerMask.GetMask("Climbing")))
            {
                rb.velocity = new Vector2(rb.velocity.x,moveInput.y * climbSpeed);
                playerAnimator.SetBool("isClimbing", true);
                playerAnimator.speed = 1;
                rb.gravityScale = 0;
            }

            else if(playerFeetBoxCollider.IsTouchingLayers(LayerMask.GetMask("Climbing")) && !playerFeetBoxCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))
                && moveInput.y == 0)
            {
                rb.velocity = Vector2.zero;
                playerAnimator.speed = 0;
                rb.gravityScale = 0;
            }
            else
            {
                playerAnimator.SetBool("isClimbing", false);
                rb.gravityScale = playerDefaultGravity;
            }

        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if(playerBodyCapsuleCollider.IsTouchingLayers(LayerMask.GetMask("Enemies","Hazards")))
                
            {
                playerInput.DeactivateInput();
                playerAnimator.SetTrigger("isDead");
                playerSpriteRenderer.color = Color.red;
                gameObject.layer = 0;
                OnPlayerDeath?.Invoke();
                GameManager.Instance.ProcessPlayerDeath();
            }
        }

        private void OnFire(InputValue inputValue)
        {
            GameObject playerProjectile = Instantiate(projectile, projectileSpawnPoint.position,Quaternion.identity);
        
        }
    }

}