using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardStock : Stock
{
    float recoilMod = 1.5f;

    // Start is called before the first frame update
    public override void Start()
    {
        
    }

    // Update is called once per frame
    public override void Update()
    {
        
    }

    public override void Recoil()
    {
        
    }

    public override float GetRecoilMod()
    {
        return recoilMod;
    }

    public override void SetRecoilMod(float newMod)
    {
        recoilMod = newMod;
    }

}
