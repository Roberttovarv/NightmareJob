using UnityEngine;

public class ProgressManager
{
    private const string MaxLevelKey = "MaxLevelUnlocked";
    private const int MinLevel = 1;

    public static void InitializeProgress()
    {
        if (!PlayerPrefs.HasKey(MaxLevelKey))
        {
            PlayerPrefs.SetInt(MaxLevelKey, MinLevel);
        }
    }

    public static int GetMaxLevelReached()
    {
        return PlayerPrefs.GetInt(MaxLevelKey, MinLevel);
    }

    public static void SetMaxLevel(int levelNumber)
    {
        int currentMax = GetMaxLevelReached();

        if (levelNumber > currentMax)
        {
            PlayerPrefs.SetInt(MaxLevelKey, levelNumber);
            PlayerPrefs.Save();
        }
    }
}
