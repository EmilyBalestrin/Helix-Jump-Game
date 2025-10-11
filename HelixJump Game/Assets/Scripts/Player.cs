using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private new Rigidbody rigidbody;
    public float bounceForce = 6f;

    //adicionar audio ao jogo

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {   //faz a bola quicar
        rigidbody.velocity = new Vector3(rigidbody.velocity.x, bounceForce, rigidbody.velocity.z);
    }
}
