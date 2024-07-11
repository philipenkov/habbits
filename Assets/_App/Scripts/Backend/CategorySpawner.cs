using UnityEngine;

public class CategorySpawner : MonoBehaviour
{
    public Transform SpawnParent;
    public GameObject CategoryPrefab;

    public void CreateCategory(string header, Color color, int counterValue = 0)
    {
        GameObject categoryObject = Instantiate(CategoryPrefab, SpawnParent);
        CategoryPanel categoryPanel = categoryObject.GetComponent<CategoryPanel>();
        categoryPanel.SetInfo(header, color, counterValue);
    }
}
