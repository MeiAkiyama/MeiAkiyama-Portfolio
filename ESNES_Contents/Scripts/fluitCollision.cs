using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fluitCollision : MonoBehaviour
{
    public StateManager stateManager;
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

    private void OnTriggerExit(Collider other)
    {
        if (!isCroped)
        {
            Debug.Log("’Ê‚è”²‚¯‚½");
            stateManager.SetState(StateManager.STATE.END);
            isCroped = true;
        }
        
    }
}
