using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundReposition : MonoBehaviour
{
    [SerializeField] Transform playerPosition;

    Vector3 playerDir;
    [SerializeField] float groundMoveDis;

    void Update()
    {
        float diffX = Mathf.Abs(transform.position.x - playerPosition.position.x);
        float diffZ = Mathf.Abs(transform.position.z - playerPosition.position.z);

        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        playerDir = new Vector3(horizontalInput, 0, verticalInput);

        if (diffX > diffZ)
        {
            transform.Translate(Vector3.right * playerDir.x * groundMoveDis);
        }
        else if (diffX < diffZ)
        {
            transform.Translate(Vector3.forward * playerDir.z * groundMoveDis);
        }
    }
}
