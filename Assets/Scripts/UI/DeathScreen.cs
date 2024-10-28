using UnityEngine;
using Game.Player;
using UnityEngine.UI;

namespace Game.UI
{
    public class DeathScreen : MonoBehaviour
    {
        [SerializeField] private Image deathScreenImage = null; 

        private void OnEnable()
        {
            PlayableCharacter.OnPlayerDeath += HandleOnPlayerDeath;
        }
        private void Start()
        {
            deathScreenImage.enabled = false;
        }
        private void OnDisable()
        {
            PlayableCharacter.OnPlayerDeath -= HandleOnPlayerDeath;
        }

        private void HandleOnPlayerDeath()
        {
            deathScreenImage.enabled = true;
        }
    }

}