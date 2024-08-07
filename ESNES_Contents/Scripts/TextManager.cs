using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextManager : MonoBehaviour
{
    [SerializeField] StateManager stateManager;//状態管理のスクリプト
    [SerializeField] Sprite[] barImage;
    [SerializeField] Sprite[] TODOImage;
    [SerializeField] Sprite[] calenderImage;

    public SpriteRenderer barSpriteRenderer;    //進行バーのスプライトレンダラー
    public SpriteRenderer todoSpriteRenderer;   //TODOのレンダラー
    public SpriteRenderer calenderSpriteRenderer;//カレンダーのレンダラー
 
    // Start is called before the first frame update
    void Start()
    {
        stateManager.GetComponent<StateManager>();
        //barSpriteRenderer = GetComponent<SpriteRenderer>();
        //todoSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //UI変更
        if (stateManager.GetState() == StateManager.STATE.START)
        {
            barSpriteRenderer.sprite = barImage[0];
            todoSpriteRenderer.sprite = TODOImage[0];
            calenderSpriteRenderer.sprite = calenderImage[0];
        }
        else if (stateManager.GetState() == StateManager.STATE.SOIL)
        {
            barSpriteRenderer.sprite = barImage[1];
            todoSpriteRenderer.sprite = TODOImage[1];
        }
        else if (stateManager.GetState() == StateManager.STATE.ARRANGE)
        {
            barSpriteRenderer.sprite = barImage[2];
            todoSpriteRenderer.sprite = TODOImage[2];
        }
        else if (stateManager.GetState() == StateManager.STATE.CUT)
        {
            barSpriteRenderer.sprite = barImage[3];
            todoSpriteRenderer.sprite = TODOImage[3];
        }
        else if(stateManager.GetState() == StateManager.STATE.PLANT)
        {
            barSpriteRenderer.sprite = barImage[4];
            todoSpriteRenderer.sprite = TODOImage[4];
            calenderSpriteRenderer.sprite = calenderImage[1];
        }
        else if(stateManager.GetState() == StateManager.STATE.GRASS)
        {
            barSpriteRenderer.sprite = barImage[5];
            todoSpriteRenderer.sprite = TODOImage[5];
            calenderSpriteRenderer.sprite = calenderImage[2];
        }
        else if(stateManager.GetState()== StateManager.STATE.BUG)
        {
            barSpriteRenderer.sprite = barImage[6];
            todoSpriteRenderer.sprite = TODOImage[6];
        }
        else if(stateManager.GetState()== StateManager.STATE.ILL)
        {
            barSpriteRenderer.sprite = barImage[7];
            todoSpriteRenderer.sprite = TODOImage[7];
        }
        else if(stateManager.GetState() == StateManager.STATE.CROP)
        {
            barSpriteRenderer.sprite = barImage[8];
            todoSpriteRenderer.sprite = TODOImage[8];
            calenderSpriteRenderer.sprite = calenderImage[3];
        }
        else if(stateManager.GetState()== StateManager.STATE.BOX)
        {
            barSpriteRenderer.sprite = barImage[9];
            todoSpriteRenderer.sprite = TODOImage[9];
        }else if(stateManager.GetState()==StateManager.STATE.END)
        {
            barSpriteRenderer.sprite= barImage[10];
            todoSpriteRenderer.sprite = TODOImage[9];
        }
    }
}
