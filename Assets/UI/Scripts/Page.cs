using UnityEngine;
using UnityEngine.UIElements;

public abstract class MenuPage : MonoBehaviour
{
    protected VisualElement ui;

    private void Awake()
    {
        ui = GetComponent<UIDocument>().rootVisualElement;
        SetDependencies();
    }

    protected abstract void SetDependencies();

    public void ShowMenu(bool value)
    {
        if (value)
            ui.style.display = DisplayStyle.Flex;
        else
            ui.style.display = DisplayStyle.None;
        PostShowMenu(ui.style.display.value);
    }

    protected abstract void PostShowMenu(DisplayStyle display);
}