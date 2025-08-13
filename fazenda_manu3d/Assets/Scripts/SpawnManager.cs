using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    public GameObject[] boostPrefabs;
    public float spawnPositionZ = 20f;
    public float startDelay = 2f;
    public float spawnInterval = 1.5f;
    private float spawnRangeX; // Largura da tela em unidades do mundo
    public float startDelayBoost = 7f;
    public float spawnIntervalBoost = 10f;



    // Start is called before the first frame update
    void Start()
    {
        // Calcula a largura da tela em unidades do mundo
        spawnRangeX = Camera.main.orthographicSize * Camera.main.aspect;
        InvokeRepeating("SpawnAnimal", startDelay, spawnInterval);
        InvokeRepeating("SpawnBoost", startDelayBoost, spawnIntervalBoost);
    }


    // Update is called once per frame
    void Update()
    {
       
    }


    void SpawnAnimal()
    {
        // escolhe um animal aleatoriamente
        int animalIndex = Random.Range(0, animalPrefabs.Length);
       
        // escolhe uma posição x aleatoriamente dentro dos limites da tela
        Vector3 randomPosition = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPositionZ);
       
        Instantiate(animalPrefabs[animalIndex], randomPosition, animalPrefabs[animalIndex].transform.rotation);
    }

    public void SpawnBoost()
    {
         Vector3 randomPosition = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, 0);
         Instantiate(boostPrefabs[0], randomPosition, boostPrefabs[0].transform.rotation);
    }
    

}
