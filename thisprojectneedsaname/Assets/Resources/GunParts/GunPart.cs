using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GunPart : MonoBehaviour
{
    public virtual float GetDamageModifier()
    {
        return 1;
    }

    public virtual void SetDamageModifier(float newMod)
    {
        
    }

    public virtual int GetSetsPerFireModifier()
    {
        return 1;
    }

    public virtual void SetSetsPerFireModifier(int newMod)
    {
        
    }

    public virtual int GetShotsPerSetModifier()
    {
        return 1;
    }

    public virtual void SetShotsPerSetModifier(int newMod)
    {
        
    }

    public virtual float GetPrecisionMod()
    {
        return 1;
    }

    public virtual void SetPrecisionMod(float newMod)
    {
        
    }

    public virtual float GetFireRateMod()
    {
        return 1;
    }

    public virtual void SetFireRateMod(float newMod)
    {
        
    }

    public virtual float GetRecoilMod()
    {
        return 1;
    }

    public virtual void SetRecoilMod(float newMod)
    {
       
    }

    public virtual float GetCapacityMod()
    {
        return 1;
    }

    public virtual void SetCapacityMod(float newMod)
    {
        
    }

    public virtual float GetReloadMod()
    {
        return 1;
    }

    public virtual void SetReloadMod(float newMod)
    {


    }
}
