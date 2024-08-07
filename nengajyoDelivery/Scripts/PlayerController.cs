using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rg;
    public float speed = 0.1f; //���x
    private bool isjump=false;//�W�����v���Ă��邩�ǂ���
    public GameObject director;

    //���֌W
    AudioSource audioSource;
    [SerializeField] AudioClip kasoku;
    [SerializeField] AudioClip gensoku;
    [SerializeField] AudioClip touchHouse;
    [SerializeField] AudioClip jump;

    GameDirector gameDirector;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        rg = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        gameDirector = director.GetComponent<GameDirector>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            //�v���C���[���}�C�i�X�����Ɍ����Ă���̂Ń}�C�i�X�̒l
            transform.Translate(-this.speed, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isjump)
            {
                audioSource.PlayOneShot(jump);
                rg.AddForce(new Vector3(0, 500, 0), ForceMode2D.Force);
                isjump = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        other.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        if (other.gameObject.tag == "house")
        {
            //���ʉ��炷
            audioSource.PlayOneShot(touchHouse);
            //�������炷���\�b�h
            gameDirector.numDecrease();
        }
        if(other.gameObject.tag == "batu")
        {
            //�V�[���J��
            SceneManager.LoadScene("GameOver");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "ground")
        {
            isjump = false;
        }

        if(collision.gameObject.tag == "moti")
        {
            this.speed += 0.05f;//�X�s�[�h2�{
            collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            collision.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            audioSource.PlayOneShot(kasoku);
            Destroy(collision.gameObject,0.5f);
        }
        else if(collision.gameObject.tag == "dragon")
        {
            this.speed /= 1.5f;//����
            collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            collision.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            audioSource.PlayOneShot(gensoku);
            Destroy(collision.gameObject, 0.5f);
        }

        if(collision.gameObject.tag == "goal")
        {
            if (gameDirector.getnum() != 0)
            {
                SceneManager.LoadScene("GameOver");
            }
            else
            {
                if (SceneManager.GetActiveScene().name == "Game_easy")
                {
                    SceneManager.LoadScene("Result_easy");
                }
                else if(SceneManager.GetActiveScene().name == "Game_normal")
                {
                    SceneManager.LoadScene("Result_normal");
                }
                else if (SceneManager.GetActiveScene().name == "Game_hard")
                {
                    SceneManager.LoadScene("Result_hard");
                }
            }
        }
    }
}
