using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Performance : MonoBehaviour
{
    [SerializeField] AudioSource _as;

    // Start is called before the first frame update
    void Start()
    {
        _as = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //�p�[�e�B�N���Đ�
    public void playParticle(ParticleSystem particle)
    {
        particle.Play();
    }

    //���ʉ��Đ�
    public void playSoundEffect(AudioClip clip)
    {
        _as.PlayOneShot(clip);
    }
}
