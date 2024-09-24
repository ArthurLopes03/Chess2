using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardSlot : MonoBehaviour
{
    public bool white;
    public GameObject card;
    public Image image;
    public PiecePlacer piecePlacer;

    public void AddNewCard(GameObject newCard)
    {
        card = newCard;

        image.sprite = card.GetComponent<Card>().sprite;
    }

    public void SelectCard()
    {
        if (white == piecePlacer.board.playerIsWhite)
        {
            piecePlacer.selectedPiece = card.GetComponent<Card>().piece;
        }
    }
}