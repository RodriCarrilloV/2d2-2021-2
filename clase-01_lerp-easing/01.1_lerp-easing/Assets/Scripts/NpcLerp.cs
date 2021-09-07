using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcLerp : MonoBehaviour
{
  // Lerp de posición
  Vector3 startPosition;
  Vector3 endPosition;
  float tPosition = 0;
  float dtPosition = 0.5f;

  // Lerp de tamaño
  float startScale = 0;
  float endScale = 1;
  float tScale = 0;
  float dtScale = 0.5f;

  void Start()
  {
    startPosition = GameObject.Find("Inicio").transform.position;
    endPosition = GameObject.Find("Fin").transform.position;
  }

  void Update()
  {
    // se cambia de posición
    transform.position = Vector3.Lerp(startPosition, endPosition, tPosition);
    tPosition += dtPosition * Time.deltaTime;

    // se cambia de tamaño
    float scale = Mathf.Lerp(startScale, endScale, tScale);
    transform.localScale = new Vector3(scale, scale, scale);
    tScale += dtScale * Time.deltaTime;
  }
}
