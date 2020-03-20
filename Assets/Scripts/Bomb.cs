using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Bomb : MonoBehaviour {

    public GameObject[] Canon_;
    public Rigidbody2D fir_velocity;
    public GameObject fire;
    public Vector2 clear_direction;
    public GameObject explosion;
    public int stage;
    public GameObject retry;
    public GameObject clear;
    public GameObject For_Rot;

    void Start () {

        fir_velocity = fire.GetComponent<Rigidbody2D>();
        Number.stage = stage;

    }
	
	// Update is called once per frame
	void Update () {            
    }

    void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.CompareTag("Fire")&&Fire.Game_start)
        {
            if (fir_velocity.velocity.normalized == clear_direction)
            {
                int i = 0;
                for (; i < Canon_.Length; ++i)
                {    
                    if (Canon_[i].gameObject.GetComponent<Canons>().possible_shot!=0) {  break; }
                }
            
                if (i == Canon_.Length)
                {
                    fire.SetActive(false);
                SoundManager.instance.Explosion();
                Instantiate(explosion, this.transform.position/*+new Vector3(-0.55f,-0.7f,0f)*/, this.transform.rotation);
                StartCoroutine(explo());
                    StartCoroutine(Next());
                }
                else
                {
                fire.SendMessage("Case_lose");
            }
            }
        else
        {
            fire.SendMessage("Case_lose");
            
        }
        }
    }

    IEnumerator explo()
    {
        clear.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        //this.gameObject.SetActive(false);
        this.transform.position = new Vector3(0f, 0f, -11f);
    }

    void Retry()
    {
        retry.SetActive(true);
    }

    IEnumerator Next()
    {
        yield return new WaitForSeconds(2f);

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

        if (SceneManager.GetActiveScene().buildIndex < 13)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }


        else
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(1);

        }
        yield break;
    }
}
