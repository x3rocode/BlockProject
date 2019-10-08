using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 
 
public class ShapeBlock : MonoBehaviour {

     

    //현재 이 블록이 어떤모양인가?
    public ShapeType shapeType;
    public enum ShapeType { Plus, Minus }; 

    public Dictionary<ShapeType, List<Vector3>> cachedShape = new Dictionary<ShapeType, List<Vector3>>();

    public bool isDebug = false; 

    //자식오브젝트의 좌표가 들어갈 리스트
    public List<Vector3> positions = new List<Vector3>(); 

    public int height;
    public int width;
    int a = 0;
    int b = -1;


    //이동된 값을 가져옴
    public void OnChangePosition(Vector3 vector)
    {
        Debug.Log("나 이동 당했어." + vector);
        for(int i = 0; i < positions.Count; i ++)
        {
           positions[i]  += vector; 
        }
    }

    public void OnChangeRotation2(Vector3 rotationAxis, float rotValue)
    {
        this.positions.Clear();

        for (int i = 0; i < this.transform.childCount; i++)
        {
        
            this.positions.Add(this.transform.GetChild(i).position);
        }
    }
     
    public void OnChangeRotation(Vector3 rotationAxis, float rotValue)
    {
        OnChangeRotation2(rotationAxis, rotValue);
        return; 
        Debug.Log("나 회전당했어. => " + rotationAxis +"," + rotValue ); 
        for (int i = 0; i < positions.Count; i++)
        { 

        }
    }

    public List<Vector3> GetShape(ShapeType type)
    {
        List<Vector3> retPositions = new List<Vector3>(); 
        for(int i = 0; i < cachedShape[type].Count; i++)
        {
            retPositions.Add(this.transform.position + cachedShape[type][i]);
        }

        return retPositions;
    }
    private void Init()
    { 
        //플러스  모양을 등록하자
        var plusList = new List<Vector3>() { new Vector3(0, 0, 2), new Vector3(0, 0, -2), new Vector3(1, 0, -1), new Vector3(1, 0, 2), new Vector3(1, 0, 1), new Vector3(1, 0, -2), new Vector3(2, 0, 0), new Vector3(2, 0, -1), new Vector3(2, 0, 1), new Vector3(-1, 0, -1), new Vector3(-1, 0, 2), new Vector3(-1, 0, 1), new Vector3(-1, 0, -2), new Vector3(-2, 0, 0), new Vector3(-2, 0, -1), new Vector3(-2, 0, 1) };
        cachedShape.Add(ShapeType.Plus, plusList);
        //마이너스  모양을  등록하자
        var minusList = new List<Vector3>() { new Vector3(0, 0, 3), new Vector3(-2, 0, -3), new Vector3(1, 0, -1), new Vector3(3, 0, 2), new Vector3(3, 0, 0), new Vector3(2, 0, -1), new Vector3(-1, 0, -1), new Vector3(-1, 0, 2), new Vector3(-1, 0, 1), new Vector3(-1, 0, -2), new Vector3(-2, 0, -1), new Vector3(3, 0, 1), new Vector3(3, 0, -1), new Vector3(1, 0, 3), new Vector3(-1, 0, 3), new Vector3(-1, 0, 0), new Vector3(-3, 0, -2), new Vector3(-1, 0, -3), new Vector3(-3, 0, -3), new Vector3(-3, 0, -1), new Vector3(0, 0, -1), new Vector3(3, 0, -2), new Vector3(3, 0, -3), new Vector3(4, 0, -3), new Vector3(5, 0, -3), new Vector3(5, 0, -2), new Vector3(5, 0, -1), new Vector3(4, 0, -1), new Vector3(4, 0, 3), new Vector3(3, 0, 3), new Vector3(2, 0, 3), new Vector3(-2, 0, 3), new Vector3(-3, 0, 3), new Vector3(-3, 0, 4), new Vector3(-3, 0, 5), new Vector3(-2, 0, 5), new Vector3(-1, 0, 5), new Vector3(-1, 0, 4), new Vector3(5, 0, 3), new Vector3(5, 0, 4), new Vector3(5, 0, 5), new Vector3(3, 0, 4), new Vector3(3, 0, 5), new Vector3(4, 0, 5), new Vector3(0, 0, 3) }; ;  // <-내친구  이안에  들어갈  네모모양을 유니티에서 중앙잘맞처서 만들어서  PrintArrayscript로  디버그로그  뽑은다음 여기에 너으렴  조아조앚왖조아 하고와...


        cachedShape.Add(ShapeType.Minus, minusList); 
    }

