using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    [SerializeField] GameObject gameScore;//ゲーム中のスコアオブジェクト
    private Text scoreText;//スコアテキスト
    [SerializeField] GameObject resultScore;//リザルトスコアオブジェクト
    private Text resultScoreText;//リザルトスコアのtextコンポーネント
    static private int point;//得点
    [SerializeField] GameObject timer;//タイマーオブジェクト
    private Text timerText;//残り時間のtextコンポーネント
    private float timeCount;//制限時間
    public GameState state;
    public float resultTime;//リザルト表示時間

    //音
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip clip;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        scoreText = gameScore.GetComponent<Text>();
        resultScoreText = resultScore.GetComponent<Text>();
        timerText = timer.GetComponent<Text>();
        point = 0;
        timeCount = 30f;
        resultTime = 0;
    }

    public void AddPoint(int p)
    {
        Debug.Log("AddPoint:" + p);
        point += p;
        Debug.Log("point:"+point);
    }

    public int GetPoint() { return point; }

    // Update is called once per frame
    void Update()
    {
        if(state.GetSTATE() == GameState.STATE.GAMESCENE)
        {
            //時間の計算・表示
            timeCount -= Time.deltaTime;
            timerText.text = timeCount.ToString("f2");
            //スコア表示
            scoreText.text = point.ToString();
            //状態遷移
            if(timeCount < 0)
            {
                audioSource.PlayOneShot(clip);
                state.SetState(GameState.STATE.RESULT);
            }
        }
        if(state.GetSTATE() == GameState.STATE.RESULT)
        {
            resultTime+= Time.deltaTime;
            resultScoreText.text = point.ToString();//スコア表示
            //シーンのロード
            if(resultTime > 10)
            {
                if(SceneManager.GetActiveScene().name == "TestScene")
                {
                    SceneManager.LoadScene("TestScene");
                }
                else
                {
                    if (SceneManager.GetActiveScene().name == "GameScene")
                    {
                        SceneManager.LoadScene("GameScene");
                    }
                }
                
            }
        }
    }
}
