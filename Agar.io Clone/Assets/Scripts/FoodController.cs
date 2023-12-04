using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodController : MonoBehaviour
{

    [SerializeField] static float minX =  - 97f;
    [SerializeField] static float MaxX =   97f;
    [SerializeField] static float miny =   73f;
    [SerializeField] static float maxY=  - 73f;

    public float amountScale = 0.1f;

   


    private void Start()
    {
        ConfigColor();
    
    }

    private void ConfigColor()
    {
        Color ColorRandom = new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f), 1);
        gameObject.GetComponent<SpriteRenderer>().color = ColorRandom;
    }

    public void SwitchPosition()
    {

        transform.position = RandomPosition();

    }
    
   


    private Vector2 RandomPosition()
    {
        float posX = Random.Range(minX, MaxX);
        float posY = Random.Range(miny, maxY);
        return new Vector2(posX, posY);
    }

}
