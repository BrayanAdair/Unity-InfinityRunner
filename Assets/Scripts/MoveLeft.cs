using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 20;
    private PlayerController PlayerController;
    // Start is called before the first frame update
    void Start()
    {
        PlayerController = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!PlayerController.gameOver)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed ); 
        }
    }
}
