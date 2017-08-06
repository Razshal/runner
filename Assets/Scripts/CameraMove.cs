using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

    public  GameObject  player;
    private Vector3     offset;
    private Vector3     playerPos;

	// Use this for initialization
	void Start () {
        offset = transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        playerPos = player.transform.position;
        playerPos.y = -3;
        transform.position = playerPos + offset;
	}
}
