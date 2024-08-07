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

    //枝から離れたら落ちるようにする
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

    //箱に入れた時の処理
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("box"))
        {
            //掴めないようにする
            this.GetComponent<HandGrabInteractable>().enabled = false;
            //カウント
            potato.PotatoCounter();
        }
    }
}
