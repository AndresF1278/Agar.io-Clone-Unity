using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class SizeController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float currentScale;
    public void IncrementSize()
    {
       // transform.localScale += size;
        transform.localScale = Vector3.Lerp(transform.localScale,
            new Vector3(currentScale,currentScale,currentScale), speed * Time.deltaTime);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Food"))
        {
            FoodController foodController = collision.GetComponent<FoodController>();
           
            foodController.SwitchPosition();

            currentScale += foodController.amountScale;
            Camera.main.GetComponent<CameraController>().currentSize += foodController.amountScale;

        }
    }
    private void Update()
    {
        IncrementSize();
        

        
    }

}
