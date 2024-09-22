using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Queen : ChessPiece
{
    public override void DetermineAttackingSquares()
    {
        attackingSquares.Clear();

        DiagonalRight(1);
        DiagonalRight(-1);

        DiagonalLeft(1);
        DiagonalLeft(-1);

        HorizontalPass(1);
        HorizontalPass(-1);

        VerticalPass(1);
        VerticalPass(-1);
    }

    void DiagonalRight(int i)
    {
        Vector2 vector2 = new Vector2(square.position.x + (1 * i), square.position.y + (1 * -i));
        while (true)
        {
            if (square.grid.squares.ContainsKey(vector2))
            {
                Square squareToCheck = square.grid.squares[vector2];

                if (squareToCheck.piece == null)
                {
                    attackingSquares.Add(squareToCheck);
                }
                else if (squareToCheck.piece.isWhite != isWhite)
                {
                    attackingSquares.Add(squareToCheck);
                    break;
                }
                else
                {
                    break;
                }
            }
            else
            {
                break;
            }

            vector2.x += i;
            vector2.y -= i;
        }
    }

    void DiagonalLeft(int i)
    {
        Vector2 vector2 = new Vector2(square.position.x + (1 * i), square.position.y + (1 * i));
        while (true)
        {
            if (square.grid.squares.ContainsKey(vector2))
            {
                Square squareToCheck = square.grid.squares[vector2];

                if (squareToCheck.piece == null)
                {
                    attackingSquares.Add(squareToCheck);
                }
                else if (squareToCheck.piece.isWhite != isWhite)
                {
                    attackingSquares.Add(squareToCheck);
                    break;
                }
                else
                {
                    break;
                }
            }
            else
            {
                break;
            }

            vector2.x += i;
            vector2.y += i;
        }
    }
    void HorizontalPass(int i)
    {
        Vector2 vector2 = new Vector2(square.position.x + (1 * i), square.position.y);
        while (true)
        {
            if (square.grid.squares.ContainsKey(vector2))
            {
                Square squareToCheck = square.grid.squares[vector2];

                if (squareToCheck.piece == null)
                {
                    attackingSquares.Add(squareToCheck);
                }
                else if (squareToCheck.piece.isWhite != isWhite)
                {
                    attackingSquares.Add(squareToCheck);
                    break;
                }
                else
                {
                    break;
                }
            }
            else
            {
                break;
            }

            vector2.x += i;
        }
    }

    void VerticalPass(int i)
    {
        Vector2 vector2 = new Vector2(square.position.x, square.position.y + (1 * i));
        while (true)
        {
            if (square.grid.squares.ContainsKey(vector2))
            {
                Square squareToCheck = square.grid.squares[vector2];

                if (squareToCheck.piece == null)
                {
                    attackingSquares.Add(squareToCheck);
                }
                else if (squareToCheck.piece.isWhite != isWhite)
                {
                    attackingSquares.Add(squareToCheck);
                    break;
                }
                else
                {
                    break;
                }
            }
            else
            {
                break;
            }

            vector2.y += i;
        }
    }
}
