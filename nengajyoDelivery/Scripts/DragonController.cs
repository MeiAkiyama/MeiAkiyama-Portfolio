using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonController : MonoBehaviour
{
    public float speed = 0.1f;
    private float dir = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, speed*dir, 0);
        if (transform.position.y > 3.5f)
        {
            dir = -1;
        }else if(transform.position.y < -2.5f)
        {
            dir = 1;
        }
    }
}
