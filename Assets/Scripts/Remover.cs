using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Remover : MonoBehaviour
{
    void OnTriggerEnter(Collider coll)
    {
        if (coll.transform.CompareTag("Enemy"))
        {
            coll.transform.GetComponent<Enemy>().NewPosition();
        }
    }
}
