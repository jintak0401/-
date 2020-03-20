using UnityEngine;
using System.Collections;

public class Position_of_Rail : MonoBehaviour {

    public GameObject[] Rail_;
    private Rigidbody2D rb_rail;

    void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDrag()
    {
        Debug.Log("1");
        rb_rail = Rail_[Fire.rail_unit].gameObject.GetComponent<Rigidbody2D>();
        rb_rail.MovePosition(this.transform.position);
    }
}
