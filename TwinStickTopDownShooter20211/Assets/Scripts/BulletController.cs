using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Factory = FactoryController;

public class BulletController : Rigidbody2DBase, IPoolableObject
{
    private float speed = 5f;
    private float distance = 2f;
    private Vector2 startPosition;

    public void Recycle()
    {
        gameObject.SetActive(false);
    }

    public void TurnOn()
    {
        gameObject.SetActive(true);
    }

    private void Start()
    {
        startPosition = tf.position;
        rb.velocity = tf.up * speed;
    }

    private void Update()
    {
        if(Vector2.Distance(startPosition,tf.position) >= distance)
        {
            Factory.Recycle("bullet", gameObject);
        }
    }

}
