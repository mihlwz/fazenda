using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostVelocidade : MonoBehaviour
{
    private PlayerController player;
    private SpawnManager spawnManager;
    void Start()
    {
       player = GameObject.Find("Player").GetComponent<PlayerController>();
       spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Destroy(gameObject);
            player.SpeedBoost();
            spawnManager.SpawnBoost();
        }
        
    }

    
}
