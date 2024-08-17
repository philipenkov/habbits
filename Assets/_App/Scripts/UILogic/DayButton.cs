using System;
using UnityEngine;
using UnityEngine.UI;

namespace _App.Scripts.UILogic
{
    public class DayInfo
    {
        public DateTime DateTime;
        public bool IsFilled;
        public string Info;
        public CategoryPanel CategoryPanel;
    }

    public class DayButton : MonoBehaviour
    {
        public Button Button;
        public Image ButtonImage;
        public Image InfoIndicator;
        public Color DefaultColor;

        public DayInfo DayInfo { get; private set; }
        
        private EditDayInfoController editDayInfoController;

        private void Start()
        {
            Button.onClick.AddListener(SendPressedButtonSignal);
        }

        public void Init(DayInfo initDayInfo)
        {
            DayInfo = initDayInfo;
            if (DayInfo.IsFilled)
                ChangeColor(DayInfo.CategoryPanel.ColorTheme);

            CheckInfoIndicator(DayInfo.Info);
        }

        public void ChangeColor(Color newColor)
        {
            ButtonImage.color = newColor;
        }

        public void CheckInfoIndicator(string info)
        {
            InfoIndicator.enabled = DayInfo.Info != string.Empty;
        }

        private void SendPressedButtonSignal()
        {
            ScreenStatesSwitcher.SwitchTo(Screens.EditDay);
            if (editDayInfoController == null)
                editDayInfoController = FindObjectOfType<EditDayInfoController>(false);
            
            editDayInfoController.SetDayInfo(DayInfo);
        }

        private void OnDestroy()
        {
            Button.onClick.RemoveListener(SendPressedButtonSignal);
        }
    }
}