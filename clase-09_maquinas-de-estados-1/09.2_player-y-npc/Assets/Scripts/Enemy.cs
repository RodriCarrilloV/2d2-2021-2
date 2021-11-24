using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
  enum EnemyState { START_TO_END, END_TO_START, FOLLOW_PLAYER, GO_TO_START };
  EnemyState state = EnemyState.START_TO_END;

  Vector3 startPosition = new Vector3(-4, 0, 0);
  Vector3 endPosition = new Vector3(4, 0, 0);
  const float ATTACK_DISTANCE = 2.5f;
  const float EPSILON = 0.1f;

  // START_TO_END
  float tStartToEnd = 0;
  float speedStartToEnd = 1;

  // END_TO_START
  float tEndToStart = 0;
  float speedEndToStart = 1;

  // GO_TO_START
  Vector3 startPositionToStart;
  float tGoToStart = 0;
  float speedGoToStart = 1;

  void Update()
  {
    switch (state)
    {
      case EnemyState.START_TO_END:
        StartToEnd();
        break;

      case EnemyState.END_TO_START:
        EndToStart();
        break;

      case EnemyState.FOLLOW_PLAYER:
        FollowPlayer();
        break;

      case EnemyState.GO_TO_START:
        GoToStart();
        break;
    }
  }

  void StartToEnd()
  {
    // acción
    transform.position = Vector3.Lerp(startPosition, endPosition, tStartToEnd);
    tStartToEnd += Time.deltaTime * speedStartToEnd;

    // condición de salida 1
    if (tStartToEnd >= 1)
    {
      // preparar variables para END_TO_START
      tEndToStart = 0;
      
      // se manda al estado END_TO_START
      state = EnemyState.END_TO_START;
    }

    // condición de salida 2
    float distance = Vector3.Distance(transform.position, GameObject.Find("Player").transform.position);
    if (distance < ATTACK_DISTANCE)
    {
      state = EnemyState.FOLLOW_PLAYER;
    }
  }

  void EndToStart()
  {
    // acción
    transform.position = Vector3.Lerp(endPosition, startPosition, tEndToStart);
    tEndToStart += Time.deltaTime * speedEndToStart;
    
    // condición de salida 1
    if (tEndToStart >= 1)
    {
      // preparar variables para START_TO_END
      tStartToEnd = 0;

      // se manda al estado START_TO_END
      state = EnemyState.START_TO_END;
    }

    // condición de salida 2
    float distance = Vector3.Distance(transform.position, GameObject.Find("Player").transform.position);
    if (distance < ATTACK_DISTANCE)
    {
      state = EnemyState.FOLLOW_PLAYER;
    }
  }

  void FollowPlayer()
  {
    // acción
    transform.position = Vector3.Lerp(transform.position, GameObject.Find("Player").transform.position, 1 * Time.deltaTime);

    // condición de salida 1
    float distance = Vector3.Distance(transform.position, GameObject.Find("Player").transform.position);
    if (distance >= ATTACK_DISTANCE)
    {
      // preparar variables para GO_TO_START
      startPositionToStart = transform.position;
      tGoToStart = 0;

      // se manda al estado GO_TO_START
      state = EnemyState.GO_TO_START;
    }
  }

  void GoToStart()
  {
    // acción
    transform.position = Vector3.Lerp(startPositionToStart, startPosition, tGoToStart);
    tGoToStart += Time.deltaTime * speedGoToStart;

    // condición de salida 1
    if (tGoToStart >= 1)
    {
      // preparar variables para START_TO_END
      tStartToEnd = 0;

      // se manda al estado START_TO_END
      state = EnemyState.START_TO_END;
    }
  }
}
