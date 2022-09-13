using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Class is abstract as there are abstract functions which bodies are declared in child classes
public abstract class MovingPlatform : MonoBehaviour
{
    //Object that's moving. Used because it's a child of an empty to keep everything local to itself
    public Transform m_moveable; 
    public float m_speed = -5f;
    public float m_moveDistance = 5f;
    public bool m_isActive = true;
    protected Vector3 originalPos;


    // Start is called before the first frame update
    protected virtual void Start()
    {
        //set original position of the m_moveable to be where it is at the start
        originalPos = m_moveable.transform.localPosition;
    }

    // Update is called once per frame
    protected virtual void Update()
    {   
        if (m_isActive)
        {
            //If the m_moveable is between it's original position and it's move distance
            if (m_moveable.transform.localPosition.y <= originalPos.y + m_moveDistance && m_moveable.transform.localPosition.y >= originalPos.y)
            {
                //Move using Vector3.up as it gets the "Up" direction of the object when moving using Translate as it uses local axes
                m_moveable.transform.Translate(Vector3.up * Time.deltaTime * m_speed);
            }

            //If the m_moveable is past it's upper limit
            if (m_moveable.transform.localPosition.y > originalPos.y + m_moveDistance)
            {
                TopHit();
            }

            //If the m_moveable is past it's original position
            if (m_moveable.transform.localPosition.y < originalPos.y)
            {
                BottomHit();
            }
        }
    }

    //Function used when m_moveable hit upper limit, changed in child classes for individual uses
    protected abstract void TopHit();

    //Function used when m_moveable hit upper limit, changed in child classes for individual uses
    protected abstract void BottomHit();

    public void ToggleActive()
    {
        //Toggles if platform is able to move at all
        m_isActive = !m_isActive;
    }
}
