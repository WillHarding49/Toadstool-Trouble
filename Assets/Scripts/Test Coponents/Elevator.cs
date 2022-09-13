using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MovingPlatform
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        //Only updates when time is not frozen to stop frozen objects from messing with automatic movement and collisions
        if (!TimeFreeze.m_timeFrozen)
        {
            base.Update();
        }
    }

    protected override void TopHit()
    {
        //Reverse speed to make elevator go the other way
        m_speed = -m_speed;

        //Move down slightly to keep elevator moving and not stay stuck at the limit
        m_moveable.transform.Translate(Vector3.down * 0.1f);
    }

    protected override void BottomHit()
    {
        m_speed = -m_speed;

        //Move up slightly to keep elevator moving and not stay stuck at the limit
        m_moveable.transform.Translate(Vector3.up * 0.1f);
    }
}
