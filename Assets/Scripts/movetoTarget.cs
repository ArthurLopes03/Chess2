using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.UI.Image;

public class movetoTarget : MonoBehaviour
{
    public GameObject chessPiece;
    Vector3 pieceWhere;
    Vector3 destination;

    // Start is called before the first frame update
    void Awake()
    {
        setParent(chessPiece.transform);
    }

    public void setParent(Transform newParent)
    {
        this.gameObject.transform.SetParent(newParent);
    }

    // Update is called once per frame
    void Update()
    {
        pieceWhere = chessPiece.transform.position;
        destination = this.gameObject.transform.position;
    }

    private void OnMouseDown()
    {
        //moveObject();
        chessPiece.transform.position = this.gameObject.transform.position;
    }

    /*public IEnumerator moveObject()
    {
        float totalMovementTime = 5f; //the amount of time you want the movement to take
        float currentMovementTime = 0f;//The amount of time that has passed
        while (Vector3.Distance(pieceWhere, destination) > 0)
        {
            currentMovementTime += Time.deltaTime;
            pieceWhere = Vector3.Lerp(pieceWhere, destination, currentMovementTime / totalMovementTime);
            yield return null;
        }
    }*/
}
