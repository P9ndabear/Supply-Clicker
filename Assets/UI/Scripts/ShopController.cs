using UnityEngine;
using UnityEngine.UIElements;

public class ShopController : MenuPage
{
    [SerializeField] private FactoryController factoryController;
    [SerializeField] private Stats stats;
    private Button exitShop;
    private Button increaseStorageButton;
    private Button increaseClickButton;
    private Button increaseAutoButton;

    protected override void SetDependencies()
    {
        exitShop = ui.Q<VisualElement>("Background").Q<VisualElement>("Top").Q<Button>("ExitShopButton");
        increaseStorageButton = ui.Q<VisualElement>("Background").Q<VisualElement>("Content").Q<Button>("IncreaseStorageButton");
        increaseClickButton = ui.Q<VisualElement>("Background").Q<VisualElement>("Content").Q<Button>("IncreaseClickButton");
        increaseAutoButton = ui.Q<VisualElement>("Background").Q<VisualElement>("Content").Q<Button>("IncreaseAutoButton");
        ShowMenu(false);
    }

    private void OnEnable()
    {
        exitShop.clicked += OnExitShopButtonClicked;
        increaseStorageButton.clicked += OnIncreaseStorageButtonClicked;
        increaseClickButton.clicked += OnIncreaseClickButtonClicked;
        increaseAutoButton.clicked += OnIncreaseAutoButtonClicked;
    }

    private void OnDisable()
    {
        exitShop.clicked -= OnExitShopButtonClicked;
        increaseStorageButton.clicked -= OnIncreaseStorageButtonClicked;
        increaseClickButton.clicked += OnIncreaseClickButtonClicked;
        increaseAutoButton.clicked += OnIncreaseAutoButtonClicked;
    }

    private void OnExitShopButtonClicked()
    {
        factoryController.ShowMenu(true);
        ShowMenu(false);
    }

    private void OnIncreaseStorageButtonClicked()
    {
        StorageUpgrade subject = factoryController.factory.GetComponentInChildren<StorageUpgrade>();
        if (stats.balance < subject.basePrice * (int)Mathf.Pow(2, subject.level-1)) {
            print("too poor");
            return;
        }

        subject.IncreaseLevel();
    }

    private void OnIncreaseClickButtonClicked()
    {
        ClickUpgrade subject = factoryController.factory.GetComponentInChildren<ClickUpgrade>();
        if (stats.balance < subject.basePrice * (int)Mathf.Pow(3, subject.level - 1))
        {
            print("too poor");
            return;
        }

        subject.IncreaseLevel();
    }

    private void OnIncreaseAutoButtonClicked()
    {
        AutoUpgrade subject = factoryController.factory.GetComponentInChildren<AutoUpgrade>();
        if (stats.balance < subject.basePrice * (int)Mathf.Pow(3, subject.level - 1))
        {
            print("too poor");
            return;
        }

        subject.IncreaseLevel();
    }

    public void Populate(Factory f) {
        
    }

    protected override void PostShowMenu(DisplayStyle display) { }
}