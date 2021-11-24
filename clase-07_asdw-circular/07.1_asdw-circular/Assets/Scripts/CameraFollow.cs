using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
  void Update()
  {
    Vector3 playerPosition = GameObject.Find("Player").transform.position;
    transform.position = new Vector3(playerPosition.x, playerPosition.y, -10);
  }
}
