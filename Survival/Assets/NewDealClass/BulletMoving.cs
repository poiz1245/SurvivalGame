using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletMoving : MonoBehaviour
{
    [SerializeField] float speed;

    [SerializeField] float damage;
    void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            gameObject.SetActive(false);
        }

        if (other.gameObject.CompareTag("Player"))
        {
            Player player = other.gameObject.GetComponent<Player>();
            player.GetDamage(damage);
            gameObject.SetActive(false);
        }
    }
}
