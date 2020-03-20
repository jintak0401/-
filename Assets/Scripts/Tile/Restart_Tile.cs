using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Restart_Tile : MonoBehaviour {

    public Sprite[] Restart_;
    private SpriteRenderer sprite_renderer;
    private Vector2 mouse;
    public GameObject For_Rot;

    void Start()
    {
        sprite_renderer = gameObject.GetComponent<SpriteRenderer>();
        sprite_renderer.sprite = Restart_[0];
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        sprite_renderer.sprite = Restart_[1];
    }

    void OnMouseDrag()
    {
        mouse = (Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y)));
        
    }

    void OnMouseUp()
    {
        sprite_renderer.sprite = Restart_[0];
        if (mouse.x <= 6.6f && mouse.x >= 5.4f && mouse.y >= -4.5f && mouse.y <= -3.3f)
        {
            StartCoroutine(Re_start());    
        }
    }

    IEnumerator Re_start()
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


        UnityEngine.SceneManagement.SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
        





    }

}
