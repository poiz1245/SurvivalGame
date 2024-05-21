using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float rotateSpeed;

    Rigidbody rigid;
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector3 moveDir = GameManager.Instance.player.transform.position - transform.position;

        Vector3 targetVelocity = moveDir * moveSpeed;
        Vector3 velocityChange = (targetVelocity - rigid.velocity);

        Move(velocityChange);
        Rotate(moveDir);
    }

    public void Rotate(Vector3 moveDir)
    {
        Quaternion deltaRotation = Quaternion.LookRotation(moveDir);
        rigid.MoveRotation(deltaRotation);
    }

    public void Move(Vector3 velocityChange)
    {
        rigid.AddForce(velocityChange, ForceMode.VelocityChange);
    }
}
