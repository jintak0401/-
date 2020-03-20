using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Before : MonoBehaviour
{

    public Sprite[] Before_;
    private SpriteRenderer sprite_renderer;
    private Vector2 mouse;
    public GameObject For_Rot;
    


    // Use this for initialization
    void Start()
    {
        sprite_renderer = gameObject.GetComponent<SpriteRenderer>();
        sprite_renderer.sprite = Before_[0];
        

    
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        sprite_renderer.sprite = Before_[1];
    }

    void OnMouseDrag()
    {
        mouse = (Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y)));
    }

    void OnMouseUp()
    {
        sprite_renderer.sprite = Before_[0];
        if (mouse.x <= -7f && mouse.x >= -8.2f && mouse.y >= -4.5f && mouse.y <= -3.3f)
        {
    
            //코루틴
            StartCoroutine(changeStage());

        }
    }

    IEnumerator changeStage()
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

        //수정
        if (Number.stage > 0)
        {
            Number.stage-=1;
            Debug.Log(Number.stage);
        }

        UnityEngine.SceneManagement.SceneManager.LoadScene("6x6 stage select");



        yield break;


        //count = 0;
        //while (count < 90)
        //{
        //    Debug.Log(i);
        //    ++i;
        //    count += Time.deltaTime * 170;
        //    For_Rot.transform.eulerAngles += Time.deltaTime * new Vector3(170f, 0.0f, 0.0f);

        //    //Quaternion.Slerp(this.transform.rotation, To, 0.3f);

        //    yield return wait;
        //}







    }

}
