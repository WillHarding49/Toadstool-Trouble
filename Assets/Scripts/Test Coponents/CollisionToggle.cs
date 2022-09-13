using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionToggle : MonoBehaviour
{
    protected Collider m_boxCollider;
    protected Renderer m_cubeRenderer; //Renderer used to change colour of object
    protected Collider[] m_playerColliders; //List of player colliders as player has multiple so the collision toggle can toggle ALL colliders

    // Start is called before the first frame update
    protected virtual void Start()
    {
        m_boxCollider = GetComponent<Collider>();
        m_cubeRenderer = GetComponent<Renderer>();
        m_playerColliders = GameObject.FindGameObjectWithTag("Player").GetComponents<Collider>();
    }

    protected void ChangeCollisions(Collider collider, bool ignore)
    {
        //Sets the collision between the object and the given collider based off the ignore bool
        Physics.IgnoreCollision(m_boxCollider, collider, ignore);
    }

    protected void ChangePlayerCollisions(bool ignore)
    {
        foreach (Collider collider in m_playerColliders)
        {
            //Change collsions for all the player colliders
            ChangeCollisions(collider, ignore);
        }
    }
}
