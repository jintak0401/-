using UnityEngine;
using System.Collections;

public class Camera_sound : MonoBehaviour {

    private GameObject cam;

    private AudioSource audio;

    static private bool first=true;

    void Start()
    {
        cam = this.gameObject;
        audio = this.GetComponent<AudioSource>();
        audio.Pause();

        if (first)
        {
            DontDestroyOnLoad(cam);
            first = false;
            audio.Play();
        }
    }
	
	// Update is called once per frame
	void Update () {
	    
	}
}
