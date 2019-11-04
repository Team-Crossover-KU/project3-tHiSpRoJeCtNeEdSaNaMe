using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Receiver : MonoBehaviour
{
    // Number of parts for the gun
    public int NUM_PARTS;

    //Base Damage before part mods
    public float baseDamage;
    //Base sets produced per call of fire before part mods
    public int baseSetsPerFire;
    //Base shots per set before part mods
    public int baseShotsPerSet;
    //Base shot spread in degrees before part mods
    public float basePrecision;
    //Base rounds per minute before part mods
    public float baseFireRate;
    //Base recoil before part mods
    public float baseRecoil;
    //Base max ammo per mag before part mods
    public int baseCapacity;
    //Base start loaded ammo before part mods
    public int baseLoadedAmmoCount;
    //Base Reload time before part mods
    public float baseReload;
    //Base Velocity of produced shots before part mods
    public float baseVelocity;
    
    // Damage after weapon mods
    public float damage;
    // Sets per fire after weapon mods
    public int setsPerFire;
    // Shots per set after weapon mods
    public int shotsPerSet;
    // Spread in degrees after weapon mods
    public float precision;
    // Rounds per minute after weapon mods
    public float fireRate;
    // Recoil per shot after weapon mods
    public float recoil;
    // Max ammo loaded per mag after weapon mods
    public int capacity;
    // currently loaded ammo
    public int loadedAmmoCount;
    // time for reload after weapon mods
    public float reload;
    // Velocity of produced rounds after weapon mods
    public float velocity;
    // An array of all parts that act as modifiers for other stats
    public GunPart[] parts;
    // The name of the gun
    public string title = "default";

    // Fire delay set so that rounds are per minute. Do not modify from 3000 unless you know what you are doing
    public  float baseFireDelay = 3000;

    //Used to track time between shots.
    public float fireDelay = 0;

    // Start is called before the first frame update
    public abstract void Start();

    // Update is called once per frame
    public virtual void Update()
    {
    }

    /**
   * @pre: N/A.
   * @post: FireDelay should be deduced every .02 seconds by the RPM.
   * @param: None.
   * @return: None.
   */
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


    public abstract bool Fire(Vector3 position, Quaternion angle);

    public abstract bool ReloadMag();

    public abstract bool AltFire();

    public abstract bool HoldFire(Vector3 position, Quaternion angle);

    public abstract bool ReleaseHoldFire();

    public abstract bool ADS();

    public abstract bool FireRecoil();

    public abstract bool BuildGun();

    public abstract void CatalogParts();

    /**
   * @pre: N/A.
   * @post: A random AmmoType should be picked from those in the AmmoTypes folder.
   * @param: None.
   * @return: The chosen AmmoType.
   */

    public AmmoType RollAmmo()
    {
        Object[] possible;
        possible = Resources.LoadAll("GunParts/AmmoTypes", typeof(AmmoType));
        Debug.Log(possible.Length);
        return (AmmoType)possible[Random.Range(0, possible.Length)];
        //return (AmmoType)possible[1];
    }


    /**
   * @pre: N/A.
   * @post: A random Barrel should be picked from those in the Barrel folder.
   * @param: None.
   * @return: The chosen Barrel.
   */
    public Barrel RollBarrel()
    {
        Object[] possible;
        possible = Resources.LoadAll("GunParts/Barrel", typeof(Barrel));
        return (Barrel)possible[Random.Range(0, possible.Length)];
    }

    /**
   * @pre: N/A.
   * @post: A random Caliber should be picked from those in the Caliber folder.
   * @param: None.
   * @return: The chosen Caliber.
   */
    public Caliber RollCaliber()
    {
        Object[] possible;
        possible = Resources.LoadAll("GunParts/Caliber", typeof(Caliber));
        return (Caliber)possible[Random.Range(0, possible.Length)];
    }

    /**
   * @pre: N/A.
   * @post: A random CyclicModifier should be picked from those in the CyclicModifier folder.
   * @param: None.
   * @return: The chosen CyclicModifier.
   */
    public CyclicModifier RollCyclicModifier()
    {
        Object[] possible;
        possible = Resources.LoadAll("GunParts/CyclicModifier", typeof(CyclicModifier));
        return (CyclicModifier)possible[Random.Range(0, possible.Length)];
    }

    /**
   * @pre: N/A.
   * @post: A random Magazine should be picked from those in the Magazine folder.
   * @param: None.
   * @return: The chosen Magazine.
   */
    public Magazine RollMagazine()
    {
        Object[] possible;
        possible = Resources.LoadAll("GunParts/Magazine", typeof(Magazine));
        return (Magazine)possible[Random.Range(0, possible.Length)];
    }

    /**
   * @pre: N/A.
   * @post: A random Sight should be picked from those in the Sight folder.
   * @param: None.
   * @return: The chosen Sight.
   */
    public Sight RollSight()
    {
        Object[] possible;
        possible = Resources.LoadAll("GunParts/Sight", typeof(Sight));
        return (Sight)possible[Random.Range(0, possible.Length)];
    }

    /**
   * @pre: N/A.
   * @post: A random Stock should be picked from those in the Stock folder.
   * @param: None.
   * @return: The chosen Stock.
   */
    public Stock RollStock()
    {
        Object[] possible;
        possible = Resources.LoadAll("GunParts/Stock", typeof(Stock));
        return (Stock)possible[Random.Range(0, possible.Length)];
    }

    /**
   * @pre: N/A.
   * @post: A random UnderBarrel should be picked from those in the UnderBarrel folder.
   * @param: None.
   * @return: The chosen UnderBarrel.
   */
    public UnderBarrel RollUnderBarrel()
    {
        Object[] possible;
        possible = Resources.LoadAll("GunParts/UnderBarrel", typeof(UnderBarrel));
        return (UnderBarrel)possible[Random.Range(0, possible.Length)];
    }

    /**
   * @pre: N/A.
   * @post: All stats should be calculated after mods for all parts are applied.
   * @param: None.
   * @return: Stub for now. Should return true if no errors occur.
   */
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
        velocity = CalculateVelocity();
        return true;

    }

    /**
   * @pre: N/A.
   * @post: Damage should be calculated after mods for all parts are applied.
   * @param: None.
   * @return: Stub for now. Should return true if no errors occur.
   */
    public float CalculateDamage()
    {
        float currentDamage = baseDamage;
        for (int i = 0; NUM_PARTS > i; i++)
        {
            currentDamage = parts[i].GetDamageModifier() * currentDamage;
        }
        return currentDamage;
    }

    /**
   * @pre: N/A.
   * @post: setsPerFire should be calculated after mods for all parts are applied.
   * @param: None.
   * @return: Stub for now. Should return true if no errors occur.
   */
    public int CalculateSetsPerFire()
    {
        int currentSets = baseSetsPerFire;
        for (int i = 0; NUM_PARTS > i; i++)
        {
            currentSets = parts[i].GetSetsPerFireModifier() * currentSets;
        }
        return currentSets;
    }

    /**
   * @pre: N/A.
   * @post: shotsPerFire should be calculated after mods for all parts are applied.
   * @param: None.
   * @return: Stub for now. Should return true if no errors occur.
   */
    public int CalculateShotsPerSet()
    {
        int currentShots = baseShotsPerSet;
        for (int i = 0; NUM_PARTS > i; i++)
        {
            currentShots = parts[i].GetShotsPerSetModifier() * currentShots;
        }
        return currentShots;
    }

    /**
   * @pre: N/A.
   * @post: precision should be calculated after mods for all parts are applied.
   * @param: None.
   * @return: Stub for now. Should return true if no errors occur.
   */
    public float CalculatePrecision()
    {
        float currentPrecision = basePrecision;
        for (int i = 0; NUM_PARTS > i; i++)
        {
            currentPrecision = parts[i].GetPrecisionMod() * currentPrecision;
        }
        return currentPrecision;
    }

    /**
   * @pre: N/A.
   * @post fire rate should be calculated after mods for all parts are applied.
   * @param: None.
   * @return: Stub for now. Should return true if no errors occur.
   */
    public float CalculateFireRate()
    {
        float currentFireRate = baseFireRate;
        for (int i = 0; NUM_PARTS > i; i++)
        {
            currentFireRate = parts[i].GetFireRateMod() * currentFireRate;
        }
        return currentFireRate;
    }

    /**
   * @pre: N/A.
   * @post recoil should be calculated after mods for all parts are applied.
   * @param: None.
   * @return: Stub for now. Should return true if no errors occur.
   */
    public float CalculateRecoil()
    {
        float currentRecoil = baseRecoil;
        for (int i = 0; NUM_PARTS > i; i++)
        {
            currentRecoil = parts[i].GetRecoilMod() * currentRecoil;
        }
        return currentRecoil;
    }

    /**
   * @pre: N/A.
   * @post capacity should be calculated after mods for all parts are applied.
   * @param: None.
   * @return: Stub for now. Should return true if no errors occur.
   */
    public int CalculateCapacity()
    {
        int currentCapacity = baseCapacity;
        for (int i = 0; NUM_PARTS > i; i++)
        {
            currentCapacity = (int)(parts[i].GetCapacityMod() * currentCapacity);
        }
        return currentCapacity;
    }

    /**
   * @pre: N/A.
   * @post reload should be calculated after mods for all parts are applied.
   * @param: None.
   * @return: Stub for now. Should return true if no errors occur.
   */
    public float CalculateReload()
    {
        float currentReload = baseReload;
        for (int i = 0; NUM_PARTS > i; i++)
        {
            currentReload = parts[i].GetReloadMod() * currentReload;
        }
        return currentReload;
    }

    /**
   * @pre: N/A.
   * @post velocity should be calculated after mods for all parts are applied.
   * @param: None.
   * @return: Stub for now. Should return true if no errors occur.
   */
    public float CalculateVelocity()
    {
        float currentVelocity = baseVelocity;
        for (int i = 0; NUM_PARTS > i; i++)
        {
            currentVelocity = parts[i].GetVelocityMod() * currentVelocity;
        }
        return currentVelocity;
    }

}
