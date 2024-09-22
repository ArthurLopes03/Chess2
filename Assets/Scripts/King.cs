using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : ChessPiece
{
    public override void DetermineAttackingSquares()
    {
        attackingSquares.Clear();

        for (int i = -1; i < 2; i++)
        {
            for (int j = -1; j < 2; j++)
            {
                Vector2 vector2 = new Vector2(square.position.x + i, square.position.y + j);
                if (square.grid.squares.ContainsKey(vector2))
                {
                    Debug.Log(vector2);
                    Square squareToCheck = square.grid.squares[vector2];

                    if (squareToCheck != null)
                    {
                        if (squareToCheck.piece == null || squareToCheck.piece.isWhite != isWhite)
                        {
                            Debug.Log("Square Added");
                            attackingSquares.Add(squareToCheck);
                        }
                    }
                }
            }
        }
    }
}