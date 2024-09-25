using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CardSlot : MonoBehaviour
{
    public bool white;
    public GameObject card;
    public Image image;
    public PiecePlacer piecePlacer;
    private Vector3 startPosition;
    private Vector3 newPosition;

    private Vector3 startSize;
    private Vector3 newSize;

    private IEnumerator cardDraw;
    private IEnumerator mouseHighlight;

    private bool isPurchasing = false;

    private void Awake()
    {
        if (white == true)
        {
            newPosition = new Vector3(this.gameObject.transform.position.x, 1, this.gameObject.transform.position.z);
            startPosition = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
        }

        else if (white == false)
        {
            newPosition = new Vector3(this.gameObject.transform.position.x, 15, this.gameObject.transform.position.z);
            startPosition = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
        }

        startSize = new Vector3(0.27f, 0.27f, 0.27f);
        newSize = new Vector3(30,30,30);

        cardDraw = MoveFunction();

        mouseHighlight = Enlarge();
    }

    public void AddNewCard(GameObject newCard)
    {
        card = newCard;

        image.sprite = card.GetComponent<Card>().sprite;

        GetComponent<Button>().interactable = true;

        StartCoroutine(cardDraw);
    }

    public void SelectCard()
    {
        if (white == piecePlacer.board.playerIsWhite)
        {
            piecePlacer.selectedPiece = card.GetComponent<Card>().piece;

            GetComponent<Button>().interactable = false;

            isPurchasing = true;
        }
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(1) && isPurchasing)
        {
            GetComponent<Button>().interactable = true;
        }

        if (Input.GetMouseButtonDown(0) && isPurchasing)
        {
            isPurchasing = false;
        }
    }

    private void OnMouseOver()
    {
        StartCoroutine(mouseHighlight);
    }

    private void OnMouseExit()
    {
        StopCoroutine(mouseHighlight);
        this.gameObject.transform.localScale = new Vector3( 0.27f , 0.27f, 0.27f);
    }

    IEnumerator MoveFunction()
    {
        float timeSinceStarted = 0f;

        while (true)
        {

            timeSinceStarted += Time.deltaTime;
            this.gameObject.transform.position = Vector3.Lerp(startPosition, newPosition, timeSinceStarted);

            // If the object has arrived, stop the coroutine
            if (this.gameObject.transform.position == newPosition)
            {
                yield break;
            }

            // Otherwise, continue next frame
            yield return null;
        }
    }

    IEnumerator Enlarge()
    {
        float timeSinceStarted = 0f;

        while (true)
        {
            timeSinceStarted += Time.deltaTime;

            while (true)
            {
                this.gameObject.transform.localScale = Vector3.Lerp(startSize, newSize, timeSinceStarted);

                if (this.gameObject.transform.localScale == newSize)
                {
                    yield break;
                }

                yield return null;
            }
        }
    }
}