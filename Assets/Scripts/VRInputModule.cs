﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
//sing Valve.VR;

public class VRInputModule : BaseInputModule
{
    public Camera m_Camera;
    //public SteamVR_Input_Sources m_TargetSouce;
    //public SteamVR_Action_Boolean m_ClickAction;
    private GameObject m_CurrentObject = null;
    protected PointerEventData m_Data = null;

    protected override void Awake()
    {
        base.Awake();
        m_Data = new PointerEventData(eventSystem);
    }
    public override void Process()
    {

        // Reset data, set camera
        m_Data.Reset();
        m_Data.position = new Vector2(m_Camera.pixelWidth / 2, m_Camera.pixelHeight / 2);
        // Raycast
        eventSystem.RaycastAll(m_Data, m_RaycastResultCache);
        m_Data.pointerCurrentRaycast = FindFirstRaycast(m_RaycastResultCache);
        m_CurrentObject = m_Data.pointerCurrentRaycast.gameObject;
        //Clear
        m_RaycastResultCache.Clear();
        //Hover
        HandlePointerExitAndEnter(m_Data, m_CurrentObject);
        //Press

        //if (/*m_ClickAction.GetStateDown(m_TargetSouce) ||*/ Input.GetKeyDown(KeyCode.Space))

        if (/*m_ClickAction.GetStateDown(m_TargetSouce) ||*/ Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) || OVRInput.GetDown(OVRInput.Button.One))

        {
            print("Downnn");
            ProcessPress(m_Data);
        }
        //Release

       // if (/*m_ClickAction.GetStateUp(m_TargetSouce) ||*/ Input.GetKeyUp(KeyCode.Space))

        if (/*m_ClickAction.GetStateUp(m_TargetSouce) ||*/ Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0) || OVRInput.GetUp(OVRInput.Button.One))

        {
            print("Upppppppp");
            ProcessRelease(m_Data);
        }

    }
    public PointerEventData GetData()
    {
        return  m_Data;
    }
    protected void ProcessPress(PointerEventData data)
    {
        
        //set raycast
        data.pointerPressRaycast = data.pointerCurrentRaycast;
        //check for object hit, get the down handler, call
        GameObject newPointerPress = ExecuteEvents.ExecuteHierarchy(m_CurrentObject, data, ExecuteEvents.pointerDownHandler);
        //if no down handler, try & get click handler
        if (newPointerPress == null)
        {
            newPointerPress = ExecuteEvents.GetEventHandler<IPointerClickHandler>(m_CurrentObject);
        }
        //set data
        data.pressPosition = data.position;
        data.pointerPress = newPointerPress;
        data.rawPointerPress = m_CurrentObject;

    }
    protected void ProcessRelease(PointerEventData data)
    {
        // Execute pointer up
        ExecuteEvents.Execute(data.pointerPress, data, ExecuteEvents.pointerUpHandler);
        //check for click handler
        GameObject pointerUpHandler = ExecuteEvents.GetEventHandler<IPointerClickHandler>(m_CurrentObject);
        //check if actual
        if (data.pointerPress == pointerUpHandler)
        {
            ExecuteEvents.Execute(data.pointerPress, data, ExecuteEvents.pointerClickHandler);
        }
        //clear selected gameobject
        eventSystem.SetSelectedGameObject(null);
        //reset data
        data.pressPosition = Vector2.zero;
        data.pointerPress = null;
        data.rawPointerPress = null;
    }
}
