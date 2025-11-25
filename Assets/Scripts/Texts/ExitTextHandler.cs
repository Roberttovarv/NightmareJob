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
        Debug.Log("Shader: " + mat.shader.name);
        Debug.Log("Tiene OutlineWidth?: " + mat.HasProperty("_OutlineWidth"));
    }

    void Update()
    {
        if (charlie.canExit)
        {
            text.color = Color.white;


            mat.SetColor("_OutlineColor", Color.red);
            mat.SetFloat("_OutlineWidth", .7f);
        }
        else
        {
            text.color = Color.black;

            mat.SetFloat("_OutlineWidth", .1f);

        }
                text.fontMaterial = mat;
        text.UpdateMeshPadding();
        text.havePropertiesChanged = true;
    }
}
