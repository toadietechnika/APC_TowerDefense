using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    LineRenderer LineRenderer;
    public List<Vector2> Waypoints = new List<Vector2>();

    void Awake()
    {
        LineRenderer = GetComponent<LineRenderer>();
        LineRenderer.positionCount = transform.childCount;

        for (int i = 0; i < transform.childCount; i++)
        {
            Waypoints.Add(transform.GetChild(i).position);
            LineRenderer.SetPosition(i, Waypoints[i]);
        }
    }
}
