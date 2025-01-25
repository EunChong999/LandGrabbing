using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2_Item : MonoBehaviour
{
    [SerializeField] private GameObject carPrefab;
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private GameObject robotPrefab;

    public Transform MovePoint;

    private float playerLotation = 0;

    private void Update()
    {
        CheckPlayerLotation();
        UesItemCar();
        UesItemBall();
        UesItemRobot();
    }

    private void CheckPlayerLotation()
    {
        if (Mathf.Abs(Input.GetAxisRaw("LeftRightArrow")) == 1f)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                playerLotation = 0;
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                playerLotation = 180;
            }
        }
        else if (Mathf.Abs(Input.GetAxisRaw("UpDownArrow")) == 1f)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                playerLotation = -90;
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                playerLotation = 90;
            }
        }
    }

    private void UesItemCar()
    {
        if(Input.GetKeyDown(KeyCode.Keypad1) && ItemManager.Instance.modernItemImage[0].activeSelf)
        {
            SoundManager.Instance.PlaySFXSound("UesItem");
            if (playerLotation == 180)
            {
                Instantiate(carPrefab, transform.position, Quaternion.Euler(new Vector3(0, playerLotation, 0)));
            }
            else
            {
                Instantiate(carPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, playerLotation)));
            }
            ItemManager.Instance.modernItemImage[0].SetActive(false);
        }
    }

    private void UesItemBall()
    {
        if(Input.GetKeyDown(KeyCode.Keypad2) && ItemManager.Instance.modernItemImage[1].activeSelf)
        {
            ItemManager.Instance.modernItemImage[1].SetActive(false);
            SoundManager.Instance.PlaySFXSound("UesItem");
            GameObject ball = Instantiate(ballPrefab, transform.position, Quaternion.identity);
            ball.GetComponent<Ball>().randomDir = new Vector2(Random.Range(-360, 360), Random.Range(-360, 360));
        }
    }

    private void UesItemRobot()
    {
        if(Input.GetKeyDown(KeyCode.Keypad3) && ItemManager.Instance.modernItemImage[2].activeSelf)
        {
            ItemManager.Instance.modernItemImage[2].SetActive(false);
            SoundManager.Instance.PlaySFXSound("UesItem");
            Instantiate(robotPrefab, transform.position, Quaternion.identity);
        }
    }

    public void HitYut()
    {
        transform.position = new Vector2(7.5f, 0.5f);
        MovePoint.position = new Vector2(7.5f, 0.5f);

        transform.GetComponent<Player2_Move>().canMove = false;

        Invoke("WaitSec", 2f);
    }

    private void WaitSec()
    {
        transform.GetComponent<Player2_Move>().canMove = true;
    }

    public void HitJaegi()
    {
        transform.position = new Vector2(7.5f, 0.5f);
        MovePoint.position = new Vector2(7.5f, 0.5f);

        transform.GetComponent<Player2_Move>().canMove = false;

        Invoke("WaitSec", 3f);
    }

    public void ReturnPos()
    {
        transform.position = new Vector2(7.5f, 0.5f);
        MovePoint.position = new Vector2(7.5f, 0.5f);
    }
}
