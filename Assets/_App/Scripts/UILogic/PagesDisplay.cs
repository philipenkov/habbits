using TMPro;
using UnityEngine;

public class PagesDisplay : MonoBehaviour
{
   public TMP_Text CurrentPage;
   public TMP_Text AllPages;

   public void SetCurrentPage(string currentPage)
   {
      CurrentPage.text = currentPage;
   }

   public void SetAllPages(string allPages)
   {
      AllPages.text = allPages;
   }
}
