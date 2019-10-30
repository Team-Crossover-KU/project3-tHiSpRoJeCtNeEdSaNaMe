using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Receiver : MonoBehaviour
{
    public int NUM_PARTS;
    public float baseDamage;
    public int baseSetsPerFire;
    public int baseShotsPerSet;
    public float basePrecision;
    public float baseFireRate;
    public float baseRecoil;
    public int baseCapacity;
    public int baseLoadedAmmoCount;
    public float baseReload;

    public float damage;
    public int setsPerFire;
    public int shotsPerSet;
    public float precision;
    public float fireRate;
    public float recoil;
    public int capacity;
    public int loadedAmmoCount;
    public float reload;
    public GunPart[] parts;
    public string title = "default";

    public float baseFireDelay = 3000;
    public float fireDelay = 0;

    // Start is called before the first frame update
    public abstract void Start();

    // Update is called once per frame
    public virtual void Update()
    {
    }

    public virtual void FixedUpdate()
    {
        if (fireDelay > 0)
        {
            fireDelay = fireDelay - fireRate;
        }
        if (fireDelay < 0)
        {
            fireDelay = 0;
        }
    }


    public abstract bool Fire();

    public abstract bool ReloadMag();

    public abstract bool AltFire();

    public abstract bool HoldFire();

    public abstract bool ReleaseHoldFire();

    public abstract bool ADS();

    public abstract bool FireRecoil();

    public abstract bool BuildGun();

    public abstract void CatalogParts();

    public AmmoType RollAmmo()
    {
        Object[] possible;
        possible = Resources.LoadAll("GunParts/AmmoTypes", typeof(AmmoType));
        Debug.Log(possible.Length);
        return (AmmoType)possible[Random.Range(0, possible.Length)];
        //return (AmmoType)possible[1];
    }

    public Barrel RollBarrel()
    {
        Object[] possible;
        possible = Resources.LoadAll("GunParts/Barrel", typeof(Barrel));
        return (Barrel)possible[Random.Range(0, possible.Length)];
    }

    public Caliber RollCaliber()
    {
        Object[] possible;
        possible = Resources.LoadAll("GunParts/Caliber", typeof(Caliber));
        return (Caliber)possible[Random.Range(0, possible.Length)];
    }

    public CyclicModifier RollCyclicModifier()
    {
        Object[] possible;
        possible = Resources.LoadAll("GunParts/CyclicModifier", typeof(CyclicModifier));
        return (CyclicModifier)possible[Random.Range(0, possible.Length)];
    }

    public Magazine RollMagazine()
    {
        Object[] possible;
        possible = Resources.LoadAll("GunParts/Magazine", typeof(Magazine));
        return (Magazine)possible[Random.Range(0, possible.Length)];
    }

    public Sight RollSight()
    {
        Object[] possible;
        possible = Resources.LoadAll("GunParts/Sight", typeof(Sight));
        return (Sight)possible[Random.Range(0, possible.Length)];
    }

    public Stock RollStock()
    {
        Object[] possible;
        possible = Resources.LoadAll("GunParts/Stock", typeof(Stock));
        return (Stock)possible[Random.Range(0, possible.Length)];
    }

    public UnderBarrel RollUnderBarrel()
    {
        Object[] possible;
        possible = Resources.LoadAll("GunParts/UnderBarrel", typeof(UnderBarrel));
        return (UnderBarrel)possible[Random.Range(0, possible.Length)];
    }

    public virtual bool CalculateStats()
    {
        CatalogParts();
        damage = CalculateDamage();
        setsPerFire = CalculateSetsPerFire();
        shotsPerSet = CalculateShotsPerSet();
        precision = CalculatePrecision();
        fireRate = CalculateFireRate();
        recoil = CalculateRecoil();
        capacity = CalculateCapacity();
        reload = CalculateReload();
        return true;

    }

    public float CalculateDamage()
    {
        float currentDamage = baseDamage;
        for (int i = 0; NUM_PARTS > i; i++)
        {
            currentDamage = parts[i].GetDamageModifier() * currentDamage;
        }
        return currentDamage;
    }

    public int CalculateSetsPerFire()
    {
        int currentSets = baseSetsPerFire;
        for (int i = 0; NUM_PARTS > i; i++)
        {
            currentSets = parts[i].GetSetsPerFireModifier() * currentSets;
        }
        return currentSets;
    }

    public int CalculateShotsPerSet()
    {
        int currentShots = baseShotsPerSet;
        for (int i = 0; NUM_PARTS > i; i++)
        {
            currentShots = parts[i].GetShotsPerSetModifier() * currentShots;
        }
        return currentShots;
    }

    public float CalculatePrecision()
    {
        float currentPrecision = basePrecision;
        for (int i = 0; NUM_PARTS > i; i++)
        {
            currentPrecision = parts[i].GetPrecisionMod() * currentPrecision;
        }
        return currentPrecision;
    }

    public float CalculateFireRate()
    {
        float currentFireRate = baseFireRate;
        for (int i = 0; NUM_PARTS > i; i++)
        {
            currentFireRate = parts[i].GetFireRateMod() * currentFireRate;
            Debug.Log(i);
            Debug.Log(parts[i]);
            Debug.Log(parts[i].GetFireRateMod());
        }
        return currentFireRate;
    }

    public float CalculateRecoil()
    {
        float currentRecoil = baseRecoil;
        for (int i = 0; NUM_PARTS > i; i++)
        {
            currentRecoil = parts[i].GetRecoilMod() * currentRecoil;
        }
        return currentRecoil;
    }

    public int CalculateCapacity()
    {
        int currentCapacity = baseCapacity;
        for (int i = 0; NUM_PARTS > i; i++)
        {
            currentCapacity = (int)(parts[i].GetCapacityMod() * currentCapacity);
        }
        return currentCapacity;
    }

    public float CalculateReload()
    {
        float currentReload = baseReload;
        for (int i = 0; NUM_PARTS > i; i++)
        {
            currentReload = parts[i].GetReloadMod() * currentReload;
        }
        return currentReload;
    }

}
