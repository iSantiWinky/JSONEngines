using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyGrid
{

    public int width;
    public int height;
    public float cellSize;
    public Vector3 offset;

    private int[,] gridArray;
    public TextMesh[,] debugTextArray;

    public MyGrid(int width, int height, float cellSize, Vector3 offset)
    {
        this.height = height;
        this.width = width;
        this.cellSize = cellSize;
        this.offset = offset;

        gridArray = new int[width, height];
        debugTextArray = new TextMesh[width, height];

        //Debug.Log("Grid size: " + width + " , " + height);

        for (int x = 0; x < gridArray.GetLength(0); x++)
        {
            for (int z = 0; z < gridArray.GetLength(0); z++)
            {
                //Debug.Log(x + "," + z);

                debugTextArray[x, z] = DebugText(gridArray[x, z].ToString(), null, GetWorldPosition(x, z) + new Vector3(cellSize, 0, cellSize) * .5f, 12, Color.white, TextAnchor.MiddleCenter);//Agregar offset 
                Debug.DrawLine(GetWorldPosition(x, z), GetWorldPosition(x, z + 1), Color.white, 100f);
                Debug.DrawLine(GetWorldPosition(x, z), GetWorldPosition(x + 1, z), Color.white, 100f);
            }
            Debug.DrawLine(GetWorldPosition(0, height), GetWorldPosition(width, height), Color.white, 100f);
            Debug.DrawLine(GetWorldPosition(width, 0), GetWorldPosition(width, height), Color.white, 100f);
        }
    }

    private Vector3 GetWorldPosition(int x, int z)
    {
        return new Vector3(x, 0, z) + offset * cellSize;
    }

    private void GetXZ(Vector3 worldPos, out int x, out int z)
    {
        x = Mathf.FloorToInt(worldPos.x / cellSize);
        z = Mathf.FloorToInt(worldPos.z / cellSize);
    }

    public void SetValue(int x, int z, int value)
    {
        if (x >= 0 && z >= 0 && x < width && z < height)
        {
            gridArray[x, z] = value;
            debugTextArray[x, z].text = gridArray[x, z].ToString();
        }
    }

    public void SetValue(Vector3 worldPos, int value)
    {
        int x, z;
        GetXZ(worldPos - offset, out x, out z);
        SetValue(x, z, value);
    }

    public int GetValue(int x, int z)
    {
        if (x >= 0 && z >= 0 && x < width && z < height) // 0 - width 0 height
        {
            return gridArray[x, z];
        }
        else
        {
            return 0;
        }

    }
    public int GetValue(Vector3 worldPos)
    {
        int x, z;
        GetXZ(worldPos, out x, out z);
        return GetValue(x, z);
    }

    public static TextMesh DebugText(string text, Transform parent = null, Vector3 lPos = default(Vector3), int fontSize = 40, Color? color = null, TextAnchor textAnchor = TextAnchor.UpperLeft, TextAlignment textAlign = TextAlignment.Left, int sortingOrder = 5000)
    {
        if (color == null) { color = Color.white; }
        return CreateText(parent, text, lPos, fontSize, (Color)color, textAnchor, textAlign, sortingOrder);
    }

    public static TextMesh CreateText(Transform parent, string text, Vector3 lPos, int fontSize, Color color, TextAnchor textAnchor, TextAlignment textAlign, int sortingOrder)
    {
        GameObject go = new GameObject("Worl_Text", typeof(TextMesh));

        Transform t = go.transform;

        t.SetParent(parent, false);

        t.localPosition = lPos;

        TextMesh tm = go.GetComponent<TextMesh>();

        tm.gameObject.transform.Rotate(90f, 0, 0);

        tm.anchor = textAnchor;

        tm.alignment = textAlign;

        tm.text = text;

        tm.fontSize = fontSize;

        tm.color = color;

        tm.GetComponent<MeshRenderer>().sortingOrder = sortingOrder;

        return tm;
    }

}