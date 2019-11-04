using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// Class responsible for AI patrol directly from spawn points and follow Player.
public class Patrol : MonoBehaviour
{

    public GameObject StartPoint; /// Used to track position of starting waypoint (spawn point).
    public GameObject FinishPoint; /// Used to track position of ending waypoint.
    public float distFromFinish; /// Distance from an AIs spawn point and waypoint.
    private NavMeshAgent agent; /// AI.
    public float lookRadius = 4f; /// Radius AI can detect player.
    public GameObject Player; /// Red Player GameObject.

    public float distanceToPlayer;



    /**
      *@pre agent is initialized
      *@post sets agent as a NavMeshAgent component
      *@param None.
      *@return None.
      */
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }


    /**
      *@pre Game is launched.
      *@post Ran first before update. Checks distance an AI from its waypoint and decided which path to follow depending on its distance.
      *@param None.
      *@return None.
      */
    void Start()
    {
        SwitchPoint();
        agent.autoBraking = false;
        //SwitchPoint(distFromFinish);
    }


    /**
      *@pre Game is launched and agents are spawned in.
      *@post Based on the agent's distance, decides which point to travel to. If close to waypoint, goes back to spawn point. If close to spawn point, goes back to waypoint.
      *@param None.
      *@return None.
      */
    void SwitchPoint()
    {
        if (distFromFinish >= 9)
        {
            agent.SetDestination(FinishPoint.transform.position);
        }
        else if (distFromFinish <= 1)
        {
            agent.destination = StartPoint.transform.position;
        }
    }


    /**
      *@pre Called every frame. Requires agents to be spawned in.
      *@post Calls SwitchPoint every frame to check distance. Updates both distance to waypoint and distance to player. If Player comes within an AIs detection radius, AI will follow Player.
      *If player falls outside the radius as it's being chased, AI will resume patrol path.
      *@param None.
      *@return None.
      */
    void Update()
    {
        distFromFinish = (agent.transform.position - FinishPoint.transform.position).magnitude;
        SwitchPoint();
        distanceToPlayer = (agent.transform.position - Player.transform.position).magnitude;

        if (distanceToPlayer <= lookRadius)
        {
            agent.SetDestination(Player.transform.position);
            agent.autoBraking = true;
        }


    }


    /**
      *@pre Agents must be spawned in.
      *@post Draws a red sphere around the AI agents on the Scene to make it easier to see how close a player can get to an AI for testing purposes
      *@param None.
      *@return None.
      */
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

}