using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotator : MonoBehaviour
{
    [SerializeField] float angle = 30f; //‰ñ“]‘¬“x
    float horizontalAngle = 0f; //…•½•ûŒü‚Ì‰ñ“]—Ê
    float verticalAngle = 0f;   //‚’¼•ûŒü‚Ì‰ñ“]—Ê

    void Update()
    {
        //‰ñ“]—Êæ“¾
        float horizontalRotation = Input.GetAxis("Horizontal") * angle *Time.deltaTime;//…•½•ûŒü
        float verticalRotation = -Input.GetAxis("Vertical") * angle * Time.deltaTime;//‚’¼•ûŒü

        //‰ñ“]—ÊXV
        horizontalAngle += horizontalRotation;
        verticalAngle += verticalRotation;

        transform.rotation = Quaternion.Euler(verticalAngle, horizontalAngle, 0);
    }
}
