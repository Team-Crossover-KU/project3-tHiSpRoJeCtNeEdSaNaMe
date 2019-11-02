using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    public GameObject parent;
    public GameObject Enemy;
    public GameObject EnemySpawn1;
    public GameObject EnemySpawn2;
    public GameObject EnemySpawn3;
    public GameObject EnemySpawn4;
    public GameObject EnemySpawn5;
    public GameObject EnemySpawn6;
    private GameObject Enemy1;
    private GameObject Enemy2;
    private GameObject Enemy3;
    private GameObject Enemy4;
    private GameObject Enemy5;
    private GameObject Enemy6;
    public GameObject Target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Enemy1 = Instantiate(Enemy, EnemySpawn1.transform.position, EnemySpawn1.transform.rotation);
            Enemy2 = Instantiate(Enemy, EnemySpawn2.transform.position, EnemySpawn2.transform.rotation);
            Enemy3 = Instantiate(Enemy, EnemySpawn3.transform.position, EnemySpawn3.transform.rotation);
            Enemy4 = Instantiate(Enemy, EnemySpawn4.transform.position, EnemySpawn4.transform.rotation);
            Enemy5 = Instantiate(Enemy, EnemySpawn5.transform.position, EnemySpawn5.transform.rotation);
            Enemy6 = Instantiate(Enemy, EnemySpawn6.transform.position, EnemySpawn6.transform.rotation);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(Enemy1);
            Destroy(Enemy2);
            Destroy(Enemy3);
            Destroy(Enemy4);
            Destroy(Enemy5);
            Destroy(Enemy6);
        }
    }
}
