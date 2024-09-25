using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SlotMachine : MonoBehaviour
{
    public List<GameObject> cards;
    public List<CardSlot> cardSlots;
    public TextMeshProUGUI coinsTag;
<<<<<<< Updated upstream

    public int Coins
    {
        get { return coins; }
        set {
                coinsTag.text = value.ToString();
                coins = value;
            }
    }

    private int coins;
=======
>>>>>>> Stashed changes

    public int Coins
    {
<<<<<<< Updated upstream
=======
        get { return coins; }
        set {
                coinsTag.text = value.ToString();
                coins = value;
            }
    }

    private int coins;

    public bool loopComplete;

    private void Awake()
    {
>>>>>>> Stashed changes
        Coins = 15;
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
