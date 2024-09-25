using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class SlotMachine : MonoBehaviour
{
    public List<GameObject> cards;
    public List<CardSlot> cardSlots;

    public TextMeshProUGUI coinTag;

    private int Coin;
    public int coin
    {
        set { 
                coinTag.text = value.ToString();
                Coin = value;
            }
        get { return Coin; }
    }

    private void Awake()
    {
        coin = 15;
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