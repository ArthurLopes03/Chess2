using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

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

    public GameObject coinCount;

    public int Economy;

    private void Start()
    {
        Economy = 30;
    }

    private void Update()
    {
        if (Economy < 0)
        {
            Economy = 0;
        }
    }

    public void PlacePawns()
    {
        if (Economy <= 0)
        {
            return;
        }

        for (int i = 1; i < 9; i++)
        {
            board.PlacePiece(pawnPrefab, new Vector2(i, 2));
        }

        Economy--;
    }

    public void PlaceBishops()
    {
        if (Economy <= 0)
        {
            return;
        }

        board.PlacePiece(bishopPrefab, new Vector2(3, 1));
        board.PlacePiece(bishopPrefab, new Vector2(6, 1));

        Economy -= 5;
    }

    public void PlaceKnights()
    {
        if (Economy <= 0)
        {
            return;
        }

        board.PlacePiece(knightPrefab, new Vector2(2, 1));
        board.PlacePiece(knightPrefab, new Vector2(7, 1));

        Economy -= 3;
    }

    public void PlaceRooks()
    {
        if (Economy <= 0)
        {
            return;
        }

        board.PlacePiece(rookPrefab, new Vector2(1, 1));
        board.PlacePiece(rookPrefab, new Vector2(8, 1));

        Economy -= 4;
    }

    public void PlaceQueen()
    {
        if (Economy <= 0)
        {
            return;
        }

        board.PlacePiece(queenPrefab, new Vector2(4, 1));

        Economy -= 7;
    }
}
