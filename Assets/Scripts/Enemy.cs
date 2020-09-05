using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody rbBolt;
    private Spawner spwnr;
    [SerializeField]
    private int health;
    private TowerGun tGun;

    public int number = 0;

    private void Awake()
    {
        rbBolt = GetComponent<Rigidbody>();
    }
    void Start()
    {
        rbBolt.velocity = -transform.forward * speed;
    }
    public void GetSpawner(Spawner spawner)
    {
        spwnr = spawner;
    }
    public void NewPosition()
    {
        transform.position = spwnr.Position();
    }
    public void SetSpeed(float speed)
    {
        this.speed = speed; 
    }
    private void OnTriggerEnter(Collider coll)
    {
        if (coll.transform.CompareTag("Bullet") && tGun != null)
        {
            health--;
            if (health == 0)
            {
                tGun.Kill(transform);
                Destroy(gameObject);
            }
        }
    }
    public void SetTower(TowerGun tGun)
    {
        this.tGun = tGun;
    }
    public void SetNumber(int number)
    {
        this.number = number;
    }
    public int GetNumber()
    {
        return number;
    }
}
