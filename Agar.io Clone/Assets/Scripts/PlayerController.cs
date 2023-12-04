using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speedStart;
    [SerializeField] private float speedCurrent;
    private Rigidbody2D rb;
    public float arrivalThreshold = 0.1f; // Distancia umbral para detener el movimiento


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speedCurrent = speedStart;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
       

    }


    private void MovePlayer()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;


        Vector3 movement = mousePosition - transform.position;
        float distanceToMouse = movement.magnitude;

        movement.Normalize();

        if (distanceToMouse > arrivalThreshold)
        {
            rb.velocity = movement * speedCurrent * Time.deltaTime;

        }
    }
}
