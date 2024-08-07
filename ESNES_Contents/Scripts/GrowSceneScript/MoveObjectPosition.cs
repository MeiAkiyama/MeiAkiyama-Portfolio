using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class MoveObjectPosition : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Vector3 CameraRotate = DishPosition.getDishRotate();
        this.gameObject.transform.Rotate(CameraRotate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
