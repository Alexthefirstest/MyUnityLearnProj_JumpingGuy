using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float jumpForce;
    public float gravityModifyer;
    public ParticleSystem particles;
    public ParticleSystem dust;
    public AudioClip jump;
    public AudioClip crash;

    private AudioSource audioSource;
    private Rigidbody playerRB;
    private Animator playerAnim;
    private bool isOnGround = true;

    public bool gameOver = false;

    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();


        Physics.gravity *= gravityModifyer;
    }

    // Update is called once per frame
    void Update()
    {
        if (isOnGround && Input.GetKeyDown(KeyCode.Space))
        {
            audioSource.PlayOneShot(jump, 1f);
            dust.Stop();
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;

            playerAnim.SetTrigger("Jump_trig");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dust.Play();
        }
        else if (collision.gameObject.CompareTag("Obst"))
        {
            audioSource.PlayOneShot(crash, 1f);
            particles.Play();
            gameOver = true;
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            dust.Stop();
        }
    }
}
