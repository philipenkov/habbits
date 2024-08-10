using TMPro;
using UnityEngine;

public class ComboCounter : MonoBehaviour
{
   public CategoryPanel CategoryPanel;
   public TMP_Text CountText;

   public void CheckCombo()
   {
      int lastId = CategoryPanel.DayButtons.Count - 1;
      int comboCount = 0;
      int missedDays = 0;

      for (int i = lastId; i > lastId - 2; i--)
      {
         if (CategoryPanel.DayButtons[i].DayInfo.IsFilled)
         {
            comboCount++;
         }
         else
         {
            missedDays++;
         }

         if (missedDays >= 2)
         {
            comboCount = 0;
            CountText.text = comboCount.ToString();
            return;
         }
      }
      
      for (int i = lastId - 2; i >= 0; i--)
      {
         if (CategoryPanel.DayButtons[i].DayInfo.IsFilled)
         {
            comboCount++;
         }
         else
         {
            CountText.text = comboCount.ToString();
         }
      }
   }
}
