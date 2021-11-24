using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
  enum EnemyState { BORN, WALK, DIE }
  EnemyState state = EnemyState.BORN;

  // lerp de Movimiento
  float startWalk = 0;
  float endWalk = 2 * Mathf.PI;
  float tWalk;
  float speedWalk;

  // lerp de Born
  Vector3 startBorn = new Vector3(0, 0, 0);
  Vector3 endBorn = new Vector3(1, 1, 1);
  float tBorn = 0;
  float speedBorn = 0.7f;

  // lerp de Die
  Vector3 startDie = new Vector3(1, 1, 1);
  Vector3 endDie = new Vector3(0, 0, 0);
  float tDie = 0;
  float speedDie = 1f;

  float direction;

  void Start()
  {
    direction = Random.Range(0, 2) == 0 ? 1 : -1;
    tWalk = Random.Range(0.0f, 1.0f);
    speedWalk = Random.Range(0.05f, 0.15f);
  }

  void Update()
  {
    switch (state)
    {
      case EnemyState.BORN:
        Born();
        break;
      case EnemyState.WALK:
        Walk();
        break;
      case EnemyState.DIE:
        Die();
        break;
    }
  }

  void Die()
  {
    /** lerp de crecimiento **/
    transform.localScale = Vector3.LerpUnclamped(startDie, endDie, Easing.EaseInBack(tDie));
    tDie += Time.deltaTime * speedDie;

    if (tDie >= 1)
    {
      Destroy(gameObject);
    }

    /** Paso de coordenadas polares a cartesianas **/
    float angle = Mathf.Lerp(startWalk, endWalk, tWalk);
    float radius = 2.5f;

    float x = radius * Mathf.Cos(angle);
    float y = radius * Mathf.Sin(angle);

    transform.position = new Vector3(x, y, 0);
    transform.up = transform.position - Vector3.zero;
  }

  void Born()
  {
    /** lerp de crecimiento **/
    transform.localScale = Vector3.LerpUnclamped(startBorn, endBorn, Easing.EaseOutBack(tBorn));
    tBorn += Time.deltaTime * speedBorn;

    if (tBorn >= 1)
    {
      state = EnemyState.WALK;
    }

    /** Paso de coordenadas polares a cartesianas **/
    float angle = Mathf.Lerp(startWalk, endWalk, tWalk);
    float radius = 2.5f;

    float x = radius * Mathf.Cos(angle);
    float y = radius * Mathf.Sin(angle);

    transform.position = new Vector3(x, y, 0);
    transform.up = transform.position - Vector3.zero;
  }

  void Walk()
  {
    /** Lógica de movimiento **/
    tWalk += direction * speedWalk * Time.deltaTime;
    if (tWalk > 1) tWalk -= 1;
    if (tWalk < 0) tWalk += 1;

    /** Paso de coordenadas polares a cartesianas **/
    float angle = Mathf.Lerp(startWalk, endWalk, tWalk);
    float radius = 2.5f;

    float x = radius * Mathf.Cos(angle);
    float y = radius * Mathf.Sin(angle);

    transform.position = new Vector3(x, y, 0);
    transform.up = transform.position - Vector3.zero;

    /** Lógica de muerte **/
    for (int i = 0; i < Global.bullets.Count; i++)
    {
      // verificar la colisión con cada bullet
      GameObject bullet = Global.bullets[i];
      float distance = Vector3.Distance(transform.position, bullet.transform.position);
      if (distance < 0.3f)
      {
        Global.bullets.Remove(bullet);
        Destroy(bullet);
        state = EnemyState.DIE;
      }
    }
  }
}