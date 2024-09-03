using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{  //rate of forward/backward movement
    private float speed = 15.0f;
    private float turnspeed = 15.0f;

    private float horizontalInput;
     float verticalInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        Debug.Log(Time.deltaTime);
        // Vector3.forward -- > (0, 0, 1)
        // (0, 0, 1) * Time.deltaTime = (0, 0, .016) * = (0, 0, .16)
        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
        // turning vehicle
        transform.Rotate(Vector3.up, Time.deltaTime * turnspeed * horizontalInput);
    }
}
