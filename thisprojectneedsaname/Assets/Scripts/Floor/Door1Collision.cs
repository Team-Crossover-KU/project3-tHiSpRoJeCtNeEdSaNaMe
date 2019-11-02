using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door1Collision : MonoBehaviour
{
    public bool enter = true;
    public bool stay = true;
    public bool exit = true;
    public float moveSpeed;
    public GameObject CombatFloor;
    public GameObject RestroomFloor;
   
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
        if(other.tag == "Player")
        {
            var RfloorRenderer = RestroomFloor.GetComponent<Renderer>();
            RfloorRenderer.material.SetColor("_Color", Color.black);
        }

    }
}
