//using Oculus.Interaction.PoseDetection.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cutPotato : MonoBehaviour
{
    GameObject stateManager;
    StateManager sm;

    public GameObject potato;       //じゃがいもオブジェクト
    GameObject potatoSpawnPosition;  //じゃがいも生成位置
    public GameObject halfPotato_L;   //半分のじゃがいもオブジェクトL
    public GameObject halfPotato_R;   //半分のじゃがいもオブジェクトR

    //半分のじゃがいもの生成位置
    GameObject halfPotatoSpawnPos_L;
    GameObject halfPotatoSpawnPos_R;

    //じゃがいもの生成位置を保存するVector3変数
    private Vector3 pos_L;
    private Vector3 pos_R;

    private Quaternion rotatoL;
    private Quaternion rotatoR;

    private int counter;            //何回じゃがいもを切ったか
    public int potatoNum = 4;       //何回じゃがいもを切るか

    public float spawnInterval = 2.0f;  //じゃがいもを切ってから何秒後にじゃがいもを生成するか

    [SerializeField] AudioClip cutClip;
    [SerializeField] AudioSource _as;

    public GameObject[] modelObject;


    // Start is called before the first frame update
    void Start()
    {
        counter = 0;
        _as.GetComponent<AudioSource>();
        

        //オブジェクトを探す
        potatoSpawnPosition = GameObject.Find("potatoSpawner");
        halfPotatoSpawnPos_L = GameObject.Find("CutpotatoSpawner_L");
        halfPotatoSpawnPos_R = GameObject.Find("CutpotatoSpawner_R");
        stateManager = GameObject.Find("SceneManager");

        pos_L = halfPotatoSpawnPos_L.transform.position;
        pos_R = halfPotatoSpawnPos_R.transform.position;

        rotatoL = halfPotatoSpawnPos_L.transform.rotation;
        rotatoR = halfPotatoSpawnPos_R.transform.rotation;

        sm = stateManager.GetComponent<StateManager>();
        spawnPotato();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Material")
        {
            _as.PlayOneShot(cutClip);
            Destroy(collision.gameObject);
            counter++;
            spawnHalfPoato();
            if (counter < potatoNum)
            {    
                StartCoroutine(waitAndPotatoSpawn(spawnInterval));
            }
            else 
            { 
                sm.SetState(StateManager.STATE.PLANT);
                this.gameObject.GetComponent<Collider>().enabled = false;
                foreach(var i in modelObject)
                {
                    i.GetComponent<Renderer>().enabled = false;
                }
                Destroy(this.gameObject,1);
            }
            
        }
    }

    //じゃがいも生成メソッド
    public void spawnPotato()
    {
        Instantiate(potato, potatoSpawnPosition.transform);
    }

    //半分のじゃがいも生成メソッド
    public void spawnHalfPoato()
    {
        //Instantiate(halfPotato,pos_L,Quaternion.Euler(0,-90,0));
        //Instantiate(halfPotato,pos_R,Quaternion.Euler(0,90,0));
        Instantiate(halfPotato_L,pos_L,rotatoL);
        Instantiate(halfPotato_R,pos_R,rotatoR);
    }

    //じゃがいも生成コルーチン
    //引数：じゃがいもが切られてから何秒後に生成するか
    public IEnumerator waitAndPotatoSpawn(float second)
    {
        //指定秒数待つ
        yield return new WaitForSeconds(second);
        spawnPotato();
    }
}
