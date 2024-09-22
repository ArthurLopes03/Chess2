using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridBoard : MonoBehaviour
{
    public GameObject squarePrefab;
    public GameObject rookPrefab;
    public GameObject bishopPrefab;
    public GameObject queenPrefab;
    public GameObject knightPrefab;
    public GameObject pawnPrefab;

    public Dictionary<Vector2, Square> squares;

    public List<Square> highlightedSquares;

    ChessPiece selectedPiece = null;

    public bool playerIsWhite = true;

    // Start is called before the first frame update
    void Start()
    {
        highlightedSquares = new List<Square>();
        SetGrid();
        ChessPiece Bishop = Instantiate(bishopPrefab, squares[new Vector2(2,1)].transform.position, this.transform.rotation).GetComponent<ChessPiece>();

        Bishop.square = squares[new Vector2(2, 1)];
        Bishop.square.piece = Bishop;
        Bishop.DetermineAttackingSquares();

        ChessPiece rook = Instantiate(rookPrefab, squares[new Vector2(1, 1)].transform.position, this.transform.rotation).GetComponent<ChessPiece>();

        rook.square = squares[new Vector2(1, 1)];
        rook.square.piece = rook;
        rook.DetermineAttackingSquares();

        ChessPiece queen = Instantiate(queenPrefab, squares[new Vector2(4, 1)].transform.position, this.transform.rotation).GetComponent<ChessPiece>();

        queen.square = squares[new Vector2(4, 1)];
        queen.square.piece = queen;
        queen.DetermineAttackingSquares();

        ChessPiece knight = Instantiate(knightPrefab, squares[new Vector2(3, 1)].transform.position, this.transform.rotation).GetComponent<ChessPiece>();

        knight.square = squares[new Vector2(3, 1)];
        knight.square.piece = knight;
        knight.DetermineAttackingSquares();

        ChessPiece pawn = Instantiate(pawnPrefab, squares[new Vector2(2, 2)].transform.position, this.transform.rotation).GetComponent<ChessPiece>();

        pawn.square = squares[new Vector2(2, 2)];
        pawn.square.piece = pawn;
        pawn.DetermineAttackingSquares();
    }

    //Sets up the grid
    void SetGrid()
    {
        squares = new Dictionary<Vector2, Square>();
        for (int x = 0; x < 8; x++)
        {
            for (int y = 0; y < 8; y++)
            {
                Square square = Instantiate(squarePrefab, new Vector3((x * 2) + 1, (y * 2) + 1, 0), Quaternion.identity).GetComponent<Square>();

                square.position = new Vector2(x + 1, y + 1);

                square.grid = this;

                squares.Add(square.position, square);
            }
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ClickSquare();
        }
        if(Input.GetMouseButtonDown(1))
        {
            DeselectPiece();
        }
    }

    void ClickSquare()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);
        if (hit)
        {
            Square selectedSquare = hit.collider.gameObject.GetComponent<Square>();

            //Moves the piece if the square is highlighted
            if(highlightedSquares.Contains(selectedSquare))
            {
                UnHighlightSquares();
                selectedPiece.MovePiece(selectedSquare);
            }
            //Selects the piece if there is one
            else if (selectedSquare.piece != null)
            {
                //If it isn't the same colour as the player, cancel
                if (selectedSquare.piece.isWhite == playerIsWhite)
                {
                    Debug.Log("Selected");
                    selectedPiece = selectedSquare.piece;
                    UnHighlightSquares();
                    highlightedSquares = selectedSquare.piece.DeterminePossibleMoves();
                    HighLightSquares();
                }
            }
        }
    }

    void DeselectPiece()
    {
        selectedPiece = null;
        UnHighlightSquares();
    }

    void HighLightSquares()
    {
        foreach (var square in highlightedSquares)
        {
            square.spriteRenderer.enabled = true;
        }
    }

    void UnHighlightSquares()
    {
        foreach (var square in highlightedSquares)
        {
            square.spriteRenderer.enabled = false;
        }
    }
}
