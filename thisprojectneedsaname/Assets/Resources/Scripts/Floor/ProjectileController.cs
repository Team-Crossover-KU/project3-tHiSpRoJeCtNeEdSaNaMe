using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    //Time in units of .02 Seconds
    public int lifeTime;
    //Damage to be dealt on impact
    public float damage;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {

    }

    /**
    * @pre: N/A.
    * @post: Controls the lifeTime of the bullet. Deducts from the timer every .02 seconds and if the timer is up, destorys the object
    * @param: None.
    * @return: None.
    */
    void FixedUpdate()
    {
        if (lifeTime > 0)
        {
            lifeTime--;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /**
   * @pre: N/A.
   * @post: sets the lifeTime variable to input
   * @param: New lifeTime for Projectile.
   * @return: None.
   */
    public void SetLifeTime(int newLife)
    {
        lifeTime = newLife;
    }

    /**
   * @pre: N/A.
   * @post: sets the damage variable to input
   * @param: New damage for Projectile.
   * @return: None.
   */
    public void SetDamage(float newDamage)
    {
        damage = newDamage;
    }

    /**
   * @pre: N/A.
   * @post: Checks if projectile hit enemy, if so deal damage
   * @param: Object hit.
   * @return: None.
   */
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Hostile")
        {
            other.GetComponent<Character>().ChangeHealth(-damage);
            Destroy(gameObject);
        }
            
    }
}
