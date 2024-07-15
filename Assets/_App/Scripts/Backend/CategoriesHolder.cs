using System.Collections.Generic;
using UnityEngine;

public class CategoriesHolder : MonoBehaviour
{
    public Transform SpawnParent;
    public GameObject CategoryPrefab;

    private List<CategoryPanel> categories = new List<CategoryPanel>();

    public void CreateCategory(string header, Color color, int counterValue = 0)
    {
        GameObject categoryObject = Instantiate(CategoryPrefab, SpawnParent);
        CategoryPanel categoryPanel = categoryObject.GetComponent<CategoryPanel>();
        categoryPanel.SetInfo(header, color, counterValue);
        categories.Add(categoryPanel);
    }

    public void DeleteCategory(CategoryPanel categoryPanel)
    {
        categories.Remove(categoryPanel);
        Destroy(categoryPanel.gameObject);
    }
}
