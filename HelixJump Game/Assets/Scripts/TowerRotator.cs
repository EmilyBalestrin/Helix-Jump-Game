using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerRotator : MonoBehaviour
{
    public float rotationSpeed = 0.5f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.gameOver) return;
        if (GameManager.levelCompleted) return;
        if (!GameManager.isGameStarted) return;

        // Desktop
        if (Input.GetAxis("Horizontal") != 0)
        {
            float horizontal = Input.GetAxis("Horizontal");
            transform.Rotate(0, -horizontal * rotationSpeed * 100f * Time.deltaTime, 0);
        }

        // Mobile
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            float deltaX = Input.GetTouch(0).deltaPosition.x;
            transform.Rotate(0, -deltaX * rotationSpeed, 0);
        }
    }
}