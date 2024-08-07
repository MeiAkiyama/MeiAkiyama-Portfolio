using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotator : MonoBehaviour
{
    [SerializeField] float angle = 30f; //��]���x
    float horizontalAngle = 0f; //���������̉�]��
    float verticalAngle = 0f;   //���������̉�]��

    void Update()
    {
        //��]�ʎ擾
        float horizontalRotation = Input.GetAxis("Horizontal") * angle *Time.deltaTime;//��������
        float verticalRotation = -Input.GetAxis("Vertical") * angle * Time.deltaTime;//��������

        //��]�ʍX�V
        horizontalAngle += horizontalRotation;
        verticalAngle += verticalRotation;

        transform.rotation = Quaternion.Euler(verticalAngle, horizontalAngle, 0);
    }
}
