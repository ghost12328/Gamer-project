using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Teleporter : MonoBehaviour
{

    public GameObject m_Pointer;
    public SteamVR_Action_Boolean m_TeleportAction;

    private SteamVR_Behaviour_Pose m_Pose = null;

    private void Awake ()
    {
        m_Pose = GetComponent<SteamVR_Behaviour_Pose>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void TryTeleport ()
    {

    }
}
