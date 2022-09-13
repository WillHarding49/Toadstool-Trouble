using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform m_player;
    private Vector3 m_offset;

    // Start is called before the first frame update
    void Start()
    {
        m_player = GameObject.FindGameObjectWithTag("Player").transform;
        m_offset = transform.position - m_player.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 cameraPos = m_player.position + m_offset; //Position to align camera with player
        transform.position = cameraPos; //Moves camera to follow player
    }
}
