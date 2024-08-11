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

      if (lastId <= 1)
      {
         for (int i = 0; i < CategoryPanel.DayButtons.Count; i++)
         {
            if (CategoryPanel.DayButtons[i].DayInfo.IsFilled)
            {
               comboCount++;
            }
         }
         
         CountText.text = comboCount.ToString();
         return;
      }

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

         if (i == lastId - 1 && !CategoryPanel.DayButtons[i].DayInfo.IsFilled)
         {
            ResetComboCount(ref comboCount);
            return;
         }

         if (missedDays >= 2)
         {
            ResetComboCount(ref comboCount);
            return;
         }
      }

      missedDays = 0;
      
      for (int i = lastId - 2; i >= 0; i--)
      {
         if (CategoryPanel.DayButtons[i].DayInfo.IsFilled)
         {
            comboCount++;
         }
         else
         {
            missedDays++;
         }
         
         if (missedDays >= 1)
         {
            CountText.text = comboCount.ToString();
            return;
         }
      }
      
      CountText.text = comboCount.ToString();
   }

   private void ResetComboCount(ref int comboCount)
   {
      comboCount = 0;
      CountText.text = comboCount.ToString();
   }
}
