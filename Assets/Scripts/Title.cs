using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class Title : MonoBehaviour {
    


	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
}
