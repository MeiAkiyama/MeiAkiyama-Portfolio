using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartObject : MonoBehaviour
{
    public GameState gameState;

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            gameState.SetState(GameState.STATE.GAMESCENE);
        }
    }
}
