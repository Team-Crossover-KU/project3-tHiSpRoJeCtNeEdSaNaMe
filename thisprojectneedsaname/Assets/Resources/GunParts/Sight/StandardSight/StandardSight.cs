using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardSight : Sight
{
    //rateOfFire modification if the player is not scoped in
    public float unScopedRateOfFiremod = 1.5f;
    //rateOfFire modification if the player is scoped in
    public float scopedRateOfFiremod = .75f;
    //recoil modification if player is not scoped in
    public float unScopedRecoilMod = 1.2f;
    //recoil modification if player is scoped in
    public float scopedRecoilMod = .8f;

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
   * @post: Toggles between player "Looking" down the sights. Also displays debug message
   * @param: None.
   * @return: None.
   */
    public override void ADSToggle()
    {
        ADS = !ADS;
        Debug.Log("ADS");
    }

    /**
   * @pre: N/A.
   * @post: Returns the fireRateMod for unscoped or scoped depending of player is ADS
   * @param: None.
   * @return: None.
   */
    public override float GetFireRateMod()
    {
        if (ADS)
        {
            return scopedRateOfFiremod;
        }
        else
        {
            return unScopedRateOfFiremod;
        }
    }

    /**
   * @pre: N/A.
   * @post: Returns the recoilMod for unscoped or scoped depending of player is ADS
   * @param: None.
   * @return: None.
   */
    public override float GetRecoilMod()
    {
        if (ADS)
        {
            return scopedRecoilMod;
        }
        else
        {
            return unScopedRecoilMod;
        }
    }
}
