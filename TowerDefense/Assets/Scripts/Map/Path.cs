using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    public Transform startPoint;
    public List<Transform> waypoints;

    private void Start() {
        startPoint = GameObject.Find("StartP").GetComponent<Transform>();
        waypoints = new List<Transform>();
        for(int i = 0; true; i++) {
            string s = "P" + i.ToString();
            GameObject nextP = GameObject.Find(s);
            if (nextP != null) {
                waypoints.Add(nextP.GetComponent<Transform>());
            } else {
                break;
            }
        }
    }
}
