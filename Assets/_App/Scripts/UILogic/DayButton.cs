using System;
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
        public event Action<DayInfo> OnButtonPressed;
        
        public Button Button;
        public Image ButtonImage;

        private DayInfo dayInfo;
        private EditDayInfoController editDayInfoController;

        private void Start()
        {
            Button.onClick.AddListener(SendPressedButtonSignal);
        }

        public void Init(DayInfo initDayInfo)
        {
            dayInfo = initDayInfo;
        }

        public void ChangeColor(Color newColor)
        {
            ButtonImage.color = newColor;
        }

        private void SendPressedButtonSignal()
        {
            ScreenStatesSwitcher.SwitchTo(Screens.EditDay);
            if (editDayInfoController == null)
                editDayInfoController = FindObjectOfType<EditDayInfoController>(false);
            
            editDayInfoController.SetDayInfo(dayInfo);
            OnButtonPressed?.Invoke(dayInfo);
        }

        private void OnDestroy()
        {
            Button.onClick.RemoveListener(SendPressedButtonSignal);
        }
    }
}