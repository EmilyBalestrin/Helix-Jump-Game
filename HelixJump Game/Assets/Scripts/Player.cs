using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private new Rigidbody rigidbody;
    public float bounceForce = 6f;
    private AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        audioManager = GameObject.Find("AudioManager").gameObject.GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {   
        if (GameManager.gameOver) return;
        if (GameManager.levelCompleted) return;

        //faz a bola quicar
        rigidbody.velocity = new Vector3(rigidbody.velocity.x, bounceForce, rigidbody.velocity.z);
        string materialName = collision.transform.GetComponent<MeshRenderer>().material.name;
       // Debug.Log(materialName);

        //colocar sons no jogo
        if (materialName == "MaterialSafe (Instance)")
        {
            //Debug.Log("Estou salvo");
            if (GameManager.isGameStarted) audioManager.Play("bounce");
        }
        else if (materialName == "MaterialUnSafe (Instance)")
        {
            //Debug.Log("GAMEOVER!!!!!!");
            audioManager.Play("gameover");
            GameManager.gameOver = true;
        } else if (materialName == "MaterialLastRing (Instance)")
        {
            //Debug.Log("YOU WIN!!!!!");
            audioManager.Play("winlevel");
            GameManager.levelCompleted = true;
        }
    }
}
