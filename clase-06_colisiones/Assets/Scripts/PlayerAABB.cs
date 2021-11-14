using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAABB : EntityAABB
{
  void Start()
  {
    width = 1.0f;
    height = 1.8f;
  }

  void Update()
  {
    base.CalculateBounds();

    Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    mousePosition.z = 0;
    transform.position = mousePosition;

    if (CollideWith(GameObject.Find("EnemyAABB").GetComponent<EntityAABB>()))
    {
      Debug.Log("Colisión");
    }
    else 
    {
      Debug.Log("No colisión");
    }
  }
}
