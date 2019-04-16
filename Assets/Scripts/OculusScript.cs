using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OculusScript : VRInputModule
{
    public OVRInput.Controller m_Source = OVRInput.Controller.RTrackedRemote;
    public OVRInput.Button m_Click = OVRInput.Button.Any;
    public override void Process()
    {
        base.Process();
        //press
        if (OVRInput.GetDown(m_Click, m_Source))
        {
           // ProcessPress(m_Data);
        }
        if (OVRInput.GetUp(m_Click, m_Source))
        {
            //ProcessRelease(m_Data);
        }
    }
}
