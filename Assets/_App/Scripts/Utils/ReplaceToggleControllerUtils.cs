public static class ReplaceToggleControllerUtils
{
    private static CategoriesHolder categoriesHolder;
    private static CategoriesReplacer categoriesReplacer;

    private static bool isInitialized;
    
    public static void Init(CategoriesReplacer replacer, CategoriesHolder holder)
    {
        if (isInitialized)
            return;

        categoriesHolder = holder;
        categoriesReplacer = replacer;

        isInitialized = true;
    }

    public static void SendToggle(CategoryPanel categoryPanel)
    {
        categoriesReplacer.RegisterID(categoriesHolder.Categories.IndexOf(categoryPanel));
    }
}
