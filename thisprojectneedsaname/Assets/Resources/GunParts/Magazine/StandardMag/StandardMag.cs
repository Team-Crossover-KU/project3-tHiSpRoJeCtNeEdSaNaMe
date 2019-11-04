using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardMag : Magazine
{
    // capacity modification for stat calc
    public float cappacityMod = 1.5f;
    // reload modification for stat calc
    public float reloadMod = 1.5f;

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
   * @post: Returns capacityMod
   * @param: None.
   * @return: capacityMod.
   */
    public override float GetCapacityMod()
    {
        return cappacityMod;
    }

    /**
   * @pre: N/A.
   * @post: Sets capacityMod to inputted value.
   * @param: new value for capacityMod.
   * @return: None.
   */
    public override void SetCapacityMod(float newMod)
    {
        cappacityMod = newMod;
    }

    /**
   * @pre: N/A.
   * @post: Returns reloadMod
   * @param: None.
   * @return: reloadMod.
   */
    public override float GetReloadMod()
    {
        return reloadMod;
    }

    /**
   * @pre: N/A.
   * @post: Sets reloadMod to inputted value.
   * @param: new value for reloadMod.
   * @return: None.
   */
    public override void SetReloadMod(float newMod)
    {
        reloadMod = newMod;
    }
}
