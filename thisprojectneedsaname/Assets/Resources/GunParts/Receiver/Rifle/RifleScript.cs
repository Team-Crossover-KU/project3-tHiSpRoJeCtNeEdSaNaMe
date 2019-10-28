using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RifleScript : Receiver
{
    public const int NUM_PARTS = 8;
    public AmmoType ammo;
    public Barrel barrel;
    public Caliber caliber;
    public CyclicModifier cyclicModifier;
    public Magazine magazine;
    public Sight sight;
    public Stock stock;
    public UnderBarrel underBarrel;
    public GunPart[] parts;

    // Start is called before the first frame update
    public override void Start()
    {
        parts = new GunPart[8];
        BuildGun();
        CalculateStats();
        Fire();
    }

    // Update is called once per frame
    public override void Update()
    {

    }

    public override bool Fire()
    {
        if (loadedAmmoCount > 0)
        {
            loadedAmmoCount--;
            ammo.Fire(new Vector3(5, 0, 0), this.transform.position);
            return true;
        }
        else
        {
            return false;
        }
    }

    public override bool FireRecoil()
    {
        stock.Recoil();
        return true;
    }

    public override bool HoldFire()
    {
        cyclicModifier.HoldFire();
        return true;
    }

    public override bool ReleaseHoldFire()
    {
        cyclicModifier.ReleaseHoldFire();
        return true;
    }

    public override bool AltFire()
    {
        underBarrel.AltFire();
        return true;
    }

    public override bool ADS()
    {
        return true;
    }

    public override bool ReloadMag()
    {
        loadedAmmoCount = capacity;
        return true;
    }

    public override bool BuildGun()
    {
        ammo = RollAmmo();
        barrel = RollBarrel();
        caliber = RollCaliber();
        cyclicModifier = RollCyclicModifier();
        cyclicModifier.Attach(this);
        magazine = RollMagazine();
        sight = RollSight();
        stock = RollStock();
        underBarrel = RollUnderBarrel();
        underBarrel.Attach(this);
        return true;
    }

    

    public void CatalogParts()
    {
        parts[0] = ammo;
        parts[1] = barrel;
        parts[2] = caliber;
        parts[3] = cyclicModifier;
        parts[4] = magazine;
        parts[5] = sight;
        parts[6] = stock;
        parts[7] = underBarrel;
    }

    public override bool CalculateStats()
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
