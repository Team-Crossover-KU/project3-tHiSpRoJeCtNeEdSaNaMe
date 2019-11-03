﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltProjectile : AmmoType
{
    public GameObject projectile;
    public GameObject projected;
    public int damage;
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
        projected.GetComponent<Rigidbody>().velocity = angle * newVelocity;
        projected.GetComponent<ProjectileController>().SetDamage(damage);
        Debug.Log(angle);
    }
}
