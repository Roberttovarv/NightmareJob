using UnityEditor;
using UnityEngine;

public static class SetMaxLevelPlayerPrefs
{
    public static void Run()
    {
        const string key = "MaxLevelUnlocked";
        const int value = 30;

        PlayerPrefs.SetInt(key, value);
        PlayerPrefs.Save();

        Debug.Log($"Set {key} to {value}");
    }
}
