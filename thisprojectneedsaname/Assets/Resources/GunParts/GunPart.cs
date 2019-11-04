using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GunPart : MonoBehaviour
{
    /**
   * @pre: N/A.
   * @post N/A.
   * @param: None.
   * @return: Value that will not modify the original installed weapon's Damage.
   * Override if you need to change stats when making a object that inherits this class.
   */

    public virtual float GetDamageModifier()
    {
        return 1;
    }

    /**
   * @pre: N/A.
   * @post No change, override if inherited object has a form of damage mod.
   * @param: None.
   * @return: None .
   */
    public virtual void SetDamageModifier(float newMod)
    {
        
    }


    /**
   * @pre: N/A.
   * @post N/A.
   * @param: None.
   * @return: Value that will not modify the original installed weapon's sets per trigger pull.
   * Override if you need to change stats when making a object that inherits this class.
   */
    public virtual int GetSetsPerFireModifier()
    {
        return 1;
    }

    /**
   * @pre: N/A.
   * @post No change, override if inherited object has a form of sets per fire mod.
   * @param: None.
   * @return: None .
   */
    public virtual void SetSetsPerFireModifier(int newMod)
    {
        
    }

    /**
   * @pre: N/A.
   * @post N/A.
   * @param: None.
   * @return: Value that will not modify the original installed weapon's shots per set.
   * Override if you need to change stats when making a object that inherits this class.
   */
    public virtual int GetShotsPerSetModifier()
    {
        return 1;
    }

    /**
   * @pre: N/A.
   * @post No change, override if inherited object has a form of shots per set mod.
   * @param: None.
   * @return: None .
   */
    public virtual void SetShotsPerSetModifier(int newMod)
    {
        
    }

    /**
   * @pre: N/A.
   * @post N/A.
   * @param: None.
   * @return: Value that will not modify the original installed weapon's Spread.
   * Override if you need to change stats when making a object that inherits this class.
   */
    public virtual float GetPrecisionMod()
    {
        return 1;
    }

    /**
   * @pre: N/A.
   * @post No change, override if inherited object has a form of spread mod.
   * @param: None.
   * @return: None .
   */
    public virtual void SetPrecisionMod(float newMod)
    {
        
    }

    /**
   * @pre: N/A.
   * @post N/A.
   * @param: None.
   * @return: Value that will not modify the original installed weapon's Fire Rate.
   * Override if you need to change stats when making a object that inherits this class.
   */
    public virtual float GetFireRateMod()
    {
        return 1;
    }

    /**
   * @pre: N/A.
   * @post No change, override if inherited object has a form of fire rate mod.
   * @param: None.
   * @return: None .
   */

    public virtual void SetFireRateMod(float newMod)
    {
        
    }

    /**
   * @pre: N/A.
   * @post N/A.
   * @param: None.
   * @return: Value that will not modify the original installed weapon's Recoil.
   * Override if you need to change stats when making a object that inherits this class.
   */
    public virtual float GetRecoilMod()
    {
        return 1;
    }

    /**
   * @pre: N/A.
   * @post No change, override if inherited object has a form of recoil mod.
   * @param: None.
   * @return: None .
   */

    public virtual void SetRecoilMod(float newMod)
    {
       
    }

    /**
   * @pre: N/A.
   * @post N/A.
   * @param: None.
   * @return: Value that will not modify the original installed weapon's cappcity.
   * Override if you need to change stats when making a object that inherits this class.
   */
    public virtual float GetCapacityMod()
    {
        return 1;
    }

    /**
   * @pre: N/A.
   * @post No change, override if inherited object has a form of cappacity mod.
   * @param: None.
   * @return: None .
   */
    public virtual void SetCapacityMod(float newMod)
    {
        
    }

    /**
   * @pre: N/A.
   * @post N/A.
   * @param: None.
   * @return: Value that will not modify the original installed weapon's Reload.
   * Override if you need to change stats when making a object that inherits this class.
   */
    public virtual float GetReloadMod()
    {
        return 1;
    }

    /**
   * @pre: N/A.
   * @post No change, override if inherited object has a form of reload mod.
   * @param: None.
   * @return: None .
   */
    public virtual void SetReloadMod(float newMod)
    {


    }

    /**
   * @pre: N/A.
   * @post N/A.
   * @param: None.
   * @return: Value that will not modify the original installed weapon's velcity.
   * Override if you need to change stats when making a object that inherits this class.
   */
    public virtual float GetVelocityMod()
    {
        return 1;
    }

    /**
   * @pre: N/A.
   * @post No change, override if inherited object has a form of velocity mod.
   * @param: None.
   * @return: None .
   */
    public virtual void SetVelocityMod(float newMod)
    {


    }
}
