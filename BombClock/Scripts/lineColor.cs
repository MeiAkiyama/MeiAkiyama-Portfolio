using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lineColor : MonoBehaviour
{
    [SerializeField] private lineManager.lineColors color;

    public lineManager.lineColors getColor()
    {
        return color;
    }
}
