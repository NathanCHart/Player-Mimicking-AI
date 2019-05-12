using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class AISearch : MonoBehaviour
{
    public string filePath;
    public List<string> playerIn;
    public List<string> enemyIn;
    public List<float> distanceIn;
    public Animator aiAnim;
    public Rigidbody2D rgbd;
    public GameObject ai;
    public GameObject player;
    public Animator playerAnim;
    public AnimatorClipInfo[] playerClipInfo;
    public string playerAnimName;
    public AnimatorClipInfo[] aiClipInfo;
    public string aiAnimName;
    public float distance;
    public SpriteRenderer aiSprite;
    public BoxCollider2D bc2d;
    public CapsuleCollider2D capsule;

    // Start is called before the first frame update
    void Start()
    {
        bc2d.GetComponent<BoxCollider2D>();
        rgbd.GetComponent<Rigidbody2D>();
        playerIn = ReadPlayer();
        enemyIn = ReadEnemy();
        distanceIn = ReadDistance();

        InvokeRepeating("AIAction", 0.75f, 0.5f);
    }

    private void Update()
    {
        distance = ai.transform.position.x - player.transform.position.x;
        if (distance > 0.56f)
        {
            aiSprite.transform.localScale = new Vector3(-1, 1, 1);

            //Store the current horizontal input in the float moveHorizontal.
            float moveHorizontal = 0.9f;
            //Use the two store floats to create a new Vector2 variable movement.
            Vector2 movement = new Vector2(moveHorizontal, 0.0f);
            float speed = -7.0f;
            aiAnim.SetFloat("Speed", moveHorizontal);
            //Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
            rgbd.AddForce(movement * speed);
        }
        else if (distance < -0.46f)
        {
            aiSprite.transform.localScale = new Vector3(1, 1, 1);

            //Store the current horizontal input in the float moveHorizontal.
            float moveHorizontal = 0.9f;
            //Use the two store floats to create a new Vector2 variable movement.
            Vector2 movement = new Vector2(moveHorizontal, 0.0f);
            float speed = 9.0f;
            aiAnim.SetFloat("Speed", moveHorizontal);
            //Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
            rgbd.AddForce(movement * speed);
        }
        else
        {
            //Store the current horizontal input in the float moveHorizontal.
            float moveHorizontal = 0.0f;
            //Use the two store floats to create a new Vector2 variable movement.
            Vector2 movement = new Vector2(moveHorizontal, 0.0f);
            float speed = -9.0f;
            aiAnim.SetFloat("Speed", moveHorizontal);
            //Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
            rgbd.AddForce(movement * speed);
        }
    }

    [STAThread]
    public List<string> ReadPlayer()
    {
        String line;
        filePath = Application.dataPath + "/PlayerInput.txt";
        try
        {
            //Pass the file path and file name to the StreamReader constructor
            StreamReader sr = new StreamReader(filePath);

            //Read the first line of text
            line = sr.ReadLine();

            //Continue to read until you reach end of file
            while (line != null)
            {
                //write the lie to console window
                playerIn.Add(line);
                //Read the next line
                line = sr.ReadLine();
            }

            //close the file
            sr.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception: " + e.Message);
        }

        return playerIn;
    }

    [STAThread]
    public List<float> ReadDistance()
    {
        string line;
        float dist;

        filePath = Application.dataPath + "/Distance.txt";
        try
        {
            //Pass the file path and file name to the StreamReader constructor
            StreamReader sr = new StreamReader(filePath);

            //Read the first line of text
            line = sr.ReadLine();
            dist = float.Parse(line);

            //Continue to read until you reach end of file
            while (line != null)
            {
                //write the lie to console window
                distanceIn.Add(dist);
                //Read the next line
                line = sr.ReadLine();
                dist = float.Parse(line);
            }

            //close the file
            sr.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception: " + e.Message);
        }

        return distanceIn;
    }

    [STAThread]
    public List<string> ReadEnemy()
    {
        String line;
        filePath = Application.dataPath + "/EnemyInput.txt";
        try
        {
            //Pass the file path and file name to the StreamReader constructor
            StreamReader sr = new StreamReader(filePath);

            //Read the first line of text
            line = sr.ReadLine();

            //Continue to read until you reach end of file
            while (line != null)
            {
                //write the lie to console window
                enemyIn.Add(line);
                //Read the next line
                line = sr.ReadLine();
            }

            //close the file
            sr.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception: " + e.Message);
        }

        return enemyIn;
    }

    public void AIAction()
    {
        aiClipInfo = aiAnim.GetCurrentAnimatorClipInfo(0);
        aiAnimName = aiClipInfo[0].clip.name;
        const float MinNormal = 0.01f;
        List<string> playerOptimal = new List<string>();

        for(int i = 0; i < enemyIn.Count; i++)
        {
            if (enemyIn[i].Equals(aiAnimName))
            {
                playerOptimal.Add(playerIn[i]);
            }
        }

        for (int i = 0; i < enemyIn.Count; i++)
        {
            float a = Math.Abs(distanceIn[i]);
            float b = Math.Abs(distance);
            float diff = Math.Abs(a - b);
            if (distanceIn[i].Equals(distance))
            {
                playerOptimal.Add(playerIn[i]);
            }
            else if (diff < MinNormal)
            {
                playerOptimal.Add(playerIn[i]);
            }
        }

        System.Random rand = new System.Random();
        int opt = rand.Next(0, playerOptimal.Count-1);

        if (playerOptimal[opt].Equals("Jump"))
        {
            aiAnim.SetTrigger("Jump");
            rgbd.AddForce(new Vector2(0, 7.7f), ForceMode2D.Impulse);
        }
        else if (playerOptimal[opt].Equals("Crouch"))
        {
            aiAnim.SetBool("Crouch", true);
            aiAnim.SetBool("Idle", false);
            capsule.size = new Vector2(0.43f, 0.581f);
        }
        else if (playerOptimal[opt].Equals("Idle"))
        {
            aiAnim.SetBool("Crouch", false);
            aiAnim.SetBool("StandBlock", false);
            aiAnim.SetBool("Idle", true);
            capsule.size = new Vector2(0.43f, 0.81f);
        }
        else if (playerOptimal[opt].Equals("StandBlock"))
        {
            aiAnim.SetBool("StandBlock", true);
        }
        else
        {
            aiAnim.SetTrigger(playerOptimal[opt]);
        }
    }
}
