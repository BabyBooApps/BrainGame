using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScrambleWords_Char_Tile : MonoBehaviour
{
    public TextMeshPro text_Obj;
    public string TileId;

    void SetPosition(Vector3 pos)
    {
        this.transform.position = pos;
    }
    void SetChar(string c)
    {
        text_Obj.text = c;
    }

    public void SetTile(Vector3 pos, string c)
    {
        //SetPosition(pos);
        SetChar(c);
        SetTileId(c);
    }
    public void SetTileId(string id)
    {
        TileId = id;
    }

    public void ValidateMove()
    {

    }
    private void OnMouseUp()
    {
        // Define the ray direction in the Z-axis for 2D
        Vector2 rayDirection = Vector2.up; // This sends the ray upward in the Z-axis for 2D.
        Vector2 rayOrigin = (Vector2)transform.position + (Vector2.up * 0.01f); // Offset by 0.01 units in the Z-axis
        float rayLength = 5.0f;
        Color rayColor = Color.red;
        Vector2 rayOriginOffset = new Vector2(0f, 0.01f);
        // Define the ray direction in the Z-axis for 2D
       // Vector2 rayDirection = Vector2.up; // This sends the ray upward in the Z-axis for 2D.

        // Calculate the ray's starting point
       // Vector2 rayOrigin = (Vector2)transform.position + rayOriginOffset;

        // Perform the 2D raycast
        RaycastHit2D hit = Physics2D.Raycast(rayOrigin, rayDirection, rayLength);

        if (hit.collider != null)
        {
            // Hit something
            Debug.Log("Ray hit object: " + hit.collider.gameObject.name);

            // Draw the ray for debugging (in red color)
            Debug.DrawRay(rayOrigin, rayDirection * hit.distance, rayColor);
        }
        else
        {
            // Ray did not hit anything, so you can draw it as well
            Debug.DrawRay(rayOrigin, rayDirection * rayLength, rayColor);
        }
    }
}

