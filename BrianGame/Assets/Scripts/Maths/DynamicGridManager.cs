using System.Collections.Generic;
using UnityEngine;

public class DynamicGridManager : MonoBehaviour
{



    public int maxColumns = 3; // Maximum number of columns
    public int maxRows = 3;
  
   

    //public int maxColumns = 3; // Maximum number of columns
    public float spacing = 2f; // Spacing between objects

    public List<Vector3> CalculateGridPositions(int numObjects)
    {
        List<Vector3> objectPositions = new List<Vector3>();
        int numRows = Mathf.CeilToInt((float)numObjects / maxColumns); // Calculate the number of rows


        // Calculate the starting position
        float startX = -(maxColumns - 1) * spacing / 2f;
        float startY = (numRows - 1) * spacing / 2f;

        for (int row = 0; row < numRows; row++)
        {
            int rowObjectCount = Mathf.Min(maxColumns, numObjects - row * maxColumns);

            for (int col = 0; col < rowObjectCount; col++)
            {
                Vector3 objectPosition = new Vector3(startX + col * spacing, startY - row * spacing, 0f);
                objectPositions.Add(objectPosition);
            }
        }

        return objectPositions;
    }

    public List<Vector3> CalculateGridPositions_V2(int numObjects)
    {
        List<Vector3> objectPositions = new List<Vector3>();

        int numRows = Mathf.Min(maxRows, Mathf.CeilToInt((float)numObjects / maxColumns));
        int numColumns = Mathf.Min(maxColumns, Mathf.CeilToInt((float)numObjects / numRows));

        float startX = -(numColumns - 1) * spacing / 2f;
        float startY = (numRows - 1) * spacing / 2f;

        float objectSize = 1f / Mathf.Sqrt(numObjects); // Calculate the object size inversely based on the number of objects

        for (int row = 0; row < numRows; row++)
        {
            for (int col = 0; col < numColumns; col++)
            {
                int objectIndex = row * numColumns + col;
                if (objectIndex < numObjects)
                {
                    float x = startX + col * spacing;
                    float y = startY - row * spacing;
                    Vector3 objectPosition = new Vector3(x, y, 0f);

                    // Scale the object size
                    Vector3 objectScale = new Vector3(objectSize, objectSize, objectSize);

                    objectPositions.Add(objectPosition);
                }
            }
        }

        List<Vector3> worldPositions = new List<Vector3>();
        foreach (Vector3 localPosition in objectPositions)
        {
            Vector3 worldPosition = this.transform.TransformPoint(localPosition);
            worldPositions.Add(worldPosition);
        }

        return worldPositions;
    }
}
