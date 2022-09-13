using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDrag : MonoBehaviour
{
    protected Rigidbody m_body;

    protected Vector3 m_screenPos;
    protected Vector3 m_worldPos;
    protected Vector3 m_toMove;
    protected float m_moveSpeed = 5f;

    protected bool m_canMove = true;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        m_body = GetComponent<Rigidbody>();
    }

    protected void OnMouseDown()
    {
        //Freeze Z rotation while held and sets velocity to 0. Makes it easier to move cube for puzzles
        m_body.constraints |= RigidbodyConstraints.FreezeRotationZ;

        //Removes velocity so the cube has no stored momentum
        m_body.velocity = Vector3.zero;

        //Allows box to move so it doesn't stick to a box if they're touching
        m_canMove = true;
    }

    protected void OnMouseUp()
    {
        //Unfreeze Z rotation so it rotates normally again
        m_body.constraints &= ~RigidbodyConstraints.FreezeRotationZ;

        //Removes velocity again so you can't fling the cube accidentily
        m_body.velocity = Vector3.zero;
    }

    protected void OnMouseDrag()
    {   
        //Only move the cube when time is not frozen and it can move
        if (!TimeFreeze.m_timeFrozen && m_canMove)
        {
            //Get mouse position with the object's z position to sync the position of the two
            m_screenPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(transform.position).z);

            //Convert the position to world points so they are coords in the game world so the box can actually move to that position
            m_worldPos = Camera.main.ScreenToWorldPoint(m_screenPos);

            //Position to move the object towards
            m_toMove = new Vector3(m_worldPos.x, m_worldPos.y, transform.position.z);

            //Moves the object towards the mouse using velocity so it can collide with walls and not cause exploits
            //m_toMove - transfrom.position to get the postition of the mouse compared to the object and it doesn't just fling away
            m_body.velocity = (m_toMove - transform.position) * m_moveSpeed;
        }
    }

    protected virtual void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Cannot move box with mouse if touching player
            m_canMove = false;
        }

        if (collision.gameObject.CompareTag("Box"))
        {
            //Sets velocity to zero and canMove to false when touching another box so you can't push them as easy and cheat
            m_body.velocity = Vector3.zero;
            m_canMove = false;
        }
    }
}