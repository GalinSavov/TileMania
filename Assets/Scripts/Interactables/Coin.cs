using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Interactables
{
    public class Coin : Interactable,IInteractable
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.CompareTag("Player") && hasPickedUp)
            {
                DestroyPickup();
            }
        }
        public void DestroyPickup()
        {
            hasPickedUp = false;
            GameManager.Instance.IncreaseScore(pointsAwardedOnPickup);
            AudioSource.PlayClipAtPoint(audioSource.clip, Camera.main.transform.position);
            Destroy(gameObject);
        }
    }
    
}