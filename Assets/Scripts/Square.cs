using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : MonoBehaviour
{
    public bool attackedByWhite;
    public bool attackedByBlack;

    public Vector2 position;

    public ChessPiece piece = null;

    public GridBoard grid;

    public SpriteRenderer spriteRenderer;

    public void HighlightSquare()
    {
        spriteRenderer.enabled = true;
    }
}
