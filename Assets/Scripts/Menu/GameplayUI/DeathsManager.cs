using TMPro;
using UnityEngine;

public class DeathsManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI deaths;
    void Start()
    {
        RefreshText();
    }

    public void RefreshText()
    {
        int totalDeaths = PlayerPrefs.GetInt("deaths");
        deaths.text = "x " + totalDeaths;
    }
}
