using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class GridBoard : MonoBehaviour
{
    public GameObject squarePrefab;
    public PiecePlacer piecePlacer;

    public Dictionary<Vector2, Square> squares;

    public List<Square> highlightedSquares;

    ChessPiece selectedPiece = null;

    public ChessPiece SelectedPiece
    {
        get { return selectedPiece; }
        set { selectedPiece = value; }
    }

    public bool playerIsWhite = true;

    public TurnManager turnManager;

    private ChessPiece whiteKing;
    private ChessPiece blackKing;

    // Start is called before the first frame update
    void Start()
    {
        highlightedSquares = new List<Square>();
        SetGrid();

        whiteKing = piecePlacer.ReturnPlacePiece(piecePlacer.kingPrefab, new Vector2(5, 1));
        blackKing = piecePlacer.ReturnPlacePiece(piecePlacer.kingPrefabBlack, new Vector2(4, 8));
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
            if(piecePlacer.selectedPiece != null)
            {
                piecePlacer.DeselectPiece();
            }
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
                if(selectedSquare.piece == null && highlightedSquares.Contains(selectedSquare))
                {
                    piecePlacer.PlacePiece(selectedSquare.position);
                    piecePlacer.selectedPiece = null;
                    UnHighlightSquares();
                    piecePlacer.activeCardSlot.ConfirmPurchase();
                }
            }
            else
            {
                //Moves the piece if the square is highlighted
                if (highlightedSquares.Contains(selectedSquare))
                {
                    Debug.Log(selectedSquare.position);
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

    public void UnHighlightSquares()
    {
        foreach (var square in highlightedSquares)
        {
            square.spriteRenderer.enabled = false;
        }
        highlightedSquares.Clear();
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

    public void HighlightPlacingSquares()
    { 
        UnHighlightSquares();
        highlightedSquares.Clear();

        int i = 0;

        if (playerIsWhite)
        {
            highlightedSquares = whiteKing.DeterminePossibleMoves();
        }
        else
        {
            i = 6;
            highlightedSquares = blackKing.DeterminePossibleMoves();
        }

        for (int y = 1 + i; y < 3 + i; y++)
        {
            for (int x = 1; x < 9; x++)
            {
                Vector2 vector2 = new Vector2(x, y);

                if (squares[vector2].piece == null)
                {
                    if(!highlightedSquares.Contains(squares[vector2]))
                        highlightedSquares.Add(squares[vector2]);
                }
            }
        }

        HighLightSquares();
    }
}
