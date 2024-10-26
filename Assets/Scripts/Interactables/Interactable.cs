using UnityEngine;

public abstract class Interactable:MonoBehaviour
{
    [SerializeField] protected AudioSource audioSource = null;
    [SerializeField] protected int pointsAwardedOnPickup = 100;
    protected bool hasPickedUp = true;
}