using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab;
    private GameObject enemy;
    [SerializeField]
    private Vector3 position;
    [Range(5, 30)]
    [SerializeField]  private int countEnemy;
    [Range(1, 3)]
    private float waitStart;
    [Range(1, 3)]
    private float waitEnemy;
    [SerializeField]
    private float maxSpeed = 3f;
    void Start()
    {
        StartCoroutine(StartInstantiate());
    }
    public Vector3 Position()
    {
        Vector3 vector = new Vector3(Random.Range(-position.x, position.x), position.y, position.z);
        return vector;
    }
    IEnumerator StartInstantiate()
    {
        yield return new WaitForSeconds(waitStart);
        for (int i = 0; i < countEnemy; i++)
        {
            enemy = Instantiate(prefab, Position(), Quaternion.identity);
            enemy.transform.GetComponent<Enemy>().GetSpawner(this);
            enemy.transform.GetComponent<Enemy>().SetSpeed(Random.Range(1f, maxSpeed));
            yield return new WaitForSeconds(waitEnemy);
        }
    }

}
