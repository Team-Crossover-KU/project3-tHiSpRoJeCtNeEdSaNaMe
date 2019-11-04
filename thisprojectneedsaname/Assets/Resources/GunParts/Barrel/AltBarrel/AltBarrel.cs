using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltBarrel : Barrel
{
    // shotsPerSetMod for stat calculation
    public int shotsPerSetMod = 3;
    // setsPerFireMod for stat calculation
    public int setsPerFireMod = 2;
    // rateOfFireMod for stat calculation
    public float rateOfFireMod = .4f;
    // precisionMod for stat Calc;
    public float precisionMod = 2;

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
   * @post: Returns setsPerFireMod.
   * @param: None.
   * @return: setsPerFireMod.
   */
    public override int GetSetsPerFireModifier()
    {
        return setsPerFireMod;
    }
    /**
   * @pre: N/A.
   * @post: Returns shotsPerSetMod.
   * @param: None.
   * @return: shotsPerSetMod.
   */
    public override int GetShotsPerSetModifier()
    {
        return shotsPerSetMod;
    }

    /**
   * @pre: N/A.
   * @post: Returns rateOfFireMod.
   * @param: None.
   * @return: rateOfFireMod.
   */
    public override float GetFireRateMod()
    {
        return rateOfFireMod;
    }

    /**
   * @pre: N/A.
   * @post: Returns precisionMod.
   * @param: None.
   * @return: precisionMod.
   */
    public override float GetPrecisionMod()
    {
        return precisionMod;
    }
}
