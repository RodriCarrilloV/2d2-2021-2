using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  // lerp de salto
  float jumpHigh = 1.3f;
  float tJump = 0;
  float speedJump = 2;

  int currentPlanet = 1;

  // movimiento circular
  float radius;
  float angle = 0;
  float speed = 1;

  bool isJumping = false;
  bool isFalling = false;

  void Update()
  {
    // se incrementa o decrementa el ángulo de rotación
    // dependiento de la dirección pulsada
    angle -= Input.GetAxis("Horizontal") * Time.deltaTime * speed;

    // se transforma la coordenada polar en cartesiana
    float x = radius * Mathf.Cos(angle) + MapData.planets[currentPlanet].position.x;
    float y = radius * Mathf.Sin(angle) + MapData.planets[currentPlanet].position.y;

    // si se presiona UP, se activa el salto
    if (Input.GetKeyDown(KeyCode.UpArrow) && !isJumping)
    {
      isJumping = true;
    }

    // si el salto está activo
    if (isJumping)
    {
      // se calcula el radio con un lerp
      radius = Mathf.Lerp(MapData.planets[currentPlanet].radius, MapData.planets[currentPlanet].radius + jumpHigh, Easing.Parabolic(tJump));
      // se incrementa el tiempo de salto
      tJump += Time.deltaTime * speedJump;

      // si termina la animación
      if (tJump >= 1)
      {
        isJumping = false;
        tJump = 0;
      }

      // se verifica si se está colisionando con el área de gravedad de algún otro planeta
      for (int i = 0; i < MapData.planets.Count; i++)
      {
        if (i != currentPlanet)
        {
          float distance = Vector3.Distance(transform.position, MapData.planets[i].position);
          if (distance <= MapData.planets[i].gravityRadius) {
            // colisionó
            isFalling = true;
          }
        }
      }
    }
    // de lo contrario, se mantiene en el piso
    else
    {
      radius = MapData.planets[currentPlanet].radius;
    }

    // se actualiza la rotación del player
    Vector3 up = transform.position - MapData.planets[currentPlanet].position;

    // se actualiza la posición del jugador
    transform.position = new Vector3(x, y, 0);
    transform.up = up;
  }
}
