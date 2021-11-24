using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
  void Start()
  {
    float angle = 1.5f * Mathf.PI;
    float radius = 3;

    float x = radius * Mathf.Cos(angle);
    float y = radius * Mathf.Sin(angle);

    transform.position = new Vector3(x, y, 0);
  }
}
