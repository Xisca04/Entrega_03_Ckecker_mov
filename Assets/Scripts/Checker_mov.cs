using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    private Vector2 previousPosition;
    private Vector2 nextPosition;

    private void Awake()
    {
       previousPosition = transform.position;
        Hide();
    }

    private void OnMouseDown()
    {
        if (gameObject.CompareTag("validPos"))
        {
            if (nextPosition.y < previousPosition.y)
            {
                Vector2 validBoxPosition = transform.position;
                player = GameObject.FindWithTag("Player");
                player.transform.position = validBoxPosition;

                previousPosition = nextPosition;
            }
            else if(nextPosition.y > previousPosition.y)
            {
                Debug.Log($"cuidado");
            }
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
