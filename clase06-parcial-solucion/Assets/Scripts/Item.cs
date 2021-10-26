using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
  // lerp
  Vector3 startScale = new Vector3(0, 0, 0);
  Vector3 endScale = new Vector3(1, 1, 1);
  float tScale = 0;
  float speedScale = 2;

  void Start()
  {
    Respawn();
  }

  void Update()
  {
    // lerp
    transform.localScale = Vector3.Lerp(startScale, endScale, tScale);
    tScale += Time.deltaTime * speedScale;

    if (tScale > 1)
    {
      tScale = 1;
    }
  }

  public void Respawn()
  {
    // se inicial la animación de lerp
    tScale = 0;
    transform.localScale = Vector3.zero;

    // se inicializa la posición
    transform.position = new Vector3(Random.Range(-5, 4) + 0.5f, Random.Range(-5, 4) + 0.5f, 0);
  }
}
