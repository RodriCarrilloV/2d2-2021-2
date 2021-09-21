using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pacticle : MonoBehaviour
{
    Vector3 velocity = new Vector3(0, 0, 0);
    Vector3 acceleration = new Vector3(0, 0, 0);

    void Update()
    {
        // calculo de velocidad para que se dirija al mouse
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;

        velocity = (mousePosition - transform.position) * 1f;

        velocity += acceleration * Time.deltaTime;
        transform.position += velocity * Time.deltaTime;         
    }
}