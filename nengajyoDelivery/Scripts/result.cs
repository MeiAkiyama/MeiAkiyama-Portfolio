using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class result : MonoBehaviour
{
    public GameObject timeObject;//時間表示オブジェクト
    public GameObject bestTimeObject;//ベストタイムオブジェクト

    private TextMeshProUGUI timeText;
    private TextMeshProUGUI bestText;

    private float time;
    private float bestTime;

    //GameDirector gameDirector;

    // Start is called before the first frame update
    void Start()
    {
        //gameDirector = GetComponent<GameDirector>();
        time = GameDirector.getTime();
        timeText = timeObject.GetComponent<TextMeshProUGUI>();
        bestText = bestTimeObject.GetComponent<TextMeshProUGUI>();

        timeText.text = time.ToString("F2");

        if(SceneManager.GetActiveScene().name == "Result_easy")
        {
            bestTime = PlayerPrefs.GetFloat("BESTTIME_EASY", 100000000);
        }
        else if(SceneManager.GetActiveScene().name == "Result_normal")
        {
            bestTime = PlayerPrefs.GetFloat("BESTTIME_NORMAL", 100000000);
        }
        else if(SceneManager.GetActiveScene().name == "Result_hard")
        {
            bestTime = PlayerPrefs.GetFloat("BESTTIME_HARD", 100000000);
        }
        
    }

    // Update is called once per frame
    void Update()
    {      
        if (bestTime > time)
        {
            bestTime = time;
            if (SceneManager.GetActiveScene().name == "Result_easy")
            {
                PlayerPrefs.SetFloat("BESTTIME_EASY", bestTime);
            }
            else if (SceneManager.GetActiveScene().name == "Result_normal")
            {
                PlayerPrefs.SetFloat("BESTTIME_NORMAL", bestTime);
            }
            else if (SceneManager.GetActiveScene().name == "Result_hard")
            {
                PlayerPrefs.SetFloat("BESTTIME_HARD", bestTime);
            }
            PlayerPrefs.Save();
        }
        bestText.text = bestTime.ToString("F2");
    }

    public void returnTitle()
    {
        SceneManager.LoadScene("Title");
    }
}
