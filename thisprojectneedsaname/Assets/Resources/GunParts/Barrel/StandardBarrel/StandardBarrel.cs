using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardBarrel : Barrel
{
    // shotsPerSetMod for stat calculation
    public int shotsPerSetMod = 1;
    // setsPerFireMod for stat calculation
    public int setsPerFireMod = 1;

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
}
