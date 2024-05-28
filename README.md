# Documentación Juego de Memoria Simon

## ¿En que consiste el juego?

Este es un juego de memoria en el que tendrás que memorizar y repetir secuencias de una serie de colores que se iluminan en el tablero de juego.

## Controles Necesarios

Para jugar adecuadamente y disfrutar al máximo del juego, es necesario contar con un mouse. Este dispositivo se utiliza para interactuar con los botones en la interfaz del juego:

- **Mouse**: Usa el mouse para hacer clic en los botones de colores que se iluminan durante la secuencia. Esto te permitirá seguir la secuencia correctamente y avanzar en las rondas del juego.

## Cómo Jugar

### Inicio del Juego

- Al iniciar el juego, se muestra un tablero con cuatro botones de colores: rojo, verde, azul y amarillo.
- El juego comienza automáticamente una vez que se carga la escena en Unity.

### Desarrollo de una Ronda

1. **Visualización de la Secuencia:**
   - El juego muestra una secuencia aleatoria de colores, resaltando cada uno de estos en un orden específico.
   - Cada ronda aumenta en longitud, comenzando con una secuencia de un solo color.

2. **Interacción del Jugador:**
   - Después de que se muestra la secuencia, el jugador debe repetir la secuencia clickeando los botones correspondientes en el mismo orden que se iluminaron.
   - Si el jugador clickea los botones en el orden correcto, avanza a la siguiente ronda, aumentando en uno la longitud de la secuencia.

3. **Error del Jugador:**
   - Si el jugador clickea algún botón en un orden incorrecto, todos los botones se iluminarán en rojo momentáneamente para indicar un error.
   - El juego reinicia la secuencia desde el principio.
   - Se cambia el orden de los colores para añadir dificultad.

### Puntuación

- **Puntaje Actual:** Se muestra constantemente en la pantalla y aumenta con cada secuencia correcta.
- **Highscore:** También se muestra en pantalla y se actualiza si el jugador alcanza una nueva puntuación máxima durante la sesión actual.

## Componentes del Juego

### Botones del Tablero

- Cada botón en el tablero corresponde a un color y se utiliza para la interacción durante la secuencia de juego.
- Los botones están configurados para responder visualmente cuando son activados por el jugador o durante la visualización de la secuencia.

### Textos en Pantalla

- **Texto de Puntaje Actual:** Muestra el puntaje actual del jugador.
- **Texto de Highscore:** Muestra el puntaje más alto alcanzado durante las sesiones de juego.

### Scripts de Control

- Un script (C#) controla la lógica del juego, maneja la secuencia de colores, la verificación de la entrada del jugador, la actualización del puntaje, y reinicia el juego cuando se comete un error.

