using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public class CategoryReplaceToggle : MonoBehaviour
{
    private CategoryPanel categoryPanel;
    private Toggle toggle;

    private void Start()
    {
        categoryPanel = GetComponentInParent<CategoryPanel>();
        toggle = GetComponent<Toggle>();
    }

    public void TogglePressed(bool value)
    {
        ReplaceToggleControllerUtils.SendToggle(categoryPanel);
    }

    private void OnDisable()
    {
        toggle.SetIsOnWithoutNotify(false);
    }
}
