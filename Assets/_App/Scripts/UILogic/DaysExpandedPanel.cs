using System;
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
    public PagesDisplay PagesDisplay;
    public CurrentExtendedButtonSelector CurrentExtendedButtonSelector;

    public List<ExpandedDay> ExpandedDays { get; private set; } = new List<ExpandedDay>();
    
    private int currentPage;
    private int pagesCount;
    private int lastIdToShow;
    private int allDaysCount;
    private List<DayButton> cachedDayButtons = new List<DayButton>();
    private ExpandedDay lastSelectedExpandedDay;

    private void Start()
    {
        CurrentExtendedButtonSelector.OnExpandedDaySelected += CacheLastSelectedExpandedButton;
    }

    public void InstantiateExpandedDays(List<DayButton> dayButtons)
    {
        cachedDayButtons = dayButtons;
        DestroysAllChilds();
        ExpandedDays.Clear();
        
        allDaysCount = dayButtons.Count;
        lastIdToShow = (allDaysCount - 1) - MaxDaysOnPage;
        pagesCount = 1;

        bool isOnePage = false;

        if (lastIdToShow < 0)
        {
            lastIdToShow = 0;
            isOnePage = true;
        }
        else
        {
            pagesCount = Mathf.CeilToInt((float)allDaysCount / MaxDaysOnPage);
        }

        currentPage = 1;
        
        if (isOnePage)
        {
            for (int i = lastIdToShow; i < allDaysCount; i++)
            {
                InstantiateExpandedDay(dayButtons[i].DayInfo);
            }   
        }
        else
        {
            for (int i = lastIdToShow + 1; i < allDaysCount; i++)
            {
                InstantiateExpandedDay(dayButtons[i].DayInfo);
            }
        }

        CheckButtonsActivity();
        PagesDisplay.SetAllPages(pagesCount.ToString());
        PagesDisplay.SetCurrentPage(currentPage.ToString());
    }

    private void InstantiateExpandedDay(DayInfo dayInfo)
    {
        var expandedDayObj = Instantiate(ExpandedDayPrefab, ExpandedDaysParent);
        ExpandedDay expandedDay = expandedDayObj.GetComponent<ExpandedDay>();
        ExpandedDays.Add(expandedDay);
        expandedDay.SetExpandedDay(dayInfo);
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

        for (int i = lastIdToShow; i <= startIdToShow; i++)
        {
            var expandedDayObj = Instantiate(ExpandedDayPrefab, ExpandedDaysParent);
            ExpandedDay expandedDay = expandedDayObj.GetComponent<ExpandedDay>();
            ExpandedDays.Add(expandedDay);
            expandedDay.SetExpandedDay(cachedDayButtons[i].DayInfo);
        }
        
        CheckButtonsActivity();
        CheckIfSelectionOfDayNeeded();
        PagesDisplay.SetCurrentPage(currentPage.ToString());
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

        for (int i = endIdToShow; i < startIdToShow; i++)
        {
            var expandedDayObj = Instantiate(ExpandedDayPrefab, ExpandedDaysParent);
            ExpandedDay expandedDay = expandedDayObj.GetComponent<ExpandedDay>();
            ExpandedDays.Add(expandedDay);
            expandedDay.SetExpandedDay(cachedDayButtons[i].DayInfo);
        }
        
        CheckButtonsActivity();
        CheckIfSelectionOfDayNeeded();
        PagesDisplay.SetCurrentPage(currentPage.ToString());
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
        PrevButton.gameObject.SetActive(currentPage < pagesCount);
        NextButton.gameObject.SetActive(currentPage > 1);
    }

    private void CacheLastSelectedExpandedButton(ExpandedDay expandedDay)
    {
        lastSelectedExpandedDay = expandedDay; 
    }

    private void CheckIfSelectionOfDayNeeded()
    {
        ExpandedDay dayToSelect = ExpandedDays.Find(day => day.LinkedDayInfo == lastSelectedExpandedDay.LinkedDayInfo);
        CurrentExtendedButtonSelector.UpdateSelection(dayToSelect);
    }

    private void OnDestroy()
    {
        CurrentExtendedButtonSelector.OnExpandedDaySelected -= CacheLastSelectedExpandedButton;
    }
}
