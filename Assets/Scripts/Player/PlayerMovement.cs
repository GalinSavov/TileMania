using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 10f;
        [SerializeField] private float jumpspeed = 5f;
        [SerializeField] private float climbSpeed = 5f;
                         private Vector2 moveInput;

        [SerializeField] private PlayerAnimator playerAnimator = null;
        [SerializeField] private PlayerPhysics playerPhysics = null;
        [SerializeField] private PlayerInput playerInput = null;
        [SerializeField] private PlayerSpriteRenderer playerSpriteRenderer = null;

        public static Action OnPlayerDeath;

        private void Start()
        {
            playerPhysics.SetPlayerDefaultGravity();
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
            if (inputValue.isPressed && playerPhysics.GetPlayerFeetBoxCollider().IsTouchingLayers(LayerMask.GetMask("Ground")))
            {
               playerPhysics.GetPlayerRigidbody2D().velocity = new Vector2(playerPhysics.GetPlayerRigidbody2D().velocity.x, jumpspeed);
            }
        }

        
        // Moves the character on the x-axis and play the appropriate animation
        private void Run()
        {
            Vector2 runInput = new Vector2(moveInput.x * moveSpeed, playerPhysics.GetPlayerRigidbody2D().velocity.y);
            playerPhysics.GetPlayerRigidbody2D().velocity = runInput;
            playerAnimator.SetBool("isRunning", moveInput.x != 0); 
        }

        // Flips the character depending if the A or D key was pressed
        private void FlipSprite()
        {
            if (moveInput.x < 0)
                transform.localScale = new Vector3(-1,1, 1);
            else if (moveInput.x > 0)
            transform.localScale = new Vector3(1, 1, 1);
        }

        private void Climb()
        {
            if (moveInput.y != 0 && playerPhysics.GetPlayerFeetBoxCollider().IsTouchingLayers(LayerMask.GetMask("Climbing")))
            {
                playerPhysics.GetPlayerRigidbody2D().velocity = new Vector2(playerPhysics.GetPlayerRigidbody2D().velocity.x,moveInput.y * climbSpeed);
                playerPhysics.GetPlayerRigidbody2D().gravityScale = 0;
                playerAnimator.SetBool("isClimbing", true);
                playerAnimator.SetSpeed(1);
            }

            else if(playerPhysics.GetPlayerFeetBoxCollider().IsTouchingLayers(LayerMask.GetMask("Climbing")) && !playerPhysics.GetPlayerFeetBoxCollider().IsTouchingLayers(LayerMask.GetMask("Ground"))
                && moveInput.y == 0)
            {
                playerPhysics.GetPlayerRigidbody2D().velocity = Vector2.zero;
                playerPhysics.GetPlayerRigidbody2D().gravityScale = 0;
                playerAnimator.SetSpeed(0);
            }
            else
            {
                playerAnimator.SetBool("isClimbing", false);
                playerPhysics.GetPlayerRigidbody2D().gravityScale = playerPhysics.GetPlayerDefaultGravity();
            }

        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if(playerPhysics.GetPlayerBodyCapsuleCollider().IsTouchingLayers(LayerMask.GetMask("Enemies","Hazards")))
                
            {
                playerInput.DeactivateInput();
                playerAnimator.SetTrigger("isDead");
                playerSpriteRenderer.SetPlayerColor(Color.red);
                gameObject.layer = 0;
                OnPlayerDeath?.Invoke();
                GameManager.Instance.ProcessPlayerDeath();
            }
        }
    }

}