using System.Collections.Generic;
using _App.Scripts.UILogic;
using UnityEngine;
using UnityEngine.UI;

public class DaysExpandedPanel : MonoBehaviour
{
    public int MaxDaysOnPage;
    public ExpandedDay ExpandedDayPrefab;
    public RectTransform ExpandedDaysParent;
    public Button PrevButton;
    public Button NextButton;

    public List<ExpandedDay> ExpandedDays { get; private set; } = new List<ExpandedDay>();
    
    private int currentPage;
    private int pagesCount;
    private int lastIdToShow;
    private int allDaysCount;
    private List<DayButton> cachedDayButtons = new List<DayButton>();

    public void InstantiateExpandedDays(List<DayButton> dayButtons)
    {
        cachedDayButtons = dayButtons;
        DestroysAllChilds();
        ExpandedDays.Clear();
        
        allDaysCount = dayButtons.Count;
        lastIdToShow = (allDaysCount - 1) - MaxDaysOnPage;

        if (lastIdToShow < 0)
            lastIdToShow = 0;
        else
        {
            pagesCount = Mathf.CeilToInt((float)allDaysCount / MaxDaysOnPage);
        }

        currentPage = 1;

        for (int i = allDaysCount - 1; i > lastIdToShow ; i--)
        {
            var expandedDayObj = Instantiate(ExpandedDayPrefab, ExpandedDaysParent);
            ExpandedDay expandedDay = expandedDayObj.GetComponent<ExpandedDay>();
            ExpandedDays.Add(expandedDay);
            expandedDay.SetExpandedDay(dayButtons[i].DayInfo);
        }
        
        CheckButtonsActivity();
    }

    public void ShowPreviousPage()
    {
        DestroysAllChilds();
        ExpandedDays.Clear();
        currentPage++;
        
        int lastShownDaysCount = allDaysCount - MaxDaysOnPage * (currentPage - 1);
        int startIdToShow;

        if (lastShownDaysCount < 0)
        {
            int daysLeft = MaxDaysOnPage - lastShownDaysCount * -1;
            lastIdToShow = 0;
            startIdToShow = daysLeft;
        }
        else if (lastShownDaysCount < MaxDaysOnPage)
        {
            startIdToShow = lastShownDaysCount - 1;
            lastIdToShow = 0;
        }
        else
        {
            startIdToShow = lastShownDaysCount - 1;
            lastIdToShow = allDaysCount - MaxDaysOnPage * currentPage;
        }

        for (int i = startIdToShow; i >= lastIdToShow ; i--)
        {
            var expandedDayObj = Instantiate(ExpandedDayPrefab, ExpandedDaysParent);
            ExpandedDay expandedDay = expandedDayObj.GetComponent<ExpandedDay>();
            ExpandedDays.Add(expandedDay);
            expandedDay.SetExpandedDay(cachedDayButtons[i].DayInfo);
        }
        
        CheckButtonsActivity();
    }

    public void ShowNextPage()
    {
        DestroysAllChilds();
        ExpandedDays.Clear();

        currentPage--;

        int startIdToShow = allDaysCount - MaxDaysOnPage * (currentPage - 1);
        int endIdToShow = startIdToShow - MaxDaysOnPage;

        if (endIdToShow < 0)
            endIdToShow = 0;

        for (int i = startIdToShow - 1; i >= endIdToShow; i--)
        {
            var expandedDayObj = Instantiate(ExpandedDayPrefab, ExpandedDaysParent);
            ExpandedDay expandedDay = expandedDayObj.GetComponent<ExpandedDay>();
            ExpandedDays.Add(expandedDay);
            expandedDay.SetExpandedDay(cachedDayButtons[i].DayInfo);
        }
        
        CheckButtonsActivity();
    }

    private void DestroysAllChilds()
    {
        foreach (Transform child in ExpandedDaysParent)
        {
            Destroy(child.gameObject);
        }
    }

    private void CheckButtonsActivity()
    {
        PrevButton.interactable = currentPage < pagesCount;
        NextButton.interactable = currentPage > 1;
    }
}
