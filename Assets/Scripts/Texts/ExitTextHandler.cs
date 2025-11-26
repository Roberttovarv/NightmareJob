using UnityEngine;
using TMPro;

public class ExitTextHandler : MonoBehaviour
{
    [SerializeField] TextMeshPro text;
    CharlieController charlie;
    Material mat;

    void Awake()
    {
        mat = text.fontMaterial;
    }

    void Start()
    {
        charlie = FindAnyObjectByType<CharlieController>();

    }

    void Update()
    {
        if (charlie.canExit)
        {
            text.color = Color.white;
        }
        else
        {
            text.color = Color.black;
        }

    }
}
