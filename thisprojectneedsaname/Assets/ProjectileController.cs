using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public int lifeTime;
    public int damage;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {

    }


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

    public void SetLifeTime(int newLife)
    {
        lifeTime = newLife;
    }

    public void SetDamage(int newDamage)
    {
        damage = newDamage;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Hostile")
        {
            other.GetComponent<Character>().ChangeHealth(-damage);
            Destroy(gameObject);
        }
            
    }
}
