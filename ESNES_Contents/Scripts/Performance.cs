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

    //パーティクル再生
    public void playParticle(ParticleSystem particle)
    {
        particle.Play();
    }

    //効果音再生
    public void playSoundEffect(AudioClip clip)
    {
        _as.PlayOneShot(clip);
    }
}
