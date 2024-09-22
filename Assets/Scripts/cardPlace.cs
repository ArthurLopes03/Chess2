using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPlace : MonoBehaviour
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

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

    public void PlacePawns()
    {
        for (int i = 1; i < 9; i++)
        {
            board.PlacePiece(pawnPrefab, new Vector2(i, 2));
        }
    }

    public void PlaceBishops()
    {
        board.PlacePiece(bishopPrefab, new Vector2(3, 1));
        board.PlacePiece(bishopPrefab, new Vector2(6, 1));
    }

    public void PlaceKnights()
    {
        board.PlacePiece(knightPrefab, new Vector2(2, 1));
        board.PlacePiece(knightPrefab, new Vector2(7, 1));
    }

    public void PlaceRooks()
    {
        board.PlacePiece(rookPrefab, new Vector2(1, 1));
        board.PlacePiece(rookPrefab, new Vector2(8, 1));
    }

    public void PlaceQueen()
    {
        board.PlacePiece(queenPrefab, new Vector2(4, 1));
    }
}
