using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class retry : MonoBehaviour
{
    public void retryGame()
    {
        this.GetComponent<AudioSource>().Play();
        Invoke("SceneChange", 1);
    }

    public void SceneChange()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
