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
        int totalDeaths = PlayerPrefs.GetInt(SessionPreferences.DeathsKey);
        deaths.text = "x " + totalDeaths;
    }
}
