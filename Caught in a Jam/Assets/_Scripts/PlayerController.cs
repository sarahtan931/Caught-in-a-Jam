using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        /*   Vector3 move = Vector3.zero;
           float speed = 1f;

           if (Input.GetKeyDown(KeyCode.LeftArrow))
           {
               move = Vector3.left;
           }
           if (Input.GetKeyDown(KeyCode.RightArrow))
           {
               move = Vector3.right;
           }
           if (Input.GetKeyDown(KeyCode.UpArrow))
           {
               move = Vector3.up;
           }
           if (Input.GetKeyDown(KeyCode.DownArrow))
           {
               move = Vector3.down;
           }

           gameObject.transform.position = gameObject.transform.position + move * speed;
           */
        float speed = 5f;
        //Pull in information from the Input class
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");

        //change transform.position based on the axes
        Vector3 pos = transform.position;
        pos.x += xAxis * speed * Time.deltaTime;
        pos.y += yAxis * speed * Time.deltaTime;
        transform.position = pos;

    }
}
