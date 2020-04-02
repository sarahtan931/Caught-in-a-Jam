using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Break : MonoBehaviour
{
    public float piecesInRow = 5;
    float health = 3;

    private void Start()
    {
        GetComponent<BoxCollider2D>().enabled = true;
    }
    void OnCollisionEnter(Collision col) 
    {
        if (col.gameObject.tag == "Axe")
        {
            health--;
            if (health == 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
