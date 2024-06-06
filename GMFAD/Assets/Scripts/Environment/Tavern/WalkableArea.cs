using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkableArea : MonoBehaviour
{
    //An array of 4 Vector3s that represent the corners of the walkable area
    public Vector3[] Corners { get; set; }


    // Start is called before the first frame update
    void Start()
    {
        //Initialize the corners array
        Corners = new Vector3[4];

        //Get all child objects of the walkable area, where the tag is corner
        Transform[] children = GetComponentsInChildren<Transform>();
        
            
        //Fill the corners array with the positions of the child objects
        int i = 0;
        foreach (var transform in children)
        {
            if (transform.CompareTag("Corner"))
            {
                Corners[i] = transform.position;
                i++;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    public Vector3 GetRandomPosition()
    {
        // Calculate two random interpolation factors between 0 and 1
        float randomFactor1 = Random.value;
        float randomFactor2 = Random.value;

        // Interpolate between the corners to get a random point within the area
        Vector3 randomPosition = (1 - randomFactor1) * (1 - randomFactor2) * Corners[0] +
                                 randomFactor1 * (1 - randomFactor2) * Corners[1] +
                                 (1 - randomFactor1) * randomFactor2 * Corners[2] +
                                 randomFactor1 * randomFactor2 * Corners[3];

        return randomPosition;
    }

    public Vector3 GetCenter()
    {
        //Calculate the center of the walkable area
        Vector3 center = (Corners[0] + Corners[1] + Corners[2] + Corners[3]) / 4;

        //Return the center position
        return center;
    }
}