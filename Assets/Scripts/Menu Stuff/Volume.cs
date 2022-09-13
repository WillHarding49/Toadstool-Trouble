using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Volume : MonoBehaviour
{
   public AudioMixer m_audioMixer;
   public void SetVolume(float volume)
    {
        //Changes volume of the main volume mixer depending on the slider value
        //Volume float is logorithmic as the volume mixer scale is also. It is *20 so it scales between 0 and -40 on the mixer, being full and mute volumes
        m_audioMixer.SetFloat("Volume", Mathf.Log10(volume) * 20);
    }
}
