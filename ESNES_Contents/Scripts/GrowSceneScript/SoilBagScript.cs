using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoilBagScript : MonoBehaviour
{
    //土袋が接触する範囲にアタッチするスクリプト
    //土袋が接触したらエフェクトを出して土袋を破棄
    //土の色を茶色にする
    //土を掘るステートに移動
    //茶色にしたらこのスクリプト（オブジェクトを破棄）

    public StateManager stateManager;       //ステート管理コンポーネント
    [SerializeField] Material soilColor;    //土の色
    public Performance performance;         //演出用コンポーネント

    [SerializeField] GameObject soilBagShadow;  //半透明の土袋
    [SerializeField] ParticleSystem particle;   //パーティクル
    //[SerializeField] AudioClip _clip;           //音
    public GameObject soilGround;               //土のエリア

    public GameObject SoilBag;
    public Transform SoilBagSpaner;

    void Start()
    {
        Instantiate(SoilBag, SoilBagSpaner);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Soil")
        {
            //エリアのコライダー・レンダラー無視
            //this.gameObject.GetComponent<MeshRenderer>().enabled = false;
            this.gameObject.GetComponent<Collider>().enabled = false;
            //パーティクル再生
            performance.playParticle(particle);
            //音再生
            //performance.playSoundEffect(_clip);
            //色変更
            soilGround.GetComponent<Renderer>().material.color = soilColor.color;
            //ステート変更
            stateManager.SetState(StateManager.STATE.ARRANGE);
            //オブジェクトの破棄
            Destroy(soilBagShadow);
            //Destroy(particle);
            Destroy(collision.gameObject,0.5f);
            Destroy(gameObject, 1);

        }
    }
}
