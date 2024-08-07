using System.Collections;
using System.Collections.Generic;
using Unity.Properties;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FoodSelect : MonoBehaviour
{
    private bool isPlay;        //���o���Đ����Ă�������bool
    private bool isChange;

    private int materialCounter;
    private int counter;        //�������̐H�ރJ�E���^�[
    public int MaterialNumber;  //�f�ނ̐�

    public float changeTime = 1.5f;             //�V�[���J�ڂ܂ł̎���
    //[SerializeField] ParticleSystem particle;   //�Đ�����p�[�e�B�N��
    [SerializeField] AudioClip _clip;           //�Đ�������ʉ�

    private string SceneName;  //���݂̃V�[���̖��O

    public Performance ps;      //���o�Đ��p�X�N���v�g
    public OVRScreenFade fade;  //�t�F�[�h�p�X�N���v�g

    public GameObject Material_1;   //��ؑI���̎��`�}
    public float DestoryTime = 1;   //���`�}��������܂ł̎���
    public GameObject Material_2;   //���Ⴊ�����I���̎��`�}

    private GameObject BGMObject;

    // Start is called before the first frame update
    void Start()
    {
        materialCounter = 1;
        isPlay = false;
        counter = 0;
        isChange = false;
        //���݂̃V�[���̖��O���擾
        SceneName = SceneManager.GetActiveScene().name;

        if(SceneName == "SelectMaterialScene")
        {
            BGMObject = GameObject.Find("BGMObject");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlay)
        {
            //�p�[�e�B�N���Đ����\�b�h�̌Ăяo��
            //ps.playParticle(particle);
            //���ʉ��Đ����\�b�h�̌Ăяo��
            ps.playSoundEffect(_clip);
            isChange = true;
            isPlay = false;
        }
        if(isChange)
        {
            //�V�[���J�ڂ̏������򏈗�
            switch (SceneName)
            {
                case "SelectFoodScene":
                    Invoke("CallSelectMaterialScene", changeTime);
                    break;
                case "SelectMaterialScene":
                    //fade.FadeOut();
                    Invoke("CallGrowScene", changeTime);
                    break;
                case "CookingScene":
                    Invoke("CallEatingScene", changeTime);
                    break;
            }
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        //�G�ꂽ�I�u�W�F�N�g�������̏ꍇ
        if(collision.gameObject.tag == "Food")
        {
            Debug.Log("test");
            //���݂̃V�[���������I���܂��͒����V�[���A�H�ׂ�V�[���̏ꍇ
            if (SceneName == "SelectFoodScene")
            {
                isPlay = true;
            }
        }

        //�G�ꂽ�I�u�W�F�N�g���f�ނ̏ꍇ
        if(collision.gameObject.tag == "Material")
        {
            //�f�ޑI���V�[���̏ꍇ
            if(SceneName == "SelectMaterialScene")
            {
                if (materialCounter == 1)
                {
                    //ps.playParticle(particle);
                    ps.playSoundEffect(_clip);
                    Destroy(Material_1);
                    Destroy(collision.gameObject,1);
                    Material_2.SetActive(true);
                    materialCounter++;
                    //isPlay = true;
                }
                else
                {
                    isPlay = true;
                } 
            }
            //�����V�[���̏ꍇ
            else if(SceneName == "CookingScene")
            {
                counter++;
                if (counter < MaterialNumber)
                {
                    //�p�[�e�B�N���Đ����\�b�h�̌Ăяo��
                    //ps.playParticle(particle);
                    //���ʉ��Đ����\�b�h�̌Ăяo��
                    ps.playSoundEffect(_clip);
                    Destroy(collision.gameObject,DestoryTime);
                }
                else
                {
                    isPlay = true;
                }
            }
        }
    }

    private void CallSelectMaterialScene()
    {
        SceneManager.LoadScene("SelectMaterialScene");
    }

    private void CallGrowScene()
    {
        Destroy(BGMObject);
        SceneManager.LoadScene("GrowScene");
    }

    public void CallEatingScene()
    {
        SceneManager.LoadScene("EatingScene");
    }

    public void CallEndingScene()
    {
        SceneManager.LoadScene("EndingScene");
    }
}
