using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    // Declare our class fields
    // Prefab for instantiating apples
    public GameObject applePrefab;
    // Speed at which the Apple tree moves in meters/second
    public float speed = 1f;

    // Distance where AppleTree turns around
    public float leftAndRightEdge = 10f;
    // Chance that the AppleTree will change directions
    public float chancetoChangeDirections = 0.1f;
    // Rate at which our apples will be intantiated
    public float secondsBetweenAppleDrops = 1f;
    // Start is called before the first frame update
    void Start()
    {
        // Dropping Apples every second
        InvokeRepeating("DropApple", 2f, secondsBetweenAppleDrops);


    }
    void DropApple()
   {
        GameObject apple = Instantiate(applePrefab) as GameObject;
        apple.transform.position = transform.position;
        }

    // Update is called once per frame
    void Update()
    {
        // Basic Movement
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;
        // Changing Direction
        if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed); // Move right

        }
        else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed); // Move left
        }
    }

    void FixedUpdate()
    {
        // Change direction randomly
        if (Random.value < chancetoChangeDirections)
        {
            speed *= -1; //Change Direction
        }
    }

}