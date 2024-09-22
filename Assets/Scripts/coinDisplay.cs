using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CoinDisplay : MonoBehaviour
{
    private int Coins;

    public TextMeshProUGUI Display;

    public GameObject coinTracker;

    // Start is called before the first frame update
    void Start()
    {
        Display = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        Coins = coinTracker.GetComponent<CardPlace>().Economy;

        Display.SetText(Coins.ToString());

        if (Coins < 0)
        {
            Coins = 0;
        }
    }
}
