using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject bullet; //�e�̃v���n�u
    [SerializeField] Transform bulletGenerator; //�e�𐶐�����ʒu

    void Update()
    {
        //����
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        //�e�𐶐�
        Instantiate(bullet,bulletGenerator.position,bullet.transform.rotation*bulletGenerator.rotation);
    }
}
