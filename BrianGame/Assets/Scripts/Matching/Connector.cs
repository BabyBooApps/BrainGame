using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Connector : MonoBehaviour
{
    public int id;
    public bool ConnectionSuccess = false;
    DrawLine LineScript;
    private void Start()
    {
        LineScript = GetComponent<DrawLine>();
    }
    public void setId(int Id)
    {
        id = Id;
    }

    private void OnMouseDown()
    {
        if(!ConnectionSuccess)
        {
            LineScript.CanDrawLine = true;
        }
        
    }
    private void OnMouseUp()
    {
       
        if (LineScript.ConnectedObj != null)
        {
            Debug.Log("Connected with : " + LineScript.ConnectedObj.name);
            if(LineScript.ConnectedObj.id == id)
            {
                Debug.Log("Connection Success");
                ConnectionSuccess = true;
                LineScript.SetEndPoint(LineScript.ConnectedObj.transform.position);
                iTween.PunchScale(this.gameObject, new Vector3(1, 1, 1), 1.5f);
                iTween.PunchScale(LineScript.ConnectedObj.gameObject, new Vector3(1, 1, 1), 1.5f);
                GamePlayManager.Instance.Matching_Level.OnSuccessfulConnection();
            }
            else
            {
                Debug.Log("Connection Wrong");
                ConnectionSuccess = false;
                LineScript.ResetLineRenderer();
            }
        }else
        {
            ConnectionSuccess = false;
            LineScript.ResetLineRenderer();
        }
        LineScript.CanDrawLine = false;


    }

    public void ResetConnector()
    {
        ConnectionSuccess = false;
        LineScript.ResetLine();
    }

}
