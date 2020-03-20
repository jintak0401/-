using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Choose : MonoBehaviour {
    
    public GameObject For_Rot;
    private bool start;

    void Start () {
        //For_Rot.transform.rotation = Quaternion.Euler(new Vector3(90f, 0f, 0f));

        start = false;
        StartCoroutine(stage_change());
    }
	
	// Update is called once per frame
	void Update () {

    }

    void OnMouseDown()
    {
        start = true;
        StartCoroutine(stage_change());
    }

    IEnumerator stage_change()
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
            if (Number.stage > 11)
            {
                Number.stage = 11;

                UnityEngine.SceneManagement.SceneManager.LoadScene(1);

            }
            else
            {
                
                UnityEngine.SceneManagement.SceneManager.LoadScene(Number.stage + 2);
            }
            //UnityEngine.SceneManagement.SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }


        yield break;
    }
}
