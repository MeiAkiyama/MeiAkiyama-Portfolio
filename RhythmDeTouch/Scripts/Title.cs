using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    private bool isPressed;//ÉLÅ[ÇâüÇµÇΩÇ©Ç«Ç§Ç©
    private float timer;
    public float sceneChangeTime = 2;
    AudioSource _as;
    [SerializeField] AudioClip startClip;

    private bool isPlaying = false;

    // Start is called before the first frame update
    void Start()
    {
        //Application.targetFrameRate = 60;
        _as = GetComponent<AudioSource>();
        timer = 0;
        isPressed = false;
        isPlaying = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isPlaying)
            {
                _as.PlayOneShot(startClip);
                isPlaying = true;
            }
            isPressed = true;
        }
        if (isPressed)
        {
            timer += Time.deltaTime;
            if (timer >= sceneChangeTime)
            {
                SceneManager.LoadScene("Tutorial");
            }
        }
    }
}
