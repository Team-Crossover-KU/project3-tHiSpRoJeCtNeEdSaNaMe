using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltProjectile : AmmoType
{
    public GameObject projectile;
    public GameObject projected;
    public int damage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Fire(Vector3 newVelocity, Vector3 Pos, Quaternion angle, float spread)
    {
        float xSpread = Random.Range(-spread, spread);
        float ySpread = Random.Range(-spread, spread);
        projected = Instantiate(projectile, Pos, Quaternion.identity);
        projected.GetComponent<Rigidbody>().velocity = angle * Quaternion.Euler(ySpread, xSpread, 0) * newVelocity;
        projected.GetComponent<ProjectileController>().SetDamage(damage);
        Debug.Log(angle);
    }
}
