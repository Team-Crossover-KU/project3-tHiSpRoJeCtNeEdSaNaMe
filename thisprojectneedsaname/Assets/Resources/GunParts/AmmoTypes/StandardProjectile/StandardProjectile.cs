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

    public override void Fire(Vector3 newVelocity, Vector3 Pos, Quaternion angle)
    {
        projected = Instantiate(projectile, Pos, Quaternion.identity);
        projected.GetComponent<Rigidbody>().velocity = angle * newVelocity ;
        Debug.Log(angle);
    }
}
