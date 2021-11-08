using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class BaseDatosHandler : MonoBehaviour {


    public BaseDatosObjeto bd;
    public Tiles tile;

    public GameObject objectToInstatiate;
    public GameObject objectToInstatiate2;
    //public List<Item> items; 

    //public Objeto prefabToCreate;
    // Use this for initialization
    void Awake () {
        string datos = File.ReadAllText(Application.dataPath + "/JSON/objetos.json");
        string datosUWU = File.ReadAllText(Application.dataPath + "/JSON/Tarea.json");
        //Debug.Log(datosUWU);
        bd = JsonUtility.FromJson<BaseDatosObjeto>(datos);
        tile = JsonUtility.FromJson<Tiles>(datosUWU);
        //Debug.Log(tile.twt);

    }

    void Start()
    {
        
    }

    public Objeto buscarObjetoPorId(int id)
    {
        return bd.baseDatos.Find(objeto => objeto.id == id);
    }
	
}
