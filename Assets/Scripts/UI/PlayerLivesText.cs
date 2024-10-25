using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Game.Text
{
    [Serializable]
    public class PlayerLivesText : Text
    {
        public override void SetText(string value)
        {
            text.text = value;
        }
    }
}

