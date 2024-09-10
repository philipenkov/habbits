using _App.Scripts.UILogic;
using UnityEngine;

public class CategoryToExpandedSetter : MonoBehaviour
{
    public EditDayInfoController EditDayInfoController;
    public DaysExpandedPanel DaysExpandedPanel;

    private void Start()
    {
        EditDayInfoController.OnInfoPanelSet += SetupCategoryButtons;
    }

    private void SetupCategoryButtons(DayInfo dayInfo)
    {
        CategoryPanel categoryPanel = dayInfo.CategoryPanel;
        DaysExpandedPanel.InstantiateExpandedDays(categoryPanel.DayButtons);
    }

    private void OnDestroy()
    {
        EditDayInfoController.OnInfoPanelSet -= SetupCategoryButtons;
    }
}
