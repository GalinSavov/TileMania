using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Game.Text
{
    [Serializable]
    public class ScoreText : Text
    {
        public override void SetText(string value)
        {
            text.text = value;
            text.color = Color.black;
        }
    }
}

