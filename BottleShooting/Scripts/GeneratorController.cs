using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorController : MonoBehaviour
{
    public float interval = 2.0f;//出現間隔
    BottleGenerator[] generator;//生成箇所のリスト
    private float timer;//出現までのタイマー

    // Start is called before the first frame update
    void Start()
    {
        generator = GetComponentsInChildren<BottleGenerator>();
        
        //全ての箇所でボトル生成
        foreach(var gen in generator)
        {
            gen.BottleGenerate();
        }

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(interval < timer)
        {
            //ランダムな箇所に生成
            int index = Random.Range(0, generator.Length);
            generator[index].BottleGenerate();

            timer = 0;
        }
    }
}
