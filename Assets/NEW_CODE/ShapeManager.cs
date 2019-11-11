using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class ShapeManager : MonoBehaviour
{
    public static ShapeManager Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<ShapeManager>();
            return instance;
        }
    }
    private static ShapeManager instance;

    public DataContainer<ShapeObject, List<Vector3>> dc = new DataContainer<ShapeObject, List<Vector3>>();
    public void AddShapeObject(ShapeObject obj)
    {
        if (dc.IsExist(obj) == false)
        {
            dc.Add(obj, obj.Positions); 
        }
    }

    public List<Vector3> GetExistVectorList(ShapeObject compareListTarget)
    {
        List<Vector3> compareList = compareListTarget.Positions;
        List<Vector3> compareList2 = new List<Vector3>();
        List<Vector3> retList = new List<Vector3>();
        foreach (var data in dc.map)
        {
            if (data.Key == compareListTarget) 
                continue;
            else
            {
                foreach (var positions in data.Value)
                    compareList2.Add(positions);
            } 
        }
        foreach(var data in compareList)
        {
            var b = compareList2.Contains(data);
            if (b) retList.Add(data);
        } 

        return retList;
    }

}
