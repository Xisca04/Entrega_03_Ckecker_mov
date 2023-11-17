using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    // restriction player to go backward

    private Vector2 lastPosition;

    void Start()
    {
        // Guarda la posici�n inicial del jugador
        lastPosition = transform.position;
    }

    void Update()
    {
        // Obtener la entrada del jugador para el movimiento vertical
        float moveYNegative = Input.GetAxisRaw("Vertical");

        // Calcula la nueva posici�n del jugador
        Vector2 newPosition = transform.position + new Vector3(moveYNegative, 0, 0);

        // Verifica si la nueva posici�n est� adelante (arriba) respecto a la posici�n anterior
        if (newPosition.y >= lastPosition.y)
        {
            // Actualiza la posici�n anterior
            lastPosition = transform.position;

            // Mueve al jugador a la nueva posici�n
            transform.position = newPosition;
        }
    }
}
