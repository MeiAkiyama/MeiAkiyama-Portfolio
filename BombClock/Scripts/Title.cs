using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    public void startGame()
    {
        this.gameObject.GetComponent<AudioSource>().Play();
        Invoke("ChangeStartToGameScene", 1f);
    }

    private void ChangeStartToGameScene()
    {
        SceneManager.LoadScene("introductionScene");
    }
}
