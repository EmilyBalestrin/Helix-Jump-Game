using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerRotator : MonoBehaviour
{
    public float rotationSpeed = 150f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.gameOver) return;
        if (GameManager.levelCompleted) return;
        if (!GameManager.isGameStarted) return;

        //fazer a programação para funcionar no mobile
        if (Input.GetAxis("Horizontal") != 0)
        {
            float horizontal = Input.GetAxis("Horizontal");
            transform.Rotate(0, -horizontal * rotationSpeed * Time.deltaTime, 0);
        }
    }
}
