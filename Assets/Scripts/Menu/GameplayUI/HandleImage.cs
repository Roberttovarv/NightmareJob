using UnityEngine;
using UnityEngine.UI;

public class HandleImage : MonoBehaviour
{
    [SerializeField] private Sprite active;
    [SerializeField] private Sprite inactive;

    public void SwitchImage(Image target, string value)
    {
        target.sprite = PlayerPrefs.GetInt(value) > 0 ? active : inactive;
    }
}