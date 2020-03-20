using UnityEngine;
using System.Collections;

public class Stage_next : MonoBehaviour
{

    public Sprite[] next_;
    private SpriteRenderer sprite_renderer;


    void Start()
    {
        sprite_renderer = gameObject.GetComponent<SpriteRenderer>();
        sprite_renderer.sprite = next_[0];
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        sprite_renderer.sprite = next_[1];
    }

    void OnMouseUp()
    {
        sprite_renderer.sprite = next_[0];
        if (Number.stage <24)
        {
            ++Number.stage;
        }
    }
}
