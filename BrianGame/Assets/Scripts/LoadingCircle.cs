using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingCircle : MonoBehaviour
{
    public float rotateSpeed = 90.0f;
    public bool CanAnimate = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(CanAnimate)
        {
            Animate_Loading();
        }
    }

    public void StartAnimation()
    {
        CanAnimate = true;
    }

    public void Animate_Loading()
    {
        transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);
    }
}
