using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UIElements;

public class FactoriesListController : MenuPage
{
    [SerializeField] private MainMenuController mainMenuController;
    [SerializeField] private FactoryController factoryController;
    [SerializeField] private NewFactoryController createNewFactoryController;
    [SerializeField] private VisualTreeAsset factoryButton;
    [SerializeField] private GameObject factoriesContainerObject;

    private Button MainMenuButton;

    private VisualElement ListContainer;

    protected override void SetDependencies()
    {
        MainMenuButton = ui.Q<VisualElement>("Background").Q<VisualElement>("Top").Q<Button>("MainMenuButton");
        ShowMenu(false);
    }

    private void OnEnable()
    {
        MainMenuButton.clicked += OnMainMenuButtonClicked;
    }

    private void OnDisable()
    {
        MainMenuButton.clicked -= OnMainMenuButtonClicked;
    }

    protected override void PostShowMenu(DisplayStyle display) {
        if (display == DisplayStyle.Flex) {
            ListContainer = ui.Q<VisualElement>("Background").Q<VisualElement>("Content");
            ListContainer.Clear();

            foreach (Transform child in factoriesContainerObject.transform)
            {
                AddFactoryButton(child.gameObject);
            }

            VisualElement tempObjectItem = factoryButton.CloneTree();
            Button button = tempObjectItem.Q<Button>("ItemContainer");
            button.text = "Create New Factory";
            button.clicked += () => OnCreateNewFactory();
            ListContainer.Add(tempObjectItem);
        }
    }

    private void AddFactoryButton(GameObject factory)
    {
        VisualElement tempObjectItem = factoryButton.CloneTree();
        Button button = tempObjectItem.Q<Button>("ItemContainer");
        button.text = factory.name;
        button.clicked += () => OnFactoryClicked(factory.name);
        ListContainer.Add(tempObjectItem);
    }

    private void OnFactoryClicked(string factoryName)
    {
        factoryController.PopulateFactory();
    }

    private void OnCreateNewFactory()
    {
        ShowMenu(false);
        createNewFactoryController.ShowMenu(true);
    }

    private void OnMainMenuButtonClicked()
    {
        mainMenuController.ShowMenu(true);
        ShowMenu(false);
    }
}