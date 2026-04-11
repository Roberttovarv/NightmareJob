using UnityEngine;

public class ProgressManager
{
    public const string MaxLevelKey = "maxLevelReached";
    private const int MinLevel = 1;
    private const int MaxLevel = 90;

    public static void InitializeProgress()
    {
        if (!PlayerPrefs.HasKey(MaxLevelKey))
        {
            PlayerPrefs.SetInt(MaxLevelKey, MinLevel);
        }
    }

    public static int GetMaxLevelReached()
    {
        return Mathf.Clamp(PlayerPrefs.GetInt(MaxLevelKey, MinLevel), MinLevel, MaxLevel);
    }

    public static void SetMaxLevel(int levelNumber)
    {
        int currentMax = GetMaxLevelReached();
        int clampedLevel = Mathf.Clamp(levelNumber, MinLevel, MaxLevel);

        if (clampedLevel > currentMax)
        {
            PlayerPrefs.SetInt(MaxLevelKey, clampedLevel);
            PlayerPrefs.Save();
        }
    }
}
