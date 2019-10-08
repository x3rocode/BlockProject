using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDataContainer
{
    public List<MapData> listMapData = new List<MapData>();
    public Dictionary<Vector3, MapData> DicMapData = new Dictionary<Vector3, MapData>();

    public void Add(Vector3 pos)
    {
        if (DicMapData.ContainsKey(pos) == false)
        {

            GameObject block = GameObject.CreatePrimitive(PrimitiveType.Cube);
            block.transform.position = pos;

            var md = new MapData();
            md.obj = block;
            md.isUsed = true;

            listMapData.Add(md);
            DicMapData.Add(pos, md);

        }
        else
        {
            Debug.Log("already exist pos =>" + pos);
        }
    }
    public void Add(List<Vector3> vectors)
    {
        foreach(var pos in vectors)
        {
            Add(pos);
        }
    }

    public void Delete(Vector3 pos)
    {
        if(DicMapData.ContainsKey(pos) == true)
        {
            var md = DicMapData[pos];
            GameObject.Destroy(md.obj);

            listMapData.Remove(DicMapData[pos]);
            DicMapData.Remove(pos);

            md.isUsed = false;
        }
        else
        {
            Debug.Log("already not exist pos =>" + pos);
        }
    }
}

public class MapData
{
    public bool isUsed = false;
    public GameObject obj;
}

 

public class CreateBlock : MonoBehaviour {

    public Vector3 vect;
    public BlockDataContainer blockDataContainer = new BlockDataContainer();

    // Use this for initialization
    void Start ()
    {
        //생성-삭제
        CreateObject(vect);
        DeleteObject(vect);

        //생-생-삭
        CreateObject(vect);
        CreateObject(vect);
        DeleteObject(vect);

        //생-삭-삭
        CreateObject(vect);
        DeleteObject(vect);
        DeleteObject(vect);
    }


    // Update is called once per frame
    void Update () {
        if (Input.GetMouseButtonDown(0))
            CreateObject(vect);
	}

    public void CreateObject(Vector3 vector)
    {
        blockDataContainer.Add(vector);
    }

    public void DeleteObject(Vector3 vector)
    {
        blockDataContainer.Delete(vector);
    }
}
