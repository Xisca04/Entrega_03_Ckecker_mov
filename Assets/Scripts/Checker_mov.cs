using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checker_mov : MonoBehaviour
{
    // Checker movement: diagonally-up right or left in one unit


    private Vector2Int position2D;
    private Vector2Int moveDirection;
    private bool validBox;

    public GameObject warningPanel;

    private void Awake()
    {
        // Initial position
        position2D = Vector2Int.zero;
        transform.position = new Vector3(position2D.x, position2D.y, 0);

        Hide()
    }

    private void Update()
    {
        Movement();
    }


    private void Movement()
    {
        if (validBox)
        {
            if (validBox)
            {
                // return position a esa casilla
            }
            else if (!validBox)
            {
                Show();
            }
        }
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
        // destacar casillas posibles
    }
}
