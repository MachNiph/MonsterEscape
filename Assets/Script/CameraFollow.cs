using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform player;
    private Vector3 cameraPos;
    private string player_tag = "Player";
    [SerializeField] private float minX, maxX;

    void Start()
    {
        GameObject playerObject = GameObject.FindWithTag(player_tag);

        if(playerObject != null)
        {
            player = playerObject.transform;
        }
        else
        {
            Debug.Log("No player tag found");
        }
        
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        if(!player)
        {
            return;
        }
        cameraPos = transform.position;
        cameraPos.x = player.position.x;

        if(cameraPos.x < minX)
        {
            cameraPos.x = minX;
        }

        if(cameraPos.x > maxX)
        {
            cameraPos.x = maxX;
        }

        transform.position = cameraPos;

    }
}
