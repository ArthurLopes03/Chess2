using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Randomizer : MonoBehaviour
{
    private int rand;
    public Sprite[] Sprite_Pic;

    void Start()
    {
        rand = Random.Range(0, Sprite_Pic.Length);
        GetComponent<SpriteRenderer>().sprite = Sprite_Pic[rand];
    }

    
    void Update()
    {
        
    }
}
