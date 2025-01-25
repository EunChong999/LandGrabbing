using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionEffect : MonoBehaviour
{
    public CameraShake CameraShake;
    public Player1_Move PM1;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(PM1.Collision == true)
        {
            StartCoroutine(CameraShake.Shake(0.05f, 0.2f));
            PM1.Collision = false;
        }
    }
}
