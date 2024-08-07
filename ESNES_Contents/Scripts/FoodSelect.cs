using System.Collections;
using System.Collections.Generic;
using Unity.Properties;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FoodSelect : MonoBehaviour
{
    private bool isPlay;        //演出を再生していいかのbool
    private bool isChange;

    private int materialCounter;
    private int counter;        //調理時の食材カウンター
    public int MaterialNumber;  //素材の数

    public float changeTime = 1.5f;             //シーン遷移までの時間
    //[SerializeField] ParticleSystem particle;   //再生するパーティクル
    [SerializeField] AudioClip _clip;           //再生する効果音

    private string SceneName;  //現在のシーンの名前

    public Performance ps;      //演出再生用スクリプト
    public OVRScreenFade fade;  //フェード用スクリプト

    public GameObject Material_1;   //野菜選択の樹形図
    public float DestoryTime = 1;   //樹形図が消えるまでの時間
    public GameObject Material_2;   //じゃがいも選択の樹形図

    private GameObject BGMObject;

    // Start is called before the first frame update
    void Start()
    {
        materialCounter = 1;
        isPlay = false;
        counter = 0;
        isChange = false;
        //現在のシーンの名前を取得
        SceneName = SceneManager.GetActiveScene().name;

        if(SceneName == "SelectMaterialScene")
        {
            BGMObject = GameObject.Find("BGMObject");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlay)
        {
            //パーティクル再生メソッドの呼び出し
            //ps.playParticle(particle);
            //効果音再生メソッドの呼び出し
            ps.playSoundEffect(_clip);
            isChange = true;
            isPlay = false;
        }
        if(isChange)
        {
            //シーン遷移の条件分岐処理
            switch (SceneName)
            {
                case "SelectFoodScene":
                    Invoke("CallSelectMaterialScene", changeTime);
                    break;
                case "SelectMaterialScene":
                    //fade.FadeOut();
                    Invoke("CallGrowScene", changeTime);
                    break;
                case "CookingScene":
                    Invoke("CallEatingScene", changeTime);
                    break;
            }
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        //触れたオブジェクトが料理の場合
        if(collision.gameObject.tag == "Food")
        {
            Debug.Log("test");
            //現在のシーンが料理選択または調理シーン、食べるシーンの場合
            if (SceneName == "SelectFoodScene")
            {
                isPlay = true;
            }
        }

        //触れたオブジェクトが素材の場合
        if(collision.gameObject.tag == "Material")
        {
            //素材選択シーンの場合
            if(SceneName == "SelectMaterialScene")
            {
                if (materialCounter == 1)
                {
                    //ps.playParticle(particle);
                    ps.playSoundEffect(_clip);
                    Destroy(Material_1);
                    Destroy(collision.gameObject,1);
                    Material_2.SetActive(true);
                    materialCounter++;
                    //isPlay = true;
                }
                else
                {
                    isPlay = true;
                } 
            }
            //料理シーンの場合
            else if(SceneName == "CookingScene")
            {
                counter++;
                if (counter < MaterialNumber)
                {
                    //パーティクル再生メソッドの呼び出し
                    //ps.playParticle(particle);
                    //効果音再生メソッドの呼び出し
                    ps.playSoundEffect(_clip);
                    Destroy(collision.gameObject,DestoryTime);
                }
                else
                {
                    isPlay = true;
                }
            }
        }
    }

    private void CallSelectMaterialScene()
    {
        SceneManager.LoadScene("SelectMaterialScene");
    }

    private void CallGrowScene()
    {
        Destroy(BGMObject);
        SceneManager.LoadScene("GrowScene");
    }

    public void CallEatingScene()
    {
        SceneManager.LoadScene("EatingScene");
    }

    public void CallEndingScene()
    {
        SceneManager.LoadScene("EndingScene");
    }
}
