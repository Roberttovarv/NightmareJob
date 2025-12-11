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
            {"hint_es", "Envía un correo en tu ordenador"}, {"hint_en", "Send an email on your computer"} } },

        { 4, new Dictionary<string, string>{{"es", "Necesito aire fresco"}, {"en", "I need fresh air"}, 
            {"hint_es", "Sal por la ventana"}, {"hint_en", "Get out throught the window"} } },

        { 5, new Dictionary<string, string>{{"es", "Hay días en los que me siento pequeño"}, {"en", "Some days I feel I'm shrinking"},
        {"hint_es", "Solo abre la puerta"}, {"hint_en", "Just open the door"} } },

        { 6, new Dictionary<string, string>{{"es", "Y otros en los que siento que este sitio me queda pequeño"}, 
        {"en", "And other days I feel this place is small for me"},
        {"hint_es", "MEmoriza el mapa y abre la puerta"}, {"hint_en", "Remember the map open the door"} } },

        { 7, new Dictionary<string, string>{{"es", "Apagón"}, {"en", "Blackout"},
        {"hint_es", "Encuentra la salida"}, {"hint_en", "Find the way out"} } },

        { 8, new Dictionary<string, string>{{"es", "¡Corre!"}, {"en", "Run!"},
        {"hint_es", "Abre la puerta antes de que se acabe el tiempo"}, {"hint_en", "Open the door before you run out of time"} } },

        { 9, new Dictionary<string, string>{{"es", "Estoy cansado, tengo sueño..."}, {"en", "I'm tired and so sleepy..."},
        {"hint_es", "Bebe algo de café"}, {"hint_en", "Get some coffee"} } },

        { 10, new Dictionary<string, string>{{"es", "Me han hecho un reporte disciplinario. Debo conseguirlo"}, 
        {"en", "I've been given a disciplinary report. I need to find it."},
        {"hint_es", "Encuentra el documento"}, {"hint_en", "Find the document"} } },

        { 11, new Dictionary<string, string>{{"es", "Debo destruirlo"}, {"en", "I have to destroy it"},
        {"hint_es", "Tíralo en la basura"}, {"hint_en", "Throuw it in the trash can"} } },

        { 12, new Dictionary<string, string>{{"es", "Demasiada cafeína"}, {"en", "Too much coffee"},
        {"hint_es", "Llega a la puerta sin morir"}, {"hint_en", "Reach the door without dying"} } },

        { 13, new Dictionary<string, string>{{"es", "¡Al infinito y más allá!"}, {"en", "To infinite and beyond"},
        {"hint_es", "Llega a la puerta sin morir, el camino más fácil es por arriba"}, 
        {"hint_en", "Reach the door without dying, the easiest way is from above"} } },

        { 14, new Dictionary<string, string>{{"es", "El moonwalker"}, {"en", "Moonwalker"},
        {"hint_es", "Llega a la puerta sin morir"}, {"hint_en", "Reach the door without dying"} } },

        { 15, new Dictionary<string, string>{{"es", "Necesito más tiempo"}, {"en", "I need more time"},
        {"hint_es", "Interactúa con el reloj"}, {"hint_en", "Interact with the clock"} } },

        { 16, new Dictionary<string, string>{{"es", "Desobedece las reglas"}, {"en", "Disobey the rules"},
        {"hint_es", "Solo abre la puerta"}, {"hint_en", "Just open the door"} } },

        { 17, new Dictionary<string, string>{{"es", "Como una rata"}, {"en", "Like a rat"},
        {"hint_es", "Escapa en por la ventilación"}, {"hint_en", "Escape through vents"} } },
        
        { 18, new Dictionary<string, string>{{"es", "Debo recoger mis apuntes"}, {"en", "I gotta get my notes"},
        {"hint_es", "Ve a la pizarra y coge tus notas"}, {"hint_en", "Go to the board and get your notes"} } },

        { 19, new Dictionary<string, string>{{"es", "Estoy sediento"}, {"en", "I'm thristy"},
        {"hint_es", "Bebe agua"}, {"hint_en", "Drink some water"} } },

        { 20, new Dictionary<string, string>{{"es", "Todo es un obstáculo"}, {"en", "Everything is an obstacle"},
        {"hint_es", "Salta los obstáculos para llegar a la puerta"}, {"hint_en", "Jump to obstacles to reach the door"} } },

        { 21, new Dictionary<string, string>{{"es", "La gravedad del asunto"}, {"en", "The gravity of the matter"},
        {"hint_es", "Tienes que controlar la gravedad con el botón de salto"}, {"hint_en", "You have to control gravity with jump button"} } },
    };
}








