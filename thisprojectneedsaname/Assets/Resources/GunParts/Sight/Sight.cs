using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Sight : GunPart
{
    //If the user is aiming down the sights
    public bool ADS = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void  ADSToggle()
    {

    }
}
