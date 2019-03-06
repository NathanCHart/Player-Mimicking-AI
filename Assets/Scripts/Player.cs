using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public GameObject player;
	public GameObject enemy;
    public Rigidbody2D rgbd;
    public Animator ryu;
    public CapsuleCollider2D capsule;
    public float speed;
    public float jumpSpeed = 0.1f;
    public float gravity = 5.0f;
    private Vector3 moveDirection = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        rgbd = GetComponent<Rigidbody2D>();
        ryu.GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveX();
        Jump();
        Crouch();
        LPunch();
        MHPunch();
        HKick();
        LMKick();
        CLKick();
        CLPunch();
        CMKick();
        CMPunch();
        CHKick();
        CHPunch();
        FLPunch();
        FLKick();
        FMKick();
        FMPunch();
        FHKick();
        FHPunch();
    }

    void MoveX()
    {
        //Store the current horizontal input in the float moveHorizontal.
        float moveHorizontal = Input.GetAxis("Horizontal");
        //Use the two store floats to create a new Vector2 variable movement.
        Vector2 movement = new Vector2(moveHorizontal, 0.0f);
        speed = 9.0f;
        ryu.SetFloat("Speed", moveHorizontal);
        //Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
        rgbd.AddForce(movement * speed);
    }

    void Jump()
    {

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            ryu.SetTrigger("Jump");
            rgbd.AddForce(new Vector2(0, 7.5f), ForceMode2D.Impulse);
        }
    }
    void Crouch()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            ryu.SetBool("Crouch", true);
            ryu.SetBool("Idle", false);
            capsule.size = new Vector2(0.43f, 0.581f);

        }
        else if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S))
        {
            ryu.SetBool("Crouch", false);
            ryu.SetBool("Idle", true);
            capsule.size = new Vector2(0.43f, 0.81f);
        }
    }
    void LPunch()
    {

        if (Input.GetKeyDown(KeyCode.U) && ryu.GetBool("Crouch").Equals(false) && ryu.GetFloat("Speed").Equals(0.0f))
        {
            ryu.SetTrigger("LPunch");
            speed = 0.0f;
        }
    }
    void LMKick()
    {

        if ((Input.GetKeyDown(KeyCode.H) || Input.GetKeyDown(KeyCode.J)) && ryu.GetBool("Crouch").Equals(false) && ryu.GetFloat("Speed").Equals(0.0f))
        {
            ryu.SetTrigger("LMKick");
            speed = 0.0f;
        }
    }
    void MHPunch()
    {

        if ((Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown(KeyCode.O)) && ryu.GetBool("Crouch").Equals(false) && ryu.GetFloat("Speed").Equals(0.0f))
        {
            ryu.SetTrigger("MHPunch");
            speed = 0.0f;
        }
    }
    void HKick()
    {

        if (Input.GetKeyDown(KeyCode.K) && ryu.GetBool("Crouch").Equals(false) && ryu.GetFloat("Speed").Equals(0.0f))
        {
            ryu.SetTrigger("HKick");
            speed = 0.0f;
        }
    }
    void CLPunch()
    {

        if (Input.GetKeyDown(KeyCode.U) && ryu.GetBool("Crouch").Equals(true))
        {
            ryu.SetTrigger("CLPunch");
        }
    }
    void CHKick()
    {

        if (Input.GetKeyDown(KeyCode.K) && ryu.GetBool("Crouch").Equals(true))
        {
            ryu.SetTrigger("CHKick");
        }
    }
    void CLKick()
    {

        if (Input.GetKeyDown(KeyCode.H) && ryu.GetBool("Crouch").Equals(true))
        {
            ryu.SetTrigger("CLKick");
        }
    }
    void CMPunch()
    {

        if (Input.GetKeyDown(KeyCode.I) && ryu.GetBool("Crouch").Equals(true))
        {
            ryu.SetTrigger("CMPunch");
        }
    }
    void CMKick()
    {

        if (Input.GetKeyDown(KeyCode.J) && ryu.GetBool("Crouch").Equals(true))
        {
            ryu.SetTrigger("CMKick");
        }
    }
    void CHPunch()
    {

        if (Input.GetKeyDown(KeyCode.O) && ryu.GetBool("Crouch").Equals(true))
        {
            ryu.SetTrigger("CHPunch");
        }
    }
    void FLPunch()
    {
        if (Input.GetKeyDown(KeyCode.U) && (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow) || ryu.GetFloat("Speed").Equals(1.0f)))
        {
            speed = 0.0f;
            ryu.SetTrigger("FLPunch");
        }
    }
    void FLKick()
    {
        if (Input.GetKeyDown(KeyCode.H) && (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow) || ryu.GetFloat("Speed").Equals(1.0f)))
        {
            ryu.SetTrigger("FLKick");
            speed = 0.0f;
        }
    }
    void FMKick()
    {
        if (Input.GetKeyDown(KeyCode.J) && (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow) || ryu.GetFloat("Speed").Equals(1.0f)))
        {
            ryu.SetTrigger("FMPunch");
            speed = 0.0f;
        }
    }
    void FMPunch()
    {
        if (Input.GetKeyDown(KeyCode.I) && (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow) || ryu.GetFloat("Speed").Equals(1.0f)))
        {
            ryu.SetTrigger("FMKick");
            speed = 0.0f;
        }
    }
    void FHPunch()
    {
        if (Input.GetKeyDown(KeyCode.O) && (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow) || ryu.GetFloat("Speed").Equals(1.0f)))
        {
            ryu.SetTrigger("FHPunch");
            speed = 0.0f;
        }
    }
    void FHKick()
    {
        if (Input.GetKeyDown(KeyCode.K) && (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow) || ryu.GetFloat("Speed").Equals(1.0f)))
        {
            ryu.SetTrigger("FHKick");
            speed = 0.0f;
        }
    }
}

