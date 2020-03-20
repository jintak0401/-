using UnityEngine;
using System.Collections;

public class Stage_last : MonoBehaviour {

    public Sprite[] last_;
    private SpriteRenderer sprite_renderer;
    

    void Start () {
        sprite_renderer = gameObject.GetComponent<SpriteRenderer>();
        sprite_renderer.sprite = last_[0];
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown()
    {
        sprite_renderer.sprite = last_[1];
    }

    void OnMouseUp()
    {
        sprite_renderer.sprite = last_[0];
        if (Number.stage > 0)
        {
            --Number.stage;
        }
    }
}
