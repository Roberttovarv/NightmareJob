using System.Collections.Generic;
using UnityEngine;

public class MenuData
{
    public static Dictionary<string, Dictionary<string, string>> Menu =
    new Dictionary<string, Dictionary<string, string>>()
    {
        { "start", new Dictionary<string, string> { { "es", "Jugar" }, { "en", "Start" } } },
        { "continue", new Dictionary<string, string> { { "es", "Continuar" }, { "en", "Continue" } } },
        { "levels", new Dictionary<string, string> { { "es", "Niveles" }, { "en", "Levels" } } },
        { "settings", new Dictionary<string, string> { { "es", "Configuración" }, { "en", "Settings" } } },
        { "quit", new Dictionary<string, string> { { "es", "Salir del Juego" }, { "en", "Quit Game" } } },
    };

    public static Dictionary<string, Dictionary<string, string>> Settings =
    new Dictionary<string, Dictionary<string, string>>()
    {
        { "language", new Dictionary<string, string> { { "es", "Idioma" }, { "en", "Language" } } },
        { "sound", new Dictionary<string, string> { { "es", "Sonido" }, { "en", "Sound" } } },
        { "music", new Dictionary<string, string> { { "es", "Música" }, { "en", "Music" } } },
    };

    public static Dictionary<string, Dictionary<string, string>> Levels =
    new Dictionary<string, Dictionary<string, string>>()
    {
            { "levels", new Dictionary<string, string> { { "es", "Niveles" }, { "en", "Levels" } } },
    };
}








