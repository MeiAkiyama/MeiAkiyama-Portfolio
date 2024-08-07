using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    [SerializeField] Transform startPos;
    [SerializeField] Transform endPos;
    public float speed = 50f;//���x
    private float director = 1f;//����

    private float targetPos_x;
    private int point;//���_

    //��
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip Plusclip;
    [SerializeField] AudioClip MinusClip;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //�ʒu�̕ύX�A�ړ�
        targetPos_x = transform.position.x;
        transform.position = new Vector3(targetPos_x -= speed * director * Time.deltaTime,
                                                transform.position.y, transform.position.z);
        if(targetPos_x < endPos.transform.position.x)
        {
            director = -1f;
        }
        if(targetPos_x > startPos.transform.position.x)
        {
            director = 1f;
        }
    }

    public int GetPoint()
    {
        point = Random.Range(-2,5)*10;
        return point;
    }

    public void OnHitBullet(int p)
    {
        if(p > 0)
        {
            audioSource.PlayOneShot(Plusclip);
        }
        else
        {
            audioSource.PlayOneShot(MinusClip);
        }
        
    }
}
