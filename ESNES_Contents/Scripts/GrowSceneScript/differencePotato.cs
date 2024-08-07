using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class differencePotato : MonoBehaviour
{
    private int counter;
    public int MaxPotato = 4;
    private bool isdifference;
    // Start is called before the first frame update
    void Start()
    {
        counter = 0;
        isdifference = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(counter >= MaxPotato)
        {
            if (!isdifference)
            {
                //this.GetComponent<CapsuleCollider>().enabled = false;
                isdifference=true;
            }
        }
    }

    public void PotatoCounter()
    {
        counter++;
    }
}
