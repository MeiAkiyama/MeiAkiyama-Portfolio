using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NoteGenerator30 : MonoBehaviour
{
    /*
     * 生成位置について
     * 1280*720:GameScene編集画面時:11で前半ズレ
     * 1280*720:GameScene最初から最大化:11.5で後半ズレ
     * 11.25が中間値
     */
    public float spawner_x = 11.5f;
    public GameObject judgeObj;
    private Transform judge_pos;
    public float delay_x = 0.5f;
    public GameObject[] notePrefab;
    private float interval;
    private float intervalTime;
    private int totalNum;
    private float bpm = 132;

    public float timer = 10;
    float time;
    private bool isfinish;
    private bool isdelay = false;

    AudioSource _as;
    [SerializeField] AudioClip finish;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        _as = GetComponent<AudioSource>();
        judge_pos = judgeObj.GetComponent<Transform>();
        isfinish = false;
        totalNum = 0;
        time = 0;
        intervalTime = 60.0f / bpm;
        SpawnNote();
    }

    // Update is called once per frame
    void Update()
    {
        interval += Time.deltaTime;
        if(totalNum>28)
        {
            time += Time.deltaTime;
            if (time >= 3.5 && !isfinish)
            {
                _as.PlayOneShot(finish);
                isfinish = true;
            }
            if (time > timer)
            {
                SceneManager.LoadScene("Result");
            }
        }
        else
        {
            if (totalNum < 9)
            {
                if (interval >= intervalTime * 8)
                {
                    SpawnNote();
                    interval = 0;
                    totalNum++;
                }
            }
            else
            {
                if (interval > intervalTime * 4)
                {
                    if (!isdelay)
                    {
                        delayNotes();
                        isdelay = true;
                    }
                    SpawnNote();
                    interval = 0;
                    totalNum++;
                }
            }
        }
        
    }

    //ノーツ生成
    public void SpawnNote()
    {
        int index = Random.Range(0, notePrefab.Length);

        Instantiate(notePrefab[index], new Vector3(spawner_x,judge_pos.position.y, 0), Quaternion.identity);
        
    }

    public void delayNotes()
    {
        spawner_x -= delay_x;
    }
}
