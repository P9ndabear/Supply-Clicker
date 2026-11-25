using UnityEngine;
using UnityEngine.UIElements;

public class NewFactoryController : MenuPage
{
    [SerializeField] private FactoriesListController factoriesListController;
    [SerializeField] private FactoryController factoryController;
    [SerializeField] private GameObject factoriesContainerObject;
    [SerializeField] private GameObject factoryPrefab;
    [SerializeField] private GameObject storageUpgradePrefab;
    [SerializeField] private GameObject clickUpgradePrefab;
    [SerializeField] private GameObject AutoUpgradePrefab;
    private Button BackToListButton;
    private Button CreateFactoryButton;
    private TextField FactoryNameInput;

    protected override void SetDependencies()
    {
        BackToListButton = ui.Q<VisualElement>("Background").Q<VisualElement>("Top").Q<Button>("BackButton");
        CreateFactoryButton = ui.Q<VisualElement>("Background").Q<VisualElement>("Bottom").Q<Button>("CreateButton");
        FactoryNameInput = ui.Q<VisualElement>("Background").Q<VisualElement>("Center").Q<TextField>("FactoryName");

        ShowMenu(false);
    }

    private void OnEnable()
    {
        BackToListButton.clicked += OnBackToListButtonClicked;
        CreateFactoryButton.clicked += OnCreateFactoryButtonClicked;
    }

    private void OnDisable()
    {
        BackToListButton.clicked -= OnBackToListButtonClicked;
        CreateFactoryButton.clicked -= OnCreateFactoryButtonClicked;
    }

    private void OnBackToListButtonClicked()
    {
        FactoryNameInput.value = "";
        ShowMenu(false);
        factoriesListController.ShowMenu(true);
    }

    private void OnCreateFactoryButtonClicked()
    {
        string factoryName = FactoryNameInput.value;

        if (string.IsNullOrWhiteSpace(factoryName) || FactoryAlreadyExists(factoryName))
            return;

        GameObject newFactory = Instantiate(factoryPrefab, factoriesContainerObject.transform);
        newFactory.name = factoryName;

        GameObject newStorageUpgrade = Instantiate(storageUpgradePrefab, newFactory.transform);
        newStorageUpgrade.name = "StorageUpgrade";

        GameObject newClickUpgrade = Instantiate(clickUpgradePrefab, newFactory.transform);
        newClickUpgrade.name = "StorageUpgrade";

        GameObject newAutoUpgrade = Instantiate(AutoUpgradePrefab, newFactory.transform);
        newAutoUpgrade.name = "AutoUpgrade";

        FactoryNameInput.value = "";

        factoryController.PopulateFactory(newFactory);
        ShowMenu(false);
        factoryController.ShowMenu(true);
    }

    private bool FactoryAlreadyExists(string factoryName)
    {
        foreach (Transform factory in factoriesContainerObject.transform)
        {
            if (factory.name == factoryName)
                return true;
        }

        return false;
    }

    protected override void PostShowMenu(DisplayStyle display){}
}