using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Player
{
    public class Gavin : PlayableCharacter,IMovable,IKillable
    {
        [SerializeField] private float climbSpeed = 5f;
        [SerializeField] private GameObject projectile = null;
        [SerializeField] private Transform projectileSpawnPoint = null;
        void Update()
        {
            Move();
            Flip();
            Climb();
        }
        protected override void OnJump(InputValue inputValue)
        {
            if (inputValue.isPressed && feetBoxCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
            {
               rb.velocity = new Vector2(rb.velocity.x, jumpspeed);
            }
        }
        private void OnFire(InputValue inputValue)
        {
            GameObject playerProjectile = Instantiate(projectile, projectileSpawnPoint.position, Quaternion.identity);
        }
        public void Move()
        {
            Vector2 runInput = new Vector2(moveInput.x * moveSpeed, rb.velocity.y);
            rb.velocity = runInput;
            playerAnimator.SetBool("isRunning", moveInput.x != 0); 
        }
        public void Flip()
        {
            if (moveInput.x < 0)
                transform.localScale = new Vector3(-1, 1, 1);
            else if (moveInput.x > 0)
                transform.localScale = new Vector3(1, 1, 1);
        }
        //extra method specific for this playable character
        private void Climb()
        {
            if (moveInput.y != 0 && rb.IsTouchingLayers(LayerMask.GetMask("Climbing")))
            {
                rb.velocity = new Vector2(rb.velocity.x,moveInput.y * climbSpeed);
                rb.gravityScale = 0;
                playerAnimator.SetBool("isClimbing", true);
                playerAnimator.speed = 1;
            }

            else if(feetBoxCollider.IsTouchingLayers(LayerMask.GetMask("Climbing")) && !feetBoxCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))
                && moveInput.y == 0)
            {
                rb.velocity = Vector2.zero;
                rb.gravityScale = 0;
                playerAnimator.speed = 0;
            }
            else
            {
                playerAnimator.SetBool("isClimbing", false);
                rb.gravityScale = playerDefaultGravity;
            }

        }
        public void Die()
        {
            if (bodyCapsuleCollider.IsTouchingLayers(LayerMask.GetMask("Enemies", "Hazards")))
            {
                playerInput.DeactivateInput();
                playerAnimator.SetTrigger("isDead");
                playerSpriteRenderer.color = Color.red;
                gameObject.layer = 0;
                OnPlayerDeath?.Invoke();
                GameManager.Instance.ProcessPlayerDeath();
            }
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            Die();
        }

    }

}