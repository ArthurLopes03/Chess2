using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public GameObject squarePrefab;

    public Dictionary<Vector2, Square> squares;

    // Start is called before the first frame update
    void Start()
    {
        squares = new Dictionary<Vector2, Square>();
        for (int x = 0; x < 8; x++)
        {
            for (int y = 0; y < 8; y++)
            {
                Square square = Instantiate(squarePrefab, new Vector3((x * 2)+1, (y * 2)+1, 0), Quaternion.identity).GetComponent<Square>();

                square.position = new Vector2(x+1, y+1);

                squares.Add(square.position, square);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
