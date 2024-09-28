using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CardSlot : MonoBehaviour
{
    public bool white;
    public GameObject card;
    public Image image;
    public PiecePlacer piecePlacer;

    public SlotMachine slotMachine;

    public void AddNewCard(GameObject newCard)
    {
        card = newCard;

        image.sprite = card.GetComponent<Card>().sprite;

        GetComponent<Button>().interactable = true;
    }

    public void SelectCard()
    {
        Card selectedCard = card.GetComponent<Card>();
        if (white == piecePlacer.board.playerIsWhite && slotMachine.coin >= selectedCard.cost)
        {
            if (piecePlacer.activeCardSlot != null)
            {
                piecePlacer.DeselectPiece();
            }
            piecePlacer.activeCardSlot = this;


            piecePlacer.selectedPiece = selectedCard.piece;

            GetComponent<Button>().interactable = false;
            slotMachine.coin -= selectedCard.cost;

            piecePlacer.board.HighlightPlacingSquares();
        }
    }

    public void UndoPurchase()
    {
        GetComponent<Button>().interactable = true;

        slotMachine.coin += card.GetComponent<Card>().cost;
    }

    public void ConfirmPurchase()
    {
        piecePlacer.activeCardSlot = null;
    }

    private void OnMouseOver()
    {
        this.gameObject.transform.localScale = new Vector3(0.32f, 0.32f, 0.32f);
    }

    private void OnMouseExit()
    {
        this.gameObject.transform.localScale = new Vector3(0.27f, 0.27f, 0.27f);
    }
}