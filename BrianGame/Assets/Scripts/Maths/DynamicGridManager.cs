using System.Collections.Generic;
using UnityEngine;

public class DynamicGridManager : MonoBehaviour
{
    public GameObject gridPrefab; // The prefab of your grid object
    public GameObject[] objectsToPlace; // An array of objects to be placed in grids

    int ObjectCount;
    public int maxColumns = 3; // Maximum number of columns
    public int maxRows = 3;
    public float Max_Size = 1;
    public List<GameObject> Math_Items = new List<GameObject>();

    void Start()
    {

    }

    public void SetGrid(int count, GameObject item , Sprite sp)
    {
        float objectSize = Max_Size / Mathf.Sqrt(count);
        List<Vector3> gridPos = CalculateGridPositions_V2(count);

        for (int i = 0; i < gridPos.Count; i++)
        {
            Debug.Log("Pos Count : " + gridPos.Count);
            GameObject currentGrid = Instantiate(item, Vector3.zero, Quaternion.identity);
            currentGrid.transform.parent = this.transform;
            currentGrid.transform.localPosition = gridPos[i];
            currentGrid.transform.localScale = new Vector3(objectSize, objectSize, 1);
            currentGrid.GetComponent<SpriteRenderer>().sprite = sp;
            Math_Items.Add(currentGrid);

        }
    }

    public void ResetGrid()
    {
        for(int i = 0; i < Math_Items.Count; i++)
        {
            Destroy(Math_Items[i]);
        }

        Math_Items.Clear();
    }

    //public void SetGrid(int count , GameObject Item)
    //{
    //    int maxColumns = 3; // Maximum number of columns
    //    int numRows = Mathf.CeilToInt((float)count / maxColumns); // Calculate the number of rows

    //    for (int row = 0; row < numRows; row++)
    //    {


    //        for (int col = 0; col < maxColumns; col++)
    //        {
    //            int objectIndex = row * maxColumns + col;



    //            if (objectIndex < count)
    //            {
    //                GameObject currentGrid = Instantiate(Item, Vector3.zero, Quaternion.identity);
    //                ///GameObject currentObject = objectsToPlace[objectIndex];
    //                currentGrid.transform.SetParent(this.transform);
    //                Debug.Log("Row : " + row + ", Col : " + col);
    //                Vector3 objectPosition = new Vector3(col * 2f, -row * 2f, 0f); // Adjust spacing as needed
    //                currentGrid.transform.localPosition = objectPosition;
    //            }
    //        }
    //    }
    //}

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

        return objectPositions;
    }
}
