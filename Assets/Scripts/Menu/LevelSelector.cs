using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using System;

public class LevelSelector : MonoBehaviour
{
    [SerializeField] private GameObject prevButton;
    [SerializeField] private GameObject nextButton;
    [SerializeField] private GridLayoutGroup layout;

    public GameObject customButton;
    public Transform buttonContainer;

    int totalLevels = 60;
    int levelsPerPage = 32;
    private bool lastInput;

    private int currentPage = 0;
    private List<GameObject> buttons = new List<GameObject>();
    private GameObject firstButton;

    private int TotalPages => Mathf.CeilToInt((float)totalLevels / levelsPerPage);

    void Awake()
    {
  
        if (GameSessionManager.isMobile)
        {
            EventSystem.current.SetSelectedGameObject(null);
            Vector2 cellSize = layout.cellSize;
            cellSize.x = 110;
            cellSize.y = 140;
            layout.cellSize = cellSize;
            levelsPerPage = 33;
        }

    }
    void Start()
    {
        GenerateButtons();
        RenderPage();
        UpdateNavigationButtons();
    }

    void Update()
    {
        if (InputDeviceManager.isController != lastInput)
        {
            lastInput = InputDeviceManager.isController;
            if (lastInput)
            {
                EventSystem.current.SetSelectedGameObject(null);
                EventSystem.current.SetSelectedGameObject(firstButton);
            }
            else
            {
                EventSystem.current.SetSelectedGameObject(null);
            }
        }
    }

    void GenerateButtons()
    {
        for (int i = 0; i < levelsPerPage; i++)
        {
            GameObject buttonObject = Instantiate(customButton, buttonContainer);
            buttons.Add(buttonObject);
        }
        firstButton = buttons[0];
    }

    void RenderPage()
    {
        int startLevel = currentPage * levelsPerPage + 1;
        int maxLevel = ProgressManager.GetMaxLevelReached();

        for (int i = 0; i < buttons.Count; i++)
        {
            int levelNumber = startLevel + i;
            GameObject buttonObject = buttons[i];

            TextMeshProUGUI text = buttonObject.GetComponentInChildren<TextMeshProUGUI>();
            Button button = buttonObject.GetComponent<Button>();

            if (levelNumber <= totalLevels)
            {
                buttonObject.SetActive(true);
                text.text = levelNumber.ToString();

                Boolean isUnlocked = levelNumber <= maxLevel;
                button.interactable = isUnlocked;

                button.onClick.RemoveAllListeners();

                int capturedLevel = levelNumber;
                button.onClick.AddListener(() =>
                {
                    SceneManager.LoadScene(capturedLevel);
                });
            }
            else
            {
                buttonObject.SetActive(false);
            }
        }
        LayoutRebuilder.ForceRebuildLayoutImmediate(buttonContainer.GetComponent<RectTransform>());
    }

    public void NextPage()
    {
        if (currentPage < TotalPages - 1)
        {
            currentPage++;
            RenderPage();
            UpdateNavigationButtons();
        }
        firstButton = buttons[0];
        if (!firstButton.GetComponent<Button>().interactable)
        {
            firstButton = prevButton;
        }
        ;
        if (InputDeviceManager.isController)
        {
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(firstButton);
        }
    }

    public void PrevPage()
    {
        if (currentPage > 0)
        {
            currentPage--;
            RenderPage();
            UpdateNavigationButtons();
        }
        firstButton = buttons[0];
        if (InputDeviceManager.isController)
        {
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(firstButton);
        }
    }

    void UpdateNavigationButtons()
    {
        prevButton.SetActive(currentPage > 0);
        nextButton.SetActive(currentPage < TotalPages - 1);
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void ResetData()
    {
        SessionPreferences.ResetData();
        currentPage = 0;
        RenderPage();
        UpdateNavigationButtons();

        firstButton = buttons[0];
        if (!firstButton.GetComponent<Button>().interactable)
        {
            firstButton = nextButton.activeSelf ? nextButton : prevButton;
        }

        if (InputDeviceManager.isController && EventSystem.current != null)
        {
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(firstButton);
        }
    }
}
