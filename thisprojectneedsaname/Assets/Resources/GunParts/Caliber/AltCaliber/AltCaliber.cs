using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltCaliber : Caliber
{
    public float damageMod = .75f;
    public float capacityMod = 1.5f;
    public float recoilMod = .75f;

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
