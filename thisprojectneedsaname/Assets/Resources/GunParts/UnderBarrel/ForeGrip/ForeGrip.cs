using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForeGrip : UnderBarrel
{
    public float precisionMod = .8f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void AltFire()
    {
        Debug.Log("Grip");
    }

    public override float GetPrecisionMod()
    {
        return precisionMod;
    }
}
