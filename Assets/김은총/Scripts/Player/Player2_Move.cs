using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2_Move : MonoBehaviour
{
    public float MoveSpeed = 5f;
    public Transform MovePoint;
    public float Radius;

    public LayerMask WhatStopMovement;

    public bool canMove = true;

    void Start()
    {
        MovePoint.parent = null;
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (canMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, MovePoint.position, MoveSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, MovePoint.position) <= 0.05f)
            {
                if (Mathf.Abs(Input.GetAxisRaw("LeftRightArrow")) == 1f)
                {
                    if (!Physics2D.OverlapCircle(MovePoint.position + new Vector3(Input.GetAxisRaw("LeftRightArrow") , 0f, 0f), Radius, WhatStopMovement))
                    {
                        MovePoint.position += new Vector3(Input.GetAxisRaw("LeftRightArrow"), 0.0f, 0.0f);
                    }
                }
                else if (Mathf.Abs(Input.GetAxisRaw("UpDownArrow")) == 1f)
                {
                    if (!Physics2D.OverlapCircle(MovePoint.position + new Vector3(0f, Input.GetAxisRaw("UpDownArrow"), 0f), Radius, WhatStopMovement))
                    {
                        MovePoint.position += new Vector3(0.0f, Input.GetAxisRaw("UpDownArrow"), 0.0f);
                    }
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player1"))
        {
            Debug.Log("Player1");
        }
    }
}
