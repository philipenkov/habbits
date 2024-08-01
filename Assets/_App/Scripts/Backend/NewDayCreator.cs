using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewDayCreator : MonoBehaviour
{
    public SaveLoadManager SaveLoadManager;
    public CategoriesHolder CategoriesHolder;

    private void Awake()
    {
        SaveLoadManager.OnLoaded += ManageNewDays;
    }

    private void ManageNewDays()
    {
        if (CategoriesHolder.Categories.Count == 0)
            return;

        DateTime currentDateTime = DateTime.Now;
        int lastDayId = CategoriesHolder.Categories[0].DayButtons.Count - 1;

        DateTime lastDayTime = CategoriesHolder.Categories[0].DayButtons[lastDayId].DayInfo.DateTime;
        TimeSpan timeSpan = currentDateTime - lastDayTime;
        int daysPassed = (int)timeSpan.TotalDays;

        List<DateTime> missedDates = GetMissedDates(lastDayTime, daysPassed);

        foreach (var category in CategoriesHolder.Categories)
        {
            for (int i = 0; i < daysPassed; i++)
            {
                category.CreateEmptyDayButton(missedDates[i]);
            }
        }
    }
    
    private List<DateTime> GetMissedDates(DateTime lastLaunchDate, int daysPassed)
    {
        List<DateTime> missedDates = new List<DateTime>();

        for (int i = 1; i <= daysPassed; i++)
        {
            missedDates.Add(lastLaunchDate.AddDays(i));
        }

        return missedDates;
    }

    private void OnDestroy()
    {
        SaveLoadManager.OnLoaded -= ManageNewDays;
    }
}
