using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public float damage { get; private set; }

    [SerializeField] float moveSpeed;

    Rigidbody rigid;
    Animator anim;

    float horizontalInput;
    float verticalInput;

    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();

        damage = 50f;
    }
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        AnimSet();
    }
    private void FixedUpdate()
    {
        Vector3 moveDir = new Vector3(horizontalInput, rigid.velocity.y, verticalInput);

        Vector3 targetVelocity = moveDir * moveSpeed;
        Vector3 velocityChange = (targetVelocity - rigid.velocity);

        Movement(velocityChange);
        Rotation(moveDir);
    }
    private void AnimSet()
    {
        if (horizontalInput != 0f || verticalInput != 0f)
        {
            anim.SetBool("isRun", true);
        }
        else
        {
            anim.SetBool("isRun", false);
        }
    }
    private void Rotation(Vector3 moveDir)
    {
        if (moveDir.x != 0 || moveDir.z != 0)
        {
            Quaternion deltaRotation = Quaternion.LookRotation(moveDir.normalized);
            rigid.MoveRotation(deltaRotation);
        }
    }
    private void Movement(Vector3 velocityChange)
    {
        rigid.AddForce(velocityChange, ForceMode.VelocityChange);
    }
}