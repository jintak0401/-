using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class stage_menu : MonoBehaviour
{

    public Sprite[] Menu_;
    private SpriteRenderer sprite_renderer;
    public GameObject For_Rot;
    
    void Start()
    {
        
        sprite_renderer = gameObject.GetComponent<SpriteRenderer>();
        sprite_renderer.sprite = Menu_[0];
    }

    // Update is called once per frame
    void Update()
    {



    }

    void OnMouseDown()
    {
        sprite_renderer.sprite = Menu_[1];
    }

    void OnMouseDrag()
    {
    }

    void OnMouseUp()
    {
        sprite_renderer.sprite = Menu_[0];
        StartCoroutine(To_Menu());
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
            UnityEngine.SceneManagement.SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        



        yield break;




    }


}
