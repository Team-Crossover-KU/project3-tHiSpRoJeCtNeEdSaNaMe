using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeLauncher : UnderBarrel
{
    //Modifier for attached weapon's spread in degrees
    public float precisionMod = 1.2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /**
   * @pre: N/A.
   * @post: Displays testing message. Later will spawn grenade
   * @param: None.
   * @return: None.
   */
    public override void AltFire()
    {
        Debug.Log("BOOOM" + receiver.damage);
    }

    /**
   * @pre: N/A.
   * @post: Returns the precision mod for part
   * @param: None.
   * @return: precisionMod.
   */
    public override float GetPrecisionMod()
    {
        return precisionMod;
    }
}
