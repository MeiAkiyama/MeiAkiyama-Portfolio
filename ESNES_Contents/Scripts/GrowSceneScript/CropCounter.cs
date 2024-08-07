using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CropCounter : MonoBehaviour
{
    private int counter;
    public int MaxPlantNumber = 6;

    public StateManager stateManager;
    public GameObject box;

    // Start is called before the first frame update
    void Start()
    {
        counter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(stateManager.GetState()==StateManager.STATE.CROP)
        {
            if(counter >= MaxPlantNumber)
            {
                box.SetActive(true);
                stateManager.SetState(StateManager.STATE.BOX);
            }
        }
    }

    public void CropPlantCount()
    {
        counter++;
    }
}
