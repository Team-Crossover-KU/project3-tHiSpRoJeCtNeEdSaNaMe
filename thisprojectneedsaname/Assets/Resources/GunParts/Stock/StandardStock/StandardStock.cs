using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardStock : Stock
{
    //Modifier for Receiver this is attached to
    float recoilMod = 1.5f;

    // Start is called before the first frame update
    public override void Start()
    {
        
    }

    // Update is called once per frame
    public override void Update()
    {
        
    }
    
    /**
   * @pre: N/A.
   * @post: Nothing for now. Later will jostile player vision
   * @param: None.
   * @return: None.
   */
    public override void Recoil()
    {
        
    }

    /**
   * @pre: N/A.
   * @post: returns recoilMod for stat calc
   * @param: None.
   * @return: recoilMod.
   */
    public override float GetRecoilMod()
    {
        return recoilMod;
    }
    /**
   * @pre: N/A.
   * @post: changes Recoilmod to input
   * @param: new value for recoil mod.
   * @return: None.
   */
    public override void SetRecoilMod(float newMod)
    {
        recoilMod = newMod;
    }

}
