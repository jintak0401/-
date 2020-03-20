using UnityEngine;
using System.Collections;

public class Plane : MonoBehaviour {

    public GameObject col;
    public BoxCollider2D box_collier;
    Vector2 original_pos;
    Vector2 original_size;
    static Vector3 direction;

    void Start () {
        box_collier = (BoxCollider2D)col.GetComponent<Collider2D>() ;
        original_pos = col.transform.position;
        original_size = box_collier.size;
        col.SetActive(false);	    
	}
	
	// Update is called once per frame
	void Update () {

	}

    void OnMouseDown()
    {
        if (!Fire.Game_start)
        {
            box_collier.size = new Vector2(0.1f, 0.1f);
            col.SetActive(true);

        }

        

    }

    void OnMouseDrag()
    {
        if (!Fire.Game_start) {
            box_collier.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }


    }
    void OnMouseUp()
    {
        col.SetActive(false);
        box_collier.size = original_size;
        box_collier.transform.position = original_pos;
    }

}
