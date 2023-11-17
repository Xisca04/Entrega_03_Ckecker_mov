using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Checker_mov : MonoBehaviour
{
    // Checker movement: diagonally-up right or left in one unit

    [SerializeField] GameObject player;
    
    //[SerializeField] private List<Vector2> validBoxList;

    // UI Elements
    [SerializeField] private GameObject warningPanel;
    [SerializeField] private Button clueButton;
    [SerializeField] private Button tryAgainButton;

    private Vector2 nextPosition;
    private Vector2 actualPosition;

    private void Awake()
    {
       actualPosition = transform.position;
        Hide();
    }

    private void OnMouseDown()
    {
        if (gameObject.CompareTag("validPos"))
        {
            if (IsMoveValid(moveDirection))
            {
                Vector2 validBoxPosition = transform.position;
                player = GameObject.FindWithTag("Player");
                player.transform.position = validBoxPosition;
            }
            else // Si una casilla era válida antes y ahora no lo es porque el player volvería atrás -> se muestra el panel de casilla no válida
            {
                Debug.Log($"no");
            }
        }
        else
        {
            Show();
        }
    }
    private Vector2 moveDirection;
    public bool IsMoveValid(Vector2 moveDirection)
    {
        // Obtiene la dirección del movimiento
       // Vector2 moveDirection = actualPosition - nextPosition;
        //actualPosition = nextPosition;

        // Está moviéndose hacia arriba y hacia la izquierda
        if ((moveDirection.x == -1f && moveDirection.y == 1f) ||
               (moveDirection.x == 1f && moveDirection.y == 1f))
        {
            return true;
        }

        // Está moviéndose hacia arriba y hacia la derecha
        //if (moveDirection.y > 0)
        //{
        //return true;
        //}

        return false;
    }

    public void Show()
    {
        warningPanel.SetActive(true);
    }

    public void Hide()
    {
        warningPanel.SetActive(false);
    }

    public void ShowClue()
    {
        GameObject[] validPosObjects = GameObject.FindGameObjectsWithTag("validPos");
        
        foreach (GameObject validBoxPosition in validPosObjects)
        {
            SpriteRenderer spriterenderer = validBoxPosition.GetComponent<SpriteRenderer>();
            
            if (spriterenderer != null)
            {
                spriterenderer.material.color = Color.red;
            }
        }
    }
}
