using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltSight : Sight
{
    public float unScopedRateOfFiremod = 1.5f;
    public float scopedRateOfFiremod = .75f;
    public float unScopedRecoilMod = 1.2f;
    public float scopedRecoilMod = .8f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void ADSToggle()
    {
        ADS = !ADS;
        Debug.Log("ADS");
    }

    public override float GetFireRateMod()
    {
        if (ADS)
        {
            return scopedRateOfFiremod;
        }
        else
        {
            return unScopedRateOfFiremod;
        }
    }

    public override float GetRecoilMod()
    {
        if (ADS)
        {
            return scopedRecoilMod;
        }
        else
        {
            return unScopedRecoilMod;
        }
    }
}
