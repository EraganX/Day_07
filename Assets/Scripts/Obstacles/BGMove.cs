using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMove : MonoBehaviour
{
    public float speed = 5f;
    private PlayerController controller;

    [SerializeField] private float xAxis, zAxis;

    private void OnEnable()
    {
        controller = FindAnyObjectByType<PlayerController>();
    }

    void Update()
    {
        if (controller.isGameOver == false)
        {
            transform.Translate(new Vector3(0, 0, -1) * speed * Time.deltaTime);
        }

        if (transform.position.z < -10)
        {
            transform.position = new Vector3(-xAxis, 0, zAxis);
        }
    }
}
