using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveArrow : MonoBehaviour {

    public float movementSpeed = 5.0f;

    void Start()
    {
    
    }

    void Update()
    {
        if (gameObject.name == "ArrowRight(Clone)")
        {
            transform.position += Vector3.left * Time.deltaTime * movementSpeed;
        }

        if (gameObject.name == "ArrowLeft(Clone)")
        {
            transform.position += Vector3.right * Time.deltaTime * movementSpeed;
        }

    }


}
