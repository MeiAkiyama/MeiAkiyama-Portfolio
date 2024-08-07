using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroyParticle : MonoBehaviour
{
    ParticleSystem particle;

    // Start is called before the first frame update
    void Start()
    {
        particle = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        if (particle.IsAlive() == false)
        {
            Destroy(gameObject);
        }
    }
}
