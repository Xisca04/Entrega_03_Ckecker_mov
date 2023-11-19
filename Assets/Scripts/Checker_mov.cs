using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Checker_mov : MonoBehaviour
{
    // Checker movement
    
    [SerializeField] private GameObject player;
    private Vector2 currentPosition;

    // UI Elements
    [SerializeField] private GameObject warningPanel;
    [SerializeField] private GameObject cluePanel;

    private void Awake()
    {
       HideWarningPanel();
       HideCluePanel();
    }

    private void Start()
    {
        player = GameObject.FindWithTag("Player"); // Hacer referencia de que el GO player es un GO con la etiqueta "Player"
        currentPosition = transform.position;
    }
   
    private void OnMouseDown()
    {
        if (gameObject.CompareTag("validPos") && player.transform.position.y < currentPosition.y)
        {
            // Mover player a la posición clicada
            Vector2 validBoxPosition = transform.position;
            player.transform.position = validBoxPosition;
            
        }
        else
        {
            ShowWarningPanel(); // Mostrar panel de advertencia
        }
    }
   
    public void ShowWarningPanel()
    {
        warningPanel.SetActive(true);
    }

    public void HideWarningPanel() // Asignar al botón TryAgain
    {
        warningPanel.SetActive(false);
    }

    public void ShowCluePanel()  
    {
        cluePanel.SetActive(true);
    }

    public void HideCluePanel()
    {
        cluePanel.SetActive(false);
    }

    public void ShowClue()  // Asignar al botón Clue
    {
        GameObject[] validPosObjects = GameObject.FindGameObjectsWithTag("validPos");
        
        foreach (GameObject validBoxPosition in validPosObjects)
        {
            SpriteRenderer _spriteRenderer = validBoxPosition.GetComponent<SpriteRenderer>();
            
            if (_spriteRenderer != null)
            {
                _spriteRenderer.material.color = Color.blue;
            }
        }

        ShowCluePanel();
    }
}
