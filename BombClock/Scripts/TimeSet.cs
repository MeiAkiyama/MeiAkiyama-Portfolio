using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.SceneManagement;

public class TimeSet : MonoBehaviour
{
    private static int hourNumber;

    [SerializeField] GameObject text1;

    private TextMeshProUGUI tex1;

    // Start is called before the first frame update
    void Start()
    {
        //時間取得
        DateTime now = DateTime.Now;
        hourNumber = now.Hour;
        int lineNumber;

        if(hourNumber == 0)
        {
            lineNumber = 24;
        }
        else if(0<hourNumber && hourNumber <= 4)
        {
            lineNumber = 4;
        }
        else
        {
            lineNumber = hourNumber;
        }

        //テキストコンポーネント取得
        tex1 = text1.GetComponent<TextMeshProUGUI>();

        tex1.text = "線は" + lineNumber + "本出てきます。";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static int getHour()
    {
        return hourNumber;
    }

    public void startClick()
    {
        this.GetComponent<AudioSource>().Play();
        Invoke("sceneChange", 1);
    }

    public void sceneChange()
    {
        SceneManager.LoadScene("BombClockScene");
    }
}
