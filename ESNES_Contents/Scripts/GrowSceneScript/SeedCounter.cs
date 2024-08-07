using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedCounter : MonoBehaviour
{
    /*
     * 種を植えた数のカウントクラス
     */
    public int PlantPositionNum = 8; //植える場所の数
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
            //植えたら雑草イベントに遷移
            Debug.Log("雑草");
            stateManager.SetState(StateManager.STATE.GRASS);
            isStateChange = true;
        }
    }

    public void PlantSeedCount()
    {
        counter++;
    }
}
