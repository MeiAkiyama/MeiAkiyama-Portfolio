using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GrassController : MonoBehaviour
{
    private Rigidbody rb;
    public GrassCounter grassCounter;
    private bool isCroped;

    // Start is called before the first frame update
    void Start()
    {
        isCroped = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionExit(Collision collision)
    {
        if (!isCroped)
        {
            grassCounter.AddGrassCounter();
            isCroped = true;
        }
        Destroy(this.gameObject, 1.5f);
    }
}
