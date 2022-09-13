using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeFreeze : MonoBehaviour
{
    public static bool m_timeFrozen = false;
    public Light m_mainLight;

    public Color m_freezeColour = new Color(0f, 1f, 1f, 1f);
    public Color m_normalColour = new Color(1f, 0.96f, 0.84f, 1f);

    private void TimeStop()
    {
        //Toggles timeFrozen bool which other objects check
        m_timeFrozen = !m_timeFrozen;
        Debug.Log("Time Frozen = " + m_timeFrozen);

        if (m_timeFrozen)
        {
            //Changes camera colour so world is differently coloured to show time is forzen
            m_mainLight.color = m_freezeColour;
        }
        else if (!m_timeFrozen)
        {
            //Changes camera colour back to normal to show time is not frozen
            m_mainLight.color = m_normalColour;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            TimeStop();
        }


    }
}
