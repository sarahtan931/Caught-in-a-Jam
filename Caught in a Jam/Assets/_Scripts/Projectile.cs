using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    
    [SerializeField]
    private float _destroyEnemy = 1f;
    private BoundsCheck _bndCheck;
    
    void Awake()
    {
        // calls on BoundsCheck script
        _bndCheck = GetComponent<BoundsCheck>();
    }
    private void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
    }

    //calls move function for every frame
    void Update()
    { 

        //checks if BoundScript is active on GameObject and if so destroys object if needed
        if (_bndCheck != null && (_bndCheck.offDown || _bndCheck.offLeft || _bndCheck.offRight))
        {
            Destroy(gameObject);
        }
    }
    


}
