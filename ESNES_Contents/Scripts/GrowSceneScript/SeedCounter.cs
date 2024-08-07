using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedCounter : MonoBehaviour
{
    /*
     * í‚ğA‚¦‚½”‚ÌƒJƒEƒ“ƒgƒNƒ‰ƒX
     */
    public int PlantPositionNum = 8; //A‚¦‚éêŠ‚Ì”
    private int counter;
    private bool isStateChange;
    public StateManager stateManager;

    // Start is called before the first frame update
    void Start()
    {
        counter = 0;
        isStateChange = false;
    
    }

    // Update is called once per frame
    void Update()
    {
        if(counter == PlantPositionNum && !isStateChange)
        {
            //A‚¦‚½‚çG‘ƒCƒxƒ“ƒg‚É‘JˆÚ
            Debug.Log("G‘");
            stateManager.SetState(StateManager.STATE.GRASS);
            isStateChange = true;
        }
    }

    public void PlantSeedCount()
    {
        counter++;
    }
}
