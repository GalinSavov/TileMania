using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Enemies
{
    public class Goober : Enemy,IMovable
    {
        void Update()
        {
            Move();
        }
        public void Move()
        {
            rb.velocity = new Vector2(moveSpeed, 0);
        }
        private void Flip()
        {
            moveSpeed = -moveSpeed;
            transform.localScale = new Vector3(transform.localScale.x * -1, 1, 1);
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            Flip();
        }
    }
}
