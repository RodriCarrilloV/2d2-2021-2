using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
  float direction;
  float radius;

  // lerp del movimiento
  float startAngle = 0;
  float endAngle = 2 * Mathf.PI;
  float tAngle;
  float speedAngle = 0.2f;

  // timer
  float timer = 0;
  const float LIFE_TIME = 1;

  void Start()
  {
    direction = -GameObject.Find("Player").transform.localScale.x;
    tAngle = GameObject.Find("Player").GetComponent<Player>().tAngle + direction * 0.04f;
    radius = GameObject.Find("Player").GetComponent<Player>().radius + 0.2f;

    Update();
  }

  void Update()
  {
    /** Timer **/
    timer += Time.deltaTime;
    if (timer > LIFE_TIME)
    {
      Global.bullets.Remove(gameObject);
      Destroy(gameObject);
    }

    /** Lógica de movimiento **/
    // -- variación del tAngle
    float angle = Mathf.Lerp(startAngle, endAngle, tAngle);
    tAngle += Time.deltaTime * speedAngle * direction;

    if (tAngle > 1) tAngle -= 1;
    if (tAngle < 0) tAngle += 1;

    float x = radius * Mathf.Cos(angle);
    float y = radius * Mathf.Sin(angle);

    transform.position = new Vector3(x, y, 0);
  }
}
