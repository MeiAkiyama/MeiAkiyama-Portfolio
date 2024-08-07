using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoxCollision : MonoBehaviour
{
    private int counter;
    public int MaxPotatoNum = 24;

    private StateManager stateManager;

    public GameObject potatoBox;
    private Transform potatoBoxSpawner;

    private bool isStateChange;

    public GameObject rootObject;


    // Start is called before the first frame update
    void Start()
    {
        counter = 0;
        stateManager = GameObject.Find("SceneManager").GetComponent<StateManager>();
        //potatoBoxSpawner = GameObject.Find("PotatoBoxSpawner").GetComponent<Transform>();
        isStateChange = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(stateManager.GetState()==StateManager.STATE.BOX)
        {
            if (counter == MaxPotatoNum)
            {
                isStateChange = true;
                stateManager.SetState(StateManager.STATE.END);
            }
        }
        if(isStateChange)
        {
            Destroy(rootObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CropObject"))
        {
            counter++;
            Destroy(other.gameObject);
        }
    }
}
