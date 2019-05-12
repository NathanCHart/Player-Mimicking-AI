using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HitBoxHealthAI : MonoBehaviour
{
    public BoxCollider2D hitbox;
    public CapsuleCollider2D enemy;
    public float EnemyHealth = 100.0f;

    // Start is called before the first frame update
    void Start()
    {
        hitbox = GetComponent<BoxCollider2D>();
        enemy = GetComponent<CapsuleCollider2D>();
    }

    private void Update()
    {
        if (EnemyHealth == 0)
        {
            SceneManager.LoadScene("AIWin", LoadSceneMode.Single);
        }
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Collided");
            EnemyHealth = EnemyHealth - 5.0f;
            Debug.Log(EnemyHealth);
        }
    }
}
