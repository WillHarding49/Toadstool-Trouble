using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RBController : MonoBehaviour
{
    public float m_moveSpeed = 8f;
    public float m_jumpForce = 10f;

    private Rigidbody m_body;

    private Vector3 m_moveDirection;

    private float m_distToGround;

    // Start is called before the first frame update
    private void Start()
    {
        m_body = GetComponent<Rigidbody>();
        m_distToGround = GetComponent<Collider>().bounds.extents.y;
    }

    private bool IsGrounded()
    {
        //If the raycast collides with an object below the player, then they are grounded
        return Physics.Raycast(transform.position, Vector3.down, m_distToGround + 0.1f);
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            //Add jump force upwards. Impluse makes it an instant force applied so the character jumps properly
            m_body.AddForce(Vector3.up * m_jumpForce, ForceMode.Impulse);
        }

        //The move direction is the which input is being pressed (left or right) multiplied the move speed. Y velocity is kept consistent so jumps aren't reset
        m_moveDirection = new Vector3(Input.GetAxis("Horizontal") * m_moveSpeed, m_body.velocity.y, 0);

        //Set the rigidbody velocity to be the moveDirection
        m_body.velocity = m_moveDirection;

        //If moving left
        if (Input.GetAxis("Horizontal") < 0)
        {
            //Flip character to face the other direction
            transform.rotation = Quaternion.Euler(0f, -180f, 0f);
        }
        //If moving right
        else if (Input.GetAxis("Horizontal") > 0)
        {
            //Reset the rotation back to facing right
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }


        string currentScene = SceneManager.GetActiveScene().name;

        //Press R to restart scene
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(currentScene);
        }
    }
}
