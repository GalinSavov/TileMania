using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Player;

namespace Game.Projectiles
{
    public class BasicProjectile : Projectile,IShootable
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            Destroy(collision);
        }
        public void Destroy(Collision2D collision)
        {
            if (collision.gameObject.tag == "Enemy")
            {
                Destroy(collision.gameObject);
            }
            Destroy(gameObject);
        }
    }

}