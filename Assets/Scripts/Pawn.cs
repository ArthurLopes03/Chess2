using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class Pawn : ChessPiece
{
    bool firstMove = true;
    List<Square> squareList = new List<Square>();   
    public override void DetermineAttackingSquares()
    {
        attackingSquares.Clear();

        Vector2 front = Vector2.zero;

        if(isWhite) front = new Vector2 (square.position.x, square.position.y + 1);
        else
        {
            front = new Vector2(square.position.x, square.position.y - 1);
        }

        Vector2 frontRight = new Vector2(square.position.x + 1, front.y);

        if (square.grid.squares.ContainsKey(frontRight))
        {
            Square squareToCheck = square.grid.squares[new Vector2(frontRight.x, frontRight.y)];
            if (squareToCheck.piece == null)
            {
                attackingSquares.Add(squareToCheck);
            }
            else if (squareToCheck.piece.isWhite != isWhite)
            {
                attackingSquares.Add(squareToCheck);
            }
        }

        Vector2 frontLeft = new Vector2(square.position.x - 1, front.y);

        if (square.grid.squares.ContainsKey(frontLeft))
        {
            Square squareToCheck = square.grid.squares[new Vector2(frontLeft.x, frontLeft.y)];
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
    public override List<Square> DeterminePossibleMoves()
    {
        DetermineAttackingSquares();

        squareList = attackingSquares;

        for(int i = squareList.Count - 1; i > -1; i--)
        {
            if( squareList[i].piece == null )
            {
                squareList.RemoveAt(i);
            }
        }

        if(isWhite)
        {
            Vector2 front = new Vector2(square.position.x, square.position.y + 1);

            if (square.grid.squares.ContainsKey(front))
            {
                Square squareToCheck = square.grid.squares[front];
                if (squareToCheck.piece == null)
                {
                    squareList.Add(squareToCheck);
                }

                if (firstMove)
                {
                    squareToCheck = square.grid.squares[new Vector2(front.x, front.y + 1)];
                    if (squareToCheck.piece == null)
                    {
                        squareList.Add(squareToCheck);
                    }
                }
            }
        }

        if (!isWhite)
        {
            Vector2 front = new Vector2(square.position.x, square.position.y - 1);

            if (square.grid.squares.ContainsKey(front))
            {
                Square squareToCheck = square.grid.squares[front];
                if (squareToCheck.piece == null)
                {
                    squareList.Add(squareToCheck);
                }

                if (firstMove)
                {
                    squareToCheck = square.grid.squares[new Vector2(front.x, front.y - 1)];
                    if (squareToCheck.piece == null)
                    {
                        squareList.Add(squareToCheck);
                    }
                }
            }
        }

        return squareList;
    }

    public override int MovePiece(Square newSquare)
    {
        int distanceMoved = GetDistance(square.position, newSquare.position);

        firstMove = false;
        base.MovePiece(newSquare);

        return distanceMoved;
    }
}
