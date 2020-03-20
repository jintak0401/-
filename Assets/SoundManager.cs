using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

    public AudioClip shot; //재생할 소리를 변수로 담습니다.
    public AudioClip gameover;
    public AudioClip explosion;

    AudioSource myAudio; //AudioSorce 컴포넌트를 변수로 담습니다.
    public static SoundManager instance;  //자기자신을 변수로 담습니다.
    void Awake() //Start보다도 먼저, 객체가 생성될때 호출됩니다
    {
        if (SoundManager.instance == null) //incetance가 비어있는지 검사합니다.
        {
            SoundManager.instance = this; //자기자신을 담습니다.
        }
    }
    void Start()
    {
        myAudio = this.gameObject.GetComponent<AudioSource>(); //AudioSource 오브젝트를 변수로 담습니다.
    }
    public void Gameover()
    {
        myAudio.PlayOneShot(gameover); //soundExplosion을 재생합니다.
    }

    public void Shot()
    {
        myAudio.PlayOneShot(shot);
    }
    
    public void Explosion()
    {
        myAudio.PlayOneShot(explosion);
    }

    // Update is called once per frame
    void Update () {
	
	}
}
