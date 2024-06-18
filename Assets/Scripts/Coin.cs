using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Interactables
{
    public class Coin : MonoBehaviour
    {
        [SerializeField] private AudioSource audioSource = null;
        [SerializeField] private int pointsAwardedOnPickup = 100;
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.CompareTag("Player"))
            {
                GameManager.Instance.IncreaseScore(pointsAwardedOnPickup);
                AudioSource.PlayClipAtPoint(audioSource.clip, Camera.main.transform.position); 
                Destroy(gameObject);
            }
        }
     
    }

}