using UnityEngine;

namespace Game.Enemies
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] protected float moveSpeed = 5f;
        [SerializeField] protected Rigidbody2D rb = null;
        [SerializeField] protected BoxCollider2D boxCollider = null;
    }
}