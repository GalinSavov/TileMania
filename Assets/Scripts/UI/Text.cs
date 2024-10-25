using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Game.Text
{
    public abstract class Text : MonoBehaviour
    {
        [SerializeField] protected TextMeshProUGUI text = null;
        public abstract void SetText(string text);
    }

}