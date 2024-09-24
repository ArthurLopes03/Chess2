using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiecePlacer : MonoBehaviour
{
    public GridBoard board;

    public GameObject selectedPiece;

    public GameObject kingPrefab;
    public GameObject kingPrefabBlack;

    public void StartingPieces()
    {
        PlacePiece(kingPrefab, new Vector2(5, 1));
        PlacePiece(kingPrefabBlack, new Vector2(4, 8));
    }

    public void PlacePiece(GameObject prefab, Vector2 position)
    {
        ChessPiece piece = Instantiate(prefab, board.squares[position].transform.position, this.transform.rotation).GetComponent<ChessPiece>();

        piece.square = board.squares[position];
        piece.square.piece = piece;
        piece.DetermineAttackingSquares();
    }

    public void PlacePiece(Vector2 position)
    {
        ChessPiece piece = Instantiate(selectedPiece, board.squares[position].transform.position, this.transform.rotation).GetComponent<ChessPiece>();

        piece.square = board.squares[position];
        piece.square.piece = piece;
        piece.DetermineAttackingSquares();
    }
}