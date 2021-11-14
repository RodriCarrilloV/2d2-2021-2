using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAABB : EntityAABB
{
  void Start()
  {
    width = 3.0f;
    height = 5.4f;
  }

  void Update()
  {
    base.CalculateBounds();
  }
}
