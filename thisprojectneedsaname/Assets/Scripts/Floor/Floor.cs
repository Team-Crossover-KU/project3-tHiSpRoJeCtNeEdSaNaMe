using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    public GameObject parent; /// Parent GameObject.
    public GameObject Enemy; /// Enemy prefab.
    public GameObject EnemySpawn1; /// Spawn point for enemy clone 1.
    public GameObject EnemySpawn2; /// Spawn point for enemy clone 2.
    public GameObject EnemySpawn3; /// Spawn point for enemy clone 3.
    public GameObject EnemySpawn4; /// Spawn point for enemy clone 4.
    public GameObject EnemySpawn5; /// Spawn point for enemy clone 5.
    public GameObject EnemySpawn6; /// Spawn point for enemy clone 6.
    private GameObject Enemy1; /// Enemy clone 1.
    private GameObject Enemy2; /// Enemy clone 2.
    private GameObject Enemy3; /// Enemy clone 3.
    private GameObject Enemy4; /// Enemy clone 4.
    private GameObject Enemy5; /// Enemy clone 5.
    private GameObject Enemy6; /// Enemy clone 6.
    public GameObject Target; /// GameObject Target.


    /**
      *@pre Called when the game is launched and before update.
      *@post None.
      *@param None.
      *@return None.
      */
    void Start()
    {
        
    }


    /**
      *@pre Called everyframe after the game launches.
      *@post None.
      *@param None.
      *@return None.
      */
    void Update()
    {
        
    }


    /**
      *@pre Game must be launched player must enter a BattleRoom.
      *@post Upon entry into a BattleRoom, 6 Enemies are instantiated (spawned) into that room at their respected spawn points. Each enemy is a clone of the prefab Enemy.
      *@param None.
      *@return None.
      */
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


    /**
      *@pre Game must be launched. Player must exit a BattleRoom.
      *@post All the instantiated enemies get destroyed and are no longer visible in game or scene.
      *@param None.
      *@return None.
      */
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
