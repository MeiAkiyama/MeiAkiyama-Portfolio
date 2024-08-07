using JetBrains.Annotations;
using Oculus.Interaction;
using Oculus.Interaction.HandGrab;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugCounter : MonoBehaviour
{
    private int counter;
    public StateManager stateManager;
    public int MaxBugNumber = 4;
    public GameObject[] BugLeafs;
    public GameObject[] yajirushi;

    // Start is called before the first frame update
    void Start()
    {
        counter = 0;
        foreach (var leaf in BugLeafs)
        {
            leaf.GetComponent<BoxCollider>().enabled = false;
            leaf.GetComponent<HandGrabInteractable>().enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (stateManager.GetState() == StateManager.STATE.BUG)
        {
            if (counter == MaxBugNumber)
            {
                Invoke("ChangeContentState", 1.5f);
                Destroy(BugLeafs[1],1.5f);
                Destroy(BugLeafs[7],1.5f);
            }
        }
    }

    public void AddCounter()
    {
        counter++;
    }

    private void ChangeContentState()
    {
        foreach (var leaf in yajirushi)
        {
            leaf.SetActive(false);
        }
        stateManager.SetState(StateManager.STATE.ILL);
    }
}
