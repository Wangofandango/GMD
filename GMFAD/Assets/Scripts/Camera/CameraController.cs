using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraController : MonoBehaviour
{
    public GameObject player; // Reference to the player

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");

        if (player == null)
        {
            Debug.LogWarning("Player not found");
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPosition = player.transform.position;
        var transVariable = transform;
        transVariable.position = new Vector3(playerPosition.x, playerPosition.y, transVariable.position.z);
    }
}

