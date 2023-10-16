using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;

    private Vector3 offset;

    //start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}