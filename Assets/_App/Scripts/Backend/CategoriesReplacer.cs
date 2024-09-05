using UnityEngine;

public class CategoriesReplacer : MonoBehaviour
{
    public CategoriesHolder CategoriesHolder;

    private int firstId;
    private bool isFirstSet;

    private int secondId;
    private SaveLoadManager saveLoadManager;

    private void Start()
    {
        ReplaceToggleControllerUtils.Init(this, CategoriesHolder);
        saveLoadManager = FindObjectOfType<SaveLoadManager>();
    }

    public void RegisterID(int id)
    {
        if (!isFirstSet)
        {
            firstId = id;
            isFirstSet = true;
            return;
        }

        if (firstId != id)
        {
            secondId = id;
            Replace();
        }
        
        isFirstSet = false;
    }

    private void Replace()
    {
        CategoriesHolder.ReplaceCategory(firstId, secondId);
        saveLoadManager.SaveReplacedCategories(firstId, secondId);
    }

    public void ResetReplacer()
    {
        isFirstSet = false;
    }
}
