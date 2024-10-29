using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    GameObject focalPoint;
    Rigidbody rbPlayer;
    public float speed = 10.0f;
    Renderer rendererPlayer;
    // Start is called before the first frame update
    void Start()
    {
        rbPlayer = GetComponent<Rigidbody>();
        rendererPlayer = GetComponent<Renderer>();
        focalPoint = GameObject.Find("Focal Point");

    }

    // Update is called once per frame
    void Update()
    {

        float forwardInput = Input.GetAxis("Vertical");
        float magnitude = forwardInput * speed * Time.deltaTime;
        rbPlayer.AddForce(focalPoint.transform.forward * magnitude, ForceMode.Force);
        Debug.Log("Mag;" + magnitude);
        Debug.Log("F1;" + forwardInput);

        if (forwardInput > 0)
        {


            rendererPlayer.material.color = new Color(1.0f - forwardInput, 1.0f, 1.0f - forwardInput);
        }
        else
        {
            rendererPlayer.material.color = new Color(1.0f + forwardInput, 1.0f, 1.0f + forwardInput);
        }
    }
}
