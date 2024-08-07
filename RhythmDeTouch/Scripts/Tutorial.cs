using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    [SerializeField] AudioClip clips;
    AudioSource _as;
    [SerializeField] GameObject yokoku;
    [SerializeField] GameObject nextPanel;

    private float timer;
    public float limitTime = 1;
    public int panelNum=0;

    private bool isSE;
    private bool isPressed;
    private bool isPlaying;

    private Image m_image;//自分自身のimageコンポーネント

    // Start is called before the first frame update
    void Start()
    {
        _as = GetComponent<AudioSource>();
        timer = 0;
        isSE = false;
        isPressed = false;
        isPlaying = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (panelNum==0)
            {
                moveNextPanel(0);
            }
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            if(panelNum==1)
            {
                moveNextPanel(1);
            }
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            if(panelNum==2)
            {
                moveNextPanel(2);
            }
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            if(panelNum==3)
            {
                moveNextPanel(3);
            }
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            if(panelNum==4)
            {
                moveNextPanel(4);
            }
        }
        else if (Input.GetKeyDown(KeyCode.G))
        {
            if(panelNum==5 && !isPressed)
            {
                isPressed = true;
                if (!isSE)
                {
                    _as.PlayOneShot(clips);
                    isSE = true;
                }
                
            }
        }
        if (isPressed)
        {
            timer += Time.deltaTime;
            if (timer > limitTime)
            {
                SceneManager.LoadScene("Game");
            }
        }
    }

    public void moveNextPanel(int index)
    {
        if (!isPlaying)
        {
            _as.PlayOneShot(clips);
            isPlaying = true;
        }
        
        if(index == 4)
        {
            yokoku.SetActive(true);
        }
        Destroy(this.gameObject, 1f);
        nextPanel.SetActive(true);
    }
}
