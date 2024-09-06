using System.Collections;
using System.Collections.Generic;
using _App.Scripts.UILogic;
using UnityEngine;

public class DaysExpandedPanel : MonoBehaviour
{
    public int MaxDaysOnPage;
    public ExpandedDay ExpandedDayPrefab;
    public RectTransform ExpandedDaysParent;

    public List<ExpandedDay> ExpandedDays { get; private set; } = new List<ExpandedDay>();
    private int currentPage;

    public void InstantiateExpandedDays(List<DayButton> dayButtons)
    {
        foreach (Transform child in ExpandedDaysParent)
        {
            Destroy(child.gameObject);
        }
        
        ExpandedDays.Clear();
        int allDaysCount = dayButtons.Count;
        int lastId = (allDaysCount - 1) - MaxDaysOnPage;

        if (lastId < 0)
            lastId = 0;
        else
        {
            //Вычесть, сколько всего страниц
        }

        //TODO: спаунить последний элемент, вычитать итератор, пока не будет достигнут максимум

        for (int i = allDaysCount - 1; i > lastId ; i--)
        {
            var expandedDayObj = Instantiate(ExpandedDayPrefab, ExpandedDaysParent);
            ExpandedDay expandedDay = expandedDayObj.GetComponent<ExpandedDay>();
            ExpandedDays.Add(expandedDay);
            expandedDay.SetExpandedDay(dayButtons[i].DayInfo);
        }
    }
}
