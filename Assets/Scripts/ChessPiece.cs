using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ChessPiece : MonoBehaviour
{
    public Square square;
    public bool isWhite;
    public bool canMove = false;

    public List<Square> attackingSquares;

    public int value = 0;

    public virtual void DetermineAttackingSquares()
    {

    }

    public virtual List<Square> DeterminePossibleMoves()
    {
        DetermineAttackingSquares();
        return attackingSquares;
    }

    public virtual int MovePiece(Square newSquare)
    {
        int distanceMoved = GetDistance(square.position, newSquare.position);

        if (newSquare.piece != null)
        {
            newSquare.piece.GetCaptured();
        }

        square.piece = null;
        square = newSquare;
        newSquare.piece = this;

        this.transform.position = newSquare.GetComponent<Transform>().position;

        DetermineAttackingSquares();

        return distanceMoved;
    }

    public int GetDistance(Vector2 start, Vector2 end)
    {
        return Mathf.RoundToInt(Mathf.Abs(end.x - start.x) + Mathf.Abs(end.y - start.y));
    }

    public void GetCaptured()
    {
        Destroy(gameObject);
    }

    public int GetSacrificed()
    {
        int reward = value;
        Destroy(gameObject);
        return reward;
    }
}
