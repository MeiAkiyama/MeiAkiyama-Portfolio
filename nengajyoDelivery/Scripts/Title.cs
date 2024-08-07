using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    [SerializeField] GameObject panel;  //�����p�l��
    [SerializeField] GameObject title;  //�^�C�g������
    [SerializeField] GameObject setumeiButton;//�����{�^��
    [SerializeField] GameObject easyButton; //�C�[�W�[�{�^��
    [SerializeField] GameObject normalButton;   //�m�[�}���{�^��
    [SerializeField] GameObject hardButton; //�n�[�h�{�^��
    [SerializeField] GameObject human;  //�l

    // Start is called before the first frame update
    void Start()
    {
        panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void easyOnClick()
    {
        SceneManager.LoadScene("Game_easy");
    }

    public void normalOnClick()
    {
        SceneManager.LoadScene("Game_normal");
    }

    public void hardOnClick()
    {
        SceneManager.LoadScene("Game_hard");
    }

    public void setumeiOnClick()
    {
        panel.SetActive(true);
        title.SetActive(false);
        setumeiButton.SetActive(false);
        easyButton.SetActive(false);
        normalButton.SetActive(false);
        hardButton.SetActive(false);
        human.SetActive(false);
    }

    public void returnOnClick()
    {
        panel.SetActive(false);
        title.SetActive(true);
        setumeiButton.SetActive(true);
        easyButton.SetActive(true);
        normalButton.SetActive(true);
        hardButton.SetActive(true);
        human.SetActive(true);
    }
}
