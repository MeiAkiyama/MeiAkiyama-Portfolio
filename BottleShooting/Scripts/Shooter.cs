using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject bullet; //’e‚ÌƒvƒŒƒnƒu
    [SerializeField] Transform bulletGenerator; //’e‚ğ¶¬‚·‚éˆÊ’u

    void Update()
    {
        //“ü—Í
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        //’e‚ğ¶¬
        Instantiate(bullet,bulletGenerator.position,bullet.transform.rotation*bulletGenerator.rotation);
    }
}
