using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeLauncher : UnderBarrel
{
    public float precisionMod = 1.2f;
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
        Debug.Log("BOOOM" + receiver.damage);
    }

    public override float GetPrecisionMod()
    {
        return precisionMod;
    }
}
