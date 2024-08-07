using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class MoveDishPosition : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string scene = SceneManager.GetActiveScene().name;
        Vector3 CameraRotate;
        if (DishPosition.getDishPosition() != null)
        {
            this.gameObject.transform.position = DishPosition.getDishPosition();
        }
        CameraRotate = DishPosition.getDishRotate();
        this.gameObject.transform.Rotate(CameraRotate);




    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
