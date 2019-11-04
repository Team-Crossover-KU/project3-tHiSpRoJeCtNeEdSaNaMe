using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


/// Class responsible for AI follow directly from spawn points.
public class EnemyNav : MonoBehaviour
{
    private NavMeshAgent navAgent; /// AI
    

    public GameObject TargetObject; /// Red Player

    /**
      *@pre agent is initialized
      *@post sets agent as a NavMeshAgent component
      *@param None.
      *@return None.
      */
    void Awake()
    {
        navAgent = GetComponent<NavMeshAgent>();
    }


    /**
      *@pre Requires game to be launched and TargetObject to be set in inspector.
      *@post Sets the TargetObject to a GameObject with tag "Player" (the Red Player)
      *@param None.
      *@return None.
      */
    void Start()
    {
        TargetObject = GameObject.FindGameObjectsWithTag("Player")[0];
    }


    /**
      *@pre Called every frame, requires Target Object to be set in inspector.
      *@post Checks if the position of the AI and the position of the TargetObject are the same. If not, continue to have the AIs destination be the position of the TargetObject.
      *@param None.
      *@return None.
      */
    void Update()
    {
        
        if(navAgent.transform.position != TargetObject.transform.position)
        {
            navAgent.SetDestination(TargetObject.transform.position);
        }
        
    }
    
}
