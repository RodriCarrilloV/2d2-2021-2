using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcEasing : MonoBehaviour
{
  // Lerp de posición
  Vector3 startPosition;
  Vector3 endPosition;
  float tPosition = 0;
  float dtPosition = 0.5f;

  void Start()
  {
    startPosition = GameObject.Find("Inicio").transform.position;
    endPosition = GameObject.Find("Fin").transform.position;
  }

  void Update()
  {
    // se cambia de posición
    transform.position = Vector3.LerpUnclamped(startPosition, endPosition, Tweens.Parabolic(tPosition));
    tPosition += dtPosition * Time.deltaTime;

    if (tPosition > 1) tPosition = 0;
  }
}
