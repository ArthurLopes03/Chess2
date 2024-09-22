using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class pieceMove : MonoBehaviour
{
    [SerializeField] private bool isitmyTurn;
    Transform position;
    Vector3 currentPosition;
    public GameObject indicator;
    public GameObject parent;

    public bool selected;

    public Collider2D childColliders;

    public bool otherpieceSelected;
    private bool toggle;

    private int moveDist;

    // Start is called before the first frame update
    void Start()
    {
        moveDist = 2;
        position = GetComponent<Transform>();
        toggle = false;

        //childColliders = parent.GetComponentInChildren<Collider2D>();
        childColliders = GetComponent<Collider2D>();
    }

    private void OnMouseDown()
    {
        toggle = !toggle;
        //childColliders.enabled = !toggle;
        this.gameObject.GetComponent<Collider2D>().enabled = true;

        //indicator.SetActive(toggle);

        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(toggle);
        }

        //indicator.GetComponentInChildren<Renderer>().enabled = !indicator.GetComponentInChildren<Renderer>().enabled;

        //transform.position = indicator.transform.position;

        //transform.position = transform.position + new Vector3(moveDist, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position += new Vector3(1, 1, 1);

        if (Input.GetKey("space"))
        {
            transform.position = transform.position + new Vector3(moveDist, 0, 0);
        }
    }
}
