using UnityEngine;
using UnityEngine.UIElements;

public class FactoryController : MenuPage
{
    [SerializeField] private FactoriesListController factoriesListController;
    private Button FactoriesButton;
    private Button ShopButton;
    private Button ProduceButton;
    protected override void SetDependencies()
    {
        FactoriesButton = ui.Q<VisualElement>("Background").Q<VisualElement>("Top").Q<Button>("FactoriesButton");
        ShopButton = ui.Q<VisualElement>("Background").Q<VisualElement>("Bottom").Q<Button>("ShopButton");
        ProduceButton = ui.Q<VisualElement>("Background").Q<VisualElement>("Center").Q<Button>("Clicker");
        ShowMenu(false);
    }

    private void OnEnable()
    {
        FactoriesButton.clicked += OnFactoriesButtonClicked;
        ShopButton.clicked += OnShopButtonClicked;
        ProduceButton.clicked += OnProduceButtonClicked;
    }

    private void OnDisable()
    {
        FactoriesButton.clicked -= OnFactoriesButtonClicked;
        ShopButton.clicked -= OnShopButtonClicked;
        ProduceButton.clicked += OnProduceButtonClicked;
    }

    private void OnFactoriesButtonClicked()
    {
        factoriesListController.ShowMenu(true);
        ShowMenu(false);
    }

    private void OnShopButtonClicked()
    {
        print("Open shop");
    }

    private void OnProduceButtonClicked()
    {
        print("produce");
    }



    public void PopulateFactory()
    {
        print("populate");
    }

    protected override void PostShowMenu(DisplayStyle display) { }
}