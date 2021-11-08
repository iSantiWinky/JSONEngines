using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCreator : MonoBehaviour
{
    public int rows = 10;
    public int columns = 10;
    public float cellSize = 1;
    public Vector3 offset;
    public int value = 1;
    public BaseDatosHandler items;
    //public BaseDatosHandler level;
    private MyGrid grid;

    private Tile[,] celdas;

    private int[,] colores;

    private int[,] letras;


    void Start()
    {
        grid = new MyGrid(rows, columns, cellSize, offset);
        celdas = new Tile[rows,columns];
        colores = new int[rows,columns];
        letras = new int[rows, columns];
        int c = items.tile.twt[0].data.Length;
        

        if (c == rows * columns)
        {
            for (int i = 0; i < c; i++)
            {

                //celdas[Mathf.FloorToInt(i / columns),Mathf.FloorToInt(i % columns)] = items.tile.twt[i];
                colores[Mathf.FloorToInt(i / columns), Mathf.FloorToInt(i % columns)] = items.tile.twt[0].data[i];
                //Debug.Log("Esta es la data de mi celda: " + colores[Mathf.FloorToInt(i / columns), Mathf.FloorToInt(i % columns)]);
                letras[Mathf.FloorToInt(i / columns), Mathf.FloorToInt(i % columns)] = items.tile.twt[1].data[i];
                //Debug.Log("Esta es la data de mi celda: " + letras[Mathf.FloorToInt(i / columns), Mathf.FloorToInt(i % columns)]);
            }
        }
        else
        {
            Debug.Log("Toy vacio");
        }

        for (int i = 0; i < colores.GetLength(0); i++)
        {
            for (int j = 0; j < colores.GetLength(1); j++)
            {
                Debug.Log("Iteracion x: " + i + " y: " + j);
                Debug.Log("Letra: "+letras[i, j]);
                Debug.Log("Color: "+colores[i, j]);
                switch (colores[i,j])
                {
                    case 1:
                        items.objectToInstatiate = Resources.Load<GameObject>(items.bd.baseDatos[1].nombre);
                        break;

                    case 2:
                        items.objectToInstatiate = Resources.Load<GameObject>(items.bd.baseDatos[2].nombre);
                        break;

                    case 3:
                        items.objectToInstatiate = Resources.Load<GameObject>(items.bd.baseDatos[3].nombre);
                        break;

                    default:
                        items.objectToInstatiate = Resources.Load<GameObject>(items.bd.baseDatos[0].nombre);
                        break;
                }
                switch(letras[i,j])
                {
                    case 4:
                        items.objectToInstatiate2 = Resources.Load<GameObject>(items.bd.baseDatos[4].nombre);
                        break;

                    case 5:
                        items.objectToInstatiate2 = Resources.Load<GameObject>(items.bd.baseDatos[5].nombre);
                        break;
                    case 6:
                        items.objectToInstatiate2 = Resources.Load<GameObject>(items.bd.baseDatos[6].nombre);
                        break;
                    case 7:
                        items.objectToInstatiate2 = Resources.Load<GameObject>(items.bd.baseDatos[7].nombre);
                        break;
                    case 8:
                        items.objectToInstatiate2 = Resources.Load<GameObject>(items.bd.baseDatos[8].nombre);
                        break;
                    case 9:
                        items.objectToInstatiate2 = Resources.Load<GameObject>(items.bd.baseDatos[9].nombre);
                        break;
                    case 10:
                        items.objectToInstatiate2 = Resources.Load<GameObject>(items.bd.baseDatos[10].nombre);
                        break;
                    case 11:
                        items.objectToInstatiate2 = Resources.Load<GameObject>(items.bd.baseDatos[11].nombre);
                        break;
                    case 12:
                        items.objectToInstatiate2 = Resources.Load<GameObject>(items.bd.baseDatos[12].nombre);
                        break;
                    case 13:
                        items.objectToInstatiate2 = Resources.Load<GameObject>(items.bd.baseDatos[13].nombre);
                        break;
                    case 14:
                        items.objectToInstatiate2 = Resources.Load<GameObject>(items.bd.baseDatos[14].nombre);
                        break;
                    case 15:
                        items.objectToInstatiate2 = Resources.Load<GameObject>(items.bd.baseDatos[15].nombre);
                        break;
                    case 16:
                        items.objectToInstatiate2 = Resources.Load<GameObject>(items.bd.baseDatos[16].nombre);
                        break;
                    case 17:
                        items.objectToInstatiate2 = Resources.Load<GameObject>(items.bd.baseDatos[17].nombre);
                        break;
                    case 18:
                        items.objectToInstatiate2 = Resources.Load<GameObject>(items.bd.baseDatos[18].nombre);
                        break;
                    case 19:
                        items.objectToInstatiate2 = Resources.Load<GameObject>(items.bd.baseDatos[19].nombre);
                        break;
                    case 20:
                        items.objectToInstatiate2 = Resources.Load<GameObject>(items.bd.baseDatos[20].nombre);
                        break;
                    case 21:
                        items.objectToInstatiate2 = Resources.Load<GameObject>(items.bd.baseDatos[21].nombre);
                        break;
                    case 22:
                        items.objectToInstatiate2 = Resources.Load<GameObject>(items.bd.baseDatos[22].nombre);
                        break;
                    case 23:
                        items.objectToInstatiate2 = Resources.Load<GameObject>(items.bd.baseDatos[23].nombre);
                        break;
                    case 24:
                        items.objectToInstatiate2 = Resources.Load<GameObject>(items.bd.baseDatos[24].nombre);
                        break;
                    case 25:
                        items.objectToInstatiate2 = Resources.Load<GameObject>(items.bd.baseDatos[25].nombre);
                        break;
                    case 26:
                        items.objectToInstatiate2 = Resources.Load<GameObject>(items.bd.baseDatos[26].nombre);
                        break;
                    case 27:
                        items.objectToInstatiate2 = Resources.Load<GameObject>(items.bd.baseDatos[27].nombre);
                        break;
                    case 28:
                        items.objectToInstatiate2 = Resources.Load<GameObject>(items.bd.baseDatos[28].nombre);
                        break;
                    case 29:
                        items.objectToInstatiate2 = Resources.Load<GameObject>(items.bd.baseDatos[29].nombre);
                        break;

                    default:
                        items.objectToInstatiate2 = Resources.Load<GameObject>(items.bd.baseDatos[0].nombre);
                        Debug.Log("BLABLA");
                        break;

                }

                if(colores[i,j]!=0)
                {
                    Instantiate(items.objectToInstatiate, grid.debugTextArray[i, j].transform.position, Quaternion.identity);
                }
                if (letras[i, j] != 0 || letras[i,j]!=1 || letras[i, j] != 2 || letras[i, j] != 3)
                {
                    Debug.Log(items.objectToInstatiate2.name);
                    Instantiate(items.objectToInstatiate2, grid.debugTextArray[i, j].transform.position + new Vector3(0, 1, 0), Quaternion.identity);
                }
            }
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Vector3 dir = hit.point - transform.position;
            dir.y = 0;
            
            Debug.DrawLine(Camera.main.transform.position, hit.point);

        }

        if (Input.GetMouseButtonDown(0))
        {
            grid.SetValue(hit.point, value);
            Debug.Log(hit.point);

        }
    }
}