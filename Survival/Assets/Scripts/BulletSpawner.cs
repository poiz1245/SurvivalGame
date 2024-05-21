using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] float spawnDelay;

    void Start()
    {
        StartCoroutine(MonsterSpawn(0, spawnDelay));
    }
    IEnumerator MonsterSpawn(int index, float spawnDelay)
    {
        int count = 0;

        while (true)
        {
            yield return new WaitForSeconds(spawnDelay);
            GameObject bullet = GameManager.Instance.bulletPool.GetBullet(index);
            bullet.transform.position = spawnPoints[count].position;
            count++;

            if (count == 2)
            { 
                count = 0;
            }
        }
    }
}
