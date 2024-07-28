using _App.Scripts.UILogic;
using UnityEngine;

public class CategoryToExpandedSetter : MonoBehaviour
{
    public EditDayInfoController EditDayInfoController;
    public GameObject ExpandedDayPrefab;
    public Transform ExpandedDaysParent;

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

        foreach (Transform child in ExpandedDaysParent)
        {
            Destroy(child.gameObject);
        }
        
        currentPanelShown = categoryPanel;

        foreach (var dayButton in categoryPanel.DayButtons)
        {
            var expandedDayObj = Instantiate(ExpandedDayPrefab, ExpandedDaysParent);
            ExpandedDay expandedDay = expandedDayObj.GetComponent<ExpandedDay>();
            expandedDay.SetExpandedDay(dayButton.DayInfo);
        }
    }

    private void OnDestroy()
    {
        EditDayInfoController.OnInfoPanelSet -= SetupCategoryButtons;
    }
}
