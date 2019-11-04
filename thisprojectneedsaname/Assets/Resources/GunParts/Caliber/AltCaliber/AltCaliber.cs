using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltCaliber : Caliber
{
    // damageMod for stat calculation
    public float damageMod = .75f;
    // capacityMod for stat calculation
    public float capacityMod = 1.5f;
    // recoilMod for stat calculation
    public float recoilMod = .75f;

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
   * @post: Returns damageMod.
   * @param: None.
   * @return: damageMod.
   */
    public override float GetDamageModifier()
    {
        return damageMod;
    }

    /**
   * @pre: N/A.
   * @post: Returns recoilMod.
   * @param: None.
   * @return: recoilMod.
   */
    public override float GetCapacityMod()
    {
        return capacityMod;
    }

    /**
   * @pre: N/A.
   * @post: Returns recoilMod.
   * @param: None.
   * @return: recoilMod.
   */
    public override float GetRecoilMod()
    {
        return recoilMod;
    }
}
