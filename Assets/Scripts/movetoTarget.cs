using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class movetoTarget : MonoBehaviour
{
    public GameObject chessPiece;

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
        
    }

    private void OnMouseDown()
    {
        chessPiece.transform.position = this.gameObject.transform.position;
    }
}
