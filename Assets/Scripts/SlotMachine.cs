using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotMachine : MonoBehaviour
{
    public List<GameObject> cards;
    public List<CardSlot> cardSlots;

    private void Start()
    {
        DrawNewCards();
    }

    public void DrawNewCards()
    {
        foreach (CardSlot slot in cardSlots)
        {
            int i = Random.Range(0, cards.Count);

            slot.AddNewCard(cards[i]);
        }
    }
}
