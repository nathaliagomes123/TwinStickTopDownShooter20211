using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField]
    private float Horizontal;
    [SerializeField]
    private float Vertical;
    [SerializeField]
    private bool Fire;
    [SerializeField]
    private bool Reload;
    [SerializeField]
    private PlayerController player;

    private void Awake()
    {
        player = GameObject.FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        Horizontal = Input.GetAxis("Horizontal");
        Vertical = Input.GetAxis("Vertical");

        Fire = Input.GetMouseButton(0);
        Reload = Input.GetMouseButton(1);


        player.SetInput(Horizontal, Vertical, Fire, Reload);
    }
}
