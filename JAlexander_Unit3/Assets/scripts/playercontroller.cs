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
    public ParticleSystem expSystem;
    public ParticleSystem dirtSystem;

    public AudioClip jumpSound;
    public AudioClip crashSound;

    private AudioSource asplayer;


    // Start is called before the first frame update
    void Start()
    {
       rbPlayer = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;

        animplayer = GetComponent<Animator>();

        asplayer = GetComponent<AudioSource>();

   
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
            dirtSystem.Stop();
            asplayer.PlayOneShot(jumpSound, 1.0f);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {

            onGround = true;
            dirtSystem.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        { 

            Debug.Log("Game Over!!!");
            gameOver = true;
            animplayer.SetBool("Death_b" ,true);
            animplayer.SetInteger("DeathType_int", 2);
            expSystem.Play();
            dirtSystem.Stop();
            asplayer.PlayOneShot(crashSound, 1.0f);

        }
    }
}
