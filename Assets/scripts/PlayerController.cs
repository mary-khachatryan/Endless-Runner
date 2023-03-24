using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    public float jumpForce;
    bool canJump;
    GameObject girl;
   public Animator animator;
    
    
    // Start is called before the first frame update
    void Start()
    {
           jumpForce = 15;
           rb = GetComponent<Rigidbody>();
           girl = GameObject.Find("PlayerGirl");
           animator = girl.GetComponent<Animator>();
           
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canJump)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            animator.SetBool("jump", true);

        }
    }
	private void OnCollisionEnter(Collision collision)
	{
        if (collision.gameObject.tag == "Ground")
        {

            canJump = true;
            
        }
	}
	private void OnCollisionExit(Collision collision)
	{
        if (collision.gameObject.tag == "Ground")
        {

            canJump = false;
            animator.SetBool("jump", false);
        }
    }

	private void OnTriggerEnter(Collider other)
	{
        if (other.gameObject.tag == "Obstacle")
        {
            SceneManager.LoadScene("Game");
        }
	}
}
