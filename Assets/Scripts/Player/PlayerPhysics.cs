using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Player
{
    public class PlayerPhysics : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rb = null;
        [SerializeField] private BoxCollider2D playerFeetBoxCollider = null;
        [SerializeField] private CapsuleCollider2D playerBodyCapsuleCollider = null;
        private float playerDefaultGravity;

        public void SetPlayerDefaultGravity()
        {
            playerDefaultGravity = rb.gravityScale;
        }
        public float GetPlayerDefaultGravity()
        {
            return playerDefaultGravity;
        }
        public BoxCollider2D GetPlayerFeetBoxCollider()
        {
            return playerFeetBoxCollider;
        }
        public CapsuleCollider2D GetPlayerBodyCapsuleCollider()
        {
            return playerBodyCapsuleCollider;
        }
        public Rigidbody2D GetPlayerRigidbody2D() { return rb; }
    }

}