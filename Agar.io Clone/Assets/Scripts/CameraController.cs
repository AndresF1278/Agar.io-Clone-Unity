using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] float speed;
    //[SerializeField] GameObject player;
    public Transform target;
    public float currentSize;
    void Start()
    {
        currentSize = gameObject.GetComponent<Camera>().orthographicSize;
       
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPosition = target.position;
        Vector3 targetPosition = new Vector3(playerPosition.x, playerPosition.y, transform.position.z);
       transform.position =  Vector3.Lerp(transform.position, targetPosition, speed * Time.deltaTime);

        gameObject.GetComponent<Camera>().orthographicSize = Mathf.Lerp(Camera.main.orthographicSize,  currentSize, speed * Time.deltaTime);
    }
    private void OnEnable()
    {
        if(target != null)
        transform.position = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);
    }

}
