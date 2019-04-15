using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PointerScript : MonoBehaviour
{
    public float m_DefaultLength = 5.0f;
    public GameObject m_Dot;
    public VRInputModule m_inputModule;
    private LineRenderer m_LineRenderer = null;
    private void Awake()
    {
        m_LineRenderer = GetComponent<LineRenderer>();
    }
    // Update is called once per frame
    void Update()
    {

        UpdateLine();
    }
    public void UpdateLine()
    {
        //use default of distance
        PointerEventData data = m_inputModule.GetData();
        float targetLenth = data.pointerCurrentRaycast.distance == 0 ? m_DefaultLength : data.pointerCurrentRaycast.distance;
        //Raycst
        RaycastHit hit = CreateRaycast(targetLenth);
        //default
        Vector3 endPosition = transform.position + (transform.forward * targetLenth);
        //or based on hit
        if (hit.collider != null)
        {
            endPosition = hit.point;
        }
        
        //set position of the dot
        m_Dot.transform.position = endPosition;
        //set linerenderer
        m_LineRenderer.SetPosition(0, transform.position);
        m_LineRenderer.SetPosition(1, endPosition);
       
    }
    public RaycastHit CreateRaycast(float length)
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.forward);
        Physics.Raycast(ray, out hit, m_DefaultLength);
        return hit;
    }
}
