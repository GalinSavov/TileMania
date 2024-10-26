using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Projectiles
{
    public abstract class Projectile : MonoBehaviour
    {
        [SerializeField] protected Rigidbody2D rb = null;
        [SerializeField] protected float speed = 5f;
        protected GameObject player;

        protected void Awake()
        {
            player = GameObject.FindWithTag("Player");
        }
        protected void Start()
        {
            rb.velocity = new Vector2(speed * player.transform.localScale.x, 0);
        }
    }
}

