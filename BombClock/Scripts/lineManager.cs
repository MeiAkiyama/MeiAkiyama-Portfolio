using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lineManager : MonoBehaviour
{
    public enum lineColors{
        Red,Blue,Green,Yellow
    };
    private int enumLength;
    private int colorNumber;

    //線の配列
    public GameObject[] lines;
    private int nowTime;
    //public int testTime;

    private lineColors linecolor;

    private void Start()
    {
        //enum要素数取得
        enumLength = Enum.GetValues(typeof(lineColors)).Length;
        //ランダムで色情報を取得
        colorNumber = UnityEngine.Random.Range(0, enumLength);
        linecolor = (lineColors)colorNumber;
        Debug.Log(linecolor);

        //時間取得
        nowTime = TimeSet.getHour();
        //nowTime = testTime;

        //時間による条件分岐
        switch (nowTime)
        {
            case 0:
                setZero(); break;
            case 1:
            case 2:
            case 3:
            case 4:
                setOneToFour(); break;
            default:
                setTimeNumber(nowTime); break;
        }
        Debug.Log(nowTime);
    }



    private void setZero()
    {
        for(int i=0; i<lines.Length; i++)
        {
            lines[i].SetActive(true);
        }
    }

    private void setOneToFour()
    {
        for(int i = 0; i < 4; i++)
        {
            lines[i].SetActive(true);
        }
    }

    private void setTimeNumber(int time)
    {
        for(int i = 0; i < time; i++)
        {
            lines[i].SetActive(true);
        }
    }

    public int getEnumLength()
    {
        return enumLength;
    }

    public lineColors getColor()
    {
        return linecolor;
    }
}
