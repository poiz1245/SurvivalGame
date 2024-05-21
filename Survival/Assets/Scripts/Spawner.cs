using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //오브젝트 풀에서 몬스터 받아서 코루틴으로 몬스터 스폰
    [SerializeField] int index;
    [SerializeField] Transform[] spawnSpot;

    void Start()
    {
        StartCoroutine(MonsterSpawn(0, 1));
    }
    IEnumerator MonsterSpawn(int index, float spawnDelay)
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnDelay);
            GameObject monster = MonsterPool.GetMonster(index);

            for (int i = 0; i < spawnSpot.Length; i++)
            {
                monster.transform.position = spawnSpot[i].position;
            }
        }
    }
}
