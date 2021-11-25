using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject playerPrefab;
    
    public float minX = -10;
    public float maxX = 10;
    public float maxZ = 10;
    public float minZ = -10;


    void Start()
    {
        Vector2 randomPosition = new Vector2(Random.Range(minX, maxX),Random.Range(minZ, maxZ));
        Vector3 spawnPosition = new Vector3(transform.position.x + randomPosition.x,transform.position.y,transform.position.z + randomPosition.y);
        PhotonNetwork.Instantiate(playerPrefab.name, spawnPosition, Quaternion.identity);
    }
}
