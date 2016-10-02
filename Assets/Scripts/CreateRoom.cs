using UnityEngine;
using System.Collections;

public class CreateRoom : MonoBehaviour {

	// Use this for initialization
	void Start () {
        int[,] area = new int[,] {{0, 0}, {0, 10}, {8, 10}, {10, 8},  {10, 0}};
        Generate(area);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void Generate (int[,] points) {
        int i, j, n = points.Length / 2;
        float max_x, max_y, min_x, min_y, px, py;
        max_x = min_x = points[0,0];
        max_y = min_y = points[0,1];
        GameObject tempfloor, template = GameObject.Find("floor");
        for (i = 1;i < n;i ++) {
            if (points[i,0] > max_x) max_x = points[i,0];
            if (points[i,0] < min_x) min_x = points[i,0];
            if (points[i,1] > max_y) max_y = points[i,1];
            if (points[i,1] < min_y) min_y = points[i,1];
        }
        for (px = min_x;px <= max_x;px += 5)
        {
            for (py = min_y;py <= max_y;py += 5)
            {
                tempfloor = (GameObject)Instantiate(template);
                tempfloor.transform.Translate(px, 0, py);
            }
        }
        template.SetActive(false);
        template = GameObject.Find("wall");
        GameObject tempwall;
        float mid_x, mid_y;
        for (i = 0;i < n - 1;i ++)
        {
            tempwall = (GameObject)Instantiate(template);
            mid_x = (points[i, 0] + points[i + 1, 0]) / 2;
            mid_y = (points[i, 1] + points[i + 1, 1]) / 2;
            px = (float)(mid_x - tempwall.transform.localScale.x);
            py = (float)(mid_y - tempwall.transform.localScale.z);
            tempwall.transform.Translate(mid_x, 0, mid_y);
            mid_x = (points[i, 0] - points[i + 1, 0]) / 2;
            mid_y = (points[i, 1] - points[i + 1, 1]) / 2;
            if (mid_x == 0)
            {
                if (mid_y > 0)
                {
                    tempwall.transform.Rotate((float)0, 180, (float)0);
                }
            }
            else if(mid_y == 0)
            {
                if (mid_x < 0)
                {
                    tempwall.transform.Rotate((float)0, 90, (float)0);
                }
                else
                {
                    tempwall.transform.Rotate((float)0, 270, (float)0);
                }
            }
            else if (mid_y < 0) {
                float ang = (float)(Mathf.Atan(mid_y / mid_x) * 360 / 6.28);
                tempwall.transform.Rotate((float)0, ang, (float)0);
            }
            else
            {
                float ang = (float)(180 + Mathf.Atan(mid_y / mid_x) * 360 / 6.28);
                tempwall.transform.Rotate((float)0, ang, (float)0);
            }
            tempwall.transform.Rotate((float)0, (float)0, (float)-90);
            tempwall.transform.localScale += new Vector3(0, 0, Mathf.Sqrt(mid_x * mid_x + mid_y * mid_y) / 5);
        }
        tempwall = (GameObject)Instantiate(template);
        mid_x = (points[n - 1, 0] + points[0, 0]) / 2;
        mid_y = (points[n - 1, 1] + points[0, 1]) / 2;
        tempwall.transform.Translate(mid_x, 0, mid_y);
        mid_x = (points[n - 1, 0] - points[0, 0]) / 2;
        mid_y = (points[n - 1, 1] - points[0, 1]) / 2;
        if (mid_x == 0)
        {
            if (mid_y > 0)
            {
                tempwall.transform.Rotate((float)0, 180, (float)0);
            }
        }
        else if (mid_y == 0)
        {
            if (mid_x < 0)
            {
                tempwall.transform.Rotate((float)0, 90, (float)0);
            }
            else
            {
                tempwall.transform.Rotate((float)0, 270, (float)0);
            }
        }
        else if (mid_y < 0)
        {
            float ang = (float)(Mathf.Atan(mid_y / mid_x) * 360 / 6.28);
            tempwall.transform.Rotate((float)0, ang, (float)0);
        }
        else
        {
            float ang = (float)(180 + Mathf.Atan(mid_y / mid_x) * 360 / 6.28);
            tempwall.transform.Rotate((float)0, ang, (float)0);
        }
        tempwall.transform.Rotate((float)0, (float)0, (float)-90);
        tempwall.transform.localScale += new Vector3(0, 0, Mathf.Sqrt(mid_x * mid_x + mid_y * mid_y) / 5);
        template.SetActive(false);
        return;
    }
}
