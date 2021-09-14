using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcSpawner : MonoBehaviour
{
    void Start()
    {
        InvokeRepeating("Spawn", 0, 1);
    }

    void Update()
    {
        
    }

    void Spawn()
    {
      Instantiate(Resources.Load("NpcSpawn") as GameObject);
    }
}
