using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBoxHealth : MonoBehaviour
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

    // Update is called once per frame
    void FixedUpdate()
    {
    }
}
