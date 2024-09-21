using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class pieceMove : MonoBehaviour
{
    public bool isWhite;
    [SerializeField] private bool firstMove;
    Transform position;
    Vector3 currentPosition;

    private int moveDist;
    private int movedistDouble;

    // Start is called before the first frame update
    void Start()
    {
        moveDist = 2;
        movedistDouble = 4;
        position = GetComponent<Transform>();
    }

    private void OnMouseDown()
    {
        if(isWhite == true)
        {
            transform.position = transform.position + new Vector3(0, moveDist, 0);
        }
        else
        {
            transform.position = transform.position - new Vector3(0, moveDist, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position += new Vector3(1, 1, 1);

        if (Input.GetKey("space"))
        {
            transform.position = transform.position + new Vector3(0, moveDist, 0);
        }
    }
}
