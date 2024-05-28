using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
    public List<Button> botones; // Lista de botones
    public TMP_Text textoPuntaje; // texto para el puntaje
    public TMP_Text textoHighscore; // texto para el highscore
    public TMP_Text perdiste; // texto perdiste
    private List<int> secuencia = new List<int>(); // lista de secuencia del juego
    private int indSecuencia; // Índice para validar secuencia correcta
    private int puntaje = 0; // Int puntaje actual
    private int highscore = 0; // Int highscore
    private Color[] colores = { Color.red, Color.green, Color.blue, Color.yellow }; // COLORES DISPONIBLES

    void Start()
    {
        textoPuntaje.text = $"{puntaje}";
        textoHighscore.text = $"{highscore}";
        CambiarColoresBotones();
        StartGame();
    }

    void StartGame()
    {
        secuencia.Clear(); // Limpia la secuencia
        puntaje = 0; // Reinicia el puntaje
        actualizaScore(); // Actualiza el puntaje
        StartCoroutine(IniciaSecuencia()); // Inicia la secuencia de botones
        Debug.Log("Empieza Juego");
    }

    IEnumerator IniciaSecuencia()
    {
        yield return new WaitForSeconds(1f);
        perdiste.text = ""; // Limpia el texto "FALLASTE"
        HabilitarBotones(false); // Deshabilita los botones
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i <= puntaje; i++) // Itera a través de la secuencia actual
        {
            if (i >= secuencia.Count) // cuando se llega al final de la secuencia
            {
                int randomIndex = Random.Range(0, botones.Count); // randomizer para añadir siguiente botón de la secuencia
                secuencia.Add(randomIndex); // Se agrega a la secuencia
            }

            AnimacionBoton(botones[secuencia[i]]); // Anima el boton para hacer visual la secuencia
            yield return new WaitForSeconds(0.5f);
            RestablecerBoton(botones[secuencia[i]]);
            yield return new WaitForSeconds(0.5f);
        }

        indSecuencia = 0; // Reiniciar el índice para nueva ronda
        perdiste.text = "TU TURNO"; // Indica al jugador que es su turno
        yield return new WaitForSeconds(1f);
        perdiste.text = ""; // Limpia el texto "TU TURNO"
        HabilitarBotones(true); // Permite al jugador interactuar con los botones
    }

    void AnimacionBoton(Button button)
    {
        var colorOriginal = button.image.color;
        button.image.color = new Color(colorOriginal.r, colorOriginal.g, colorOriginal.b, 0.3f); // Hace el color 30% transparente
    }

    void Fallaste(Button button) // Cambiar el color de todos los botones a rojo
    {
        var colorOriginal = button.image.color;
        button.image.color = Color.red;
    }

    void RestablecerBoton(Button button)
    {
        var colorOriginal = button.image.color;
        button.image.color = new Color(colorOriginal.r, colorOriginal.g, colorOriginal.b, 1f); // Restaura la opacidad
    }

    public void BotonPresionado(int buttonIndex) // Función que evalua el botón presionado
    {
        if (buttonIndex == secuencia[indSecuencia]) // Si el botón presionado es el correcto
        {
            indSecuencia++; // Aumenta la secuencia
            if (indSecuencia == secuencia.Count) // Si se completa la ronda con éxito
            {
                puntaje++; // Aumenta el puntaje
                actualizaScore(); // Actualiza el puntaje
                Debug.Log("Completo ronda #" + puntaje);
                if (puntaje > highscore) // Evalua si el puntaje actual es mayor al highscore actual
                {
                    highscore = puntaje; // Actualiza el highscore
                    textoHighscore.text = $"{highscore}";
                    Debug.Log("Nuevo Highscore: " + highscore);
                }
                StartCoroutine(IniciaSecuencia()); // Iniciar la siguiente ronda
            }
        }
        else
        {
            Debug.Log("Perdiste, reiniciando juego");
            StartCoroutine(MostrarFallaste()); // Muestra el texto "FALLASTE" y pone los botones en rojo
        }
    }

    IEnumerator MostrarFallaste() // Corrutina para manejar el estado de fallo
    {
        foreach (var button in botones)
        {
            Fallaste(button); // Cambiar el color de todos los botones a rojo
        }
        perdiste.text = "FALLASTE"; // imprime "Fallaste"
        yield return new WaitForSeconds(1f); // Espera un segundo
        perdiste.text = ""; // Limpia el texto "FALLASTE"
        CambiarColoresBotones(); // cambia los colores de los botones
        StartGame(); // reiniciar el juego
    }

    void actualizaScore() // Actualizar la visualización del puntaje
    {
        textoPuntaje.text = $"{puntaje}";
    }

    void HabilitarBotones(bool estado) // habilida o deshabilita los botones
    {
        foreach (var button in botones)
        {
            button.interactable = estado;
            if (!estado)
            {
                var colors = button.colors;
                colors.disabledColor = colors.normalColor;
                button.colors = colors;
            }
        }
    }

    void CambiarColoresBotones() // Función para cambiar los colores de los botones cada ronda
    {
        List<Color> coloresDisponibles = new List<Color>(colores); // Copia la lista de colores disponibles
        foreach (var button in botones)
        {
            int randomColorIndex = Random.Range(0, coloresDisponibles.Count);
            button.image.color = coloresDisponibles[randomColorIndex];
            coloresDisponibles.RemoveAt(randomColorIndex); // Elimina el color usado de la lista para evitar repeticiones
        }
    }
}
