using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float jumpForce;
    public float gravityMultiplier;
    public bool isGround = true;
    public bool gameOver;
    public ParticleSystem splatter, explosion;
    public AudioClip jumpClip, CrashClip;
    public AudioSource gameMusic;
    public GameObject panelGameOver;

    private Animator playerAnimator;
    private Rigidbody playerRb;
    private AudioSource playerAudio;
    
    // Start is called before the first frame update
    void Start()
    {
      playerAnimator = GetComponent<Animator>();
      playerRb = GetComponent<Rigidbody>();
      playerAudio = GetComponent<AudioSource>();

      playerAnimator.SetFloat("Speed_f",1);

      Physics.gravity = gravityMultiplier * new Vector3(0,-9.81f,0);
       panelGameOver.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        UserInteraction();
    }

    private void UserInteraction()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround  && !gameOver)
        {
            isGround = false;
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            playerAnimator.SetTrigger("Jump_trig");
            splatter.Stop();
            playerAudio.PlayOneShot(jumpClip);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            splatter.Play();
            isGround = true;
        }
        if(collision.gameObject.CompareTag("Obstacle"))
        {
            playerAnimator.SetBool("Death_b", true);
            gameOver = true;
            splatter.Stop();
            explosion.Play();
            playerAudio.PlayOneShot(CrashClip);
            gameMusic.Stop();
            panelGameOver.SetActive(true);
        }
    }
    public void RestartScene()
    {
        SceneManager.LoadScene(0);
    }
}
