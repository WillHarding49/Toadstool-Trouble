using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntangibleObject : CollisionToggle
{
    public bool m_tangible; //Bool to determine if object is solid or not

    //Colours of object when it is solid while time is in motion
    public Color m_tangibleCollide = new Color(1f, 1f, 0f, 1f); //When solid
    public Color m_tangibleNoCollide = new Color(1f, 1f, 0f, 0.5f); //When not solid

    //Colours of object when it is not solid while time is in motion
    public Color m_intangibleCollide = new Color(0f, 0f, 1f, 1f); //When solid
    public Color m_intangibleNoCollide = new Color(0f, 0f, 1f, 0.5f); //When not solid


    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    private void Update()
    {
        //If cube is solid
        if (m_tangible)
        {
            if (TimeFreeze.m_timeFrozen)
            {   //set colour of cube that is not solid when time is frozen
                m_cubeRenderer.material.color = m_tangibleNoCollide;
            }
            else
            {   //set colour of cube that is solid when time is frozen
                m_cubeRenderer.material.color = m_tangibleCollide;
            }
        }
        else
        {
            if (TimeFreeze.m_timeFrozen)
            {   //set colour of cube that is solid when time is frozen
                m_cubeRenderer.material.color = m_intangibleCollide;
            }
            else
            {   //set colour of cube that is not solid when time is frozen
                m_cubeRenderer.material.color = m_intangibleNoCollide;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (m_tangible)
        {   //If a box or button's top collides with box
            if (other.gameObject.CompareTag("Box") || other.gameObject.CompareTag("Button Top"))
            {   
                //Turn off collisions if time is frozen
                ChangeCollisions(other, TimeFreeze.m_timeFrozen);
            }

            //If player collides with box
            if (other.gameObject.CompareTag("Player"))
            {
                //Turn off collisions if time is frozen
                ChangePlayerCollisions(TimeFreeze.m_timeFrozen);
            }
        }
        else
        {
            if (other.gameObject.CompareTag("Box") || other.gameObject.CompareTag("Button Top"))
            {
                //Turn off collisions if time is unfrozen
                ChangeCollisions(other, !TimeFreeze.m_timeFrozen);
            }

            if (other.gameObject.CompareTag("Player"))
            {
                //Turn off collisions if time is unfrozen
                ChangePlayerCollisions(!TimeFreeze.m_timeFrozen);
            }
        }

    }
}