    public string PrintArrayScript()
    {
        //이건 무어신지 곧 알개댈거야.
        string front = "{";
        for(int i = 0; i< positions.Count; i++)
        {
            //일캐하면 {0}엔 x,, {1} y, {2}에 z가 들어간단다 ㅇㅋ?응 
            string strPos = string.Format("new  Vector3({0},{1},{2})", positions[i].x, positions[i].y, positions[i].z) ;
            if(positions.Count -1 == i)
            {
                strPos += "};";
            }
            else
            {
                strPos += ",";
            }

            front += strPos;
        }

       
        return front;
    }

    public void OnDrawGizmos()
    {
#if UNITY_EDITOR
        for (int i = 0; i < this.transform.childCount; i++)
        {
            if(i  == 19)
            UnityEditor.Handles.Label(this.transform.GetChild(i).position, "("+i.ToString()+")"+this.transform.GetChild(i).position.ToString()); 
        }
#endif
    }
    public void Awake()
    {
        DebugPositionLoad();
        Init();
        ResizeHeight();
        ResizeWidth();
    } 

    //자식오브젝트 좌표를 가져온다
    public void DebugPositionLoad()
    {
        if(isDebug == true)
        {
            //이미 positions가 있다면 초기화(안전성을 위해)
            positions.Clear();
            for (int i = 0; i < transform.childCount; i ++)
            {
                positions.Add(transform.GetChild(i).position);
            } 
        }
    }
 
    public int GetResizeScale()
    {
        if (shapeType == ShapeType.Plus) return 6;
        if (shapeType == ShapeType.Minus) return 6; 

        return -1;
    }

    //세로로 붙히기
    public void ResizeHeight()
    {
        height = height - 1;
        List<Vector3> newVectList = new List<Vector3>();
        //Copy
        for (int i = 0; i < positions.Count; i++)
        {
            for(int j = 1; j <= height; j ++)
            {
                Vector3 newPosition = positions[i] - new Vector3(0, 0, GetResizeScale() * j);

                if (positions.Contains(newPosition) == false && newVectList.Contains(newPosition) == false)
                {
                    GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    cube.transform.SetParent(gameObject.transform);
                    cube.transform.position = newPosition; 
                    newVectList.Add(newPosition);
                }
                else
                {
                    Debug.Log("contains remove processing => " + newPosition);
                }
            }
           
        }

        positions.AddRange(newVectList);

        for (int i = 0; i < positions.Count; i++)
        {
            Vector3 newPosition = positions[i] + new Vector3(0, 0, GetResizeScale()/2 * height);
            transform.GetChild(i).position = newPosition;
        }

        DebugPositionLoad();
    }


    public void ResizeWidth()
    {
        width = width - 1;
        List<Vector3> newVectList = new List<Vector3>();

        for (int i = 0; i < positions.Count; i++)
        {
            for (int j = 1; j <= width; j++)
            {
               
                Vector3 newPosition = positions[i] - new Vector3(GetResizeScale() * j, 0, 0);

                if (positions.Contains(newPosition) == false && newVectList.Contains(newPosition) == false)
                {
                    GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    cube.transform.SetParent(gameObject.transform);
                    cube.transform.position = newPosition;
                    newVectList.Add(newPosition);
                }
                else
                {
                    Debug.Log("contains remove processing => " + newPosition);
                }
            } 
        }

        positions.AddRange(newVectList);
        for (int i = 0; i < positions.Count; i++)
        {
            Vector3 newPosition = positions[i] + new Vector3(GetResizeScale()/2 * width, 0, 0);
            transform.GetChild(i).position = newPosition;
        }

        DebugPositionLoad();
    }
}
 