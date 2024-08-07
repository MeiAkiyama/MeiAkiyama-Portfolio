using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ILLPlantCount : MonoBehaviour
{
    public ILLManager iLLManager;
    private bool isCount;
    // Start is called before the first frame update
    void Start()
    {
        isCount = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        if(!isCount)
        {
            iLLManager.ILLCounter();
            Debug.Log("èoÇΩ");
            isCount = true;
        }
        
        Destroy(gameObject,1);
    }
}
