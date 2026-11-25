using UnityEngine;
using UnityEngine.UIElements;

public class FactoryController : MenuPage
{
    [SerializeField] private FactoriesListController factoriesListController;
    [SerializeField] private Stats stats;
    private Button FactoriesButton;
    private Button ShopButton;
    private Button ProduceButton;
    private Factory factory;

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
        factory = null;
        factoriesListController.ShowMenu(true);
        ShowMenu(false);
    }

    private void OnShopButtonClicked()
    {
        print("Open shop");
    }

    private void OnProduceButtonClicked()
    {
        factory.IncreaseStoredProduct(1);
    }

    public void PopulateFactory(GameObject f)
    {
        factory = f.GetComponent<Factory>();
        ui.Q<VisualElement>("Background").Q<VisualElement>("Top").Q<VisualElement>("StatsContainer").Q<VisualElement>("FactoryNameContainer").Q<Label>("FactoryName").text = f.name;
    }

    private void Update()
    {
        if (ui.style.display == DisplayStyle.None)
            return;

        ui.Q<VisualElement>("Background").Q<VisualElement>("Top").Q<VisualElement>("StatsContainer").Q<VisualElement>("BalanceContainer").Q<Label>("Balance").text = "Balance: " + stats.balance.ToString();
        ui.Q<VisualElement>("Background").Q<VisualElement>("Top").Q<VisualElement>("StatsContainer").Q<VisualElement>("StorageContainer").Q<Label>("Storage").text = "Storage: " + factory.StoredProduct.ToString() + "/" + factory.MaxStorage.ToString();
    }

    protected override void PostShowMenu(DisplayStyle display) { }
}