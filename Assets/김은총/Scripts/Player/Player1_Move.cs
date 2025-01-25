using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1_Move : MonoBehaviour
{
    public float MoveSpeed = 5f;
    public Transform MovePoint;
    public float Radius;
    public bool Collision;
    public LayerMask WhatStopMovement;

    public bool canMove = true;

    void Start()
    {
        MovePoint.parent = null;
    }

    void Update()
    {
        if (canMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, MovePoint.position, MoveSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, MovePoint.position) <= 0.05f)
            {
                if (Mathf.Abs(Input.GetAxisRaw("AD")) == 1f)
                {
                    if (!Physics2D.OverlapCircle(MovePoint.position + new Vector3(Input.GetAxisRaw("AD"), 0f, 0f), Radius, WhatStopMovement))
                    {
                        MovePoint.position += new Vector3(Input.GetAxisRaw("AD"), 0.0f, 0.0f);
                    }
                }
                else if (Mathf.Abs(Input.GetAxisRaw("WS")) == 1f)
                {
                    if (!Physics2D.OverlapCircle(MovePoint.position + new Vector3(0f, Input.GetAxisRaw("WS"), 0f), Radius, WhatStopMovement)) 
                    {
                        MovePoint.position += new Vector3(0.0f, Input.GetAxisRaw("WS"), 0.0f);
                    }
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player2"))
        {
            Debug.Log("Player2");
            Collision = true;
        }
    }
}

