using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public GameObject player;
	public GameObject enemy;
    public Rigidbody2D rgbd;
    public Animator ryu;
    public Animator enemyAnim;
    public AnimatorClipInfo[] enemyClipInfo;
    string enemyAnimName;
    public CapsuleCollider2D capsule;
    public float speed;
    public float jumpSpeed = 0.1f;
    public float gravity = 5.0f;
    public float distance;
    private Vector3 moveDirection = Vector3.zero;
    public Record inputRecorder = new Record();
    public SpriteRenderer playerSprite;
    public BoxCollider2D bc2d;

    // Start is called before the first frame update
    void Start()
    {
        rgbd.GetComponent<Rigidbody2D>();
        ryu.GetComponent<Animator>();
        enemyAnim.GetComponent<Animator>();
        bc2d.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Input.anyKey)
        {
            ryu.SetBool("Idle", true);
        }

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
        FLJumpPunch();
        FMHJumpPunch();
        HJumpKick();
        LMHJumpPunch();
        LMJumpKick();
        FBlock();

        distance = enemy.transform.position.x - player.transform.position.x;
        if (distance > 0.46f)
        {
            player.transform.localScale = new Vector3(1, 1, 1);
        }
        else if (distance < -0.42f)
        {
            player.transform.localScale = new Vector3(-1, 1, 1);

        }
    }

    void MoveX()
    {
        if (!ryu.GetBool("StandBlock"))
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
    }

    void FBlock()
    {
        if (Input.GetKeyDown(KeyCode.A) && (distance < 0.48) && (distance > 0.45))
        {
            ryu.SetBool("StandBlock", true);
            inputRecorder.WriteDistance(distance);
            inputRecorder.WritePlayer("StandBlock");
            enemyClipInfo = enemyAnim.GetCurrentAnimatorClipInfo(0);
            enemyAnimName = enemyClipInfo[0].clip.name;
            inputRecorder.WriteEnemy(enemyAnimName);
        }
        else if (Input.GetKeyDown(KeyCode.D) && (distance < -0.45) && (distance > -0.48))
        {
            ryu.SetBool("StandBlock", true);
            inputRecorder.WriteDistance(distance);
            inputRecorder.WritePlayer("StandBlock");
            enemyClipInfo = enemyAnim.GetCurrentAnimatorClipInfo(0);
            enemyAnimName = enemyClipInfo[0].clip.name;
            inputRecorder.WriteEnemy(enemyAnimName);
        }
        else
        {
            ryu.SetBool("StandBlock", false);
        }
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            ryu.SetTrigger("Jump");
            rgbd.AddForce(new Vector2(0, 7.7f), ForceMode2D.Impulse);
            distance = enemy.transform.position.x - player.transform.position.x;
            inputRecorder.WriteDistance(distance);
            inputRecorder.WritePlayer("Jump");
            enemyClipInfo = enemyAnim.GetCurrentAnimatorClipInfo(0);
            enemyAnimName = enemyClipInfo[0].clip.name;
            inputRecorder.WriteEnemy(enemyAnimName);
        }
    }
    void Crouch()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            ryu.SetBool("Crouch", true);
            ryu.SetBool("Idle", false);
            capsule.size = new Vector2(0.43f, 0.581f);
            inputRecorder.WritePlayer("Crouch");
            distance = enemy.transform.position.x - player.transform.position.x;
            inputRecorder.WriteDistance(distance);
            enemyClipInfo = enemyAnim.GetCurrentAnimatorClipInfo(0);
            enemyAnimName = enemyClipInfo[0].clip.name;
            inputRecorder.WriteEnemy(enemyAnimName);
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S))
        {
            ryu.SetBool("Crouch", false);
            ryu.SetBool("Idle", true);
            capsule.size = new Vector2(0.43f, 0.81f);
            inputRecorder.WritePlayer("Idle");
            distance = enemy.transform.position.x - player.transform.position.x;
            inputRecorder.WriteDistance(distance);
            enemyClipInfo = enemyAnim.GetCurrentAnimatorClipInfo(0);
            enemyAnimName = enemyClipInfo[0].clip.name;
            inputRecorder.WriteEnemy(enemyAnimName);
        }
    }
    void LPunch()
    {

        if (Input.GetKeyDown(KeyCode.U) && ryu.GetBool("Crouch").Equals(false) && ryu.GetFloat("Speed").Equals(0.0f))
        {
            rgbd.velocity = new Vector2(0.0f, 0.0f);
            ryu.SetTrigger("LPunch");
            speed = 0.0f;
            inputRecorder.WritePlayer("LPunch");
            distance = enemy.transform.position.x - player.transform.position.x;
            inputRecorder.WriteDistance(distance);
            enemyClipInfo = enemyAnim.GetCurrentAnimatorClipInfo(0);
            enemyAnimName = enemyClipInfo[0].clip.name;
            inputRecorder.WriteEnemy(enemyAnimName);
        }
    }
    void LMKick()
    {

        if ((Input.GetKeyDown(KeyCode.H) || Input.GetKeyDown(KeyCode.J)) && ryu.GetBool("Crouch").Equals(false) && ryu.GetFloat("Speed").Equals(0.0f))
        {
            rgbd.velocity = new Vector2(0.0f, 0.0f);
            ryu.SetTrigger("LMKick");
            speed = 0.0f;
            inputRecorder.WritePlayer("LMKick");
            distance = enemy.transform.position.x - player.transform.position.x;
            inputRecorder.WriteDistance(distance);
            enemyClipInfo = enemyAnim.GetCurrentAnimatorClipInfo(0);
            enemyAnimName = enemyClipInfo[0].clip.name;
            inputRecorder.WriteEnemy(enemyAnimName);
        }
    }
    void MHPunch()
    {

        if ((Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown(KeyCode.O)) && ryu.GetBool("Crouch").Equals(false) && ryu.GetFloat("Speed").Equals(0.0f))
        {
            rgbd.velocity = new Vector2(0.0f, 0.0f);
            ryu.SetTrigger("MHPunch");
            inputRecorder.WritePlayer("MHPunch");
            distance = enemy.transform.position.x - player.transform.position.x;
            inputRecorder.WriteDistance(distance);
            speed = 0.0f;
            enemyClipInfo = enemyAnim.GetCurrentAnimatorClipInfo(0);
            enemyAnimName = enemyClipInfo[0].clip.name;
            inputRecorder.WriteEnemy(enemyAnimName);
        }
    }
    void HKick()
    {

        if (Input.GetKeyDown(KeyCode.K) && ryu.GetBool("Crouch").Equals(false) && ryu.GetFloat("Speed").Equals(0.0f))
        {
            rgbd.velocity = new Vector2(0.0f, 0.0f);
            ryu.SetTrigger("HKick");
            inputRecorder.WritePlayer("HKick");
            distance = enemy.transform.position.x - player.transform.position.x;
            inputRecorder.WriteDistance(distance);
            speed = 0.0f;
            enemyClipInfo = enemyAnim.GetCurrentAnimatorClipInfo(0);
            enemyAnimName = enemyClipInfo[0].clip.name;
            inputRecorder.WriteEnemy(enemyAnimName);
        }
    }
    void CLPunch()
    {

        if (Input.GetKeyDown(KeyCode.U) && ryu.GetBool("Crouch").Equals(true))
        {
            rgbd.velocity = new Vector2(0.0f, 0.0f);
            ryu.SetTrigger("CLPunch");
            inputRecorder.WritePlayer("CLPunch");
            distance = enemy.transform.position.x - player.transform.position.x;
            inputRecorder.WriteDistance(distance);
            enemyClipInfo = enemyAnim.GetCurrentAnimatorClipInfo(0);
            enemyAnimName = enemyClipInfo[0].clip.name;
            inputRecorder.WriteEnemy(enemyAnimName);
        }
    }
    void CHKick()
    {

        if (Input.GetKeyDown(KeyCode.K) && ryu.GetBool("Crouch").Equals(true))
        {
            rgbd.velocity = new Vector2(0.0f, 0.0f);
            ryu.SetTrigger("CHKick");
            inputRecorder.WritePlayer("CHKick");
            distance = enemy.transform.position.x - player.transform.position.x;
            inputRecorder.WriteDistance(distance);
            enemyClipInfo = enemyAnim.GetCurrentAnimatorClipInfo(0);
            enemyAnimName = enemyClipInfo[0].clip.name;
            inputRecorder.WriteEnemy(enemyAnimName);
        }
    }
    void CLKick()
    {

        if (Input.GetKeyDown(KeyCode.H) && ryu.GetBool("Crouch").Equals(true))
        {
            rgbd.velocity = new Vector2(0.0f, 0.0f);
            ryu.SetTrigger("CLKick");
            inputRecorder.WritePlayer("CLKick");
            distance = enemy.transform.position.x - player.transform.position.x;
            inputRecorder.WriteDistance(distance);
            enemyClipInfo = enemyAnim.GetCurrentAnimatorClipInfo(0);
            enemyAnimName = enemyClipInfo[0].clip.name;
            inputRecorder.WriteEnemy(enemyAnimName);
        }
    }
    void CMPunch()
    {

        if (Input.GetKeyDown(KeyCode.I) && ryu.GetBool("Crouch").Equals(true))
        {
            rgbd.velocity = new Vector2(0.0f, 0.0f);
            ryu.SetTrigger("CMPunch");
            inputRecorder.WritePlayer("CMPunch");
            distance = enemy.transform.position.x - player.transform.position.x;
            inputRecorder.WriteDistance(distance);
            enemyClipInfo = enemyAnim.GetCurrentAnimatorClipInfo(0);
            enemyAnimName = enemyClipInfo[0].clip.name;
            inputRecorder.WriteEnemy(enemyAnimName);
        }
    }
    void CMKick()
    {

        if (Input.GetKeyDown(KeyCode.J) && ryu.GetBool("Crouch").Equals(true))
        {
            rgbd.velocity = new Vector2(0.0f, 0.0f);
            ryu.SetTrigger("CMKick");
            inputRecorder.WritePlayer("CMKick");
            distance = enemy.transform.position.x - player.transform.position.x;
            inputRecorder.WriteDistance(distance);
            enemyClipInfo = enemyAnim.GetCurrentAnimatorClipInfo(0);
            enemyAnimName = enemyClipInfo[0].clip.name;
            inputRecorder.WriteEnemy(enemyAnimName);
        }
    }
    void CHPunch()
    {

        if (Input.GetKeyDown(KeyCode.O) && ryu.GetBool("Crouch").Equals(true))
        {
            rgbd.velocity = new Vector2(0.0f, 0.0f);
            ryu.SetTrigger("CHPunch");
            inputRecorder.WritePlayer("CHPunch");
            distance = enemy.transform.position.x - player.transform.position.x;
            inputRecorder.WriteDistance(distance);
            enemyClipInfo = enemyAnim.GetCurrentAnimatorClipInfo(0);
            enemyAnimName = enemyClipInfo[0].clip.name;
            inputRecorder.WriteEnemy(enemyAnimName);
        }
    }
    void FLPunch()
    {
        if (Input.GetKeyDown(KeyCode.U) && (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow) || ryu.GetFloat("Speed").Equals(1.0f)))
        {
            rgbd.velocity = new Vector2(0.0f, 0.0f);
            speed = 0.0f;
            ryu.SetTrigger("FLPunch");
            inputRecorder.WritePlayer("FLPunch");
            distance = enemy.transform.position.x - player.transform.position.x;
            inputRecorder.WriteDistance(distance);
            enemyClipInfo = enemyAnim.GetCurrentAnimatorClipInfo(0);
            enemyAnimName = enemyClipInfo[0].clip.name;
            inputRecorder.WriteEnemy(enemyAnimName);
        }
    }
    void FLKick()
    {
        if (Input.GetKeyDown(KeyCode.H) && (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow) || ryu.GetFloat("Speed").Equals(1.0f)))
        {
            rgbd.velocity = new Vector2(0.0f, 0.0f);
            ryu.SetTrigger("FLKick");
            inputRecorder.WritePlayer("FLKick");
            distance = enemy.transform.position.x - player.transform.position.x;
            inputRecorder.WriteDistance(distance);
            speed = 0.0f;
            enemyClipInfo = enemyAnim.GetCurrentAnimatorClipInfo(0);
            enemyAnimName = enemyClipInfo[0].clip.name;
            inputRecorder.WriteEnemy(enemyAnimName);
        }
    }
    void FMKick()
    {
        if (Input.GetKeyDown(KeyCode.J) && (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow) || ryu.GetFloat("Speed").Equals(1.0f)))
        {
            rgbd.velocity = new Vector2(0.0f, 0.0f);
            ryu.SetTrigger("FMKick");
            inputRecorder.WritePlayer("FMKick");
            distance = enemy.transform.position.x - player.transform.position.x;
            inputRecorder.WriteDistance(distance);
            speed = 0.0f;
            enemyClipInfo = enemyAnim.GetCurrentAnimatorClipInfo(0);
            enemyAnimName = enemyClipInfo[0].clip.name;
            inputRecorder.WriteEnemy(enemyAnimName);
        }
    }
    void FMPunch()
    {
        if (Input.GetKeyDown(KeyCode.I) && (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow) || ryu.GetFloat("Speed").Equals(1.0f)))
        {
            rgbd.velocity = new Vector2(0.0f, 0.0f);
            ryu.SetTrigger("FMPunch");
            inputRecorder.WritePlayer("FMPunch");
            distance = enemy.transform.position.x - player.transform.position.x;
            inputRecorder.WriteDistance(distance);
            speed = 0.0f;
            enemyClipInfo = enemyAnim.GetCurrentAnimatorClipInfo(0);
            enemyAnimName = enemyClipInfo[0].clip.name;
            inputRecorder.WriteEnemy(enemyAnimName);
        }
    }
    void FHPunch()
    {
        if (Input.GetKeyDown(KeyCode.O) && (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow) || ryu.GetFloat("Speed").Equals(1.0f)))
        {
            rgbd.velocity = new Vector2(0.0f, 0.0f);
            ryu.SetTrigger("FHPunch");
            inputRecorder.WritePlayer("FHPunch");
            distance = enemy.transform.position.x - player.transform.position.x;
            inputRecorder.WriteDistance(distance);
            speed = 0.0f;
            enemyClipInfo = enemyAnim.GetCurrentAnimatorClipInfo(0);
            enemyAnimName = enemyClipInfo[0].clip.name;
            inputRecorder.WriteEnemy(enemyAnimName);
        }
    }
    void FHKick()
    {
        if (Input.GetKeyDown(KeyCode.K) && (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow) || ryu.GetFloat("Speed").Equals(1.0f)))
        {
            rgbd.velocity = new Vector2(0.0f, 0.0f);
            ryu.SetTrigger("FHKick");
            inputRecorder.WritePlayer("FHKick");
            distance = enemy.transform.position.x - player.transform.position.x;
            inputRecorder.WriteDistance(distance);
            speed = 0.0f;
            enemyClipInfo = enemyAnim.GetCurrentAnimatorClipInfo(0);
            enemyAnimName = enemyClipInfo[0].clip.name;
            inputRecorder.WriteEnemy(enemyAnimName);
        }
    }
    void FLJumpPunch()
    {
        if ((Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) && Input.GetKeyDown(KeyCode.I) && (player.transform.position.y > (-1.073f)))
        {
            ryu.SetTrigger("FLJumpPunch");
            inputRecorder.WritePlayer("FLJumpPunch");
            distance = enemy.transform.position.x - player.transform.position.x;
            inputRecorder.WriteDistance(distance);
            speed = 0.0f;
            enemyClipInfo = enemyAnim.GetCurrentAnimatorClipInfo(0);
            enemyAnimName = enemyClipInfo[0].clip.name;
            inputRecorder.WriteEnemy(enemyAnimName);
        }
    }
    void FMHJumpPunch()
    {
        if ((Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) && (Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown(KeyCode.O)) && (player.transform.position.y > (-1.073f)))
        {
            ryu.SetTrigger("FMHJumpPunch");
            inputRecorder.WritePlayer("FMHJumpPunch");
            distance = enemy.transform.position.x - player.transform.position.x;
            inputRecorder.WriteDistance(distance);
            speed = 0.0f;
            enemyClipInfo = enemyAnim.GetCurrentAnimatorClipInfo(0);
            enemyAnimName = enemyClipInfo[0].clip.name;
            inputRecorder.WriteEnemy(enemyAnimName);
        }
    }
    void HJumpKick()
    {
        if (Input.GetKeyDown(KeyCode.K) && (player.transform.position.y > (-1.073f)))
        {
            rgbd.velocity = new Vector2(0.0f, 0.0f);
            ryu.SetTrigger("HJumpKick");
            inputRecorder.WritePlayer("HJumpKick");
            distance = enemy.transform.position.x - player.transform.position.x;
            inputRecorder.WriteDistance(distance);
            speed = 0.0f;
            enemyClipInfo = enemyAnim.GetCurrentAnimatorClipInfo(0);
            enemyAnimName = enemyClipInfo[0].clip.name;
            inputRecorder.WriteEnemy(enemyAnimName);
        }
    }
    void LMHJumpPunch()
    {
        if ((Input.GetKeyDown(KeyCode.U) || Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown(KeyCode.O)) && (player.transform.position.y > (-1.073f)))
        {
            rgbd.velocity = new Vector2(0.0f, 0.0f);
            ryu.SetTrigger("LMHJumpPunch");
            inputRecorder.WritePlayer("LMHJumpPunch");
            distance = enemy.transform.position.x - player.transform.position.x;
            inputRecorder.WriteDistance(distance);
            speed = 0.0f;
            enemyClipInfo = enemyAnim.GetCurrentAnimatorClipInfo(0);
            enemyAnimName = enemyClipInfo[0].clip.name;
            inputRecorder.WriteEnemy(enemyAnimName);
        }

    }
    void LMJumpKick()
    {
        if ((Input.GetKeyDown(KeyCode.H) || Input.GetKeyDown(KeyCode.J)) && (player.transform.position.y > (-1.073f)))
        {
            rgbd.velocity = new Vector2 (0.0f,0.0f);
            ryu.SetTrigger("LMJumpKick");
            inputRecorder.WritePlayer("LMJumpKick");
            distance = enemy.transform.position.x - player.transform.position.x;
            inputRecorder.WriteDistance(distance);
            enemyClipInfo = enemyAnim.GetCurrentAnimatorClipInfo(0);
            enemyAnimName = enemyClipInfo[0].clip.name;
            inputRecorder.WriteEnemy(enemyAnimName);
        }
    }
}

