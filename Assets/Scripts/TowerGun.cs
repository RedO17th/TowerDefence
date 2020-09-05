using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerGun : MonoBehaviour
{
    private Transform tower;
    private Transform gun;
    [SerializeField] float speedBulets;
    [SerializeField] private Transform shot;
    [Range(0.2f, 0.5f)]
    [SerializeField] private float fireRate;
    private float nextFire;

    private Quaternion originalRotation;

    private List<Transform> listEnemy = new List<Transform>();
    private List<int> hashEnemies = new List<int>();
    private bool isEnd = true;
    [SerializeField] float speedRotTower = 0.05f;

    void Awake()
    {
        tower = transform.GetChild(0);
        gun = tower.transform.GetChild(0);
        originalRotation = tower.localRotation;
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Enemy") && IsEnemy(col.transform.GetComponent<Enemy>().GetNumber()))
        {
            Debug.Log("Добавили");
            col.transform.GetComponent<Enemy>().SetTower(this);
            int hash = Random.Range(0, 100);
            hashEnemies.Add(hash);
            col.transform.GetComponent<Enemy>().SetNumber(hash);
            listEnemy.Add(col.transform);
            isEnd = false;
        }

    }
    void Update()
    {
        if (!isEnd)
        {

            if (listEnemy.Count != 0)
            {
                tower.transform.LookAt(listEnemy[0]);

                if (Time.time > nextFire)
                {
                    Shoot();
                }
            }
            else
            {
                tower.rotation = Quaternion.Lerp(tower.rotation, originalRotation, Time.time * speedRotTower);
                if (tower.rotation.Equals(originalRotation))
                {
                    Debug.Log("Враги закончились...");
                    isEnd = true;
                }
            }
        }
    }
    private void Shoot()
    {
        nextFire = Time.time + fireRate;
        GameObject bullet = Instantiate(shot, gun.position, gun.rotation).gameObject;
        bullet.GetComponent<Bolt>().SetSpeed(speedBulets);
    }
    public void Kill(Transform item)
    {
        listEnemy.Remove(item);
    }
    private bool IsEnemy(int hash)
    {
        for (int i = 0; i < hashEnemies.Count; i++)
        {
            if (hashEnemies[i] == hash)
            {
                Debug.Log("Совпал враг");
                return false;
            }
        }
        return true;
    }


}
