using UnityEngine;
using System.Collections;

public class Rails : MonoBehaviour {

    public bool isActivated;
    static public bool lock_on;
    float timerForDoubleClick = 0.0f;
    float delay = 0.3f;
    Vector3 origianl_pos;
    float _doubleTapTimeD;
    bool doubleTapD = false;
    public GameObject rail_pos;
    
    // Use this for initialization
    void Start () {
        isActivated = false;
        Rails.lock_on = false;
        StartCoroutine(Original_pos());
    }
	
	// Update is called once per frame
	void Update () {
        //if (!isActivated && original_pos.x != this.transform.position.x && original_pos.y != this.transform.position.y)
        //   {
        //       isActivated = true;
        //       Fire.rail_unit -= 1;
        //   }

        //if (end == false && Menu_Tile.end)
        //{
        //    origianl_pos = this.transform.position;
        //    end = true;
        //}


        doubleTapD = false;
        
    }

    IEnumerator Original_pos()
    {
        yield return new WaitForSeconds(0.7f);

        origianl_pos = this.transform.position;
    }


    void OnMouseDown() {
        
        if (!Fire.Game_start && !isActivated)
        {
            //필드위에 설치 안한 것 활성화
            lock_on = !lock_on;
            
        }
        

        
        

        if (lock_on)
        {
            Debug.Log("lock on");
        }

        if (isActivated)
        {
            rail_pos.SetActive(false);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            if (Time.time < _doubleTapTimeD + .3f)
            {
                doubleTapD = true;
            }
            _doubleTapTimeD = Time.time;
        }

        if (doubleTapD)
        {
            if (!Fire.Game_start && isActivated)
            {
                this.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
                transform.position = origianl_pos;
                ++Fire.rail_unit;
                isActivated = false;
                rail_pos.SetActive(true);
            }
         
        }
    }
    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.CompareTag("Rail_Position_column") || other.CompareTag("Rail_Position_row"))
        {
            rail_pos = other.gameObject;
            rail_pos.SetActive(false);
            }
    }

}
