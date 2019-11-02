using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerNav : MonoBehaviour
{
    private NavMeshAgent navAgent;

    public GameObject TargetObject;
    void Awake()
    {
        navAgent = GetComponent<NavMeshAgent>();
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
        if(navAgent.transform.position != TargetObject.transform.position)
        {
            navAgent.SetDestination(TargetObject.transform.position);
        }
        
    }
    
}
