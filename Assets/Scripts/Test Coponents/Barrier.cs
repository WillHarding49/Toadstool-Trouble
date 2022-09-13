using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : CollisionToggle
{
    public bool m_objectBarrier; //Bool for if barriers block objects (true) or players (false) only

    //Colours for when the barriers block certain objects
    public Color m_objectBlockColour = new Color(0f, 1f, 0f, 0.5f);
    public Color m_playerBlockColour = new Color(1f, 0f, 1f, 0.5f);

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    private void Update()
    {
        if (m_objectBarrier)
        {
            //Change coour of barrier to be the object barrier colour
            m_cubeRenderer.material.color = m_objectBlockColour;
        }
        else
        {
            //Change coour of barrier to be the player barrier colour
            m_cubeRenderer.material.color = m_playerBlockColour;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Box"))
        {
            //Set collisions off if objectBarrier is true. Looks wrong because false bool is to turn off collisions
            ChangeCollisions(other, !m_objectBarrier);
        }

        if (other.gameObject.CompareTag("Player"))
        {
            ////Set collisions on if objectBarrier is false
            ChangePlayerCollisions(m_objectBarrier);
        }
    }

    //Function used by buttons
    public void ToggleEffect()
    {
        //Toggles what barrier blocks
        m_objectBarrier = !m_objectBarrier;
    }
}
