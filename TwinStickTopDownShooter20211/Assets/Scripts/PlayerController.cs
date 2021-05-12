using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Factory = FactoryController;

public class PlayerController : Rigidbody2DBase
{
    public int Hp { get; protected set; }

    public GameObject bulletPrefab;

    [SerializeField]
    private Transform bulletRespawn;

    

    private float speed = 2f;

    public float Horizontal { get; protected set; }
    public float Vertical { get; protected set; }
    public bool Fire { get; protected set; }

    private bool FindTransform(Transform tf)
    {
        return tf.name.Contains("BulletRespawn");
    }

    protected override void Awake()
    {
        base.Awake();

        //List<Transform> transforms = new List<Transform>(GetComponentsInChildren<Transform>());
        //bulletRespawn = transforms.Find(FindTransform);
        bulletRespawn = tf.Find("BulletRespawn");
    }
    public void SetInput(float horizontal, float vertical, bool fire)
    {
        Horizontal = horizontal;
        Vertical = vertical;
        Fire = fire;
    }

    private void Update()
    {
        if(Fire)
        {
            Vector3 rotation = bulletRespawn.rotation.eulerAngles;

            Factory.GetObject("bullet", bulletRespawn.position, Quaternion.Euler(rotation.x,rotation.y,rotation.z - 10));
            Factory.GetObject("bullet", bulletRespawn.position, bulletRespawn.rotation);
            Factory.GetObject("bullet", bulletRespawn.position, Quaternion.Euler(rotation.x, rotation.y, rotation.z + 10));
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(Horizontal, Vertical) * speed;
    }
}
