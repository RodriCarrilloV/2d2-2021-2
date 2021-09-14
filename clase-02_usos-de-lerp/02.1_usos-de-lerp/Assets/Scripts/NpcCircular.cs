using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcCircular : MonoBehaviour
{
    // coordenadas polares
    float radius = 5;
    float angle = 0;

    // lerp de angulo
    float startAngle = 0;
    float endAngle = 2 * Mathf.PI;
    float tAngle = 0;
    float speedAngle = 0.3f;

    void Update()
    {         
        // se calcula el input en X
        float moveX = -Input.GetAxis("Horizontal");

        // calcula el ángulo mediante un lerp
        angle = Mathf.Lerp(startAngle, endAngle, tAngle);
        // incrementa el porcentaje de lerp
        tAngle += Time.deltaTime * speedAngle * moveX;

        // se valida que tAngle no pase los límites
        if (tAngle > 1) { tAngle = 0; moveX = 0; }
        if (tAngle < 0) { tAngle = 1; moveX = 0; }

        // calcular coordenadas cartesianas
        float x = radius * Mathf.Cos(angle);
        float y = radius * Mathf.Sin(angle);

        transform.position = new Vector3(x, y, 0);
    }
}
