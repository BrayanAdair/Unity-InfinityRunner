using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject [] obstacles; 

    private PlayerController PlayerController;
    private int index;
    private float startDelay = 2;
    private float repeatRate = 2;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObject", startDelay, repeatRate);
        PlayerController = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    void SpawnObject()
        {
            if(!PlayerController.gameOver)
        {
            index = Random.Range(0, obstacles.Length);
            Instantiate(obstacles[index],transform.position, transform.rotation);
        }
        }

}
