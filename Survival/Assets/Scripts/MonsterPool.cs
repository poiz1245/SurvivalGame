using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterPool : MonoBehaviour
{
    public static MonsterPool Instance;

    [SerializeField] GameObject[] monsterPrefabs;

    List<GameObject>[] monsterPool;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        Initialize();
    }

    private void Initialize()
    {
        monsterPool = new List<GameObject>[monsterPrefabs.Length];

        for (int i = 0; i < monsterPool.Length; i++)
        {
            monsterPool[i] = new List<GameObject>();
        }
    }

    public static GameObject GetMonster(int index)
    {
        GameObject select = null;

        foreach (GameObject obj in Instance.monsterPool[index])
        {
            if (!obj.activeSelf)
            {
                select = obj;
                select.SetActive(true);
                break;
            }
        }

        if (!select)
        {
            select = Instantiate(Instance.monsterPrefabs[index], Instance.transform);
            Instance.monsterPool[index].Add(select);
        }

        return select;
    }
}