using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class GrassCounter : MonoBehaviour
{
    private int counter;
    private bool isStateSet;
    public int MaxGrassNumber = 10;

    public StateManager stateManager;


    // Start is called before the first frame update
    void Start()
    {
        counter = 0;
        isStateSet = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (counter == MaxGrassNumber && !isStateSet)
        {
            Invoke("ChangeContentState", 1.5f);
            isStateSet = true;
        }
    }

    public void AddGrassCounter()
    {
        counter++;
    }

    private void ChangeContentState()
    {
        stateManager.SetState(StateManager.STATE.BUG);
    }
}
