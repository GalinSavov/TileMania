using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Player;

namespace Game.Projectiles
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rb = null;
        [SerializeField] private float speed = 5f;
        private GameObject player;

        private void Awake()
        {
            player = GameObject.FindWithTag("Player");
        }
        void Start()
        {
            rb.velocity = new Vector2(speed * player.transform.localScale.x, 0);
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Enemy")
            {
                Destroy(collision.gameObject);
            }
            Destroy(gameObject);
        }

    }

}