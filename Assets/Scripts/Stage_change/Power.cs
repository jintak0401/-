using UnityEngine;
using System.Collections;

public class Power : MonoBehaviour {

    public Sprite[] Power_;
    private SpriteRenderer sprite_renderer;


    void Start () {
        sprite_renderer = gameObject.GetComponent<SpriteRenderer>();
        sprite_renderer.sprite = Power_[0];
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown()
    {
        sprite_renderer.sprite = Power_[1];
        StartCoroutine(game_quit());
    }

    IEnumerator game_quit()
    {
        yield return new WaitForSeconds(1f);
        Application.Quit();
    }

}
