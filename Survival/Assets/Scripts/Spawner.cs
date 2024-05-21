using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] int index;
    [SerializeField] Transform[] spawnPoints;

    void Start()
    {
        StartCoroutine(MonsterSpawn(0, 1));
    }
    IEnumerator MonsterSpawn(int index, float spawnDelay)
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnDelay);

            for (int i = 0; i < spawnPoints.Length; i++)
            {
                GameObject monster = GameManager.Instance.monsterPool.GetMonster(index);
                monster.transform.position = spawnPoints[i].position;
            }
        }
    }
}
