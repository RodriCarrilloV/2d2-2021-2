using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
  Vector3 startPosition = new Vector3(-7, -3, 0);
  Vector3 endPosition = new Vector3(-3, -3, 0);
  float tPosition = 0;
  float speedPosition = 0.1f;
  public bool isActive;
  public bool canShoot;

  void Start()
  {
    transform.position = startPosition;
  }

  void Update()
  {
    if (!isActive) return;

    // se obtiene la dirección hacia donde apunta el cañón
    Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    mousePosition.z = 0;
    Vector3 direction = mousePosition - transform.position;
    transform.up = direction;

    // si se preciona barra espaciadora se dispara
    if (Input.GetMouseButtonDown(0) && canShoot)
    {
      Instantiate(Resources.Load("Bullet1") as GameObject);
      canShoot = false;
    }

    // // se mueve al jugador
    tPosition += Input.GetAxis("Horizontal") * speedPosition;
    tPosition = Mathf.Clamp(tPosition, 0, 1);

    transform.position = Vector3.Lerp(startPosition, endPosition, tPosition);
  }
}
