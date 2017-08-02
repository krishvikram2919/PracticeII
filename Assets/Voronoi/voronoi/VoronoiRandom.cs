﻿using UnityEngine;
using System.Collections.Generic;


namespace Voronoi{
public class VoronoiRandom : MonoBehaviour {

    public float minX = -1;
    public float maxX = +1;

    public float minY = -1;
    public float maxY = +1;

    public int length = 100;
	
	public List<Vector2> points = new List<Vector2>();
	public List<Color> colours = new List<Color>();

    private Material material;

    // Use this for initialization
    public void Start () {
        material = GetComponent<Renderer>().sharedMaterial;

        //points = new Vector2[length];
        //colours = new Color[length];

        for (int i = 0; i < length; i ++)
        {
			//points.Add( new Vector2( transform.position.x + Random.Range(minX, maxX), transform.position.y + Random.Range(minY, maxY) ) );
           	//colours.Add( HSVToRGB( (1f / length) * i, 0.75f, 0.75f));

            // Shader
            material.SetVector("_Points" + i.ToString(), points[i]);
            material.SetVector("_Colors" + i.ToString(), colours[i]);
        }
        material.SetInt("_Length", length);
    }




    public static Color HSVToRGB(float H, float S, float V)
    {
        if (S == 0f)
            return new Color(V, V, V);
        else if (V == 0f)
            return Color.black;
        else
        {
            Color col = Color.black;
            float Hval = H * 6f;
            int sel = Mathf.FloorToInt(Hval);
            float mod = Hval - sel;
            float v1 = V * (1f - S);
            float v2 = V * (1f - S * mod);
            float v3 = V * (1f - S * (1f - mod));
            switch (sel + 1)
            {
                case 0:
                    col.r = V;
                    col.g = v1;
                    col.b = v2;
                    break;
                case 1:
                    col.r = V;
                    col.g = v3;
                    col.b = v1;
                    break;
                case 2:
                    col.r = v2;
                    col.g = V;
                    col.b = v1;
                    break;
                case 3:
                    col.r = v1;
                    col.g = V;
                    col.b = v3;
                    break;
                case 4:
                    col.r = v1;
                    col.g = v2;
                    col.b = V;
                    break;
                case 5:
                    col.r = v3;
                    col.g = v1;
                    col.b = V;
                    break;
                case 6:
                    col.r = V;
                    col.g = v1;
                    col.b = v2;
                    break;
                case 7:
                    col.r = V;
                    col.g = v3;
                    col.b = v1;
                    break;
            }
            col.r = Mathf.Clamp(col.r, 0f, 1f);
            col.g = Mathf.Clamp(col.g, 0f, 1f);
            col.b = Mathf.Clamp(col.b, 0f, 1f);
            return col;
        }
    }
}
}
