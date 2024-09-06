using _App.Scripts.UILogic;
using UnityEngine;

public class CategoryToExpandedSetter : MonoBehaviour
{
    public EditDayInfoController EditDayInfoController;
    public GameObject ExpandedDayPrefab;
    public Transform ExpandedDaysParent;
    public DaysExpandedPanel DaysExpandedPanel;

    private CategoryPanel currentPanelShown;

    private void Start()
    {
        EditDayInfoController.OnInfoPanelSet += SetupCategoryButtons;
    }

    private void SetupCategoryButtons(DayInfo dayInfo)
    {
        CategoryPanel categoryPanel = dayInfo.CategoryPanel;
        
        if (currentPanelShown == categoryPanel)
            return;
        
        currentPanelShown = categoryPanel;
        DaysExpandedPanel.InstantiateExpandedDays(categoryPanel.DayButtons);
    }

    private void OnDestroy()
    {
        EditDayInfoController.OnInfoPanelSet -= SetupCategoryButtons;
    }
}
