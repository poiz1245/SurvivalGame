using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] int index;
    [SerializeField] float spawnDelay;

    [Header("Monster Pool")]
    [SerializeField] Transform[] spawnPoints;

    int rnd;

    void Start()
    {
        StartCoroutine(MonsterSpawn(0, spawnDelay));
    }

    private void Update()
    {
        rnd = Random.Range(0, spawnPoints.Length);
    }
    IEnumerator MonsterSpawn(int index, float spawnDelay)
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnDelay);

            GameObject monster = GameManager.Instance.monsterPool.GetMonster(index);
            monster.transform.position = spawnPoints[rnd].position;

            /*for (int i = 0; i < spawnPoints.Length; i++)
            {
                GameObject monster = GameManager.Instance.monsterPool.GetMonster(index);
                monster.transform.position = spawnPoints[i].position;
            }*/
        }
    }
}
