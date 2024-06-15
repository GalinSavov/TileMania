using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rb = null;
        [SerializeField] private float moveSpeed = 10f;
        [SerializeField] private float jumpHeight = 5f;
        [SerializeField] private Animator playerAnimator = null;    

        private Vector2 moveInput;
        
        void Update()
        {
            Run();
            FlipSprite();
            
        }

        private void OnMove(InputValue inputValue)
        {
            moveInput = inputValue.Get<Vector2>();
        }

        private void OnJump(InputValue inputValue)
        {

            if (inputValue.isPressed)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
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
    

    }

}