using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZZ : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] LayerMask playerMask;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        rb.gravityScale = 0f;
    }



    void Update()
    {
        CheckForPlayer();
    }

     void CheckForPlayer()
    {
        if (Physics2D.Raycast(transform.position, Vector2.down, 100f, playerMask))//по играку полетит
        {
            rb.gravityScale = 1f;
        }
    }
}
