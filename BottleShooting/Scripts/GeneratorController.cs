using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorController : MonoBehaviour
{
    public float interval = 2.0f;//�o���Ԋu
    BottleGenerator[] generator;//�����ӏ��̃��X�g
    private float timer;//�o���܂ł̃^�C�}�[

    // Start is called before the first frame update
    void Start()
    {
        generator = GetComponentsInChildren<BottleGenerator>();
        
        //�S�Ẳӏ��Ń{�g������
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
            //�����_���ȉӏ��ɐ���
            int index = Random.Range(0, generator.Length);
            generator[index].BottleGenerate();

            timer = 0;
        }
    }
}
