using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    [SerializeField] GameObject panel;  //説明パネル
    [SerializeField] GameObject title;  //タイトル文字
    [SerializeField] GameObject setumeiButton;//説明ボタン
    [SerializeField] GameObject easyButton; //イージーボタン
    [SerializeField] GameObject normalButton;   //ノーマルボタン
    [SerializeField] GameObject hardButton; //ハードボタン
    [SerializeField] GameObject human;  //人

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
