using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundReposition : MonoBehaviour
{
    [SerializeField] Transform playerPosition;
    [SerializeField] float groundMoveDis;

    private void Update()
    {
        print("Horizontal" + Input.GetAxisRaw("Horizontal"));
        print("Vertical" + Input.GetAxisRaw("Vertical"));
    }
    private void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.CompareTag("Area"))
        {
            return;
        }

        float diffX = Mathf.Abs(transform.position.x - playerPosition.position.x);
        float diffZ = Mathf.Abs(transform.position.z - playerPosition.position.z);

        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        float playerXDir = horizontalInput;
        float playerZDir = verticalInput;

        if (Mathf.Abs(diffX - diffZ) <= 0.3f)
        {
            print("X,Z축 모두 이동");
            print($"X축 차이 : {diffX}  Z축 차이 : {diffZ}");
            transform.Translate(playerXDir * groundMoveDis, 0, playerZDir * groundMoveDis);
        }
        else if (diffX > diffZ)
        {
            print("X축 이동");
            print($"X축 차이 : {diffX}  Z축 차이 : {diffZ}  차이 : {diffX - diffX}");
            transform.Translate(Vector3.right * playerXDir * groundMoveDis);
        }
        else if (diffX < diffZ)
        {
            print("Z축 이동");
            print($"X축 차이 : {diffX}  Z축 차이 : {diffZ}  차이 : {diffX - diffX}");
            transform.Translate(Vector3.forward * playerZDir * groundMoveDis);
        }
        
    }
}
