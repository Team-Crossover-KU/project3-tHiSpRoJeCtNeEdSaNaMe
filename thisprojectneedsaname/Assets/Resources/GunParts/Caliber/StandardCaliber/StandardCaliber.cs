using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardCaliber : Caliber
{
    public float damageMod = 1.5f;
    public float capacityMod = .5f;
    public float recoilMod = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override float GetDamageModifier()
    {
        return damageMod;
    }

    public override float GetCapacityMod()
    {
        return capacityMod;
    }

    public override float GetRecoilMod()
    {
        return recoilMod;
    }
}
