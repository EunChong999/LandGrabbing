using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] float setTime = 10.0f;
    [SerializeField] Text countdownText;

    [SerializeField] private Player1_Move player1;
    [SerializeField] private Player2_Move player2;

    private bool timeStop = false;

    void Start()
    {
        countdownText.text = setTime.ToString();
        countdownText.enabled = false;
    }

    void Update()
    {
        if (!timeStop)
        {
            setTime -= Time.deltaTime;

            if (setTime < 3.5f)
            {
                countdownText.enabled = true;
                setTime += Time.deltaTime * 0.25f;

                if (setTime <= 0)
                {
                    timeStop = true;
                    player1.canMove = false;
                    player2.canMove = false;
                    GameManager.Instance.LoadResult();
                }
            }

            countdownText.text = Mathf.Round(setTime).ToString();
        }
    }
}
