using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class StateManager : MonoBehaviour
{
    public enum STATE
    {
        START,      //�J�n�X�e�[�g
        SOIL,       //�y��
        ARRANGE,    //�y�𐮂���
        CUT,        //�킢����؂�
        PLANT,      //�A����
        BUG,        //�Q���t�F�[�Y
        GRASS,      //�G���C�x���g
        ILL,        //�u�a�t�F�[�Y
        GROW,       //��Ă�
        CROP,       //���n
        BOX,        //���ɓ����
        END         //��Ă�t�F�[�Y�̏I��
    }
    public STATE state;
    //public Performance ps;
    [SerializeField] AudioClip timeClip;
    [SerializeField] AudioSource _as;

    public GameObject soilBag;
    public Transform soilBagSpawner;

    public GameObject box;
    public Transform boxSpawner;

    public GameObject potatoBox;
    public Transform potatoBoxSpawner;

    [SerializeField] GameObject ichiba;
    [SerializeField] GameObject arrows;
    // Start is called before the first frame update
    void Start()
    {
        SetState(STATE.START);
        _as = GetComponent<AudioSource>();
    }

    //��Ԃ�ݒ肷�郁�\�b�h
    //�����Ɏ��̏�Ԃ�enum������
    public void SetState(STATE _state)
    {
        switch (_state)
        {
            case STATE.START:
                if(state == STATE.START) { return; }
                state = STATE.START;
                Instantiate(soilBag,soilBagSpawner);
                break;
            case STATE.SOIL:
                if(state == STATE.SOIL) { return; }
                state = STATE.SOIL;
                break;
            case STATE.ARRANGE:
                if(state == STATE.ARRANGE) { return; }
                state = STATE.ARRANGE;
                arrows.SetActive(true);
                _as.PlayOneShot(timeClip);
                break;
            case STATE.CUT:
                if(state == STATE.CUT) { return; }
                state = STATE.CUT;
                arrows.SetActive(false);
                _as.PlayOneShot(timeClip);
                break;
            case STATE.PLANT:
                if(state == STATE.PLANT) {  return; }
                state = STATE.PLANT;
                _as.PlayOneShot(timeClip);
                break;
            case STATE.GRASS:
                if (state == STATE.GRASS) { return; }
                state = STATE.GRASS;
                _as.PlayOneShot(timeClip);
                break;
            case STATE.BUG:
                if(state == STATE.BUG) { return; }
                state = STATE.BUG;
                _as.PlayOneShot(timeClip);
                break;
            case STATE.ILL:
                if(state == STATE.ILL) { return; }
                state = STATE.ILL;
                _as.PlayOneShot(timeClip);
                break;
            case STATE.GROW:
                if(state == STATE.GROW) {  return; }
                state = STATE.GROW;
                _as.PlayOneShot(timeClip);
                break;
            case STATE.CROP:
                if(state == STATE.CROP) {  return; }
                state = STATE.CROP;
                _as.PlayOneShot(timeClip);
                break;
            case STATE.BOX:
                if(state == STATE.BOX) { return; }
                state = STATE.BOX;
                Instantiate(box, boxSpawner);
                _as.PlayOneShot(timeClip); break;
            case STATE.END:
                if(state == STATE.END) { return; }
                state = STATE.END;
                Instantiate(potatoBox, potatoBoxSpawner);
                Destroy(box);
                ichiba.SetActive(true);
                _as.PlayOneShot(timeClip);
                break;

        }
    }

    //���݂̏�Ԃ��擾���郁�\�b�h
    public STATE GetState()
    {
        return state;
    }
}
