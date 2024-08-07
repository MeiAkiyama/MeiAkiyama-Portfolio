using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    [SerializeField] GameObject gameScore;//�Q�[�����̃X�R�A�I�u�W�F�N�g
    private Text scoreText;//�X�R�A�e�L�X�g
    [SerializeField] GameObject resultScore;//���U���g�X�R�A�I�u�W�F�N�g
    private Text resultScoreText;//���U���g�X�R�A��text�R���|�[�l���g
    static private int point;//���_
    [SerializeField] GameObject timer;//�^�C�}�[�I�u�W�F�N�g
    private Text timerText;//�c�莞�Ԃ�text�R���|�[�l���g
    private float timeCount;//��������
    public GameState state;
    public float resultTime;//���U���g�\������

    //��
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip clip;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        scoreText = gameScore.GetComponent<Text>();
        resultScoreText = resultScore.GetComponent<Text>();
        timerText = timer.GetComponent<Text>();
        point = 0;
        timeCount = 30f;
        resultTime = 0;
    }

    public void AddPoint(int p)
    {
        Debug.Log("AddPoint:" + p);
        point += p;
        Debug.Log("point:"+point);
    }

    public int GetPoint() { return point; }

    // Update is called once per frame
    void Update()
    {
        if(state.GetSTATE() == GameState.STATE.GAMESCENE)
        {
            //���Ԃ̌v�Z�E�\��
            timeCount -= Time.deltaTime;
            timerText.text = timeCount.ToString("f2");
            //�X�R�A�\��
            scoreText.text = point.ToString();
            //��ԑJ��
            if(timeCount < 0)
            {
                audioSource.PlayOneShot(clip);
                state.SetState(GameState.STATE.RESULT);
            }
        }
        if(state.GetSTATE() == GameState.STATE.RESULT)
        {
            resultTime+= Time.deltaTime;
            resultScoreText.text = point.ToString();//�X�R�A�\��
            //�V�[���̃��[�h
            if(resultTime > 10)
            {
                if(SceneManager.GetActiveScene().name == "TestScene")
                {
                    SceneManager.LoadScene("TestScene");
                }
                else
                {
                    if (SceneManager.GetActiveScene().name == "GameScene")
                    {
                        SceneManager.LoadScene("GameScene");
                    }
                }
                
            }
        }
    }
}
