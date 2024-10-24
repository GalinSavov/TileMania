using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Player
{
    public class PlayerCombat : MonoBehaviour
    {
        [SerializeField] private GameObject projectile = null;
        [SerializeField] private Transform projectileSpawnPoint = null;
        [SerializeField] private PlayerInput playerInput = null;


        private void OnFire(InputValue inputValue)
        {
            GameObject playerProjectile = Instantiate(projectile, projectileSpawnPoint.position, Quaternion.identity);
        }
    }
}