using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    Vector3 velocity;
    Vector3 acceleration;
    float lifeTime = 0.5f;
    float lifeTimeVariation = 0.4f;
    float speed = 5;
    float timer = 0;

    void Start()
    {
        velocity = Random.insideUnitCircle * speed;
        acceleration = new Vector3(0, 0, 0);
    }

    void Update()
    {
        // incrementa el contador de tiempo
        timer += Time.deltaTime;
        if (timer > Random.Range((1 - lifeTimeVariation) * lifeTime, (1 + lifeTimeVariation) * lifeTime))
        {
          // acción
          Die();
        }

        float alpha = 1 - timer / lifeTime;
        GetComponent<Renderer>().material.color = new Color(1, 1, 1, alpha);
        
        velocity += acceleration * Time.deltaTime;
        transform.position += velocity * Time.deltaTime;
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
