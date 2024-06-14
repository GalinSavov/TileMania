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
        Vector2 moveInput;
        string jump;
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            Run();
        }

        private void OnMove(InputValue inputValue)
        {
            moveInput = inputValue.Get<Vector2>();
        }

        private void Run()
        {
            //instead of 0, use rb.velocity.y
            //whatever the current y of the rb is, use that
            Vector2 runInput = new Vector2(moveInput.x * moveSpeed, rb.velocity.y);
            rb.velocity = runInput;
        }
    }

}