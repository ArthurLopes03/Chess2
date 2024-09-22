using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : ChessPiece
{
    public override void DetermineAttackingSquares()
    {
        attackingSquares.Clear();

        ForwardPass(-1);
        ForwardPass(1);

        BackwardPass(1);
        BackwardPass(-1);
    }

    void ForwardPass(int i)
    {
        Vector2 left = new Vector2(square.position.x - 1, square.position.y + 2 * i);
        
        if (square.grid.squares.ContainsKey(left))
        {
            Square squareToCheck = square.grid.squares[left];
            if (squareToCheck.piece == null)
            {
                attackingSquares.Add(squareToCheck);
            }
            else if (squareToCheck.piece.isWhite != isWhite)
            {
                attackingSquares.Add(squareToCheck);
            }
        }

        Vector2 right = new Vector2(square.position.x + 1, square.position.y + 2 * i);

        if (square.grid.squares.ContainsKey(right))
        {
            Square squareToCheck = square.grid.squares[right];
            if (squareToCheck.piece == null)
            {
                attackingSquares.Add(squareToCheck);
            }
            else if (squareToCheck.piece.isWhite != isWhite)
            {
                attackingSquares.Add(squareToCheck);
            }
        }
    }

    void BackwardPass(int i)
    {
        Vector2 left = new Vector2(square.position.x + 2 * i, square.position.y - 1);

        if (square.grid.squares.ContainsKey(left))
        {
            Square squareToCheck = square.grid.squares[left];
            if (squareToCheck.piece == null)
            {
                attackingSquares.Add(squareToCheck);
            }
            else if (squareToCheck.piece.isWhite != isWhite)
            {
                attackingSquares.Add(squareToCheck);
            }
        }

        Vector2 right = new Vector2(square.position.x + 2 * i, square.position.y + 1);

        if (square.grid.squares.ContainsKey(right))
        {
            Square squareToCheck = square.grid.squares[right];
            if (squareToCheck.piece == null)
            {
                attackingSquares.Add(squareToCheck);
            }
            else if (squareToCheck.piece.isWhite != isWhite)
            {
                attackingSquares.Add(squareToCheck);
            }
        }
    }
}
