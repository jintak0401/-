using UnityEngine;
using System.Collections;

public class Sub_rail : MonoBehaviour {

    public GameObject active;
    public Sprite[] nums;
    private SpriteRenderer sprite_renderer;


    void Start()
    {
        active.SetActive(false);
        sprite_renderer = gameObject.GetComponent<SpriteRenderer>();
        sprite_renderer.sprite = nums[Fire.rail_unit+1];
        Debug.Log(Fire.rail_unit);
    }

    // Update is called once per frame
    void Update () {
	    if (Rails.lock_on)
        {
            active.SetActive(true);

        }
        else
        {
            active.SetActive(false);
        }
        sprite_renderer.sprite = nums[Fire.rail_unit+1];

    }
}
