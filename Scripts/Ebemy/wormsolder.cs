using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wormsolder : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] Transform myPoint;
    [SerializeField] LayerMask groundMask;
    [SerializeField] private float moveSpeed = 5f;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        MoveWorm();
    }

    private void MoveWorm()
    {
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        if(!Physics2D.Raycast(myPoint.position, Vector2.down, 0.2f, groundMask))
        {
            Vector3 temp = transform.localScale;
            temp.x *= -1f;
            transform.localScale = temp;
            moveSpeed *= -1f;
        }
       
        

    }
}//class
