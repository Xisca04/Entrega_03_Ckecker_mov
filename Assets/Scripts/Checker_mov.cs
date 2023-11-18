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
    [SerializeField] private GameObject cluePanel;

    private Vector2 previousPosition;
    private Vector2 currentPosition;
    private Vector2 moveDirection;
    [SerializeField] private GameObject player;

    private void Awake()
    {
       Hide();
    }

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        currentPosition = transform.position;
    }
   
    private void OnMouseDown()
    {
        if (gameObject.CompareTag("validPos") && player.transform.position.y < currentPosition.y)
        {
            // Mover player a la posici�n clicada
            Vector2 validBoxPosition = transform.position;
            player.transform.position = validBoxPosition;
            
        }
        else
        {
            Show(); // Mostrar panel de advertencia
        }
    }
   
    public void Show()
    {
        warningPanel.SetActive(true);
    }

    public void Hide()
    {
        warningPanel.SetActive(false);
        cluePanel.SetActive(false);
    }

    public void ShowCluePanel()
    {
        cluePanel.SetActive(true);
    }

    public void ShowClue()
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
