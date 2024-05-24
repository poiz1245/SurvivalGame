using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Fired : MonoBehaviour
{
    [SerializeField] float fireDelay;

    [Header("ShottingPoints")]
    [SerializeField] Transform[] leftShottingPoints;
    [SerializeField] Transform[] rightShottingPoints;
    [SerializeField] Transform[] topShottingPoints;
    [SerializeField] Transform[] bottomShottingPoints;

    bool leftfire = false;
    bool rightfire = false;
    bool upfire = false;
    bool downfire = false;

    private void Start()
    {
        Stage1Start();
    }

    void Stage1Start()
    {
        StartLeftFire();
        Invoke("StopLeftFire", 3);
        Invoke("StartRightFire", 2);
        Invoke("StopRightFire", 5);
        Invoke("StartUpFire", 4);
        Invoke("StopUpFire", 7);
        Invoke("StartDownFire", 6);
        Invoke("StopDownFire", 9);
    }
    public void StartLeftFire()
    {
        leftfire = true;
        StartCoroutine(LeftFire());
    }
    void StartRightFire()
    {
        rightfire = true;
        StartCoroutine(RightFire());
    }
    void StartUpFire()
    {
        upfire = true;
        StartCoroutine(UpFire());
    }
    void StartDownFire()
    {
        downfire = true;
        StartCoroutine(DownFire());
    }
    void StopLeftFire()
    {
        leftfire = false;
        StopCoroutine(LeftFire());
    }
    void StopRightFire()
    {
        rightfire = false;
        StopCoroutine(RightFire());
    }
    void StopUpFire()
    {
        upfire = false;
        StopCoroutine(UpFire());
    }
    void StopDownFire()
    {
        downfire = false;
        StopCoroutine(DownFire());
    }
    IEnumerator LeftFire()
    {
        while (leftfire)
        {
            for (int i = 0; i < leftShottingPoints.Length; i++)
            {
                GameManager_Newdeal.instance.objectPool.GetBullet(0, leftShottingPoints[i], new Vector3(0f, 90f, 0f));
            }
            yield return new WaitForSeconds(fireDelay);
        }
    }
    IEnumerator RightFire()
    {
        while (rightfire)
        {
            for (int i = 0; i < rightShottingPoints.Length; i++)
            {
                GameManager_Newdeal.instance.objectPool.GetBullet(0, rightShottingPoints[i], new Vector3(0f, -90f, 0f));
            }

            yield return new WaitForSeconds(fireDelay);
        }
    }
    IEnumerator UpFire()
    {
        while (upfire)
        {
            for (int i = 0; i < topShottingPoints.Length; i++)
            {
                GameManager_Newdeal.instance.objectPool.GetBullet(0, topShottingPoints[i], new Vector3(0f, 180f, 0f));
            }

            yield return new WaitForSeconds(fireDelay);
        }
    }
    IEnumerator DownFire()
    {
        while (downfire)
        {
            for (int i = 0; i < bottomShottingPoints.Length; i++)
            {
                GameManager_Newdeal.instance.objectPool.GetBullet(0, bottomShottingPoints[i], new Vector3(0f, 0f, 0f));
            }

            yield return new WaitForSeconds(fireDelay);
        }
    }


}
