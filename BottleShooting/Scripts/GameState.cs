using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameState : MonoBehaviour
{
    [SerializeField] GameObject bottleGenerator;//ボトル生成箇所
    [SerializeField] GameObject titleText;//タイトルテキスト
    [SerializeField] GameObject titleImage;
    [SerializeField] GameObject timeText;
    [SerializeField] GameObject time;//タイム
    [SerializeField] GameObject scoreText;
    [SerializeField] GameObject score;//スコアテキスト
    [SerializeField] GameObject result;//リザルトテキスト
    [SerializeField] GameObject resultScore;//リザルトスコアテキスト
    [SerializeField] GameObject StartObject;//スタートオブジェクト
    [SerializeField] GameObject startText;//スタートテキスト
    [SerializeField] GameObject gunMan;//保安官オブジェクト
    
    public enum STATE
    {
        TITLE,//タイトル
        GAMESCENE,//ゲームシーン
        RESULT//リザルト
    }
    public STATE state;

    // Start is called before the first frame update
    void Start()
    {
        //初期状態をタイトル
        SetState(STATE.TITLE);
    }

    //状態遷移を管理
    public void SetState(STATE _state)
    {
        Debug.Log("状態遷移開始");
        Debug.Log(_state);

        switch (_state)
        {
            case STATE.TITLE:
                StartObject.SetActive(true);
                titleText.SetActive(true);
                titleImage.SetActive(true);
                startText.SetActive(true);
                Debug.Log("Stateを設定");
                break;

            case STATE.GAMESCENE:
                Debug.Log(state);
                StartObject.SetActive(false);
                titleText.SetActive(false);
                titleImage.SetActive(false);
                startText.SetActive(false);
                timeText.SetActive(true);
                time.SetActive(true);
                scoreText.SetActive(true);
                score.SetActive(true);
                bottleGenerator.SetActive(true);
                gunMan.SetActive(true);
                Debug.Log("Stateを設定");
                break;
            case STATE.RESULT:
                timeText.SetActive(false);
                time.SetActive(false);
                scoreText.SetActive(false);
                score.SetActive(false);
                bottleGenerator.SetActive(false);
                result.SetActive(true);
                resultScore.SetActive(true);
                gunMan.SetActive (false);
                Debug.Log("Stateを設定");
                break;
        }
        Debug.Log("状態遷移終了");
        state = _state;
    }

    public STATE GetSTATE()
    {
        return state;
    }
}
