using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Result : MonoBehaviour
{
    [SerializeField] GameObject comboTextObj;
    [SerializeField] GameObject comboNumObj;
    [SerializeField] GameObject fullComboObj;
    [SerializeField] GameObject APObj;
    private TextMeshProUGUI comboText;
    private int combo;

    [SerializeField] GameObject perfect;
    [SerializeField] GameObject great;
    [SerializeField] GameObject good;
    [SerializeField] GameObject miss;

    private TextMeshProUGUI perfectText;
    private TextMeshProUGUI greatText;
    private TextMeshProUGUI goodText;
    private TextMeshProUGUI missText;

    private int perfectNum;
    private int greatNum;
    private int goodNum;
    private int missNum;

    [SerializeField] GameObject scoreObj;
    private TextMeshProUGUI scoreText;
    private int scoreNum;

    // Start is called before the first frame update
    void Start()
    {
        comboText = comboNumObj.GetComponent<TextMeshProUGUI>();
        perfectText = perfect.GetComponent<TextMeshProUGUI>();
        greatText = great.GetComponent<TextMeshProUGUI>();
        goodText = good.GetComponent<TextMeshProUGUI>();
        missText = miss.GetComponent<TextMeshProUGUI>();
        scoreText = scoreObj.GetComponent<TextMeshProUGUI>();


        combo = GameMaster.getMaxCombo();
        perfectNum = GameMaster.getPerfect();
        greatNum = GameMaster.getGreat();
        goodNum = GameMaster.getGood();
        missNum = GameMaster.getMiss();
        scoreNum = GameMaster.getScore();

        if (perfectNum == 30)
        {
            APObj.SetActive(true);
        }
        else if(combo == 30)
        {
            fullComboObj.SetActive(true);
            comboTextObj.SetActive(false);
            comboNumObj.SetActive(false);
        }
        else
        {
            fullComboObj.SetActive(false);
            comboTextObj.SetActive(true) ;
            comboNumObj.SetActive(true) ;
        }

        perfectText.text = perfectNum.ToString();
        greatText.text = greatNum.ToString();
        goodText.text = goodNum.ToString();
        missText.text = missNum.ToString();
        comboText.text = combo.ToString();
        scoreText.text = scoreNum.ToString();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Title");
        }
    }
}
