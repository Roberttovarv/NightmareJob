using System.Collections.Generic;
using UnityEngine;

public class LevelsData
{
    public static Dictionary<int, Dictionary<string, string>> level =
    new Dictionary<int, Dictionary<string, string>>()
    {
        { 0, new Dictionary<string, string> { { "es", "Nightmare Job" }, { "en", "Load Screen" } } },

        { 1, new Dictionary<string, string> { { "es", "Debo salir de la ofi..." }, { "en", "I must get out of the office..." }, 
            {"hint_es", "Solo abre la puerta"}, {"hint_en", "Just open the door"} } },

        { 2, new Dictionary<string, string> { { "es", "El momento perfecto" }, { "en", "The perfect timing" },
            {"hint_es", "Abre la puerta cuando la luz esté encendida"}, {"hint_en", "Open the door when the light is on"} } },

        { 3, new Dictionary<string, string>{{"es", "Debo enviar el informe"}, {"en", "I gotta send the report"},
            {"hint_es", "Envía un correo en tu ordenador"}, {"hint_en", "Send and email on your computer"} } },

        { 4, new Dictionary<string, string>{{"es", "Necesito aire fresco"}, {"en", "I need fresh air"}, 
            {"hint_es", "Sal por la ventana"}, {"hint_en", "Get out throught the window"} } },

        { 5, new Dictionary<string, string>{{"es", "Hay días en los que me siento pequeño"}, {"en", "Some days I feel I'm shrinking"},
        {"hint_es", "Solo abre la puerta"}, {"hint_en", "Just open the door"} } },

        { 6, new Dictionary<string, string>{{"es", "Y otros en los que siento que este sitio me queda peuqeño"}, {"en", "And other days I feel this place is small for me"},
        {"hint_es", "Solo abre la puerta"}, {"hint_en", "Just open the door"} } },

        { 7, new Dictionary<string, string>{{"es", "Apagón"}, {"en", "Blackout"},
        {"hint_es", "Encuentra la salida"}, {"hint_en", "Find the way out"} } },
    };
}








