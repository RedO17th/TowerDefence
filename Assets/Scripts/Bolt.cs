using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolt : MonoBehaviour
{
    private float speed;
    private Rigidbody rbBolt;
    private float waitDie = 2f;

    private void Awake()
    {
        rbBolt = GetComponent<Rigidbody>();
    }
    void Start()
    {
        rbBolt.velocity = transform.forward * speed;
    }
    void FixedUpdate()
    {
        waitDie -= Time.fixedDeltaTime;
        if (waitDie <= 0)
            Destroy(gameObject);
    }
    void OnTriggerEnter(Collider coll)
    {
        if (coll.transform.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
    public void SetSpeed(float speed)
    {
        this.speed = speed; 
    }
}
