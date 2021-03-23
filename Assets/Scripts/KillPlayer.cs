using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    [SerializeField]Transform spawnPoint;

    void OnCollisionEnter2D(Collision2D coli)
    {
        if (coli.transform.CompareTag("Player"))
            coli.transform.position = spawnPoint.position;
    }
}
