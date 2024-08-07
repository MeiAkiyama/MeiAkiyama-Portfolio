using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoilCollision : MonoBehaviour
{
    /*
     * くわで耕す処理
     * 植える位置の表示
     */

    public StateManager stateManager;   //ステート管理
    public Performance performance;     //演出

    public GameObject kuwa;                     //くわのオブジェクト
    public Transform kuwaSpawner;               //くわの出現位置
    [SerializeField] ParticleSystem particle;   //パーティクル
    [SerializeField] AudioClip clip;     //耕したときの音
    [SerializeField] AudioClip grow_1;  //成長段階1
    [SerializeField] AudioClip grow_2;  //成長段階2
    private bool isSE;
    private bool isSE_Grow2;

    public GameObject houtyo;       //包丁オブジェクト
    public Transform houtyoSpawner; //包丁生成位置

    public int arrangeCount = 5;  //耕す総数
    private int arrangeCounter = 0;
    private bool kuwaLife;
    public Material ground;       //耕した後の地面のマテリアル

    private GameObject kuwaObj; //くわのprivate変数

    public GameObject PlantPositionGroupe;  //植える場所のオブジェクト
    public GameObject GrassPositionGroupe;  //雑草の場所を保持するオブジェクト
    public GameObject PlantObjectGroupe;    //植えたもののオブジェクト(Collider無し)
    public GameObject BigPlantObject;       //成長した植えたもののオブジェクト
    public GameObject BugObjectGroupe;      //害虫オブジェクトグループ
    
    // Start is called before the first frame update
    void Start()
    {
        kuwaLife = false;
        isSE = false;
        isSE_Grow2 = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (stateManager.GetState() == StateManager.STATE.ARRANGE)
        {
            if(!kuwaLife)
            {
                kuwaObj = Instantiate(kuwa, kuwaSpawner.transform);
                kuwaLife = true;
            }
            if (arrangeCounter >= arrangeCount)
            {
                this.gameObject.GetComponent<Renderer>().material.color = ground.color;
                Instantiate(houtyo, houtyoSpawner.transform);
                Destroy(kuwaObj);
                stateManager.SetState(StateManager.STATE.CUT);
            }
        }
        //植える位置の表示
        if(stateManager.GetState()==StateManager.STATE.PLANT)
        {
            PlantPositionGroupe.SetActive(true);
        }
        //雑草と芽の表示
        if (stateManager.GetState() == StateManager.STATE.GRASS)
        {
            if (!isSE)
            {
                performance.playSoundEffect(grow_1);
                isSE = true;
            }
            PlantObjectGroupe.SetActive(true);
            GrassPositionGroupe.SetActive(true);
        }
        //害虫イベントが始まる際の処理
        if(stateManager.GetState()==StateManager.STATE.BUG)
        {
            Destroy(PlantObjectGroupe);
            if (!isSE_Grow2)
            {
                performance.playSoundEffect(grow_2);
                isSE_Grow2 = true;
            }
            BugObjectGroupe.SetActive(true);
            BigPlantObject.SetActive(true);
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "kuwa")
        {
            arrangeCounter++;
            performance.playSoundEffect(clip);
        }
    }
}
