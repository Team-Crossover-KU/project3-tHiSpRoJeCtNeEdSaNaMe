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

    /**
   * @pre: N/A.
   * @post: sets the UnderBarrel's receiver to input. Used by some UnderBarrels
   * @param: New receiver for UnderBarrel.
   * @return: None.
   */
    public void Attach(Receiver mainBody)
    {
        receiver = mainBody;
    }
}
