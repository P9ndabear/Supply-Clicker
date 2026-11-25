using UnityEngine;
using UnityEngine.UIElements;

public class ShopController : MenuPage
{
    protected override void SetDependencies()
    {
        ShowMenu(false);
    }

    protected override void PostShowMenu(DisplayStyle display) { }
}