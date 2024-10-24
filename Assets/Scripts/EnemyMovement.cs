using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Enemies
{
    public class EnemyMovement : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rb = null;
        [SerializeField] private float moveSpeed = 5f;
        [SerializeField] private BoxCollider2D boxCollider = null;
        void Update()
        {
            Move();
        }
        private void Move()
        {
            rb.velocity = new Vector2(moveSpeed, 0);
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            moveSpeed = -moveSpeed;
            transform.localScale = new Vector3(transform.localScale.x * -1, 1, 1);
        }
    }
}
