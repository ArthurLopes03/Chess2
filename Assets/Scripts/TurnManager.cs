using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public SlotMachine blackSlotmachine;
    public SlotMachine whiteSlotmachine;

    public void AddCoins(bool isWhite, int numberOfCoins)
    {
        if(isWhite)
        {
            whiteSlotmachine.coin += numberOfCoins;
        }
        else if(!isWhite)
        {
            blackSlotmachine.coin += numberOfCoins;
        }
    }
}
