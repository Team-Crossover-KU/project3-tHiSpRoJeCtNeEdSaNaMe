using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RifleScript : Receiver
{
    new public const int NUM_PARTS = 8;
    public AmmoType ammo;
    public Barrel barrel;
    public Caliber caliber;
    public CyclicModifier cyclicModifier;
    public Magazine magazine;
    public Sight sight;
    public Stock stock;
    public UnderBarrel underBarrel;
    public int fireDamage;


    /**
   * @pre: N/A.
   * @post: Gun should be set up for use by player.
   * @param: None.
   * @return: None.
   */
    public override void Start()
    {
        parts = new GunPart[NUM_PARTS];
        BuildGun();
        CalculateStats();
    }

    // Update is called once per frame
    public override void Update()
    {
        
    }

    /**
   * @pre: CalculateStats function should be called on a fully built gun first .
   * @post: A shot should be produced if ammo can be deducted successfully and it is not cooling down from prior shot, nothing otherwise.
   * @param: None.
   * @return: Did at least one shot get produced.
   */
    public override bool Fire(Vector3 positon, Quaternion angle)
    {
        if (fireDelay == 0)
        {
            fireDamage = (int)damage / shotsPerSet;
            for (int i = 0; setsPerFire > i; i++)
            {
                for (int j = 0; shotsPerSet > j; j++)
                {
                    if (loadedAmmoCount > 0)
                    {
                        ammo.Fire(new Vector3(0, 0, velocity), positon, angle, precision,fireDamage);
                        fireDelay = baseFireDelay;
                    }
                    
                }
                loadedAmmoCount--;
            }
           
                return true;
        }
        
        else
        {
            return false;
        }
    }

    /**
   * @pre: N/A.
   * @post: Calls stock's recoil function, a dummy function for now.
   * @param: None.
   * @return: Stub, should return if gun recoils correctly.
   */
    public override bool FireRecoil()
    {
        stock.Recoil();
        return true;
    }

    /**
   * @pre: N/A.
   * @post: Calls the cyclicModifier's HoldFire function.
   * @param: None.
   * @return: Stub for now, should return if cyclicModifier's HoldFire function returns correctly.
   */
    public override bool HoldFire(Vector3 position, Quaternion angle)
    {
        cyclicModifier.HoldFire(position, angle);
        return true;
    }

    /**
   * @pre: N/A.
   * @post: Calls the cyclicModifier's ReleaseHoldFire function.
   * @param: None.
   * @return: Stub for now, should return if cyclicModifier's ReleaseHoldFire function returns correctly.
   */
    public override bool ReleaseHoldFire()
    {
        cyclicModifier.ReleaseHoldFire();
        return true;
    }

    /**
   * @pre: N/A.
   * @post: Calls the underBarrel's AltFire function.
   * @param: None.
   * @return: Stub for now, should return if underBarrel's AltFire function returns correctly.
   */
    public override bool AltFire()
    {
        underBarrel.AltFire();
        return true;
    }

    /**
   * @pre: N/A.
   * @post: Calls the sight's ADS function.
   * @param: None.
   * @return: Stub for now, should return if sight's ADS function returns correctly.
   */
    public override bool ADS()
    {
        sight.ADSToggle();
        return true;
    }

    /**
   * @pre: N/A.
   * @post: Gun's loaded ammo should be refilled.
   * @param: None.
   * @return: Stub for now, should return if reload occurs with no issues function returns correctly.
   */
    public override bool ReloadMag()
    {
        loadedAmmoCount = capacity;
        return true;
    }

    /**
   * @pre: None.
   * @post: Gun's parts should be rolled, ready for stats to be calculated.
   * @param: None.
   * @return: Stub for now, should return if build occurs with no issues function returns correctly.
   */

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

    /**
   * @pre: Gun is built.
   * @post: parts array should be populated.
   * @param: None.
   * @return: None.
   */
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
