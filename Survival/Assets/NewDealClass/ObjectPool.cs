using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject[] bulletPrefabs;

    List<GameObject>[] bulletPool;

    private void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {
        bulletPool = new List<GameObject>[bulletPrefabs.Length];

        for (int i = 0; i < bulletPool.Length; i++)
        {
            bulletPool[i] = new List<GameObject>();
        }
    }

    public GameObject GetBullet(int index, Transform spawnPosition, Vector3 rotation)
    {
        GameObject select = null;

        foreach (GameObject obj in bulletPool[index])
        {
            if (!obj.activeSelf)
            {
                select = obj;
                select.transform.position = spawnPosition.position;
                select.transform.rotation = Quaternion.Euler(rotation);
                select.SetActive(true);
                break;
            }
        }

        if (!select)
        {
            select = Instantiate(bulletPrefabs[index], spawnPosition.position, Quaternion.Euler(rotation));
            bulletPool[index].Add(select);
        }

        return select;
    }
}