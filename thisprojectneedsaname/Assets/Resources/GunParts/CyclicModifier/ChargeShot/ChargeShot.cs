using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeShot : CyclicModifier
{
    //fireRateMod for calculating stats
    public float fireRateMod = 1;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    /**
   * @pre: N/A.
   * @post: Returns fireRateMod.
   * @param: None.
   * @return: fireRateMod.
   */
    public override float GetFireRateMod()
    {
        return fireRateMod;
    }

    /**
   * @pre: N/A.
   * @post: A stub until changed to a charge shot. Constantly attempts to fire the receiver as if the user was pulling the trigger every .02 seconds. Also reduces hand cramps.
   * @param: None.
   * @return: None.
   */
    public override void HoldFire(Vector3 position, Quaternion angle)
    {
        receiver.Fire(position, angle);
    }

    /**
   * @pre: N/A.
   * @post: Displays debug message.
   * @param: None.
   * @return: None.
   */
    public override void ReleaseHoldFire()
    {
        Debug.Log("Release");
    }
}
