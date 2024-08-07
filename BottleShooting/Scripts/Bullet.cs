using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;   //�e�̑��x
    [SerializeField] GameObject otherParticle;//���I�u�W�F�N�g�ɓ����������̃p�[�e�B�N��
    private GameObject bottleParticle;//�{�g���̃p�[�e�B�N��
    private float timer;
    public GameObject gameMaster;
    //public GameState gameState;

    //��
    [SerializeField] AudioSource audiosource;
    [SerializeField] AudioClip bulletClip;
    //[SerializeField] AudioClip OtherClip;

    //�R���|�[�l���g
    Bottle bottle;
    TargetController target;
    BottleGenerator bg;
    GameMaster master;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        master = gameMaster.GetComponent<GameMaster>();
        audiosource = gameObject.GetComponent<AudioSource>();

        //�e������
        //�O�����̑��x�x�N�g�����v�Z
        Vector3 velocity = speed * transform.forward;

        //�R���|�[�l���g�擾
        Rigidbody rb = GetComponent<Rigidbody>();

        //������������
        rb.AddForce (velocity,ForceMode.VelocityChange);

        audiosource.PlayOneShot(bulletClip);
    }

    // Update is called once per frame
    void Update()
    {
        //3�b�o�����玩���I�ɒe�I�u�W�F�N�g��j��
        timer += Time.deltaTime; 
        if (timer > 3) 
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("��������");
        if (collision.gameObject.tag == "Bullet") return;

        if (collision.gameObject.tag == "OtherObject")
        {
            Debug.Log("�ǂ����ɓ�������");
            if (otherParticle != null)
            {
                //�p�[�e�B�N���Đ�
                Instantiate(otherParticle, transform.position, Quaternion.identity);
            }
        }
        else
        {
            if (collision.gameObject.tag == "Bottle")
            {
                Debug.Log("�{�g���ɓ�������");
                //Bottle�R���|�[�l���g���擾
                bottle = collision.gameObject.GetComponent<Bottle>();
                //���_���Z
                master.AddPoint(bottle.GetPoint());
                //���o����
                bottle.OnHitBullet();
            }
            else if (collision.gameObject.tag == "Target")
            {
                //�R���|�[�l���g�擾
                target = collision.gameObject.GetComponent<TargetController>();
                master.AddPoint(target.GetPoint());
                //����炷�A�p�[�e�B�N���Đ�
            }
            //����I�u�W�F�N�g�̍폜
            collision.gameObject.GetComponent<BoxCollider>().enabled = false;
            collision.gameObject.GetComponent<Renderer>().enabled = false;
            Destroy(collision.gameObject,1);
            Debug.Log("�I�u�W�F�N�g��j������");
        }
        //���I�u�W�F�N�g�̍폜
        gameObject.GetComponent<BoxCollider>().enabled = false;
        gameObject.GetComponent<Renderer>().enabled = false;

        Destroy(gameObject,1);
    }
}
