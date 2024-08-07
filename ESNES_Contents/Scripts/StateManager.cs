using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class StateManager : MonoBehaviour
{
    public enum STATE
    {
        START,      //開始ステート
        SOIL,       //土袋
        ARRANGE,    //土を整える
        CUT,        //種いもを切る
        PLANT,      //植える
        BUG,        //害虫フェーズ
        GRASS,      //雑草イベント
        ILL,        //疫病フェーズ
        GROW,       //育てる
        CROP,       //収穫
        BOX,        //箱に入れる
        END         //育てるフェーズの終了
    }
    public STATE state;
    //public Performance ps;
    [SerializeField] AudioClip timeClip;
    [SerializeField] AudioSource _as;

    public GameObject soilBag;
    public Transform soilBagSpawner;

    public GameObject box;
    public Transform boxSpawner;

    public GameObject potatoBox;
    public Transform potatoBoxSpawner;

    [SerializeField] GameObject ichiba;
    [SerializeField] GameObject arrows;
    // Start is called before the first frame update
    void Start()
    {
        SetState(STATE.START);
        _as = GetComponent<AudioSource>();
    }

    //状態を設定するメソッド
    //引数に次の状態のenumを入れる
    public void SetState(STATE _state)
    {
        switch (_state)
        {
            case STATE.START:
                if(state == STATE.START) { return; }
                state = STATE.START;
                Instantiate(soilBag,soilBagSpawner);
                break;
            case STATE.SOIL:
                if(state == STATE.SOIL) { return; }
                state = STATE.SOIL;
                break;
            case STATE.ARRANGE:
                if(state == STATE.ARRANGE) { return; }
                state = STATE.ARRANGE;
                arrows.SetActive(true);
                _as.PlayOneShot(timeClip);
                break;
            case STATE.CUT:
                if(state == STATE.CUT) { return; }
                state = STATE.CUT;
                arrows.SetActive(false);
                _as.PlayOneShot(timeClip);
                break;
            case STATE.PLANT:
                if(state == STATE.PLANT) {  return; }
                state = STATE.PLANT;
                _as.PlayOneShot(timeClip);
                break;
            case STATE.GRASS:
                if (state == STATE.GRASS) { return; }
                state = STATE.GRASS;
                _as.PlayOneShot(timeClip);
                break;
            case STATE.BUG:
                if(state == STATE.BUG) { return; }
                state = STATE.BUG;
                _as.PlayOneShot(timeClip);
                break;
            case STATE.ILL:
                if(state == STATE.ILL) { return; }
                state = STATE.ILL;
                _as.PlayOneShot(timeClip);
                break;
            case STATE.GROW:
                if(state == STATE.GROW) {  return; }
                state = STATE.GROW;
                _as.PlayOneShot(timeClip);
                break;
            case STATE.CROP:
                if(state == STATE.CROP) {  return; }
                state = STATE.CROP;
                _as.PlayOneShot(timeClip);
                break;
            case STATE.BOX:
                if(state == STATE.BOX) { return; }
                state = STATE.BOX;
                Instantiate(box, boxSpawner);
                _as.PlayOneShot(timeClip); break;
            case STATE.END:
                if(state == STATE.END) { return; }
                state = STATE.END;
                Instantiate(potatoBox, potatoBoxSpawner);
                Destroy(box);
                ichiba.SetActive(true);
                _as.PlayOneShot(timeClip);
                break;

        }
    }

    //現在の状態を取得するメソッド
    public STATE GetState()
    {
        return state;
    }
}
