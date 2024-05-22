using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Bullet : MonoBehaviour
{
    Transform targetPos;
    Vector3 posA;

    float time = 0;

    void Update()
    {
        targetPos = GameManager.Instance.player.nearestTargetPos;

        Vector3 dir = (targetPos.position-transform.position ).normalized;
        posA = dir * 1f;

        print(posA);
        Vector3 p1 = Vector3.Lerp(transform.position, posA, time);
        Vector3 p2 = Vector3.Lerp(posA, targetPos.position, time);

        transform.position = Vector3.Lerp(p1, p2, time);
        time += Time.deltaTime;
    }
}
