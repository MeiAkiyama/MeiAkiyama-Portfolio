using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantSeed : MonoBehaviour
{
    /*
     * 種を植える場所のオブジェクトそれぞれにアタッチ
     */
    public Material seedGround;
    public SeedCounter seedCounter;
    public CropCounter cropCounter;

    [SerializeField] ParticleSystem particle;
    [SerializeField] AudioClip clip;
    [SerializeField] AudioSource _as;

    public bool isSeed = false;
    public bool dontClop = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("seed") && !isSeed)
        {
            _as.PlayOneShot(clip);
            this.gameObject.GetComponent<Renderer>().material.color = seedGround.color;
            seedCounter.PlantSeedCount();
            Destroy(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("IllLeaf"))
        {
            Destroy(other.gameObject,1.5f);
        }
        if (other.gameObject.CompareTag("CropObject"))
        {
            if (!dontClop)
            {
                cropCounter.CropPlantCount();
            }
        }
    }
}
