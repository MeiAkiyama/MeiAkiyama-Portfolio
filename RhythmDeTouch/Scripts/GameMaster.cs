using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameMaster : MonoBehaviour
{
    [SerializeField] GameObject combo;
    private TextMeshProUGUI comboText;
    private static int comboNum;
    private static int maxCombo;

    private static int perfectNum;
    private static int greatNum;
    private static int goodNum;
    private static int missNum;

    private static int score;


    // Start is called before the first frame update
    void Start()
    {
        comboText = combo.GetComponent<TextMeshProUGUI>();
        comboNum = 0;
        maxCombo = 0;
        perfectNum = 0;
        greatNum = 0;
        goodNum = 0;
        missNum = 0;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        comboText.text = comboNum.ToString();
        if(comboNum >= maxCombo)
        {
            maxCombo = comboNum;
        }
    }

    //コンボ加算
    public void AddCombo()
    {
        comboNum++;
    }

    //コンボリセット
    public void ComboReset()
    {
        comboNum = 0;
    }

    public static int getCombo()
    {
        return comboNum;
    }

    public static int getMaxCombo()
    {
        return maxCombo;
    }

    public void AddPerfect()
    {
        perfectNum++;
    }

    public static int getPerfect()
    {
        return perfectNum;
    }

    public void AddGreat()
    {
        greatNum++;
    }

    public static int getGreat()
    {
        return greatNum;
    }

    public void AddGood()
    {
        goodNum++;
    }

    public static int getGood()
    {
        return goodNum;
    }

    public void AddMiss()
    {
        missNum++;
    }

    public static int getMiss()
    {
        return missNum;
    }

    public void AddScore(int sc)
    {
        score += sc;
    }

    public static int getScore()
    {
        return score;
    }
}
