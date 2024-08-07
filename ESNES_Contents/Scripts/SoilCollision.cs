using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoilCollision : MonoBehaviour
{
    /*
     * ����ōk������
     * �A����ʒu�̕\��
     */

    public StateManager stateManager;   //�X�e�[�g�Ǘ�
    public Performance performance;     //���o

    public GameObject kuwa;                     //����̃I�u�W�F�N�g
    public Transform kuwaSpawner;               //����̏o���ʒu
    [SerializeField] ParticleSystem particle;   //�p�[�e�B�N��
    [SerializeField] AudioClip clip;     //�k�����Ƃ��̉�
    [SerializeField] AudioClip grow_1;  //�����i�K1
    [SerializeField] AudioClip grow_2;  //�����i�K2
    private bool isSE;
    private bool isSE_Grow2;

    public GameObject houtyo;       //��I�u�W�F�N�g
    public Transform houtyoSpawner; //������ʒu

    public int arrangeCount = 5;  //�k������
    private int arrangeCounter = 0;
    private bool kuwaLife;
    public Material ground;       //�k������̒n�ʂ̃}�e���A��

    private GameObject kuwaObj; //�����private�ϐ�

    public GameObject PlantPositionGroupe;  //�A����ꏊ�̃I�u�W�F�N�g
    public GameObject GrassPositionGroupe;  //�G���̏ꏊ��ێ�����I�u�W�F�N�g
    public GameObject PlantObjectGroupe;    //�A�������̂̃I�u�W�F�N�g(Collider����)
    public GameObject BigPlantObject;       //���������A�������̂̃I�u�W�F�N�g
    public GameObject BugObjectGroupe;      //�Q���I�u�W�F�N�g�O���[�v
    
    // Start is called before the first frame update
    void Start()
    {
        kuwaLife = false;
        isSE = false;
        isSE_Grow2 = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (stateManager.GetState() == StateManager.STATE.ARRANGE)
        {
            if(!kuwaLife)
            {
                kuwaObj = Instantiate(kuwa, kuwaSpawner.transform);
                kuwaLife = true;
            }
            if (arrangeCounter >= arrangeCount)
            {
                this.gameObject.GetComponent<Renderer>().material.color = ground.color;
                Instantiate(houtyo, houtyoSpawner.transform);
                Destroy(kuwaObj);
                stateManager.SetState(StateManager.STATE.CUT);
            }
        }
        //�A����ʒu�̕\��
        if(stateManager.GetState()==StateManager.STATE.PLANT)
        {
            PlantPositionGroupe.SetActive(true);
        }
        //�G���Ɖ�̕\��
        if (stateManager.GetState() == StateManager.STATE.GRASS)
        {
            if (!isSE)
            {
                performance.playSoundEffect(grow_1);
                isSE = true;
            }
            PlantObjectGroupe.SetActive(true);
            GrassPositionGroupe.SetActive(true);
        }
        //�Q���C�x���g���n�܂�ۂ̏���
        if(stateManager.GetState()==StateManager.STATE.BUG)
        {
            Destroy(PlantObjectGroupe);
            if (!isSE_Grow2)
            {
                performance.playSoundEffect(grow_2);
                isSE_Grow2 = true;
            }
            BugObjectGroupe.SetActive(true);
            BigPlantObject.SetActive(true);
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "kuwa")
        {
            arrangeCounter++;
            performance.playSoundEffect(clip);
        }
    }
}
