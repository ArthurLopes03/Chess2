using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class GridBoard : MonoBehaviour
{
    public GameObject squarePrefab;
    public PiecePlacer piecePlacer;

    public Dictionary<Vector2, Square> squares;

    List<Square> highlightedSquares;

    ChessPiece selectedPiece = null;

    public bool playerIsWhite = true;

    public TurnManager turnManager;

    // Start is called before the first frame update
    void Start()
    {
        highlightedSquares = new List<Square>();
        SetGrid();
        piecePlacer.StartingPieces();
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
            piecePlacer.selectedPiece = null;
        }
    }

    void ClickSquare()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);
        if (hit)
        {
            Square selectedSquare = hit.collider.gameObject.GetComponent<Square>();

            if(piecePlacer.selectedPiece != null)
            {
                if(selectedSquare.piece == null)
                {
                    piecePlacer.PlacePiece(selectedSquare.position);
                    piecePlacer.selectedPiece = null;
                }
            }
            else
            {
                //Moves the piece if the square is highlighted
                if (highlightedSquares.Contains(selectedSquare))
                {
                    try
                    {
                        ProcessTurn(selectedSquare);
                    }
                    catch
                    {
                        Debug.Log("smth happened");
                    }
                }
                //Selects the piece if there is one
                else if (selectedSquare.piece != null)
                {
                    //If it isn't the same colour as the player, cancel
                    if (selectedSquare.piece.isWhite == playerIsWhite)
                    {
                        SelectPiece(selectedSquare);
                    }
                }
                else
                {
                    DeselectPiece();
                }
            }
        }
    }

    void ProcessTurn(Square selectedSquare)
    {
        UnHighlightSquares();
        turnManager.AddCoins(playerIsWhite , Mathf.CeilToInt(selectedPiece.MovePiece(selectedSquare))/2);
        ChangeTurn();
    }

    void SelectPiece(Square selectedSquare)
    {
        selectedPiece = selectedSquare.piece;
        UnHighlightSquares();
        highlightedSquares = selectedSquare.piece.DeterminePossibleMoves();
        HighLightSquares();
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

    void ChangeTurn()
    {
        DeselectPiece();
        if(playerIsWhite)
        {
            playerIsWhite = false;
        }
        else if(!playerIsWhite)
        {
            playerIsWhite = true;
        }
    }
}
