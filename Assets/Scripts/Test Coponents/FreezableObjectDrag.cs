using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezableObjectDrag : ObjectDrag
{
    protected bool m_frozen = false;
    protected bool m_wasFrozen = true;
    protected Renderer m_cubeRenderer; //Renderer used to change colour of object

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        m_cubeRenderer = GetComponent<Renderer>();

        //Turns off glow so unity has baked the glow for the cube and it can be toggled later
        m_cubeRenderer.material.DisableKeyword("_EMISSION");
    }

    protected void FreezeToggle()
    {
        //Toggles frozen bool
        m_frozen = !m_frozen;

        //Toggles if object is frozen or not
        m_body.isKinematic = !m_body.isKinematic;

        //If emission is on
        if (m_cubeRenderer.material.IsKeywordEnabled("_EMISSION"))
        {
            //Turn off emission so cube isn't glowing
            m_cubeRenderer.material.DisableKeyword("_EMISSION");
        }
        else
        {
            //Turn on emission so cube glows
            m_cubeRenderer.material.EnableKeyword("_EMISSION");
        }
    }

    protected void UnFreeze()
    {
        m_frozen = false;

        //Makes objet move
        m_body.isKinematic = false;

        //Disable emission so cube stops glowing
        m_cubeRenderer.material.DisableKeyword("_EMISSION");
    }

    protected override void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);
    }

    protected void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Box") || collision.gameObject.CompareTag("Player"))
        {
            if (TimeFreeze.m_timeFrozen)
            {
                return;
            }
            else
            {
                //Unfreeze rigidbody if time is not frozen or it touches the player or another box so it can only be frozen if time is frozen
                UnFreeze();
            }
        }
    }

    private void OnMouseOver()
    {
        //On right click
        if (Input.GetButtonDown("Fire2")) 
        {
            //Freeze box in place
            FreezeToggle();
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (TimeFreeze.m_timeFrozen)
        {
            if (!m_frozen)
            {
                //Freeze box if it isn't frozen when time freezes
                FreezeToggle();

                //Was Frozen is used to check if the object was frozen in place before time was frozen
                //If they weren't frozen already, was frozen is false
                m_wasFrozen = false;
            }
        }

        else if (!TimeFreeze.m_timeFrozen)
        {
            //If the object wasn't frozen before
            if (!m_wasFrozen)
            {
                //Unfreeze box if it's frozen when time unfreezes
                FreezeToggle();
                
                m_wasFrozen = true;
            }
        }
    }
}
