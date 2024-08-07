using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plantManager : MonoBehaviour
{
    public StateManager stateManager;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GrowPlant()
    {
        this.gameObject.transform.Translate(new Vector3(0,0.05f,0));
    }
}
