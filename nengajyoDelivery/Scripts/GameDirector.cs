using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameDirector : MonoBehaviour
{
    public GameObject number;   //�c�薇���̃I�u�W�F�N�g
    public GameObject timer;    //�^�C�}�[�̃e�L�X�g
    private TextMeshProUGUI numberTxt;  //�c�薇���̃e�L�X�g
    private TextMeshProUGUI timerTxt;   //�^�C�}�[�̃e�L�X�g
    private static float time; //�o�ߎ���
    public int num; //�c�薇��
    private static float bestTime;//�x�X�g�^�C��

    // Start is called before the first frame update
    void Start()
    {
        numberTxt = number.GetComponent<TextMeshProUGUI>();
        timerTxt = timer.GetComponent<TextMeshProUGUI>();
        time = 0;
        bestTime = time;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        
        if(time > bestTime)
        {
            bestTime = time;
        }

        //UI�\��
        numberTxt.text = "�~" + num;
        timerTxt.text = "Time:" + time.ToString("F2");
    }

    public void numDecrease()
    {
        num -= 1;
    }

    public int getnum()
    {
        return num;
    }

    public static float getTime()
    {
        return time;
    }
}
