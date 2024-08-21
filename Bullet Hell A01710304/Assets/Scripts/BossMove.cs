using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMove : MonoBehaviour
{
    public string inputId;
    public float speed;
    public float horizontalInput;
    public float forwardInput;

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        // Mover hacia adelante/atrás
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        // Mover de izquierda a derecha
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
    }
}

