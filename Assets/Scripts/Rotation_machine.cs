using UnityEngine;
using System.Collections;

public class Rotation_machine : MonoBehaviour {

    static public bool isActivated;

	void Start () {
        Rotation_machine.isActivated = false;
	}
	
	// Update is called once per frame
	void Update () {
	    if (Fire.Game_start)
        {
            Rotation_machine.isActivated = true;
        }
	}
}
