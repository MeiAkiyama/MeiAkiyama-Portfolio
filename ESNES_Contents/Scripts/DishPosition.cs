using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DishPosition : MonoBehaviour
{
    private static Vector3 dishPosition;
    private static Vector3 dishRotate;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void setDishPosition(Vector3 dish)
    {
        dishPosition = dish;
    }
    
    public static Vector3 getDishPosition()
    {
        return dishPosition;
    }

    public static void setCameraRotate(Vector3 cam)
    {
        dishRotate.x = 0;
        dishRotate.y = cam.y;
        dishRotate.z = 0;
    }

    public static Vector3 getDishRotate()
    {
        return dishRotate;
    }
}
