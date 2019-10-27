﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardBarrel : Barrel
{
    public int shotsPerSetMod = 3;
    public int setsPerFireMod = 2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override int GetSetsPerFireModifier()
    {
        return setsPerFireMod;
    }

    public override int GetShotsPerSetModifier()
    {
        return shotsPerSetMod;
    }
}