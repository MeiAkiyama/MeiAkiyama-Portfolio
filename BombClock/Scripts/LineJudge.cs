using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LineJudge : MonoBehaviour
{
    public lineManager lineMg;
    private lineManager.lineColors correctColor;

    // Start is called before the first frame update
    void Start()
    {
        //ê≥âÇÃêFäiî[
        correctColor = lineMg.getColor();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public lineManager.lineColors getCurrectColor()
    {
        return correctColor;
    }
}
