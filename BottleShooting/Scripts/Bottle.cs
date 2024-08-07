using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public enum bottleType
{
    Bottle1,
    Bottle2,
    Bottle3,
    Bottle4,
    Bottle5,
}
public class Bottle : MonoBehaviour
{
    [SerializeField] GameObject[] bottle;//�{�g���I�u�W�F�N�g���i�[
    public GameObject pariticle;//�p�[�e�B�N�����i�[
    [SerializeField] bottleType type;
    private BottleGenerator generator;

    [SerializeField] AudioSource audiosource;
    [SerializeField] AudioClip clip;

    private void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }

    //���_�擾
    public int GetPoint()
    {
        switch (type)
        {
            case bottleType.Bottle1: return 3;
            case bottleType.Bottle2: return 1;
            case bottleType.Bottle3: return 2;
            case bottleType.Bottle4: return 5;
            case bottleType.Bottle5: return 3;
            default:return 0;
        }
    }

    public void OnHitBullet()
    {
        if(pariticle != null)
        {
            Instantiate(pariticle,new Vector3(transform.position.x,transform.position.y+5,transform.position.z),Quaternion.identity);
        }
        //���̍Đ�
        audiosource.PlayOneShot(clip);
    }
}
