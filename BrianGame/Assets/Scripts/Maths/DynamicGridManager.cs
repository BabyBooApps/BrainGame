using System.Collections.Generic;
using UnityEngine;

public class DynamicGridManager : MonoBehaviour
{



    public int maxColumns = 3; // Maximum number of columns
    public int maxRows = 3;



    //public int maxColumns = 3; // Maximum number of columns
    float spacing_X = 0.5f; // Spacing between objects
    float spacing_Y = 0.5f;

    float min_Spacing = 0.1f;
    float max_spacing = 2.0f;


    public List<Vector3> CalculateGridPositions(int numObjects)
    {
        List<Vector3> objectPositions = new List<Vector3>();
        int numRows = Mathf.CeilToInt((float)numObjects / maxColumns); // Calculate the number of rows


        // Calculate the starting position
        float startX = -(maxColumns - 1) * spacing_X / 2f;
        float startY = (numRows - 1) * spacing_Y / 2f;

        for (int row = 0; row < numRows; row++)
        {
            int rowObjectCount = Mathf.Min(maxColumns, numObjects - row * maxColumns);

            for (int col = 0; col < rowObjectCount; col++)
            {
                Vector3 objectPosition = new Vector3(startX + col * spacing_X, startY - row * spacing_Y, 0f);
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

        float startX = -(numColumns - 1) * spacing_X / 2f;
        float startY = (numRows - 1) * spacing_X / 2f;

        float objectSize = 1f / Mathf.Sqrt(numObjects); // Calculate the object size inversely based on the number of objects

        for (int row = 0; row < numRows; row++)
        {
            for (int col = 0; col < numColumns; col++)
            {
                int objectIndex = row * numColumns + col;
                if (objectIndex < numObjects)
                {
                    float x = startX + col * spacing_X;
                    float y = startY - row * spacing_X ;
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

    public List<Vector3> CalculateGridPositions_V3(int numObjects)
    {
        List<Vector3> objectPositions = new List<Vector3>();

        // Calculate the number of rows and columns to fit the desired number of objects while maintaining symmetry
        int numRows = Mathf.CeilToInt(Mathf.Sqrt(numObjects));
        int numColumns = Mathf.CeilToInt((float)numObjects / numRows);

        float objectSize = 1f * 0.5f / Mathf.Sqrt(numObjects); // Calculate the object size inversely based on the number of objects
        float minObjectSize = 0.2f; // Set a minimum object size

        // Adjust objectSize based on the number of objects
        objectSize = Mathf.Max(objectSize, minObjectSize);

        // Increase spacing_X and spacing_Y to increase the spacing between grid objects
        float spacing_X = 1.2f;
        float spacing_Y = 1.2f;

        // Calculate the half-width and half-height of the grid based on the new spacing
        float halfWidth = (numColumns - 1) * spacing_X / 2;
        float halfHeight = (numRows - 1) * spacing_Y / 2;

        for (int row = 0; row < numRows; row++)
        {
            for (int col = 0; col < numColumns; col++)
            {
                // Calculate the local position based on row, column, spacing, and the center.
                Vector3 localPosition = new Vector3(col * spacing_X - halfWidth, row * spacing_Y - halfHeight, 0);

                // Calculate the world position by adding the grid generator position to the local position.
                Vector3 worldPosition = this.transform.TransformPoint(localPosition);

                objectPositions.Add(worldPosition);

                if (objectPositions.Count >= numObjects)
                {
                    // Stop adding positions once the desired number is reached
                    return objectPositions;
                }
            }
        }

        return objectPositions;
    }


    public List<Vector3> GenerateGrid(int rows, int columns)
    {
        spacing_X = Mathf.Lerp(min_Spacing, max_spacing, Mathf.Clamp01(2.0f / columns));
        spacing_Y = Mathf.Lerp(min_Spacing, max_spacing, Mathf.Clamp01(2.0f / rows));


        List<Vector3> objectPositions = new List<Vector3>();
        // Calculate the half-width and half-height of the grid.
        float halfWidth = (columns - 1) * spacing_X / 2;
        float halfHeight = (rows - 1) * spacing_Y / 2;

        // Get the position of the GridGenerator game object.
        Vector3 gridGeneratorPosition = transform.position;

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                // Calculate the local position based on row, column, spacing, and the center.
                Vector3 localPosition = new Vector3(col * spacing_X - halfWidth, row * spacing_Y - halfHeight, 0);

                // Calculate the world position by adding the grid generator position to the local position.
                Vector3 worldPosition = this.transform.TransformPoint(localPosition);

                objectPositions.Add(worldPosition);

                // Instantiate the gridObjectPrefab at the calculated world position.
               // Instantiate(gridObjectPrefab, worldPosition, Quaternion.identity);
            }
        }
        return objectPositions;
    }
}
