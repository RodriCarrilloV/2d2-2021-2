using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  // lerp para el movimiento
  float startAngle = 0;
  float endAngle = 2 * Mathf.PI;
  public float tAngle = 0.25f;
  float speedAngle = 0.2f;

  // lerp para el salto
  float startJump = 2.5f;
  float endJump = 4;
  float tJump = 0;
  float speedJump = 2;

  bool isJumping = false;
  public float radius;

  void Update()
  {
    /** Lógica de movimiento **/
    // -- variación del tAngle
    float axisX = Input.GetAxis("Horizontal");
    tAngle -= axisX * speedAngle * Time.deltaTime;
    if (tAngle > 1) tAngle -= 1;
    if (tAngle < 0) tAngle += 1;

    // -- orientación del player
    if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
    {
      transform.localScale = new Vector3(-1, 1, 1);
    }

    if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
    {
      transform.localScale = new Vector3(1, 1, 1);
    }

    /** Lógica de salto **/
    // -- variación del tJump
    if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
    {
      if (!isJumping)
      {
        isJumping = true; // activar el salto
        tJump = 0; // reiniciar el tJump
      }
    }

    // -- si está en modo salto, se anima el lerp del salto hasta que termine
    if (isJumping)
    {
      tJump += speedJump * Time.deltaTime;
      if (tJump > 1)
      {
        isJumping = false;
      };
    }

    /** Disparo **/
    if (Input.GetKeyDown(KeyCode.Space))
    {
      GameObject bullet = Instantiate(Resources.Load("Bullet") as GameObject);
      Global.bullets.Add(bullet);
    }

    // coordenadas polares del player
    float angle = Mathf.Lerp(startAngle, endAngle, tAngle);
    radius = Mathf.Lerp(startJump, endJump, Easing.Parabolic(tJump));

    // coordenadas cartesianas del player
    float x = radius * Mathf.Cos(angle);
    float y = radius * Mathf.Sin(angle);

    // posición del player
    transform.position = new Vector3(x, y, 0);
    // dirección del player
    transform.up = transform.position - Vector3.zero;
  }
}
