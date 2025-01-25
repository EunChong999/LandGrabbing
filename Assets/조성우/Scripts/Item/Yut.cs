using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yut : MonoBehaviour
{
    [SerializeField] private float speed;

    private void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player2"))
        {
            collision.gameObject.GetComponent<Player2_Item>().HitYut();
            Destroy(gameObject);
        }
        if(collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
}
