using UnityEngine;
using System.Collections;

public class Collider_point : MonoBehaviour {

    public GameObject[] Rail_;

    // Use this for initialization
    void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (Rails.lock_on && Fire.rail_unit >= 0 && other.CompareTag("Rail_Position_column"))
        {
            Rail_[Fire.rail_unit].transform.Rotate(new Vector3(0f, 0f, 90f));
            Rail_[Fire.rail_unit].transform.position = new Vector3(other.transform.position.x,other.transform.position.y,-0.1f);
            Rail_[Fire.rail_unit].GetComponent<Rails>().isActivated = true;
            Fire.rail_unit -= 1;
            if (Fire.rail_unit == -1)
            {
                Rails.lock_on = false;
            }
            //GetComponent<Rails>().rail_pos = other.gameObject;
            //other.gameObject.SetActive(false);
        }

        else if (Rails.lock_on && Fire.rail_unit >= 0 && other.CompareTag("Rail_Position_row"))
        {
            Rail_[Fire.rail_unit].transform.position = new Vector3(other.transform.position.x, other.transform.position.y, -0.1f);
            Rail_[Fire.rail_unit].GetComponent<Rails>().isActivated = true;
            Fire.rail_unit -= 1;
            //other.gameObject.SetActive(false);
            //Debug.Log(other);
        }
        
    }
}
