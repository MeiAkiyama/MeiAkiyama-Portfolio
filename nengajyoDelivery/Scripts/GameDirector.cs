using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameDirector : MonoBehaviour
{
    public GameObject number;   //残り枚数のオブジェクト
    public GameObject timer;    //タイマーのテキスト
    private TextMeshProUGUI numberTxt;  //残り枚数のテキスト
    private TextMeshProUGUI timerTxt;   //タイマーのテキスト
    private static float time; //経過時間
    public int num; //残り枚数
    private static float bestTime;//ベストタイム

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

        //UI表示
        numberTxt.text = "×" + num;
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
