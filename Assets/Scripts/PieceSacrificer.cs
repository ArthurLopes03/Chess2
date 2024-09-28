using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceSacrificer : MonoBehaviour
{
    [SerializeField]
    SlotMachine whiteSlotMachine;
    [SerializeField]
    SlotMachine blackSlotMachine;

    [SerializeField]
    GridBoard board;

    public void SacrificePiece()
    {
        if(board.SelectedPiece != null && board.SelectedPiece.value != 0)
        {
            bool isWhite = board.SelectedPiece.isWhite;
            int reward = board.SelectedPiece.GetSacrificed();

            if (isWhite)
            {
                whiteSlotMachine.coin += reward;
            }
            else
            {
                blackSlotMachine.coin += reward;
            }

            board.UnHighlightSquares();
        }
    }
}
