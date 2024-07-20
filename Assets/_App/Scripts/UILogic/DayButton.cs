using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;

namespace _App.Scripts.UILogic
{
    public struct DayInfo
    {
        public DateTime DateTime;
        public bool IsFilled;
        public string Info;
    }

    public class DayButton : MonoBehaviour
    {
        public Button Button;

        private void Start()
        {
        
        }

        private void SendPressedButtonSignal()
        {
        
        }

        private void OnDestroy()
        {
        
        }
    }
}