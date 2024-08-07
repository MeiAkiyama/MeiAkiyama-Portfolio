using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ILLManager : MonoBehaviour
{
    public StateManager stateManager;
    private bool isIllObujectInstance;

    public GameObject[] illPlants;
    public GameObject bigLeafs;
    public GameObject cropLeafs;

    private int flag;
    private int counter;

    // Start is called before the first frame update
    void Start()
    {
        isIllObujectInstance = false;
        flag = 0;
        counter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (stateManager.GetState() == StateManager.STATE.ILL)
        {
            if (!isIllObujectInstance)
            {
                foreach (var l in illPlants)
                {
                    l.SetActive(true);
                }
            }
            isIllObujectInstance = true;

            
            if (counter >= 2)
            {
                Destroy(bigLeafs,1);
                Invoke("setNextObject", 1f);
                Invoke("ChangeContentState", 1f);
            }
        }    
    }

    private void ChangeContentState()
    {
        stateManager.SetState(StateManager.STATE.CROP);
    }

    private void setNextObject()
    {
        cropLeafs.SetActive(true);
    }

    public void ILLCounter()
    {
        counter++;
    }
}
