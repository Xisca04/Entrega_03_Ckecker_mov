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
    private List<Vector2> validBoxList;
    private Vector2 clickedPos;

    // UI Elements
    [SerializeField] private GameObject warningPanel;
    [SerializeField] private Button clueButton;
    [SerializeField] private Button tryAgainButton;

    private void Awake()
    {
        // Initial position
        //position2D = Vector2Int.zero;
        //transform.position = new Vector3(position2D.x, position2D.y, 0);

        // Initialize the valid box list
        List<Vector2> validBoxList = new List<Vector2>();

        tryAgainButton.onClick.AddListener(Hide);
       // clueButton.onClick.AddListener(Hide);

        Hide();
    }

    private void OnMouseDown()
    {
        if (validBox)
        {
            GameObject player = GameObject.FindWithTag("Player");
            player.transform.position = new Vector3(1, 1, 0);
        }
        /*
        else if (!validBox)
        {
           Show();
        }
        */
        player = GameObject.FindWithTag("Player");
        player.transform.position = new Vector3(1, 1, 0);
        Debug.Log($"mouseDown");
    }

    public void Show()
    {
        warningPanel.SetActive(true);
    }

    public void Hide()
    {
        warningPanel.SetActive(false);
    }

    private void ShowClue()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            // Destacar casillas válidas
        }
    }
}
