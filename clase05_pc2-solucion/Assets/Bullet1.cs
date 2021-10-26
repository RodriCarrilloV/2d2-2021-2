using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet1 : MonoBehaviour
{
  Vector3 velocity = new Vector3(10, 10, 0);
  Vector3 acceleration = new Vector3(0, -9.8f, 0);
  float speed = 10;

  void Start()
  {
    // se obtiene la posición inicial
    transform.position = GameObject.Find("Tip1").transform.position;

    // se calcula la velocidad
    Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    mousePosition.z = 0;
    Vector3 direction = mousePosition - GameObject.Find("Player1").transform.position;

    velocity = direction.normalized * speed;
  }

  void Update()
  {
    // se aplican las físicas
    transform.position += velocity * Time.deltaTime;
    velocity += acceleration * Time.deltaTime;

    // verifica si colisionó con el Player 2
    float distance = Vector3.Distance(transform.position, GameObject.Find("Player2").transform.position);
    if (distance < 0.5f)
    {
      GameObject.Find("GameManager").GetComponent<GameManager>().ActivateTurnPlayer2();
      Destroy(gameObject);
    }
  }

  void OnBecameInvisible()
  {
    Destroy(gameObject);
    GameObject.Find("GameManager").GetComponent<GameManager>().ActivateTurnPlayer2();
  }
}
