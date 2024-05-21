using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMove : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float rotateSpeed;

    GameObject playerPos;
    Rigidbody rigid;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        playerPos = GameObject.Find("Player");
    }

    private void Update()
    {
        /*if ()
        {
            anim.SetBool("isAttack", true);
        }*/
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 moveDir = playerPos.transform.position - transform.position;

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
        //transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }
}
