using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ClickAndJudge : MonoBehaviour
{
    public lineManager lj;
    lineManager.lineColors color;


    public void OnClicked()
    {
        color = this.gameObject.GetComponent<lineColor>().getColor();
        Debug.Log(color);
        if(lj.getColor() == color)
        {
            SceneManager.LoadScene("ClearScene");
        }
        else
        {
            SceneManager.LoadScene("GameOverScene");
        }
    }


}
