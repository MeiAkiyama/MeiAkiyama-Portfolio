using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject bullet; //弾のプレハブ
    [SerializeField] Transform bulletGenerator; //弾を生成する位置

    void Update()
    {
        //入力
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        //弾を生成
        Instantiate(bullet,bulletGenerator.position,bullet.transform.rotation*bulletGenerator.rotation);
    }
}
