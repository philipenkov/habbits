using System.Collections;
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
        
        // NextButton.interactable = false;
        // PrevButton.interactable = true;
        
        foreach (Transform child in ExpandedDaysParent)
        {
            Destroy(child.gameObject);
        }
        
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
    }

    public void ShowPreviousPage()
    {
        foreach (Transform child in ExpandedDaysParent)
        {
            Destroy(child.gameObject);
        }
        
        ExpandedDays.Clear();
        int lastShownDaysCount = allDaysCount - MaxDaysOnPage * currentPage;
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
            lastIdToShow = allDaysCount - MaxDaysOnPage * (currentPage + 1);
        }

        for (int i = startIdToShow; i >= lastIdToShow ; i--)
        {
            var expandedDayObj = Instantiate(ExpandedDayPrefab, ExpandedDaysParent);
            ExpandedDay expandedDay = expandedDayObj.GetComponent<ExpandedDay>();
            ExpandedDays.Add(expandedDay);
            expandedDay.SetExpandedDay(cachedDayButtons[i].DayInfo);
        }
        
        currentPage++;
    }

    public void ShowNextPage()
    {
        
    }

}
