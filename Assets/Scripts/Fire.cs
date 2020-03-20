using UnityEngine;
using System.Collections;

public class Fire : MonoBehaviour {

    public GameObject[] Canon_;
    public GameObject[] Rail_;
    private Vector2 original_pos;
    static public bool isActivated;
    //static bool canon_set;
    //static bool rail_set;
    static public int fire_speed;
    static public int rail_unit;
    public GameObject col;
    public GameObject case_lose;
    public GameObject bomb;

    static public bool Game_start;

	void Start () {
        isActivated = false;
        original_pos = this.transform.position;
        //canon_set = false;
        //rail_set = false;
        Fire.Game_start = false;
        Fire.fire_speed = 10000;
        Fire.rail_unit = Rail_.Length-1;
        StartCoroutine(Original_pos());
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator Original_pos()
    {
        yield return new WaitForSeconds(0.7f);

        original_pos = this.transform.position;
     }

    void OnMouseDrag()
    {
        if (Canon_set() && Rail_set() && !Fire.Game_start)
        {
            this.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0.0f)) + new Vector3(0f, 0f, 10f);
            
        }
    }

    void OnMouseUp()
    {
        

        int layerMask = (1 << LayerMask.NameToLayer("Canon"));

        Collider2D hit = Physics2D.OverlapCircle(this.transform.position, 0.1f,layerMask);


        if (hit == null)
        {
            if (!isActivated)
            {
                this.transform.position = original_pos;
            }
        }

        else if (!hit.CompareTag("Canon"))
        {
            if (!isActivated){
                this.transform.position = original_pos;
            }
        }


        else if (hit.CompareTag("Canon"))
        {
            if (hit.gameObject.GetComponent<Canons>().isFirst)  //모든 대포가 설치 됐는지도 확인
            {
                gameObject.GetComponent<Collider2D>().offset = new Vector2(0f, -0.3f);
                isActivated = true;
                Fire.Game_start = true;
                hit.gameObject.SendMessage("Correct_direction");
                
            }
            else
            {
                this.transform.position = original_pos;
            }
        }
        
    }


    //게임오버 처리
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Plane") && Fire.Game_start)
        {
            //게임오버
            Debug.Log("exit");
            Case_lose();
        }
    }

    bool Canon_set()
    {
        for (int i = 0; i < Canon_.Length; ++i)
        {
            if (!Canon_[i].gameObject.GetComponent<Canons>().isActivated)
            {
                return false;
            }
        }
        return true;
    }

    bool Rail_set()
    {
        for (int i = 0; i < Rail_.Length; ++i)
        {
            if (!Rail_[i].gameObject.GetComponent<Rails>().isActivated)
            {
                return false;
            }
        }
        return true;
    }

    void Case_lose()
    {
        Instantiate(case_lose, this.transform.position + new Vector3(-0.3f, .5f, 0f), this.transform.rotation);
        SoundManager.instance.Gameover();
        this.gameObject.SetActive(false);
        bomb.SendMessage("Retry");
    }


}
