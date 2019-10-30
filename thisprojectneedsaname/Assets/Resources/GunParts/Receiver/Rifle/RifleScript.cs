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
        if (loadedAmmoCount > 0 && fireDelay == 0)
        {
            loadedAmmoCount--;
            ammo.Fire(new Vector3(0, 0, 5), this.transform.position, this.transform.parent.transform.rotation);
            fireDelay = baseFireDelay;
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
        sight.ADSToggle();
        return true;
    }

    public override bool ReloadMag()
    {
        loadedAmmoCount = capacity;
        return true;
    }

    public override bool BuildGun()
    {
        ammo = Instantiate(RollAmmo(), this.transform);
        barrel = Instantiate(RollBarrel(), this.transform);
        caliber = Instantiate(RollCaliber(), this.transform);
        cyclicModifier = Instantiate(RollCyclicModifier(), this.transform);
        cyclicModifier.Attach(this);
        magazine = Instantiate(RollMagazine(), this.transform);
        sight = Instantiate(RollSight(), this.transform);
        stock = Instantiate(RollStock(), this.transform);
        underBarrel = Instantiate(RollUnderBarrel(), this.transform);
        underBarrel.Attach(this);
        return true;
    }

    public override void CatalogParts()
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


}
