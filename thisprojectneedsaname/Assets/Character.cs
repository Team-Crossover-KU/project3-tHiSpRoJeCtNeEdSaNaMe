using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    
public class Character : MonoBehaviour {

    public int maxJump = 2;
    public float health = 100;
    public float maxHealth;
    public bool hit = false;
    public float speed = 10.0f;

    public Rigidbody2D rb;
    public Transform tr;

    // Use this for initialization
    public virtual void Start () {
        maxHealth = health;
        rb = this.GetComponent("Rigidbody2D") as Rigidbody2D;
        tr = this.GetComponent("Transform") as Transform;
    }

    // Update is called once per frame
    public virtual void Update ()
    {
        if (health == 0)
        {
            Object.Destroy(gameObject);
        }

        if (hit)
        {
            hit = false;
        }

    }

    public virtual void FixedUpdate()
    {

    }

    public virtual void ChangeHealth(float change)
    {
        if (health + change < 0)
        {
            health = 0;
        }

        else
        {
            health = health + change;
        }
    }

    public Vector2 AngleVector(float angle, float length)
    {
        Vector2 result;
        result = new Vector2(Mathf.Cos(angle) * length, Mathf.Sin(angle) * length);
        Debug.Log(result.x + " " + result.y);
        return result;
    }

}
