﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeShot : CyclicModifier
{
    public float fireRateMod = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override float GetFireRateMod()
    {
        return fireRateMod;
    }

    public override void HoldFire(Vector3 position ,Quaternion angle)
    {
        receiver.Fire(position, angle);
    }

    public override void ReleaseHoldFire()
    {
        Debug.Log("Release");
    }
}
