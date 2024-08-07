using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowSceneStart : MonoBehaviour
{
    private GameObject table;
    private GameObject state;
    private StateManager stateManager;
    // Start is called before the first frame update
    void Start()
    {
        table = GameObject.Find("table");
        state = GameObject.Find("SceneManager");
        stateManager = state.GetComponent<StateManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject == table)
        {
            stateManager.SetState(StateManager.STATE.SOIL);
        }
    }
}
