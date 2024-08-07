using Oculus.Interaction.HandGrab;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CropedPotato : MonoBehaviour
{
    private Rigidbody rb;
    private differencePotato potato;
    private bool isdifarence;
    public GameObject thisObj;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        isdifarence = false;
        potato = thisObj.gameObject.GetComponent<differencePotato>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //�}���痣�ꂽ�痎����悤�ɂ���
    private void OnTriggerExit(Collider other)
    {
        GameObject plant = other.gameObject;
        if (plant==thisObj)
        {
            if (!isdifarence)
            {
                //potato.PotatoCounter();
                this.transform.parent = null;
                rb.drag = 5;
                rb.constraints = RigidbodyConstraints.None;
                isdifarence=true;
            }  
        } 
    }

    //���ɓ��ꂽ���̏���
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("box"))
        {
            //�͂߂Ȃ��悤�ɂ���
            this.GetComponent<HandGrabInteractable>().enabled = false;
            //�J�E���g
            potato.PotatoCounter();
        }
    }
}
