using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezableObject : MonoBehaviour
{
    public Rigidbody m_body;
    // Start is called before the first frame update
    private void Start()
    {
        m_body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (TimeFreeze.m_timeFrozen)
        {
            //Freeze object when time is frozen
            m_body.isKinematic = true;
        }

        else if (!TimeFreeze.m_timeFrozen)
        {
            //Unfreeze object when time is frozen
            m_body.isKinematic = false;
        }
    }
}
