using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    // restriction player to go backward

    private Vector2 lastPosition;

    void Start()
    {
        // Guarda la posición inicial del jugador
        lastPosition = transform.position;
    }

    void Update()
    {
        // Obtener la entrada del jugador para el movimiento vertical
        float moveYNegative = Input.GetAxisRaw("Vertical");

        // Calcula la nueva posición del jugador
        Vector2 newPosition = transform.position + new Vector3(moveYNegative, 0, 0);

        // Verifica si la nueva posición está adelante (arriba) respecto a la posición anterior
        if (newPosition.y >= lastPosition.y)
        {
            // Actualiza la posición anterior
            lastPosition = transform.position;

            // Mueve al jugador a la nueva posición
            transform.position = newPosition;
        }
    }
}
