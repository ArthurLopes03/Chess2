using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiecePlacer : MonoBehaviour
{
    public GridBoard board;

    public GameObject rookPrefab;
    public GameObject bishopPrefab;
    public GameObject queenPrefab;
    public GameObject knightPrefab;
    public GameObject pawnPrefab;
    public GameObject kingPrefab;

    public GameObject rookPrefabBlack;
    public GameObject bishopPrefabBlack;
    public GameObject queenPrefabBlack;
    public GameObject knightPrefabBlack;
    public GameObject pawnPrefabBlack;
    public GameObject kingPrefabBlack;

    public void PlaceWhitePieces()
    {
        board.PlacePiece(kingPrefab, new Vector2(5, 1));
        /*
        board.PlacePiece(rookPrefab, new Vector2(1, 1));
        board.PlacePiece(rookPrefab, new Vector2(8, 1));

        board.PlacePiece(knightPrefab, new Vector2(2, 1));
        board.PlacePiece(knightPrefab, new Vector2(7, 1));

        board.PlacePiece(bishopPrefab, new Vector2(3, 1));
        board.PlacePiece(bishopPrefab, new Vector2(6, 1));

        board.PlacePiece(queenPrefab, new Vector2(4, 1));

        for (int i = 1; i < 9; i++)
        {
            board.PlacePiece(pawnPrefab, new Vector2(i, 2));
        }*/
    }

    public void PlaceBlackPieces()
    {
        board.PlacePiece(rookPrefabBlack, new Vector2(1, 8));
        board.PlacePiece(rookPrefabBlack, new Vector2(8, 8));

        board.PlacePiece(knightPrefabBlack, new Vector2(2, 8));
        board.PlacePiece(knightPrefabBlack, new Vector2(7, 8));

        board.PlacePiece(bishopPrefabBlack, new Vector2(3, 8));
        board.PlacePiece(bishopPrefabBlack, new Vector2(6, 8));

        board.PlacePiece(queenPrefabBlack, new Vector2(4, 8));
        board.PlacePiece(kingPrefabBlack, new Vector2(5, 8));

        for (int i = 1; i < 9; i++)
        {
            board.PlacePiece(pawnPrefabBlack, new Vector2(i, 7));
        }
    }
}
