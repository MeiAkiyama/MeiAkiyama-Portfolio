using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JudjeScript : MonoBehaviour
{
    [SerializeField] GameObject perfect;
    [SerializeField] GameObject great;
    [SerializeField] GameObject good;
    [SerializeField] GameObject miss;
    private float timer = 0;
    public float lifetime = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //�����������Ƃ�������\�����\�b�h
    public void GreadJudge(float dis)
    {
        timer += Time.deltaTime;
        if (dis <= 0.125f)
        {
            perfect.SetActive(true);
        }
        else if (dis <= 0.375f)
        {
            great.SetActive(true);
        }
        else if (dis <= 0.625f)
        {
            good.SetActive(true);
        }
        else
        {
            miss.SetActive(true);
        }

        if (timer > lifetime)
        {
            perfect.SetActive(false);
            great.SetActive(false);
            good.SetActive(false);
            miss.SetActive(false);
            timer = 0;
        }
    }

    public void missJudge()
    {
        timer += Time.deltaTime;
        miss.SetActive(true);
        if(timer > lifetime)
        {
            miss.SetActive(false) ;
        }
    }
}
