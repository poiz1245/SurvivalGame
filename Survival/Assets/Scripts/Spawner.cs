using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //������Ʈ Ǯ���� ���� �޾Ƽ� �ڷ�ƾ���� ���� ����
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
