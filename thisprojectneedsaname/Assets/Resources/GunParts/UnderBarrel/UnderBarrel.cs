using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UnderBarrel : GunPart
{
    public Receiver receiver;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public abstract void AltFire();
    public void Attach(Receiver mainBody)
    {
        receiver = mainBody;
    }
}
