using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float speed = 10.0f;
    float PlaneAlimit = 10.0f;
    float PlaneBlimit = 5.0f;
    float gravityModifier = 2.5f;
    int jumpForce = 10;
    Rigidbody playerRb;

    bool PlaneA = false;
    bool PLaneB = false;
    
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();

        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.forward * Time.deltaTime * verticalInput * speed);
        transform.Translate(Vector3.right * Time.deltaTime * horizontalInput * speed);

        if (PlaneA == true || PLaneB == false)
        {
            //PlaneA
            //front and back border (PlaneA)
            if (transform.position.z < -PlaneAlimit)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, -PlaneAlimit);
            }
            else if (transform.position.z > PlaneAlimit)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, PlaneAlimit);
            }

            //right and left border (PlaneA)
            if (transform.position.x < -PlaneAlimit)
            {
                transform.position = new Vector3(-PlaneAlimit, transform.position.y, transform.position.z);
            }
            else if (transform.position.x > PlaneAlimit)
            {
                transform.position = new Vector3(PlaneAlimit, transform.position.y, transform.position.z);
            }
        }

        else if (PLaneB == true || PlaneA == false)
        {
            //PlaneB
            //front and back border(PlaneB)
            if (transform.position.z < -PlaneBlimit)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, -PlaneBlimit);
            }
            else if (transform.position.z > PlaneBlimit)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, PlaneBlimit);
            }

            //right and left border (PlaneB)
            if (transform.position.x < -PlaneBlimit)
            {
                transform.position = new Vector3(-PlaneBlimit, transform.position.y, transform.position.z);
            }
            else if (transform.position.x > PlaneBlimit)
            {
                transform.position = new Vector3(PlaneBlimit, transform.position.y, transform.position.z);
            }
        }

    }
}
