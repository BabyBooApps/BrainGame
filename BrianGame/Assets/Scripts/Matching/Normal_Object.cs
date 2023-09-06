using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Normal_Object : MonoBehaviour
{
    public Connector connector;
    public void SetSprite(Sprite img)
    {
        GetComponent<SpriteRenderer>().sprite = img;
    }

}
