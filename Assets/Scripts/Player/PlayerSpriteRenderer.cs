using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Player
{
    public class PlayerSpriteRenderer : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer playerSpriteRenderer = null;
        public void SetPlayerColor(Color color)
        {
            playerSpriteRenderer.color = color;
        }
        public SpriteRenderer GetPlayerSpriteRenderer()
        {
            return playerSpriteRenderer;
        }
    }
}
