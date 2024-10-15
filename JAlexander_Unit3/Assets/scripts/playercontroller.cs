using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller : MonoBehaviour
{
    private Rigidbody rbPlayer;
    public float gravityModifier;
    public float jumpForce;
    private bool onGround = true;
    public bool gameOver = false;

    private Animator animplayer;

    // Start is called before the first frame update
    void Start()
    {
       rbPlayer = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;

        animplayer = GetComponent<Animator>();

   
    }

    // Update is called once per frame
    void Update()
    {
        bool spaceDown = Input.GetKeyDown(KeyCode.Space);
            if (spaceDown && onGround && !gameOver)
        {
            rbPlayer.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            onGround = false;
            animplayer.SetTrigger("Jump_trig");
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {

            onGround = true;
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        { 

            Debug.Log("Game Over!!!");
            gameOver = true;
            animplayer.SetBool("Death_b" ,true);
            animplayer.SetInteger("DeathType_int", 2);
        }
    }
}
