using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] float spawnDelay;

    float spawnTime;
    int count = 0;
    bool findTarget;
    private void FixedUpdate()
    {
        spawnTime -= Time.fixedDeltaTime;
        findTarget = GameManager.Instance.player.findTarget;

        if (spawnTime <= 0 && findTarget)
        {
            MonsterSpawn(0);
            spawnTime = spawnDelay;
        }
    }

    public void MonsterSpawn(int index)
    {
        if (count == 2) { count = 0; }

        GameObject bullet = GameManager.Instance.bulletPool.GetBullet(index);
        bullet.transform.position = spawnPoints[count].position;
        count++;
    }
}
