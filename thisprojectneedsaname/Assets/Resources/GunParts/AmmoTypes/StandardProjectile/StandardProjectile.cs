using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardProjectile : AmmoType
{
    public GameObject projectile;
    public GameObject projected;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Fire(Vector3 newVelocity)
    {
        projected = Instantiate(projectile);
        projected.GetComponent<Rigidbody>().velocity = newVelocity;
    }
}
