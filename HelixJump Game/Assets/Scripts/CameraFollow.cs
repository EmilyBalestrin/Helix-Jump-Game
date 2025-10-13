using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; //player
    private Vector3 offset; //distancia entre a camera e o player
    public float smoothSpeed = 0.04f; //velocidade de seguimento da camera

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - target.position;
    }

    // Update is called once per frame
    void Update()
    {
        //criando nova coordenada entre o ponto A e o ponto B
        Vector3 newPosition = Vector3.Lerp(transform.position, target.position + offset, smoothSpeed);
        //atualizando a posiçao da camera
        transform.position = newPosition;
    }
}
