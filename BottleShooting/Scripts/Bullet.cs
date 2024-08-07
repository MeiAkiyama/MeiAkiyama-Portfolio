using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;   //弾の速度
    [SerializeField] GameObject otherParticle;//他オブジェクトに当たった時のパーティクル
    private GameObject bottleParticle;//ボトルのパーティクル
    private float timer;
    public GameObject gameMaster;
    //public GameState gameState;

    //音
    [SerializeField] AudioSource audiosource;
    [SerializeField] AudioClip bulletClip;
    //[SerializeField] AudioClip OtherClip;

    //コンポーネント
    Bottle bottle;
    TargetController target;
    BottleGenerator bg;
    GameMaster master;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        master = gameMaster.GetComponent<GameMaster>();
        audiosource = gameObject.GetComponent<AudioSource>();

        //弾を撃つ
        //前方向の速度ベクトルを計算
        Vector3 velocity = speed * transform.forward;

        //コンポーネント取得
        Rigidbody rb = GetComponent<Rigidbody>();

        //初速を加える
        rb.AddForce (velocity,ForceMode.VelocityChange);

        audiosource.PlayOneShot(bulletClip);
    }

    // Update is called once per frame
    void Update()
    {
        //3秒経ったら自動的に弾オブジェクトを破棄
        timer += Time.deltaTime; 
        if (timer > 3) 
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("当たった");
        if (collision.gameObject.tag == "Bullet") return;

        if (collision.gameObject.tag == "OtherObject")
        {
            Debug.Log("壁か床に当たった");
            if (otherParticle != null)
            {
                //パーティクル再生
                Instantiate(otherParticle, transform.position, Quaternion.identity);
            }
        }
        else
        {
            if (collision.gameObject.tag == "Bottle")
            {
                Debug.Log("ボトルに当たった");
                //Bottleコンポーネントを取得
                bottle = collision.gameObject.GetComponent<Bottle>();
                //得点加算
                master.AddPoint(bottle.GetPoint());
                //演出処理
                bottle.OnHitBullet();
            }
            else if (collision.gameObject.tag == "Target")
            {
                //コンポーネント取得
                target = collision.gameObject.GetComponent<TargetController>();
                master.AddPoint(target.GetPoint());
                //音を鳴らす、パーティクル再生
            }
            //相手オブジェクトの削除
            collision.gameObject.GetComponent<BoxCollider>().enabled = false;
            collision.gameObject.GetComponent<Renderer>().enabled = false;
            Destroy(collision.gameObject,1);
            Debug.Log("オブジェクトを破棄した");
        }
        //自オブジェクトの削除
        gameObject.GetComponent<BoxCollider>().enabled = false;
        gameObject.GetComponent<Renderer>().enabled = false;

        Destroy(gameObject,1);
    }
}
