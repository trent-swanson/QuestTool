using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour {

    public Transform player;
    public Transform camPoint;
    public float camSpeed = 5;

	void Update() {
        transform.position = Vector3.Lerp(transform.position, camPoint.position, camSpeed * Time.deltaTime);
        transform.LookAt(player.position);
    }
}
