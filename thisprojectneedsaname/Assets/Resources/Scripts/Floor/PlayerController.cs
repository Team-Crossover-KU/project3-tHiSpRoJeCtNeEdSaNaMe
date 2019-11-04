using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : Character
{
    // Camera attached to player. Needed for Aiming
    public Camera cam;
    // Value for hover function. Unused Currently
    public int hoverTime = 0;
    // Value for jumping, 1 allows for no air jumps
    int jumpsRemaining;
    // Force upwards used for jumping
    public float jumpForce = 10.0f;

    private float rightLeftPrior = 0;
    private float forwardBackPrior = 0;
    private float jumpPrior = 0;
    private float firePrior = 0;
    private float altFirePrior = 0;
    private float aimPrior = 0;
    private float selectWeaponBackPrior = 0;
    private float selectWeaponForwardPrior = 0;
    private float selectPrior = 0;
    private float submitPrior = 0;
    private float reloadPrior = 0;
    public int rightLeftHeld = 0;
    public int forwardBackHeld = 0;
    public int jumpHeld = 0;
    public int fireHeld = 0;
    public int altFireHeld = 0;
    public int aimHeld = 0;
    public int reloadHeld = 0;
    public int selectWeaponBackHeld = 0;
    public int selectWeaponForwardHeld = 0;
    public int selectHeld = 0;
    public int submitHeld = 0;

    // If the player is on the ground
    public bool grounded = true;

    //If the player is currently holding the fire button
    public bool holdFire = false;
    //If the player is currently holding the altFire button
    public bool holdAltFire = false;
    //If the player is currently holding the ADS button
    public bool holdADS = false;
    //If the player is currently holding the holdReload button
    public bool holdReload = false;
    //If the player is currently holding attacking
    public bool attacking = false;
    //If current action can be interupted. Not used currently
    public bool cancelable = true;

    //Timer for cancel mechanics, Not currently used
    public float timeCombo = -1f;
    //Timer for cancel mechanics, Not currently used
    public float timeCancel = -1f;
    //Timer for cancel mechanics, Not currently used
    public int attackState = 0;

    //Switch to control how player swaps between weapons
    public int weaponStyle;
    //Weapon player is currently using
    public Receiver equipedWeapon;
    //Starting Receiver of player/ first weapon
    public Receiver defaultWeapon;
    //Second Receiver player has equiped
    public Receiver secondWeapon;
    //Third Receiver player has equiped
    public Receiver thirdWeapon;

    // Text for use with UI. Not currently Used.
    public Text TimeComboUI;
    // Text for use with UI. Not currently Used.
    public Text TimeCancelUI;
    // Text for use with UI. Not currently Used.
    public Text attackStateUI;
    // Text for use with UI. Not currently Used.
    public Text PlayerHealthUI;
    // Text for use with UI. Not currently Used.
    public Text WeaponTextUI;

    // Timer for time player is unable to be hurt after taking damage
    public int iFrames;

    // Use this for initialization
    public override void Start()
    {
        base.Start();
        base.Start();
        jumpsRemaining = maxJump;
        rb = this.GetComponent("Rigidbody") as Rigidbody;
        tr = this.GetComponent("Transform") as Transform;
        //TimeComboUI.text = "ComboTime: " + timeCombo.ToString();
        //TimeCancelUI.text = "CancelTime: " + timeCancel.ToString();
        //attackStateUI.text = "AttackState: " + attackState.ToString();
        if (defaultWeapon != null)
        {
            equipedWeapon = defaultWeapon;
        }
        if (secondWeapon == null)
        {
            secondWeapon = defaultWeapon;
        }
        if (thirdWeapon == null)
        {
            thirdWeapon = defaultWeapon;
        }
    }

    /**
   * @pre: N/A.
   * @post: Player input should be parsed.
   * @param: None.
   * @return: None.
   */
    public override void Update()
    {
        base.Update();
        HeldCheck();
        Attack();
        WeaponSelect();
        Invulnerability();
        if (hoverTime == 0)
        {
            Hover(false, false, 0);
        }
        else
        {
            hoverTime--;
        }

        if (timeCancel > 0)
        {
            timeCancel--;
        }
        else
        {
            timeCancel = -1;
            cancelable = true;
        }


        if (timeCombo > 0)
        {
            timeCombo--;
        }
        else
        {
            timeCombo = -1f;
            attacking = false;
        }


        if (!attacking)
        {
            Jump();
            GravControl();
        }
        

    }

    /**
   * @pre: N/A.
   * @post: {hysics related requirements should be parsed.
   * @param: None.
   * @return: None.
   */
    public override void FixedUpdate()
    {
        base.FixedUpdate();
        Look();
        Movement(Input.GetAxisRaw("ForwardBack") * speed, Input.GetAxisRaw("RightLeft") * speed);
        // Check for movement and facing direction
        if (!grounded)
        {
            rb.AddForce(Physics.gravity * 2);

        }
        
    }

    /**
   * @pre: All slots for the players Receiver's are filled.
   * @post: Player should swap to appropriate item if button to swap Receiver is pressed.
   * @param: None.
   * @return: None.
   */
    void WeaponSelect()
    {
        if (defaultWeapon != null)
        {
            if (weaponStyle == 0)
            {
                if (selectWeaponBackHeld == 0 && selectWeaponForwardHeld == 0)
                {
                    if (
                                    Input.GetAxisRaw("Fire") > 0 ||
                                    Input.GetAxisRaw("AltFire") > 0 ||
                                    Input.GetAxisRaw("ADS") > 0 ||
                                    (Input.GetAxisRaw("SelectWeaponBack") > 0 && equipedWeapon == secondWeapon) ||
                                    (Input.GetAxisRaw("SelectWeaponForward") > 0 && equipedWeapon == thirdWeapon)
                                    )
                    {
                        equipedWeapon = defaultWeapon;
                    }

                    else if (Input.GetAxisRaw("SelectWeaponBack") > 0)
                    {

                        equipedWeapon = secondWeapon;

                    }
                    else if (Input.GetAxisRaw("SelectWeaponForward") > 0)
                    {
                        equipedWeapon = thirdWeapon;
                    }
                }

            }
            else if (weaponStyle == 1)
            {
                if (Input.GetAxisRaw("SelectWeaponBack") > 0)
                {

                    equipedWeapon = secondWeapon;

                }
                else if (Input.GetAxisRaw("SelectWeaponForward") > 0)
                {
                    equipedWeapon = thirdWeapon;
                }
                else
                {
                    equipedWeapon = defaultWeapon;
                }

            }
            else if (weaponStyle == 2)
            {
                if (Input.GetAxisRaw("SelectWeaponBack") > 0 && selectWeaponBackHeld == 0)
                {
                    if (equipedWeapon == defaultWeapon)
                    {
                        equipedWeapon = thirdWeapon;
                    }
                    else if (equipedWeapon == secondWeapon)
                    {
                        equipedWeapon = defaultWeapon;
                    }
                    else
                    {
                        equipedWeapon = secondWeapon;
                    }
                }
                if (Input.GetAxisRaw("SelectWeaponForward") > 0 && selectWeaponForwardHeld == 0)
                {
                    if (equipedWeapon == defaultWeapon)
                    {
                        equipedWeapon = secondWeapon;
                    }
                    else if (equipedWeapon == secondWeapon)
                    {
                        equipedWeapon = thirdWeapon;
                    }
                    else
                    {
                        equipedWeapon = defaultWeapon;
                    }
                }

               
            }
            //if (equipedWeapon.title != null)
               // WeaponTextUI.text = equipedWeapon.title;

        }
    }

    /**
   * @pre: N/A.
   * @post: Commands relating to equiped Receiver should be parsed.
   * @param: None.
   * @return: None.
   */
    void Attack()
    {
        if (defaultWeapon != null)
        {


            if (Input.GetAxisRaw("Fire") == 1 && fireHeld == 0)
            {
                Debug.Log(transform.rotation);
                // Quaternion derp = Quaternion.Euler(0, transform.rotation.y, 0);
                Quaternion derp = Quaternion.Euler(cam.transform.eulerAngles.x, transform.eulerAngles.y, 0);
                equipedWeapon.Fire(transform.position, derp);
            }
            else if (Input.GetAxisRaw("Fire") == 1 && fireHeld != 0)
            {
                Quaternion derp = Quaternion.Euler(cam.transform.eulerAngles.x, transform.eulerAngles.y, 0);
                equipedWeapon.HoldFire(transform.position, derp);
                holdFire = true;
                
            }
            else if (Input.GetAxisRaw("Fire") == 0 && holdFire)
            {
                equipedWeapon.ReleaseHoldFire();
                holdFire = false;
            }

            if (Input.GetAxisRaw("AltFire") == 1 && altFireHeld == 0)
            {

                equipedWeapon.AltFire();
            }

            if (Input.GetAxisRaw("ADS") == 1 && aimHeld == 0)
            {
                equipedWeapon.ADS();
            }

            if (Input.GetAxisRaw("Reload") == 1 && reloadHeld == 0)
            {
                equipedWeapon.ReloadMag();
            }


        }
        
    }

    /**
   * @pre: N/A.
   * @post: None currently. When implemented should allow for attacks to interupt eachother
   * @param: None.
   * @return: None.
   */
    public void Interupt()
    {
        if (defaultWeapon != null)
        {
           // defaultWeapon.Interupt();
           // secondWeapon.Interupt();
            //thirdWeapon.Interupt();
        }

    }

    /**
   * @pre: N/A.
   * @post: Resets players jumps when touching the ground or an enemy. Jump on enemies heads for style.
   * @param: None.
   * @return: None.
   */
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Hostile")
        {
            jumpsRemaining = maxJump;
            grounded = true;
        }
    }

    /**
   * @pre: N/A.
   * @post: if player has jumps left, should be sent upwards.
   * @param: None.
   * @return: None.
   */
    void Jump()
    {
        if (Input.GetAxis("Jump") > 0 && jumpHeld == 0)
        {
            if (jumpsRemaining > 0)
            {
                rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
                rb.AddForce(new Vector3(0, jumpForce ,0));
                grounded = false;
                jumpsRemaining--;
            }
        }
    }

    /**
   * @pre: N/A.
   * @post: Not currently implemented. After implementation should change player fall speed based on input
   * @param: None.
   * @return: None.
   */
    void GravControl()
    {
        if (Input.GetAxisRaw("Jump") < 0)
        {
           // rb.gravityScale = gravFast;
        }

        else if (Input.GetAxisRaw("Jump") > 0)
        {
            //rb.gravityScale = gravSlowed;
        }

        else
        {
           // rb.gravityScale = gravNormal;
        }
    }


    /**
   * @pre: N/A.
   * @post: Player's movement should be realitive to where they are looking.
   * @param: forwardBack and leftRight are how far forward and left the player should move.
   * @return: None.
   */
    public void Movement(float forwardBack, float leftRight)
    {
        rb.velocity = new Quaternion(0,rb.rotation.y,0,rb.rotation.w) * new Vector3(leftRight, rb.velocity.y, forwardBack);
    }

    /**
   * @pre: N/A.
   * @post: Player should look following the mouse.
   * @param: None.
   * @return: None.
   */
    public void Look()
    {
        //Debug.Log(Input.GetAxis("Mouse X"));
        transform.Rotate(0, Input.GetAxis("Mouse X"), 0);
        cam.transform.Rotate(-Input.GetAxis("Mouse Y"), 0, 0);
    }

    /**
   * @pre: N/A.
   * @post: Not yet implemented. Once implemented should teleport player to area described
   * @param: pos is area to teleport to.
   * @return: None.
   */
    public void Teleport(Vector3 pos)
    {
        
    }

    /**
   * @pre: N/A.
   * @post: Not yet implemented. Once implemented should let player hover in air for a second
   * @param: ground is if player is on the ground, onOrOff should control if you are currently hovering, time should be how long the hover lasts.
   * @return: None.
   */
    public void Hover(bool ground, bool onOrOff, int time)
    {
        /*
        if (onOrOff)
        {
            rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
            hoverTime = time;
        }
        else
        {
            rb.constraints = RigidbodyConstraints.FreezeRotation;
            hoverTime = 0;
        }
        */
    }

    /**
   * @pre: N/A.
   * @post: Variables for checking if a button is held should be updated
   * @param: None.
   * @return: None.
   */
    public void HeldCheck()
    {
        if (rightLeftPrior == Input.GetAxisRaw("RightLeft") && rightLeftPrior != 0)
        {
            rightLeftHeld = rightLeftHeld + 1;
        }
        else
        {
            rightLeftHeld = 0;
        }

        if (forwardBackPrior == Input.GetAxisRaw("ForwardBack") && forwardBackPrior != 0)
        {
            forwardBackHeld = forwardBackHeld + 1;
        }
        else
        {
            forwardBackHeld = 0;
        }

        if (jumpPrior == Input.GetAxisRaw("Jump") && jumpPrior != 0)
        {
            jumpHeld = jumpHeld + 1;
        }
        else
        {
            jumpHeld = 0;
        }

        if (firePrior == Input.GetAxisRaw("Fire") && firePrior != 0)
        {
            fireHeld = fireHeld + 1;
        }
        else
        {
            fireHeld = 0;
        }

        if (altFirePrior == Input.GetAxisRaw("AltFire") && altFirePrior != 0)
        {
            altFireHeld = altFireHeld + 1;
        }
        else
        {
            altFireHeld = 0;
        }

        if (reloadPrior == Input.GetAxisRaw("Reload") && reloadPrior != 0)
        {
            reloadHeld = reloadHeld + 1;
        }
        else
        {
            reloadHeld = 0;
        }

        if (aimPrior == Input.GetAxisRaw("ADS") && aimPrior != 0)
        {
            aimHeld = aimHeld + 1;
        }
        else
        {
            aimHeld = 0;
        }

        if (selectWeaponBackPrior == Input.GetAxisRaw("SelectWeaponBack") && selectWeaponBackPrior != 0)
        {
            selectWeaponBackHeld = selectWeaponBackHeld + 1;
        }
        else
        {
            selectWeaponBackHeld = 0;
        }

        if (selectWeaponForwardPrior == Input.GetAxisRaw("SelectWeaponForward") && selectWeaponForwardPrior != 0)
        {
            selectWeaponForwardHeld = selectWeaponForwardHeld + 1;
        }
        else
        {
            selectWeaponForwardHeld = 0;
        }

        if (selectPrior == Input.GetAxisRaw("Select") && selectPrior != 0)
        {
            selectHeld = selectHeld + 1;
        }
        else
        {
            selectHeld = 0;
        }

        if (submitPrior == Input.GetAxisRaw("Submit") && submitPrior != 0)
        {
            submitHeld = submitHeld + 1;
        }
        else
        {
            submitHeld = 0;
        }

        rightLeftPrior = Input.GetAxisRaw("RightLeft");
        forwardBackPrior = Input.GetAxisRaw("ForwardBack");
        jumpPrior = Input.GetAxisRaw("Jump");
        firePrior = Input.GetAxisRaw("Fire");
        altFirePrior = Input.GetAxisRaw("AltFire");
        aimPrior = Input.GetAxisRaw("ADS");
        reloadPrior = Input.GetAxisRaw("Reload");
        selectWeaponBackPrior = Input.GetAxisRaw("SelectWeaponBack");
        selectWeaponForwardPrior = Input.GetAxisRaw("SelectWeaponForward");
        selectPrior = Input.GetAxisRaw("Select");
        submitPrior = Input.GetAxisRaw("Submit");

    }

    /**
   * @pre: N/A.
   * @post: Not yet implemented. Once implemented should pickup item collided with
   * @param: other object hit.
   * @return: None.
   */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PickUp")
        {
            collision.gameObject.transform.parent = tr;
           // collision.gameObject.GetComponent<Receiver>().PickUp();
        }

    }

    /**
   * @pre: N/A.
   * @post: Change current default Receiver to the input
   * @param: derp is new default Weapon.
   * @return: None.
   */
    public void Equip(Receiver derp)
    {
        if (defaultWeapon == null)
        {
            defaultWeapon = derp;
            secondWeapon = derp;
            thirdWeapon = derp;
            equipedWeapon = derp;
        }
        else if (defaultWeapon == secondWeapon)
        {
            secondWeapon = derp;
        }
        else if (defaultWeapon == thirdWeapon)
        {
            thirdWeapon = derp;
        }
    }

    /**
   * @pre: N/A.
   * @post: Adds input to player health value as long as the player is not invulnerable
   * @param: change is value to be added to health.
   * @return: None.
   */
    public override void ChangeHealth(float change)
    {
        if (iFrames <= 0)
        {
            if (health + change < 0)
            {
                health = 0;
                iFrames = 50;
            }

            else
            {
                health = health + change;
                iFrames = 50;
            }
        }
    }

    /**
   * @pre: N/A.
   * @post: Adds input to player health value as long as the player is not invulnerable
   * @param: change is value to be added to health, saving frames is time the player is invulnerable after health is changed.
   * @return: None.
   */
    public virtual void ChangeHealth(float change, int savingFrames)
    {
        if (iFrames <= 0)
        {
            if (health + change < 0)
            {
                health = 0;
                iFrames = savingFrames;
            }

            else
            {
                health = health + change;
                iFrames = savingFrames;
            }
        }

    }

    /**
   * @pre: N/A.
   * @post: Subtracts timer for player's invulnerable status
   * @param: None.
   * @return: None.
   */
    public virtual void Invulnerability()
    {
        if (iFrames > 0)
        {
            iFrames--;
        }      
    }



}


