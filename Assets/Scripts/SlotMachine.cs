using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class SlotMachine : MonoBehaviour
{
    public List<GameObject> cards;
    public List<CardSlot> cardSlots;

    public bool loopComplete;

    private void Awake()
    {
        DrawNewCards();
    }

    public void DrawNewCards()
    {
        foreach (CardSlot slot in cardSlots)
        {
            loopComplete = false;

            int i = Random.Range(0, cards.Count);

            slot.AddNewCard(cards[i]);
        }

        loopComplete = true;
    }
}
