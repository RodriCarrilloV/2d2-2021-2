using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;

        transform.position = mousePosition;

        float distance = Vector3.Distance(transform.position, GameObject.Find("Enemy").transform.position);
        if (distance < 0.75f + 1.5f)
        {
            Debug.Log("Colisión");
        } else {
            Debug.Log("No colisión");
        }
    }
}
