using System.Collections;
using System.Collections.Generic;
using System.Net;
using TMPro;
using UnityEngine;

public class Note : MonoBehaviour
{
    /*
     * ���FW
     * �L�FA
     * �������FS
     * ���܁FD
     * ����FF
     * ���FG
     */

    private float speed=5.8f;
    [SerializeField] GameObject judgeObject;
    private float judgePos_x;
    private float distance;

    private bool isSEPlay = false;//SE���Đ�����Ă��邩�ǂ���
    private bool isJudged = false;//���肳��Ă��邩�ǂ���
    private bool isLife = false;//���蕶�����������Ă��邩�ǂ���
    private bool isCombo = false;//�R���{�����Z���Ă��邩�ǂ���

    AudioSource audioSource;
    public AudioClip clearClip;
    public AudioClip goodClip;
    public AudioClip missClip;

    [SerializeField] GameObject gameMaster;
    GameMaster gm;

    public GameObject perfect;
    public GameObject great;
    public GameObject good;
    public GameObject miss;

    GameObject text;

    private int PerfectScore = 100;
    private int GreatScore = 50;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        gm = gameMaster.GetComponent<GameMaster>();
        judgePos_x = judgeObject.transform.position.x;
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-speed*Time.deltaTime,0,0);
        distance = Mathf.Abs(judgePos_x-this.transform.position.x);
        
        //����p�I�u�W�F�N�g�ƐڐG���Ă����
        if(distance< 2.45)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                if(this.gameObject.tag == "dog_w")
                {
                    judged(distance);
                }
                else
                {
                    judged(6);
                }
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                if (this.gameObject.tag == "cat_a")
                {
                    judged(distance);
                }
                else
                {
                    judged(6);
                }
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                if (this.gameObject.tag == "rabbit_s")
                {
                    judged(distance);
                }
                else
                {
                    judged(6);
                }
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                if (this.gameObject.tag == "bear_d")
                {
                    judged(distance);
                }
                else
                {
                    judged(6);
                }
            }
            else if (Input.GetKeyDown(KeyCode.F))
            {
                if (this.gameObject.tag == "monkey_f")
                {
                    judged(distance);
                }
                else
                {
                    judged(6);
                }
            }
            else if (Input.GetKeyDown(KeyCode.G))
            {
                if (this.gameObject.tag == "fish_g")
                {
                    judged(distance);
                }
                else
                {
                    judged(6);
                }
            }
        }
        else if(this.transform.position.x< judgePos_x - 2.45 && !isJudged)
        {
            //SE�A����\���ƃR���{������1��̂ݍs��
            if (!isSEPlay)
            {
                gm.ComboReset();
                judged(2.5f);
                playSE(2.5f);
                isSEPlay = true;
            }
            
            //��ʊO�֏o����Destroy
            if (this.transform.position.x < -10.5f)
            {
                Destroy(this.gameObject,1);
            }
        }
    }

    //�L�[�����������̋����������Ƃ������胁�\�b�h
    public void judged(float dis)
    {
        isJudged = true;
        
        if (dis <= 0.2f)
        {
            Debug.Log("Perfect");
            if (!isCombo)
            {
                gm.AddCombo();
                gm.AddPerfect();
                gm.AddScore(PerfectScore);
                isCombo = true;
            }
            
            text = perfect;
        }
        else if(dis <= 1.23f)
        {
            Debug.Log("Great");
            if (!isCombo)
            {
                gm.AddCombo();
                gm.AddGreat();
                gm.AddScore(GreatScore);
                isCombo = true;
            }
            
            text = great;
        }
        else if(dis < 2.45f)
        {
            Debug.Log("Good");
            if (!isCombo)
            {
                gm.ComboReset();
                gm.AddGood();
                isCombo = true;
            }
            
            text = good;
        }
        else
        {
            if (!isCombo)
            {
                Debug.Log("miss");
                gm.ComboReset();
                gm.AddMiss();
                text = miss;
                isCombo = true;
            }
            
        }

        GameObject judgeUI;
        GameObject mini_judgeUI;

        if (!isLife)
        {
            judgeUI = Instantiate(text, new Vector3(3.5f, 3f, 0), Quaternion.identity);
            mini_judgeUI = Instantiate(text, new Vector3(-6.5f, 0.4f, 0),Quaternion.identity);
            mini_judgeUI.transform.localScale = new Vector3(0.55f, 0.55f, 0.55f);
            isLife = true;
            playSE(dis);
            this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            Destroy(this.gameObject, 1);
            Destroy(judgeUI, 1);
            Destroy(mini_judgeUI, 1);
        }
    }

    //�����������Ƃ��A�����ɂ���ĉ���炷���\�b�h
    public void playSE(float dis)
    {
        if(dis <= 1.23f)
        {
            audioSource.PlayOneShot(clearClip);
        }
        else if(dis <= 2.45f)
        {
            audioSource.PlayOneShot(goodClip);
        }
        else
        {
            audioSource.PlayOneShot(missClip);
        }
    }
}
