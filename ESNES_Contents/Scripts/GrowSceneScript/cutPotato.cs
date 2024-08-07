//using Oculus.Interaction.PoseDetection.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cutPotato : MonoBehaviour
{
    GameObject stateManager;
    StateManager sm;

    public GameObject potato;       //���Ⴊ�����I�u�W�F�N�g
    GameObject potatoSpawnPosition;  //���Ⴊ���������ʒu
    public GameObject halfPotato_L;   //�����̂��Ⴊ�����I�u�W�F�N�gL
    public GameObject halfPotato_R;   //�����̂��Ⴊ�����I�u�W�F�N�gR

    //�����̂��Ⴊ�����̐����ʒu
    GameObject halfPotatoSpawnPos_L;
    GameObject halfPotatoSpawnPos_R;

    //���Ⴊ�����̐����ʒu��ۑ�����Vector3�ϐ�
    private Vector3 pos_L;
    private Vector3 pos_R;

    private Quaternion rotatoL;
    private Quaternion rotatoR;

    private int counter;            //���񂶂Ⴊ������؂�����
    public int potatoNum = 4;       //���񂶂Ⴊ������؂邩

    public float spawnInterval = 2.0f;  //���Ⴊ������؂��Ă��牽�b��ɂ��Ⴊ�����𐶐����邩

    [SerializeField] AudioClip cutClip;
    [SerializeField] AudioSource _as;

    public GameObject[] modelObject;


    // Start is called before the first frame update
    void Start()
    {
        counter = 0;
        _as.GetComponent<AudioSource>();
        

        //�I�u�W�F�N�g��T��
        potatoSpawnPosition = GameObject.Find("potatoSpawner");
        halfPotatoSpawnPos_L = GameObject.Find("CutpotatoSpawner_L");
        halfPotatoSpawnPos_R = GameObject.Find("CutpotatoSpawner_R");
        stateManager = GameObject.Find("SceneManager");

        pos_L = halfPotatoSpawnPos_L.transform.position;
        pos_R = halfPotatoSpawnPos_R.transform.position;

        rotatoL = halfPotatoSpawnPos_L.transform.rotation;
        rotatoR = halfPotatoSpawnPos_R.transform.rotation;

        sm = stateManager.GetComponent<StateManager>();
        spawnPotato();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Material")
        {
            _as.PlayOneShot(cutClip);
            Destroy(collision.gameObject);
            counter++;
            spawnHalfPoato();
            if (counter < potatoNum)
            {    
                StartCoroutine(waitAndPotatoSpawn(spawnInterval));
            }
            else 
            { 
                sm.SetState(StateManager.STATE.PLANT);
                this.gameObject.GetComponent<Collider>().enabled = false;
                foreach(var i in modelObject)
                {
                    i.GetComponent<Renderer>().enabled = false;
                }
                Destroy(this.gameObject,1);
            }
            
        }
    }

    //���Ⴊ�����������\�b�h
    public void spawnPotato()
    {
        Instantiate(potato, potatoSpawnPosition.transform);
    }

    //�����̂��Ⴊ�����������\�b�h
    public void spawnHalfPoato()
    {
        //Instantiate(halfPotato,pos_L,Quaternion.Euler(0,-90,0));
        //Instantiate(halfPotato,pos_R,Quaternion.Euler(0,90,0));
        Instantiate(halfPotato_L,pos_L,rotatoL);
        Instantiate(halfPotato_R,pos_R,rotatoR);
    }

    //���Ⴊ���������R���[�`��
    //�����F���Ⴊ�������؂��Ă��牽�b��ɐ������邩
    public IEnumerator waitAndPotatoSpawn(float second)
    {
        //�w��b���҂�
        yield return new WaitForSeconds(second);
        spawnPotato();
    }
}
