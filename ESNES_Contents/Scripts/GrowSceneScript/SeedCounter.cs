using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedCounter : MonoBehaviour
{
    /*
     * ���A�������̃J�E���g�N���X
     */
    public int PlantPositionNum = 8; //�A����ꏊ�̐�
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
            //�A������G���C�x���g�ɑJ��
            Debug.Log("�G��");
            stateManager.SetState(StateManager.STATE.GRASS);
            isStateChange = true;
        }
    }

    public void PlantSeedCount()
    {
        counter++;
    }
}
