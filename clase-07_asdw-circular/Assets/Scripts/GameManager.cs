using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
  // Start is called before the first frame update
  void Start()
  {
    for (int i = 0; i < MapData.planets.Count; i++)
    {
      GameObject planet = Instantiate(Resources.Load("Planet")) as GameObject;
      planet.transform.position = MapData.planets[i].position;
      planet.transform.localScale = new Vector3(MapData.planets[i].radius * 2, MapData.planets[i].radius * 2, MapData.planets[i].radius * 2);

      GameObject planetGravity = Instantiate(Resources.Load("PlanetGravity")) as GameObject;
      planetGravity.transform.position = MapData.planets[i].position;
      planetGravity.transform.localScale = new Vector3(MapData.planets[i].gravityRadius * 2, MapData.planets[i].gravityRadius * 2, MapData.planets[i].gravityRadius * 2);
    }
  }

  // Update is called once per frame
  void Update()
  {

  }
}
