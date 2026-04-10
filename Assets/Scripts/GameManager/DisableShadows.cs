using UnityEngine;


public class DisableShadows : MonoBehaviour
{
    void Awake()
    {
        if (Application.isMobilePlatform)
        {
            gameObject.SetActive(false);
        }
    }
}

