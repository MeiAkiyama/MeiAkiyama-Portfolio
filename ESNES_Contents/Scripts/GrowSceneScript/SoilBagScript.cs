using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoilBagScript : MonoBehaviour
{
    //�y�܂��ڐG����͈͂ɃA�^�b�`����X�N���v�g
    //�y�܂��ڐG������G�t�F�N�g���o���ēy�܂�j��
    //�y�̐F�𒃐F�ɂ���
    //�y���@��X�e�[�g�Ɉړ�
    //���F�ɂ����炱�̃X�N���v�g�i�I�u�W�F�N�g��j���j

    public StateManager stateManager;       //�X�e�[�g�Ǘ��R���|�[�l���g
    [SerializeField] Material soilColor;    //�y�̐F
    public Performance performance;         //���o�p�R���|�[�l���g

    [SerializeField] GameObject soilBagShadow;  //�������̓y��
    [SerializeField] ParticleSystem particle;   //�p�[�e�B�N��
    //[SerializeField] AudioClip _clip;           //��
    public GameObject soilGround;               //�y�̃G���A

    public GameObject SoilBag;
    public Transform SoilBagSpaner;

    void Start()
    {
        Instantiate(SoilBag, SoilBagSpaner);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Soil")
        {
            //�G���A�̃R���C�_�[�E�����_���[����
            //this.gameObject.GetComponent<MeshRenderer>().enabled = false;
            this.gameObject.GetComponent<Collider>().enabled = false;
            //�p�[�e�B�N���Đ�
            performance.playParticle(particle);
            //���Đ�
            //performance.playSoundEffect(_clip);
            //�F�ύX
            soilGround.GetComponent<Renderer>().material.color = soilColor.color;
            //�X�e�[�g�ύX
            stateManager.SetState(StateManager.STATE.ARRANGE);
            //�I�u�W�F�N�g�̔j��
            Destroy(soilBagShadow);
            //Destroy(particle);
            Destroy(collision.gameObject,0.5f);
            Destroy(gameObject, 1);

        }
    }
}
