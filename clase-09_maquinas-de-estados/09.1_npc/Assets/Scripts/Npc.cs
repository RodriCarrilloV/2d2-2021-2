using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc : MonoBehaviour
{
  enum PlayerState { BORN, MOVE, DIE };

  PlayerState state = PlayerState.BORN;

  // estado BORN
  Vector3 startBorn = new Vector3(0, 0, 0);
  Vector3 endBorn = new Vector3(1, 1, 1);
  float tBorn = 0;
  float speedBorn = 0.5f;

  // estado MOVE
  Vector3 startMove = new Vector3(-4, 0, 0);
  Vector3 endMove = new Vector3(4, 0, 1);
  float tMove = 0;
  float speedMove = 2;

  // estado DIE
  Vector3 startDie = new Vector3(1, 1, 1);
  Vector3 endDie = new Vector3(0, 0, 0);
  float tDie = 0;
  float speedDie = 0.5f;

  void Update()
  {
    switch (state)
    {
      case PlayerState.BORN:
        Born();
        break;

      case PlayerState.MOVE:
        Move();
        break;

      case PlayerState.DIE:
        Die();
        break;
    }
  }

  void Born()
  {
    // acción
    transform.position = startMove;
    transform.localScale = Vector3.Lerp(startBorn, endBorn, tBorn);
    tBorn += Time.deltaTime * speedBorn;

    // condiciones de salida
    if (tBorn >= 1)
    {
      state = PlayerState.MOVE;
    }
  }

  void Move()
  {
    // acción
    transform.position = Vector3.Lerp(startMove, endMove, tMove);
    tMove += Time.deltaTime * speedMove;

    // condiciones de salida
    if (tMove >= 1)
    {
      state = PlayerState.DIE;
    }
  }

  void Die()
  {
    // acción
    transform.position = endMove;
    transform.localScale = Vector3.Lerp(startDie, endDie, tDie);
    tDie += Time.deltaTime * speedDie;

    // condiciones de salida
    if (tDie >= 1)
    {
      Destroy(gameObject);
    }
  }
}
