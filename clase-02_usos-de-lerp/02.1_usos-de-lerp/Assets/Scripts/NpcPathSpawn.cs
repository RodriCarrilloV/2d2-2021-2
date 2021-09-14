using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcPathSpawn : MonoBehaviour
{
    int index = 0;
    float tPosition = 0;
    float speedPosition = 3;
    List<Vector3> points = new List<Vector3>();

    GameObject path;

    void Start()
    {
      path = GameObject.Find("PathSpawn");

      // se crea una lista de puntos con los puntos del path
      for (int i = 0; i < path.transform.childCount; i++)
      {
        points.Add(path.transform.GetChild(i).transform.position);
      }

      Update();
    }

    void Update()
    {
      // se calculan los puntos del tramo actual
      Vector3 startPosition = points[index];
      Vector3 endPosition = points[index + 1];
      
      // se interpola la posicion del npc entre startPosition y endPosition
      transform.position = Vector3.Lerp(startPosition, endPosition, tPosition);

      // se varía el porcentaje del lerp según la distancia
      float distance = Vector3.Distance(startPosition, endPosition);
      tPosition += speedPosition * Time.deltaTime / distance;

      // se valida si se termina el tramo o si se termina el path
      if (tPosition >= 1)
      {
        tPosition = 0;

        index++; 
        if (index > points.Count - 2) // si se llegó al tramo final
        {
          Destroy(gameObject);
        }
      }
    }
}
