using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Checker_mov : MonoBehaviour
{
    // Checker movement: diagonally-up right or left in one unit

    private Vector2Int position2D;
    private Vector2Int moveDirection;
    private bool validBox;
    [SerializeField] GameObject player;
    
    [SerializeField] private List<Vector2> validBoxList;
    private Vector2 clickedPosition;

    // UI Elements
    [SerializeField] private GameObject warningPanel;
    [SerializeField] private Button clueButton;
    [SerializeField] private Button tryAgainButton;

    private void Awake()
    {
        // Initialize the valid box list
        List<Vector2> validBoxList = new List<Vector2>();
        AddBoxPositionsInList(validBoxList);

        //tryAgainButton.onClick.AddListener(Hide);
       // clueButton.onClick.AddListener(Hide);

        Hide();
    }

    private void OnMouseDown()
    {
        if (IsPositionBoxValid(clickedPosition, validBoxList))
        {
            Debug.Log($"La posici�n clicada est� dentro de la lista de posiciones v�lidas.");
            player = GameObject.FindWithTag("Player");
            player.transform.position = clickedPosition;
        }
        else
        {
            Show();
        }
    }

    private bool IsPositionBoxValid(Vector2 clickedPosition, List<Vector2> validBoxList)
    {
        // Verificar si la posici�n est� en la lista de posiciones v�lidas
        foreach (Vector2 pos in validBoxList)
        {
            if (pos.x == clickedPosition.x && pos.y == clickedPosition.y)
            {
                return true; // La posici�n est� en la lista de posiciones v�lidas
            }
        }
        return false; // La posici�n no est� en la lista de posiciones v�lidas
    }

    private void AddBoxPositionsInList(List<Vector2> validBoxList)
    {
        validBoxList.Add(new Vector2(3.5f, 3.5f));
        validBoxList.Add(new Vector2(2.5f, 3.5f));
        validBoxList.Add(new Vector2(1.5f, 3.5f));
        validBoxList.Add(new Vector2(0.5f, 3.5f));
        validBoxList.Add(new Vector2(0.0f, 3.0f));
        validBoxList.Add(new Vector2(1.0f, 3.0f));
        validBoxList.Add(new Vector2(2.0f, 3.0f));
        validBoxList.Add(new Vector2(3.0f, 3.0f));
        validBoxList.Add(new Vector2(2.5f, 2.5f));
        validBoxList.Add(new Vector2(1.5f, 2.5f));
        validBoxList.Add(new Vector2(0.5f, 2.5f));
        validBoxList.Add(new Vector2(0.0f, 2.0f));
        validBoxList.Add(new Vector2(1.0f, 2.0f));
        validBoxList.Add(new Vector2(2.0f, 2.0f));
        validBoxList.Add(new Vector2(1.5f, 1.5f));
        validBoxList.Add(new Vector2(0.5f, 1.5f));
        validBoxList.Add(new Vector2(0.0f, 1.0f));
        validBoxList.Add(new Vector2(1.0f, 1.0f));
        validBoxList.Add(new Vector2(0.5f, 0.5f));
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
        // Destacar casillas posibles con un color
        // Hacer un bucle que recorra las posiciones validas y que pinte el fondo del cuadrado, y que descuente la posici�n actual de la ficha?
        Debug.Log($"Clue");
    }
}
