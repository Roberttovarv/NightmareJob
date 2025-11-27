using System.Collections.Generic;
using UnityEngine;

public class LevelsData
{
    public static Dictionary<int, Dictionary<string, string>> level =
    new Dictionary<int, Dictionary<string, string>>()
    {
        { 0, new Dictionary<string, string> { { "es", "Pantalla de carga" }, { "en", "Load Screen" } } },
        { 1, new Dictionary<string, string> { { "es", "Debo salir de la ofi..." }, { "en", "I must get out of the office..." } } },
        { 2, new Dictionary<string, string> { { "es", "El momento perfecto" }, { "en", "The perfect timing" } } }
    };
}








