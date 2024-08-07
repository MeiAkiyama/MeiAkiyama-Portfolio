using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameState : MonoBehaviour
{
    [SerializeField] GameObject bottleGenerator;//�{�g�������ӏ�
    [SerializeField] GameObject titleText;//�^�C�g���e�L�X�g
    [SerializeField] GameObject titleImage;
    [SerializeField] GameObject timeText;
    [SerializeField] GameObject time;//�^�C��
    [SerializeField] GameObject scoreText;
    [SerializeField] GameObject score;//�X�R�A�e�L�X�g
    [SerializeField] GameObject result;//���U���g�e�L�X�g
    [SerializeField] GameObject resultScore;//���U���g�X�R�A�e�L�X�g
    [SerializeField] GameObject StartObject;//�X�^�[�g�I�u�W�F�N�g
    [SerializeField] GameObject startText;//�X�^�[�g�e�L�X�g
    [SerializeField] GameObject gunMan;//�ۈ����I�u�W�F�N�g
    
    public enum STATE
    {
        TITLE,//�^�C�g��
        GAMESCENE,//�Q�[���V�[��
        RESULT//���U���g
    }
    public STATE state;

    // Start is called before the first frame update
    void Start()
    {
        //������Ԃ��^�C�g��
        SetState(STATE.TITLE);
    }

    //��ԑJ�ڂ��Ǘ�
    public void SetState(STATE _state)
    {
        Debug.Log("��ԑJ�ڊJ�n");
        Debug.Log(_state);

        switch (_state)
        {
            case STATE.TITLE:
                StartObject.SetActive(true);
                titleText.SetActive(true);
                titleImage.SetActive(true);
                startText.SetActive(true);
                Debug.Log("State��ݒ�");
                break;

            case STATE.GAMESCENE:
                Debug.Log(state);
                StartObject.SetActive(false);
                titleText.SetActive(false);
                titleImage.SetActive(false);
                startText.SetActive(false);
                timeText.SetActive(true);
                time.SetActive(true);
                scoreText.SetActive(true);
                score.SetActive(true);
                bottleGenerator.SetActive(true);
                gunMan.SetActive(true);
                Debug.Log("State��ݒ�");
                break;
            case STATE.RESULT:
                timeText.SetActive(false);
                time.SetActive(false);
                scoreText.SetActive(false);
                score.SetActive(false);
                bottleGenerator.SetActive(false);
                result.SetActive(true);
                resultScore.SetActive(true);
                gunMan.SetActive (false);
                Debug.Log("State��ݒ�");
                break;
        }
        Debug.Log("��ԑJ�ڏI��");
        state = _state;
    }

    public STATE GetSTATE()
    {
        return state;
    }
}
