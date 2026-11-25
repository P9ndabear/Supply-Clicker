using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class MainMenuController : MenuPage
{
    [SerializeField] private FactoriesListController factoriesListController;
    private Button StartButton;
    private Button QuitButton;

    protected override void SetDependencies()
    {
        StartButton = ui.Q<VisualElement>("Background").Q<VisualElement>("Content").Q<Button>("StartButton");
        QuitButton = ui.Q<VisualElement>("Background").Q<VisualElement>("Content").Q<Button>("QuitButton");
        ShowMenu(true);
    }

    private void OnEnable()
    {
        StartButton.clicked += OnStartButtonClicked;
        QuitButton.clicked += OnQuitButtonClicked;
    }

    private void OnDisable()
    {
        StartButton.clicked -= OnStartButtonClicked;
        QuitButton.clicked -= OnQuitButtonClicked;
    }

    private void OnStartButtonClicked()
    {
        factoriesListController.ShowMenu(true);
        ShowMenu(false);
    }

    private void OnQuitButtonClicked()
    {
        Application.Quit();
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#endif
    }

    protected override void PostShowMenu(DisplayStyle display) { }
}