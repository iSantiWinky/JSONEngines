using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

[System.Serializable]
public class Objeto : ISerializationCallbackReceiver {

    //public string nombreSprite;
    //public string rutaSprite;
    //GameObject gameObject;
    //public int vida;
    //public float ataque;
    public string nombre;
    public int id;
    public string code;
    //public string rutaObjeto;

    
    
    //public GameObject prefabToCreate;
    
    
    void ISerializationCallbackReceiver.OnBeforeSerialize() {}

    void ISerializationCallbackReceiver.OnAfterDeserialize()
    {
        //this.rutaSprite = "Sprites/" + nombreSprite;
        //this.rutaObjeto = "/Assets/Resources/Prefabs/LevelCreator/" + nombre;


    }
}

[System.Serializable]
public class Tile: ISerializationCallbackReceiver
{
    public int[] data;
    public int height;
    public string name;
    public int width;

    void ISerializationCallbackReceiver.OnBeforeSerialize() { }

    void ISerializationCallbackReceiver.OnAfterDeserialize()
    {
        //this.rutaSprite = "Sprites/" + nombreSprite;
        //this.rutaObjeto = "/Assets/Resources/Prefabs/LevelCreator/" + nombre;


    }
}

[System.Serializable]
public class BaseDatosObjeto
{
    public List<Objeto> baseDatos;
}


[System.Serializable]
public class Tiles
{
    public List<Tile> twt;
}



