using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcPingPoing : MonoBehaviour
{
  // lerp de posición
  Vector3 startPosition;
  Vector3 endPosition;
  float tPosition;
  float dtPosition;
  float speed = 4;

  void Update()
  {
    // se actualizan las posiciones de inicio y final
    startPosition = GameObject.Find("Inicio").transform.position;
    endPosition = GameObject.Find("Fin").transform.position;

    // se actualiza el tiempo de lerp
    float distance = Vector3.Distance(startPosition, endPosition);
    dtPosition = speed / distance;

    // se actualiza la posición
    transform.position = Vector3.Lerp(startPosition, endPosition, tPosition);
    tPosition += dtPosition * Time.deltaTime;

    // se validan los límites para invertir la dirección
    if (tPosition > 1) {
      speed *= -1;
      tPosition = 1;
    }

    if (tPosition < 0) {
      speed *= -1;
      tPosition = 0;
    }
  }
}
