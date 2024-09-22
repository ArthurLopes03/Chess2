using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ChessPiece : MonoBehaviour
{
    public Square square;
    public bool isWhite;

    public List<Square> attackingSquares;

    public virtual void DetermineAttackingSquares()
    {

    }

    public virtual List<Square> DeterminePossibleMoves()
    {
        DetermineAttackingSquares();
        return attackingSquares;
    }

    public virtual void MovePiece(Square newSquare)
    {
        if (newSquare.piece != null)
        {
            newSquare.piece.GetCaptured();
        }

        square.piece = null;
        square = newSquare;
        newSquare.piece = this;

        this.transform.position = newSquare.GetComponent<Transform>().position;

        DetermineAttackingSquares();
    }

    public void GetCaptured()
    {
        Destroy(gameObject);
    }
}
