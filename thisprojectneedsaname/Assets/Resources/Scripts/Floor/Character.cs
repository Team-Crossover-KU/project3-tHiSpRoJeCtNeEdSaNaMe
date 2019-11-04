using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    
public class Character : MonoBehaviour {

    // Maximum number of jumps for the character
    public int maxJump = 2;
    //  Health of character
    public float health = 100;
    // Maximum health a character can have
    public float maxHealth;
    // If the character has been hit
    public bool hit = false;
    // Movement speed of the character
    public float speed = 10.0f;

    //Character's RigidBody
    public Rigidbody rb;
    //Character's Transform
    public Transform tr;

    /**
   * @pre: N/A.
   * @post: Character should be spawned and ready to use
   * @param: None.
   * @return: None.
   */
    public virtual void Start () {
        maxHealth = health;
        rb = this.GetComponent("Rigidbody2D") as Rigidbody;
        tr = this.GetComponent("Transform") as Transform;
    }

    /**
   * @pre: N/A.
   * @post: Destorys character if they have no health
   * @param: None.
   * @return: None.
   */
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

    /**
   * @pre: N/A.
   * @post: Adds input to player health
   * @param: None.
   * @return: None.
   */
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

    /**
   * @pre: N/A.
   * @post: Converts a angle in degrees and a length to new vector. Not used
   * @param: None.
   * @return: None.
   */
    public Vector2 AngleVector(float angle, float length)
    {
        Vector2 result;
        result = new Vector2(Mathf.Cos(angle) * length, Mathf.Sin(angle) * length);
        Debug.Log(result.x + " " + result.y);
        return result;
    }

}
