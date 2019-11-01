using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : Character
{
   
    public int hoverTime = 0;
    int jumpsRemaining;
    public float jumpForce = 10.0f;
    public float gravNormal;
    public float gravSlowed;
    public float gravFast;


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
    public int rightLeftHeld = 0;
    public int forwardBackHeld = 0;
    public int jumpHeld = 0;
    public int fireHeld = 0;
    public int altFireHeld = 0;
    public int aimHeld = 0;
    public int selectWeaponBackHeld = 0;
    public int selectWeaponForwardHeld = 0;
    public int selectHeld = 0;
    public int submitHeld = 0;

    public bool grounded = true;

    public bool holdFire = false;
    public bool holdAltFire = false;
    public bool holdADS = false;
    public bool attacking = false;
    public bool cancelable = true;

    public float timeCombo = -1f;
    public float timeCancel = -1f;
    public int attackState = 0;

    public int weaponStyle;
    public Receiver equipedWeapon;
    public Receiver defaultWeapon;
    public Receiver secondWeapon;
    public Receiver thirdWeapon;

    public Text TimeComboUI;
    public Text TimeCancelUI;
    public Text attackStateUI;
    public Text PlayerHealthUI;
    public Text WeaponTextUI;

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

    // Update is called once per frame
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

    //Run physics related stuffs here
    public override void FixedUpdate()
    {
        base.FixedUpdate();
        Movement(Input.GetAxisRaw("ForwardBack") * speed, Input.GetAxisRaw("RightLeft") * speed);
        // Check for movement and facing direction
        if (!grounded)
        {
            rb.AddForce(Physics.gravity * 2);

        }
        
    }

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

    // Calls attack from weapon
    void Attack()
    {
        if (defaultWeapon != null)
        {


            if (Input.GetAxisRaw("Fire") == 1 && fireHeld == 0)
            {
                equipedWeapon.Fire();
            }
            else if (Input.GetAxisRaw("Fire") == 1 && fireHeld != 0)
            {
                equipedWeapon.HoldFire();
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


        }
        
    }

    // Called by weapon to interupt all other attacks
    public void Interupt()
    {
        if (defaultWeapon != null)
        {
           // defaultWeapon.Interupt();
           // secondWeapon.Interupt();
            //thirdWeapon.Interupt();
        }

    }

    // Check for collisions, currently used to check if on the ground.
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Hostile")
        {
            jumpsRemaining = maxJump;
            grounded = true;
        }
    }

    //Adds upwards velocity and sets grounded false.
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

    // Falling speed controls. Lower grav when holding up, visa versa for down
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

    // Call this when you want to change characters facing direction
    // helps to keep model and otherwise setup right.


    public void Movement(float forwardBack, float leftRight)
    {
        rb.velocity = new Quaternion(0,rb.rotation.y,0,rb.rotation.w) * new Vector3(leftRight, rb.velocity.y, forwardBack);
    }

    public void Teleport(float horizontal, float vertical)
    {
        
    }

    public void Hover(bool ground, bool onOrOff, int time)
    {
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
    }

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
        selectWeaponBackPrior = Input.GetAxisRaw("SelectWeaponBack");
        selectWeaponForwardPrior = Input.GetAxisRaw("SelectWeaponForward");
        selectPrior = Input.GetAxisRaw("Select");
        submitPrior = Input.GetAxisRaw("Submit");

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PickUp")
        {
            collision.gameObject.transform.parent = tr;
           // collision.gameObject.GetComponent<Receiver>().PickUp();
        }

    }

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
