using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardMag : Magazine
{

    public float cappacityMod = 1.5f;
    public float reloadMod = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override float GetCapacityMod()
    {
        return cappacityMod;
    }

    public override void SetCapacityMod(float newMod)
    {
        cappacityMod = newMod;
    }

    public override float GetReloadMod()
    {
        return reloadMod;
    }

    public override void SetReloadMod(float newMod)
    {
        reloadMod = newMod;
    }
}
