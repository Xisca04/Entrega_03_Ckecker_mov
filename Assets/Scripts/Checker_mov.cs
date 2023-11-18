using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Checker_mov : MonoBehaviour
{
    // Checker movement: diagonally-up right or left in one unit

    //[SerializeField] GameObject player;

    // UI Elements
    [SerializeField] private GameObject warningPanel;
    [SerializeField] private Button clueButton;
    [SerializeField] private Button tryAgainButton;

    private Vector2 previousPosition;
    private Vector3 currentPosition;
    private Vector2 moveDirection;
    [SerializeField] private GameObject player;

    private void Awake()
    {
       Hide();
    }

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        previousPosition = player.transform.position;
    }
    
    private void Update()
    {
        currentPosition = transform.position;

        if (currentPosition.y < previousPosition.y)
        {
            currentPosition.y = previousPosition.y; // Ajusta la posici�n en Y a la anterior
            transform.position = currentPosition; // Aplica el cambio de posici�n al GameObject
        }

        // Actualiza la posici�n anterior a la actual para la siguiente comparaci�n
        previousPosition = player.transform.position;
    }
    
    private void OnMouseDown()
    {
        if (gameObject.CompareTag("validPos"))
        {
            // Mover player a la posici�n clicada
            Vector2 validBoxPosition = transform.position;
            //player = GameObject.FindWithTag("Player");
            player.transform.position = validBoxPosition;
            
        }
        else
        {
            Show(); // Mostrar panel de advertencia
        }
    }
   





    /*
    private bool IsMoveValid(Vector2 moveDirection)
    {
        nextPosition = transform.position;
        //player.transform.position = moveDirection;

        if (nextPosition.y < actualPosition.y)
        {
            Debug.Log("El GameObject est� retrocediendo en el eje Y.");
            // Realiza aqu� las acciones correspondientes al retroceso
            return false;
        }

        // Actualiza la posici�n anterior a la actual para el pr�ximo frame
        actualPosition = nextPosition;
        return true;
    }
    */
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
