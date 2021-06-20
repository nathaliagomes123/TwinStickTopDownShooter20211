using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderController : MonoBehaviour
{
    public PlayerController playerController;

    void Start() 
    {
        playerController = GetComponent<PlayerController>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        Debug.Log(other.name);
        if (other.tag == "bullet")
        {
            playerController.Damage();
        } 
    }
}
