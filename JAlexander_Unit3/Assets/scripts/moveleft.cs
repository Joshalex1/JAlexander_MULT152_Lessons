using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveleft : MonoBehaviour

{
    public float speed;
    private playercontroller playerCtrl;
    private float LeftBounds = -10;
    // Start is called before the first frame update
    void Start()
    {
        playerCtrl = GameObject.Find("player").GetComponent<playercontroller>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerCtrl.gameOver == false)
        {

         transform.Translate(Vector3.left * Time.deltaTime * speed);

        }
        if (transform.position.x < LeftBounds && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
