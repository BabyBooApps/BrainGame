using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private Vector3 startPoint;
    private Vector3 pivotPoint;

    public bool CanDrawLine = false;
    public Connector ConnectedObj;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
        lineRenderer.useWorldSpace = true;

        lineRenderer.SetPosition(0, Vector3.zero);
        lineRenderer.SetPosition(1, Vector3.zero);
    }

    void Update()
    {
        if(!CanDrawLine)
        {
            return;
        }
        if (Input.GetMouseButtonDown(0))
        {
            startPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            startPoint.z = 0;
            pivotPoint = startPoint;

            Debug.Log("Line Renderer Object :" + this.gameObject.name);

            lineRenderer.SetPosition(0, this.transform.position);
            lineRenderer.SetPosition(1, this.transform.position);
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 endPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            endPoint.z = 0;

            Vector3 direction = endPoint - pivotPoint;
            float length = direction.magnitude;
            Vector3 midpoint = pivotPoint + direction * 0.5f;

            //transform.position = midpoint;
           // transform.right = direction.normalized;

            // Only scale in the direction of the mouse
            lineRenderer.SetPosition(0, pivotPoint);
            lineRenderer.SetPosition(1, pivotPoint + direction);

            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 rayDirection = Vector3.down; // Cast the ray in the downward direction
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, rayDirection);

          //  RaycastHit2D hit = Physics2D.Raycast(transform.position, endPoint - transform.position, (endPoint - transform.position).magnitude);
            // Debug.DrawRay to visualize the raycast line
           // Debug.DrawRay(transform.position, endPoint - transform.position, Color.green);
            Debug.DrawRay(mousePosition, rayDirection * 10f, Color.green);

            // Check if the raycast hit something
            if (hit.collider != null && hit.collider.gameObject != this.gameObject)
            {
                Debug.Log("Hit Collider Name: " + hit.collider.name);
                if(hit.collider.GetComponent<Connector>())
                {
                    ConnectedObj = hit.collider.GetComponent<Connector>();
                }else
                {
                    ConnectedObj = null;
                }
            }else
            {
                ConnectedObj = null;
            }
        }
    }

    public void ResetLineRenderer()
    {

    
       
        lineRenderer.SetPosition(0, this.transform.position);
        lineRenderer.SetPosition(1, this.transform.position); // Clear all line positions
    }

    public void SetEndPoint(Vector3 Pos)
    {
        if(ConnectedObj!= null)
        {
            lineRenderer.SetPosition(1, ConnectedObj.transform.position);
            
        }
        
    }

    public void ResetLine()
    {
        lineRenderer.SetPosition(0, Vector3.zero);
        lineRenderer.SetPosition(1, Vector3.zero);
        CanDrawLine = false;
    }


}
