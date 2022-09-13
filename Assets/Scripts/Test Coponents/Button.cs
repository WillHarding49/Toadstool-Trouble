
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/********************************************************************************************
*    Title: PhysicsButton
*    Author: daniel-ziorli
*    Date: 02/01/21
*    Availability: https://github.com/daniel-ziorli/PhysicsButton/blob/main/PhysicsButton.cs
*
*   I have taken this code from the above link and modifed and optomised it for my own use
*********************************************************************************************/

public class Button : MonoBehaviour
{
    public Transform m_buttonTop; //The bit of the button you press
    public Rigidbody m_topBody; //Button top's ridigbody

    public Transform m_lowerLimit; //Where the button top stops moving up 
    public Transform m_upperLimit; //Where the button top stops moving down

    public float m_threshold = 0.5f; //How much leeway there is in when the button is pressed to count it as "pressed"
    public float m_force = 10f; //Amout of force to apply to the button so it pushes back up when you release it

    private float m_upperLowerDiff; //The distance between the upper and lower limits
    public bool m_pressed;
    private bool m_prevPressedState;

    public AudioSource m_pressedSound;
    public AudioSource m_releasedSound;

    public UnityEvent m_onPressed;
    public UnityEvent m_onReleased;

    // Start is called before the first frame update
    void Start()
    {
        //Turns off collision between button sections so the top can slide into the base
        Physics.IgnoreCollision(GetComponent<Collider>(), m_buttonTop.GetComponent<Collider>());

        m_topBody = m_buttonTop.GetComponent<Rigidbody>();

        //The distance between the upper and lower limits
        m_upperLowerDiff = Vector3.Distance(m_upperLimit.position, m_lowerLimit.position);
    }

    // Update is called once per frame
    void Update()
    {
        //Local positions are used as they are relative to the button itself, so the button can move around or be rotated if needed
        //if the button top is lower than the lower limit
        if (m_buttonTop.localPosition.y <= m_lowerLimit.localPosition.y)
        {
            //Move button to lower limit
            m_buttonTop.transform.position = m_lowerLimit.position;
        }

        //if button higher than it's original position
        if (m_buttonTop.localPosition.y >= 0)
        {
            //Move button to upper limit
            m_buttonTop.transform.position = m_upperLimit.position;
            //Set button top RB velcoity to zero to stop it building up and causing huge force applying to stuff
            m_topBody.velocity = Vector3.zero;
        }
        else
        {
            //Add force to move button up. Uses buttonTop's transfrom.up to get the local "Up" as Addfoce uses world axes
            m_topBody.AddForce(m_buttonTop.transform.up * m_force * Time.fixedDeltaTime);
        }

        //If the button moves in it's local x direction
        if (m_buttonTop.localPosition.x != 0)
        {
            //Reset x position to 0
            m_buttonTop.transform.localPosition = new Vector3(0, m_buttonTop.transform.localPosition.y, 0);
        }

        //If the distance between the button top and the lower limit is less than the distance between the
        //upper and lower limits multipled by the threashold
        if (Vector3.Distance(m_buttonTop.position, m_lowerLimit.position) < m_upperLowerDiff * m_threshold)
        {
            m_pressed = true;
        }
        else
        {
            m_pressed = false;
        }

        //Allows for the button to be activated once and not be repeatdly activated from one press
        if (m_pressed && m_prevPressedState != m_pressed)
        {
            Pressed();
        }

        if (!m_pressed && m_prevPressedState != m_pressed)
        {
            Released();
        }
    }

    void Pressed()
    {
        m_prevPressedState = m_pressed;
        m_pressedSound.Play();
        m_onPressed.Invoke();
    }

    void Released()
    {
        m_prevPressedState = m_pressed;
        m_releasedSound.Play();
        m_onReleased.Invoke();
    }
}

