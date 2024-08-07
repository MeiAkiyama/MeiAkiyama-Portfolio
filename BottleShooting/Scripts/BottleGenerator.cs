using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleGenerator : MonoBehaviour
{

    [SerializeField] Bottle[] bottlePrefub;//ボトルのプレハブ
    Bottle bottle;

    public void BottleGenerate()
    {
        if (bottle == null)
        {
            int index = Random.Range(0, bottlePrefub.Length);
            bottle = Instantiate(bottlePrefub[index], transform.position, transform.rotation);
        }
    }
}
