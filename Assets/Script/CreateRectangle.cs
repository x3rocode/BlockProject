using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateRectangle : MonoBehaviour {

    public GameObject cubePrefab;
    public int scale;

	// Use this for initialization
	void Start () {
        CreateRect(scale);

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    /*
    public void CreateRect(int count)
    {
        for (int i = (count - 1) * -1; i <= count - 1; i++)
        {
            for (int j = count - 1; j >= (count - 1) * -1; j--)
            {
                GameObject cube = GameObject.Instantiate(cubePrefab);
                cube.transform.position = new Vector3(i, j);
                Rectangle rect = cube.GetComponent<Rectangle>();

                rect.topLine.SetActive(true);
            }
        }
    }
    */


    public void CreateRect(int count)
    {
        for(int i = (count-1) * -1; i <= count -1; i ++ )
        {
            for(int j = count - 1; j >= (count-1) * -1; j--)
            {
                for(int k = (count - 1) * -1; k <= count-1; k++)
                {
                    GameObject cube = GameObject.Instantiate(cubePrefab);
                    cube.transform.position = new Vector3(i, j, k);
                    Rectangle rect = cube.GetComponent<Rectangle>();

                    rect.fronttopLine.SetActive(true);
                    rect.frontleftLine.SetActive(true);
                    rect.topleftLine.SetActive(true);


                    if (j == (count - 1) * -1)
                    {
                        rect.frontbottomLine.SetActive(true);
                        rect.bottomleftLine.SetActive(true);
                    }
                    if (i == (count - 1))
                    {
                        rect.frontrightLine.SetActive(true);
                        rect.toprightLine.SetActive(true);
                        if (j == (count - 1) * -1)
                        {
                            rect.bottomrightLine.SetActive(true);
                        }

                    }

                    if (k == (count - 1))
                    {
                        rect.leftLine.SetActive(true);
                        rect.rightLine.SetActive(true);
                        rect.topLine.SetActive(true);
                        rect.bottomLine.SetActive(true);
                    }

                }
            }
        }
    }
}
