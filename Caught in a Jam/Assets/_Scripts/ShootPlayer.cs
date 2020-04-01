using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPlayer : MonoBehaviour
{

    public GameObject venom;

 

    public Transform launchPoint;

    public float wait;
    private float shotCounter;

    // Start is called before the first frame update
    void Start()
    {
       
        shotCounter = wait;
    }

    // Update is called once per frame
    void Update()
    {
        shotCounter -= Time.deltaTime;
        if (shotCounter <= 0)
        {
            Instantiate(venom, launchPoint.position, launchPoint.rotation);
            shotCounter = wait;
        }
    }
}
