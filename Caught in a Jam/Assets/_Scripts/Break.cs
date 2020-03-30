using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Break : MonoBehaviour
{
    public float piecesInRow = 5;

    private void Start()
    {
        GetComponent<BoxCollider2D>().enabled = false;
    }
    void OnTriggerEnter(Collider col) 
    {
        if (col.gameObject.name == "Axe")
        {
            Shatter();

        }
    }

    // Update is called once per frame
    void Shatter()
    {
        gameObject.SetActive(false);
        for (int x = 0; x < piecesInRow; x++){
            for (int y = 0; y < piecesInRow; y++){
                for (int z =0; z < piecesInRow;z++){
                    CreatePiece(x, y, z);
                }
            }
        }
    }

    void CreatePiece(int x, int y, int z)
    {
        GameObject piece;
        piece = GameObject.CreatePrimitive(PrimitiveType.Cube);

        piece.transform.position = transform.position + new Vector3(0.2f *x,0.2f *y, 0.2f *z);
        piece.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);

        piece.AddComponent<Rigidbody2D>();
        piece.GetComponent<Rigidbody2D>().mass = 0.2f;
    }
}
