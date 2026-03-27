using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using System.Diagnostics;
using System;

public class LevelSelector : MonoBehaviour
{
    [SerializeField] private GameObject prevButton;
    [SerializeField] private GameObject nextButton;

    public GameObject customButton;
    public Transform buttonContainer;

    public int totalLevels = 60;
    public int levelsPerPage = 32;

    private int currentPage = 0;
    private List<GameObject> buttons = new List<GameObject>();

    private int TotalPages => Mathf.CeilToInt((float)totalLevels / levelsPerPage);

    void Start()
    {
        GenerateButtons();
        RenderPage();
        UpdateNavigationButtons();
    }

    void GenerateButtons()
    {
        for (int i = 0; i < levelsPerPage; i++)
        {
            GameObject buttonObject = Instantiate(customButton, buttonContainer);
            buttons.Add(buttonObject);
        }
        EventSystem.current.SetSelectedGameObject(buttons[0]);
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
        EventSystem.current.SetSelectedGameObject(buttons[0]);
    }

    public void PrevPage()
    {
        if (currentPage > 0)
        {
            currentPage--;
            RenderPage();
            UpdateNavigationButtons();
        }
        EventSystem.current.SetSelectedGameObject(buttons[0]);

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
}