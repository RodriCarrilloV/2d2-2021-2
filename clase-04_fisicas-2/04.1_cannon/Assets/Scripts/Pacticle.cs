using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pacticle : MonoBehaviour
{
    Vector3 velocity = new Vector3(0, 0, 0);
    Vector3 acceleration = new Vector3(0, -10, 0);
    Vector3 mousePosition;

    float speed = 5;

    void Start()
    {
      // punto de origen
      transform.position = GameObject.Find("Tip").transform.position;

      // se calcula posición del mouse
      mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
      mousePosition.z = 0;

      // se calcula la velocidad
      velocity = (mousePosition - transform.position).normalized * speed;
    }

    void Update()
    {
        // se aplica las físicas
        velocity += acceleration * Time.deltaTime;
        transform.position += velocity * Time.deltaTime;
    }

    void OnBecameInvisible()
    {
      Destroy(gameObject);
    }
}