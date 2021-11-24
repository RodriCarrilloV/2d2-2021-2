using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
  void Start()
  {
    for (int i = 0; i < 4; i++)
    {
      Instantiate(Resources.Load("Enemy"));
    }
  }
}
