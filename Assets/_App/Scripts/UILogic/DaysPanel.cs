using System.Collections.Generic;
using _App.Scripts.UILogic;
using UnityEngine;

public class DaysPanel : MonoBehaviour
{
    public int MaxDaysOnPanel;
    public DayButton DayButtonPrefab;

    private Queue<DayButton> shownDayButtons = new Queue<DayButton>();

    public DayButton AddDayButton()
    {
        DayButton dayButton = Instantiate(DayButtonPrefab, transform);
        shownDayButtons.Enqueue(dayButton);

        if (shownDayButtons.Count > MaxDaysOnPanel)
        {
            int daysToDequeue = shownDayButtons.Count - MaxDaysOnPanel;

            for (int i = 0; i < daysToDequeue; i++)
            {
                DayButton dequeuedDayButton = shownDayButtons.Dequeue();
                Destroy(dequeuedDayButton.gameObject);
            }
        }

        return dayButton;
    }
}
