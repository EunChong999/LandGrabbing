using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1_Item : MonoBehaviour
{
    [SerializeField] private GameObject yutPrefab;
    [SerializeField] private GameObject jaegiPrefab;
    [SerializeField] private GameObject topPrefab;

    public Transform MovePoint;

    private float playerLotation = 0;

    void Update()
    {
        CheckPlayerLotation();
        UseItemYut();
        UseItemJaegi();
        UseItemTop();
    }

    private void CheckPlayerLotation()
    {
        if (Mathf.Abs(Input.GetAxisRaw("AD")) == 1f)
        {
            if (Input.GetKey(KeyCode.A))
            {
                playerLotation = 90;
            }
            if (Input.GetKey(KeyCode.D))
            {
                playerLotation = -90;
            }
        }
        else if (Mathf.Abs(Input.GetAxisRaw("WS")) == 1f)
        {
            if (Input.GetKey(KeyCode.W))
            {
                playerLotation = 0;
            }
            if (Input.GetKey(KeyCode.S))
            {
                playerLotation = 180;
            }
        }
    }

    private void UseItemYut()
    {
        if (Input.GetKeyDown(KeyCode.J) && ItemManager.Instance.folkItemImage[0].activeSelf)
        {
            ItemManager.Instance.folkItemImage[0].SetActive(false);
            SoundManager.Instance.PlaySFXSound("UesItem");
            Instantiate(yutPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, playerLotation + 9)));
            Instantiate(yutPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, playerLotation + 30)));
            Instantiate(yutPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, playerLotation + -9)));
            Instantiate(yutPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, playerLotation + -30)));
        }
    }

    private void UseItemJaegi()
    {
        if (Input.GetKeyDown(KeyCode.K) && ItemManager.Instance.folkItemImage[1].activeSelf)
        {
            ItemManager.Instance.folkItemImage[1].SetActive(false);
            SoundManager.Instance.PlaySFXSound("UesItem");
            GameObject jaegi = Instantiate(jaegiPrefab, transform.position, Quaternion.identity);
            jaegi.GetComponent<Jaegi>().randomDir = new Vector2(Random.Range(-360, 360), Random.Range(-360, 360));
        }
    }

    private void UseItemTop()
    {
        if (Input.GetKeyDown(KeyCode.L) && ItemManager.Instance.folkItemImage[2].activeSelf)
        {
            ItemManager.Instance.folkItemImage[2].SetActive(false);
            SoundManager.Instance.PlaySFXSound("UesItem");
            Instantiate(topPrefab, transform.position, Quaternion.identity);
        }
    }

    public void HitCar()
    {
        transform.position = new Vector2(-8.5f, 0.5f);
        MovePoint.position = new Vector2(-8.5f, 0.5f);

        transform.GetComponent<Player1_Move>().canMove = false;

        Invoke("WaitSec", 2f);
    }

    public void HitBall()
    {
        transform.position = new Vector2(-8.5f, 0.5f);
        MovePoint.position = new Vector2(-8.5f, 0.5f);

        transform.GetComponent<Player1_Move>().canMove = false;

        Invoke("WaitSec", 2f);
    }

    public void ReturnPos()
    {
        transform.position = new Vector2(-8.5f, 0.5f);
        MovePoint.position = new Vector2(-8.5f, 0.5f);
    }

    private void WaitSec()
    {
        transform.GetComponent<Player1_Move>().canMove = true;
    }
}
