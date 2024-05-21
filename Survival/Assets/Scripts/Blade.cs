using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    [SerializeField] float rotateSpeed;

    private void Update()
    {
        transform.Rotate(-1 * rotateSpeed, 0, 0);
        transform.position = new Vector3(GameManager.Instance.player.transform.position.x,0.7f, GameManager.Instance.player.transform.position.z);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Monster"))
        {
            Monster monster = other.gameObject.GetComponent<Monster>();
            monster.GetDamage(GameManager.Instance.player.damage);
        }
    }

}
