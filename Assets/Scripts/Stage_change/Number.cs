using UnityEngine;
using System.Collections;

public class Number : MonoBehaviour {

    public Sprite[] Stage_;
    private SpriteRenderer sprite_renderer;
    static public int stage = 0;

    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        sprite_renderer = gameObject.GetComponent<SpriteRenderer>();
        sprite_renderer.sprite = Stage_[stage];
    }

    
}
