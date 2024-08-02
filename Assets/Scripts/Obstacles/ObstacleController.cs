using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            transform.position = 
                new Vector3(Random.Range(-5.54f,7.2f),transform.position.y, Random.Range(-2.10f, 4f));
        }
    }
}