/*
 * public void lockOn()
    {
       
        if (Input.GetKeyDown(KeyCode.E))
        {

            RaycastHit2D hit;

            if (lockOnTarget != null)
            {
                lockOnTarget = null;
            }


            else if (facingRight)
            {
                Debug.Log("Fire Right");
                for (float x = -0.523599f; x < 0.523599f; x = x + 0.0174533f)
                {
                    hit = Physics2D.Raycast(transform.position, angleVector((x), 5f), 20f, lockOnAble);
                    if (hit.collider != null)
                    {
                        lockOnTarget = hit.transform.gameObject;
                        break;
                    }
                }
                
            }

            else if (!facingRight)
            {
                Debug.Log("Fire Left");
                for (float x = 2.61799f; x < 3.66519f; x = x + 0.0174533f)
                {
                    hit = Physics2D.Raycast(transform.position, angleVector((x), 5f), 20f, lockOnAble);
                    if (hit.collider != null)
                    {
                        lockOnTarget = hit.transform.gameObject;
                        break;
                    }
                }
            }

          
            else
            {

            }

           
        }

        if (lockOnTarget != null)
        {
            lockOnSign.transform.position = lockOnPos;
            lockOnSign.GetComponent<SpriteRenderer>().enabled = true;
            LockOnHealthUI.text = "HostileHealth: " + lockOnTarget.GetComponent<HostileController>().health;
        }
        else
        {
            lockOnSign.GetComponent<SpriteRenderer>().enabled = false;
        }
        
    }

    //For lockon-facing
     {
                lockOnPos = lockOnTarget.GetComponent<Transform>().position;
                if (rb.transform.position.x < lockOnPos.x && !facingRight)
                {
                    changeFacingDirection();
                }
                else if (rb.transform.position.x > lockOnPos.x && facingRight)
                {
                    changeFacingDirection();
                }
            }
 */
