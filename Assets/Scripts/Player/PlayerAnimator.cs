using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

namespace Game.Player
{
    public class PlayerAnimator: MonoBehaviour
    {
        [SerializeField] private Animator playerAnimator = null;

        public void SetBool(string animationName, bool value)
        {
            playerAnimator.SetBool(animationName, value);
        }
        public void SetSpeed(int value)
        {
            playerAnimator.speed = value;
        }
        public void SetTrigger(string animationName)
        {
            playerAnimator.SetTrigger(animationName);
        }
    }
}