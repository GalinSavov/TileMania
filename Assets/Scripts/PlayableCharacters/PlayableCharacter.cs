using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Player
{
    public abstract class PlayableCharacter : MonoBehaviour
    {
        [SerializeField] protected float moveSpeed = 10f;
        [SerializeField] protected float jumpspeed = 5f;
        [SerializeField] protected Rigidbody2D rb = null;
        [SerializeField] protected BoxCollider2D feetBoxCollider = null;
        [SerializeField] protected CapsuleCollider2D bodyCapsuleCollider = null;
        [SerializeField] protected PlayerInput playerInput = null;
        [SerializeField] protected Animator playerAnimator = null;
        [SerializeField] protected SpriteRenderer playerSpriteRenderer = null;
        protected float playerDefaultGravity;
        protected Vector2 moveInput;
        public static Action OnPlayerDeath;
        protected void Start()
        {
            playerDefaultGravity = rb.gravityScale;
            playerInput.ActivateInput();
        }
        protected void OnMove(InputValue inputValue)
        {
            moveInput = inputValue.Get<Vector2>();
        }
        protected abstract void OnJump(InputValue inputValue);
    }
}
