using Oculus.Interaction.HandGrab;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugDestroyScript : MonoBehaviour
{
    public BugCounter bugCounter;
    private bool isCrop;

    // Start is called before the first frame update
    void Start()
    {
        isCrop = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        if(!isCrop)
        {
            bugCounter.AddCounter();
            Destroy(other.GetComponent<CapsuleCollider>());
            Invoke("DestroyBug", 1.5f);
            isCrop = true;
        }
    }

    private void DestroyBug()
    {
        Destroy(this.gameObject);
    }
}
