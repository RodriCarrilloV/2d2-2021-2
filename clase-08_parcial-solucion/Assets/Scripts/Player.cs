using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  // lerp
  Vector3 startPosition = new Vector3(-4.5f, 4.5f, 0);
  Vector3 endPosition = new Vector3(-4.5f, 4.5f, 0);
  float tPosition = 0;
  float tSpeed = 10;

  void Update()
  {
    // lerp
    transform.position = Vector3.Lerp(startPosition, endPosition, tPosition);
    tPosition += tSpeed * Time.deltaTime;

    if (tPosition > 1)
    {
      tPosition = 1;
      startPosition = endPosition;
    }

    // movimiento
    if (Input.GetKeyDown(KeyCode.UpArrow) && tPosition == 1 && endPosition.y < 4.5f)
    {
      tPosition = 0;
      endPosition = new Vector3(endPosition.x, endPosition.y + 1, 0);
    }
    if (Input.GetKeyDown(KeyCode.DownArrow) && tPosition == 1 && endPosition.y > -4.5f)
    {
      tPosition = 0;
      endPosition = new Vector3(endPosition.x, endPosition.y - 1, 0);
    }
    if (Input.GetKeyDown(KeyCode.LeftArrow) && tPosition == 1 && endPosition.x > -4.5f)
    {
      tPosition = 0;
      endPosition = new Vector3(endPosition.x - 1, endPosition.y, 0);
    }
    if (Input.GetKeyDown(KeyCode.RightArrow) && tPosition == 1 && endPosition.x < 4.5f)
    {
      tPosition = 0;
      endPosition = new Vector3(endPosition.x + 1, endPosition.y, 0);
    }

    // condición de spawn
    GameObject item = GameObject.Find("Item");
    if (Vector3.Distance(transform.position, item.transform.position) < 1.0f)
    {
      item.GetComponent<Item>().Respawn();
      EffectsSystem.CreateExplosion(endPosition, "Particle");
    }
  }
}
