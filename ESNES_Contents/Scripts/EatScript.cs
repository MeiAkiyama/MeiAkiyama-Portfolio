using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EatScript : MonoBehaviour
{
    [SerializeField] AudioClip startClip;
    [SerializeField] AudioClip eatClip;
    private bool isSound;

    [SerializeField] AudioSource _as;

    private GameObject BGMObject;

    // Start is called before the first frame update
    void Start()
    {
        _as = GetComponent<AudioSource>();
        _as.PlayOneShot(startClip);
        isSound = false;
        BGMObject = GameObject.Find("BGMObject");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Food"))
        {
            if (!isSound)
            {
                _as.PlayOneShot(eatClip);
                isSound = true;
                Invoke("ChangeScene", 1.5f);
            }
        }
    }

    private void ChangeScene()
    {
        Destroy(BGMObject);
        SceneManager.LoadScene("EndingScene");
    }
}
