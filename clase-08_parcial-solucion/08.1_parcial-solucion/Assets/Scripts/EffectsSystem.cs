using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsSystem
{
  static public void CreateExplosion(Vector3 position, string type)
  {
    // crea N particulas en la posicion indicada
    
    for (int i = 0; i < 50; i++)
    {
      GameObject particle = Object.Instantiate(Resources.Load(type) as GameObject);
      particle.transform.position = position;
    }
  }
}