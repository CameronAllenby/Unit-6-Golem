using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator anim;
    private Rigidbody rigidBody;
    private float yRot;
    public float mouseSensitivity = 5f;
    AudioSource audioSource;
    public AudioClip footstep1;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        anim = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }


    // Update is called once per frame
    void Update()
    {
        float speed = 0.5f;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 2;
        }
        bool move = true;
        anim.SetBool("Run", false);
        anim.SetBool("Walk", false);
        anim.SetBool("Right", false);
        anim.SetBool("Left", false);
        anim.SetBool("Back", false);
        if (move == false)
        {
            speed = 0;
        }
        if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            //transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * playerSpeed);
            rigidBody.velocity += transform.right * Input.GetAxisRaw("Horizontal") * speed;
        }
        if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
        {
            //transform.Translate(Vector3.forward * Input.GetAxis("Vertical") * playerSpeed);
            rigidBody.velocity += transform.forward * Input.GetAxisRaw("Vertical") * speed;
        }
        if (Input.GetKey(KeyCode.D))
            anim.SetBool("Right", true);
        if (Input.GetKey(KeyCode.W))
        {
            anim.SetBool("Walk", true);
            if (Input.GetKey(KeyCode.LeftShift))
            {
                anim.SetBool("Run", true);
                speed = 1;
            }
        }
        if (Input.GetKey(KeyCode.S))
            anim.SetBool("Back", true);
        if (Input.GetKey(KeyCode.A))
            anim.SetBool("Left", true);
        if (anim.GetBool("Left") == true && anim.GetBool("Right") == true)
        {
            anim.SetBool("Right", false);
            anim.SetBool("Left", false);
        }
        if (anim.GetBool("Back") == true && anim.GetBool("Walk") == true)
        {
            anim.SetBool("Walk", false);
            anim.SetBool("Back", false);
            anim.SetBool("Run", false);
        }

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.W))
        {
            yRot += Input.GetAxis("Mouse X") * mouseSensitivity;
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, -yRot, transform.localEulerAngles.z);
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            StartCoroutine(Attk());
            move = false;
        }
    }
    IEnumerator Attk()
    {
        anim.SetBool("Att1", true);
        yield return new WaitForSeconds(2.1f);
        anim.SetBool("Att1", false);
    }
    void PlaySoundEffect()
    {
        audioSource.PlayOneShot(footstep1, 0.7f); // play audio clip with volume 0.7
    }

}
