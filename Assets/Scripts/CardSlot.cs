using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CardSlot : MonoBehaviour
{
    public bool white;
    public GameObject card;
    public Image image;
    public PiecePlacer piecePlacer;

    private bool isPurchasing = false;

    public void AddNewCard(GameObject newCard)
    {
        card = newCard;

        image.sprite = card.GetComponent<Card>().sprite;

        GetComponent<Button>().interactable = true;
    }

    public void SelectCard()
    {
        if (white == piecePlacer.board.playerIsWhite)
        {
            piecePlacer.selectedPiece = card.GetComponent<Card>().piece;

            GetComponent<Button>().interactable = false;

            isPurchasing = true;
        }
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(1) && isPurchasing)
        {
            GetComponent<Button>().interactable = true;
        }

        if (Input.GetMouseButtonDown(0) && isPurchasing)
        {
            isPurchasing = false;
        }
    }
}