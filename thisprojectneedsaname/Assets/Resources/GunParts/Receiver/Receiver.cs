using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Receiver : MonoBehaviour
{

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
    public string title;

    // Start is called before the first frame update
    public abstract void Start();

    // Update is called once per frame
    public abstract void Update();

    public abstract bool Fire();

    public abstract bool ReloadMag();

    public abstract bool AltFire();

    public abstract bool HoldFire();

    public abstract bool ReleaseHoldFire();

    public abstract bool FireRecoil();

    public abstract bool CalculateStats();

    public abstract bool BuildGun();

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

}
