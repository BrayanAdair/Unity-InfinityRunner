using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(BoxCollider))]
public class RepeatBackground : MonoBehaviour
{
   private Vector3 startPos;
   private float RepeatWidth;
    // Start is called before the first frame update
    void Start()
    {
     startPos = transform.position;
     RepeatWidth = GetComponent<BoxCollider>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if( startPos.x - transform.position.x > 56)
        {
            transform.position = startPos;
        }
    }
}
