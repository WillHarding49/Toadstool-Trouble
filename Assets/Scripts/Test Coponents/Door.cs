using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MovingPlatform
{
    public AudioSource m_openSound;
    public AudioSource m_closedSound;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    protected override void TopHit()
    {   //Move door back to the upper limit
        m_moveable.transform.localPosition = new Vector3(originalPos.x, originalPos.y + m_moveDistance, originalPos.z);
    }

    protected override void BottomHit()
    {   //Move door back to it's original position
        m_moveable.transform.localPosition = originalPos;
    }

    //Function called when remote button is pressed
    public void Open()
    {
        //Reverse speed to make door go the other way
        m_speed = -m_speed;

        m_openSound.Play();
    }

    //Function called when remote button is unpressed
    public void Close()
    {
        m_speed = -m_speed;

        m_closedSound.Play();
    }

}
