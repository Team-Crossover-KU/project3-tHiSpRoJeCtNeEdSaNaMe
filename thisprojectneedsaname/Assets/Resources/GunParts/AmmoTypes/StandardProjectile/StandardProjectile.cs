using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardProjectile : AmmoType
{
    // Type of projectile to be fired
    public GameObject projectile;
    // Last fired projectile
    public GameObject projected;
    // Damage of produced projectile
    public float damage;
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
   * @post: A shot should be produced with inputted damage with a velocity and angle within a range described by spread.
   * @param: newVelocity, angle, and position are their respective values for the shot, spread is variation from the prior mentioned shot pattern in degrees and newDamage is expected damage of round.
   * @return: None.
   */
    public override void Fire(Vector3 newVelocity, Vector3 Pos, Quaternion angle, float spread, float newDamage)
    {
        float xSpread = Random.Range(-spread, spread);
        float ySpread = Random.Range(-spread, spread);
        projected = Instantiate(projectile, Pos, Quaternion.identity);
        projected.GetComponent<Rigidbody>().velocity = angle * Quaternion.Euler(ySpread, xSpread, 0) * newVelocity;
        projected.GetComponent<ProjectileController>().SetDamage(newDamage);
        Debug.Log(angle);
    }
}
