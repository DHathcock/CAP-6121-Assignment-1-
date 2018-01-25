using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDroid : MonoBehaviour {
    public float chaseSpeed = 2;
    string targetName = "Player";
    GameObject target;

	// Use this for initialization
	void Start () {
        // Find the Player Game Object with the Tag: "Player".
        target = GameObject.FindWithTag(targetName);
	}
	
	// Update is called once per frame
	void Update () {
        // Have this object look at the target
        this.transform.LookAt(target.transform);
        // Move this object position toward the target
        this.transform.position += transform.forward * chaseSpeed * Time.deltaTime;
	}
}
