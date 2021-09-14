using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // lerp de posición
    Vector3 startPositionX;
    Vector3 endPositionX;
    float tPositionX = 0;
    float speed = 0.1f;

    void Start()
    {
        startPositionX = GameObject.Find("A").transform.position;
        endPositionX = GameObject.Find("B").transform.position;
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        tPositionX += speed * moveX;

        if (tPositionX > 1) {
          tPositionX = 1;
          moveX = 0;
        }

        if (tPositionX < 0) {
          tPositionX = 0;
          moveX = 0;
        }

        transform.position = Vector3.Lerp(startPositionX, endPositionX, tPositionX);
    }
}
