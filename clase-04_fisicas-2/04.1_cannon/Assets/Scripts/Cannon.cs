using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        Vector3 direction = mousePosition - transform.position;
        transform.up = direction;

        if (Input.GetMouseButtonDown(0)) {
            Instantiate(Resources.Load("Particle") as GameObject);
        }
    }
}
