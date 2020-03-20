using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class Menu_Tile : MonoBehaviour {

    public Sprite[] Menu_;
    private SpriteRenderer sprite_renderer;
    private Vector2 mouse;
    public GameObject For_Rot;
    private bool start;
    
    void Start () {
        For_Rot.transform.rotation = Quaternion.Euler(new Vector3(90f, 0f, 0f));
        StartCoroutine(To_Menu());

        sprite_renderer = gameObject.GetComponent<SpriteRenderer>();
        sprite_renderer.sprite = Menu_[0];
        start = false;
    }
	
	// Update is called once per frame
	void Update () {

        

    }

    void OnMouseDown()
    {
        sprite_renderer.sprite = Menu_[1];
    }

    void OnMouseDrag()
    {
        mouse = (Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y)));
    }

    void OnMouseUp()
    {
        sprite_renderer.sprite = Menu_[0];
        if (mouse.x <= -5.4f && mouse.x >=-6.6 && mouse.y >=-4.5f && mouse.y <= -3.3f)
        {
            start = true;
            StartCoroutine(To_Menu());
        }
    }

    IEnumerator To_Menu()
    {

        
        WaitForFixedUpdate wait = new WaitForFixedUpdate();
        
        Vector3 vec = For_Rot.transform.rotation.eulerAngles;
        vec.x = vec.x - 90f;
        //Mathf.RoundToInt(vec.z);

        Quaternion To = Quaternion.Euler(vec);

        float count = 0;
        while (count < 90)
        {
            
            count += Time.deltaTime * 170;
            For_Rot.transform.eulerAngles += Time.deltaTime * new Vector3(-170f, 0.0f, 0.0f);

            //Quaternion.Slerp(this.transform.rotation, To, 0.3f);

            yield return wait;
        }

        For_Rot.transform.rotation = To;

        

        //바꿔주자
        if (start == true)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        }

        


        yield break;
        



    }


}
