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
        //List<Vector2> validBoxList = new List<Vector2>();
        //AddBoxPositionsInList(validBoxList);

        //tryAgainButton.onClick.AddListener(Hide);
       // clueButton.onClick.AddListener(Hide);

        Hide();
    }

    private void OnMouseDown()
    {
        if (gameObject.CompareTag("validPos"))
        {
            Vector2 validBoxPosition = transform.position;
            player = GameObject.FindWithTag("Player");
            player.transform.position = validBoxPosition;
        }
        else
        {
            Show();
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
        GameObject[] validPosObjects = GameObject.FindGameObjectsWithTag("validPos");
        
        foreach (GameObject validBoxPosition in validPosObjects)
        {
            SpriteRenderer spriterenderer = validBoxPosition.GetComponent<SpriteRenderer>();
            
            if (spriterenderer != null)
            {
                spriterenderer.material.color = Color.red;
            }
        }
        Debug.Log($"Clue");
    }
}
