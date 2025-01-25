using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Top : MonoBehaviour
{
    private bool canAttack = true;

    private void Awake()
    {
        Invoke("StartFade", 15);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (canAttack && collision.gameObject.CompareTag("Player2"))
        {
            collision.gameObject.GetComponent<Player2_Item>().ReturnPos();
            Destroy(gameObject);
        }
    }

    private void StartFade()
    {
        canAttack = false;
        StartCoroutine(FadeInStart(1));
    }

    private IEnumerator FadeInStart(float time)
    {
        Color color = transform.GetComponent<SpriteRenderer>().color;
        while (color.a > 0f)
        {
            color.a -= Time.deltaTime / time;
            transform.GetComponent<SpriteRenderer>().color = color;
            yield return null;
        }
        Destroy(gameObject);
    }
}
