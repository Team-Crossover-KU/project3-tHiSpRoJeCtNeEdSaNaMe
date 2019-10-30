using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public int lifeTime;
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

    void setLifeTime(int newLife)
    {
        lifeTime = newLife;
    }
}
