using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    public GameObject customButton;
    public Transform buttonContainer;
    public int totalLevels = 30;

    void Start()
    {
        GenerateLevelButtons();
    }
    public void GenerateLevelButtons()
    {
        for (int i = 1; i <= totalLevels; i++)
        {
            int sceneIndex = i;
            GameObject buttonObject = Instantiate(customButton, buttonContainer);
            buttonObject.GetComponentInChildren<TextMeshProUGUI>().text = sceneIndex.ToString();

            buttonObject.GetComponent<Button>().onClick.AddListener(() =>
            {
                SceneManager.LoadScene(sceneIndex);
            });
        }
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
}
