using UnityEngine;
using System.Collections;

public class Canons : MonoBehaviour
{
    //간격 1.6

    public bool isActivated;
    static public GameObject canon;
    public bool isFirst;
    public int possible_shot;
    public Sprite[] Canon_;
    private Vector3 original_pos;
    private Vector3 where_to_go;
    public bool[] inPutFire;
    public bool[] outPutFire;
    public GameObject fire;
    public Rigidbody2D fire_move;
    private SpriteRenderer sprite_renderer;
    private Rigidbody2D canon_move;
    static public bool set_check;
    static public int unit_canon;
    //private bool canon_should_stop;
    private Vector3 target;
    private bool moving;
    private bool rot_out;
    private bool reset;
    private GameObject ptr;
    

    private float _doubleTapTimeD;
    private bool doubleTapD = false;

    bool clock;

    //private bool first_touch;
    private Vector2 mouse_down;
    private Vector2 mouse_up;


   
    void Start()

    {
        set_check = false;
        isActivated = false;
        isFirst = false;
        original_pos = Camera.main.ScreenToWorldPoint(this.transform.position);
        where_to_go = original_pos;
        fire_move = fire.gameObject.GetComponent<Rigidbody2D>();
        sprite_renderer = gameObject.GetComponent<SpriteRenderer>();
        sprite_renderer.sprite = Canon_[possible_shot];
        //fire_move.AddForce(new Vector2(-1f, 0f)*50);
        canon_move = this.GetComponent<Rigidbody2D>();
        //canon_should_stop = true;
        moving = false;
        rot_out = true;
        reset = true;
        clock = false;
       
        //first_touch = false;

        StartCoroutine(Original_pos());
    }

    void FixedUpdate()
    {   
    }

    void Update()
    {
        //if (end==false && Menu_Tile.end)
        //{
        //    original_pos = this.transform.position;
        //    end = true;
        //}

        

        //if (isFirst && Fire.Game_start&&drag_direction().sqrMagnitude>0)
        //{
        //    isFirst = false;
        //    StartCoroutine(moving_on_rail());
        //}

        // 슬라이드 구현필요

        //transform.position = Vector3.MoveTowards(this.transform.position, temp, 0.06f);


        doubleTapD = false;





        //확인용
        //if (isFirst && Fire.isActivated)
        //{
        //    fire.transform.position = this.transform.position;
        //    //fire_move.AddForce(new Vector2(-1f, 0f) * Fire.fire_speed);
        //    Correct_direction();
        //    Fire.Game_start = true;
        //    change_fire_direction();
        //    isFirst = !isFirst;
        //    this.possible_shot -= 1;
        //    sprite_renderer.sprite = Canon_[possible_shot];

        //}

    }

    IEnumerator Original_pos()
    {
        yield return new WaitForSeconds(0.7f);

        original_pos = this.transform.position;
        }

    

    void OnMouseDown()
    {
        if (Fire.Game_start)
        {
            mouse_down = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

        }

        //실수시 되돌리기
        //else if (isActivated)
        //{
        //    reset = !reset;
        //    if (reset)
        //    {
        //        isActivated = false;
        //        this.transform.position = original_pos;
        //        isFirst = false;
        //        ptr.SetActive(true);
        //    }
        //}
        if (Time.time < _doubleTapTimeD + .3f)
        {
            doubleTapD = true;
        }
        _doubleTapTimeD = Time.time;

        if (doubleTapD)
        {
            if (!Fire.Game_start && isActivated)
            {
                isFirst = false;

                ptr.SetActive(true);
                isActivated = false;
            }
        }

    }

    void OnMouseDrag()
    {
        if (!isActivated )
        {
            //canon_move.MovePosition(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0.0f)) + new Vector3(0f, 0f, 10f));
            this.transform.position=(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0.0f)) + new Vector3(0f, 0f, 10f));
        }

        //게임스타트시 
        //if (isActivated && Fire.Game_start&&canon_should_stop)
        //{
        //    int layerMask = (1 << LayerMask.NameToLayer("Rail")) /*| (1 << LayerMask.NameToLayer("Canon"))*/;

        //    Collider2D hit = Physics2D.OverlapCircle(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0.0f)), 0.1f, layerMask);
        //    if (hit==this)
        //    {
        //        first_touch = true;
        //    }
        //    if (hit.CompareTag("Rail") && first_touch)
        //    {
                
        //        first_touch = false;
        //        canon_should_stop = false;
                
        //    }
        //}
        if (isActivated)
        {
            //StartCoroutine(moving_on_rail());
        }
    }

    void OnMouseUp()
    {

        if (!isActivated)
        {
            int layerMask = (1 << LayerMask.NameToLayer("Point"));

            Collider2D hit = Physics2D.OverlapCircle(this.transform.position, 0.1f, layerMask);
            if (hit == null)
            {
                where_to_go = original_pos;
            }
            else if (hit.CompareTag("Start_Point"))
            {
                where_to_go = new Vector3(hit.transform.position.x, hit.transform.position.y, -0.2f);
                ptr = hit.gameObject;
                hit.gameObject.SetActive(false);
                isFirst = true;
                isActivated = true;
            }
            else if (hit.CompareTag("Point"))
            {
                where_to_go = new Vector3(hit.transform.position.x,hit.transform.position.y,-0.2f);
                ptr = hit.gameObject;
                hit.gameObject.SetActive(false);
                isActivated = true;
            }


            //canon_move.MovePosition(where_to_go);
            this.transform.position = where_to_go;


        }

        else if (Fire.Game_start && !moving)
        {


            mouse_up = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
                StartCoroutine(moving_on_rail());
            
        }

    }

    IEnumerator moving_on_rail()
    {
        
        

        //Debug.Log("cour");

        moving = true;
        Vector3 direction = drag_direction().normalized * 0.8f;
        
            while (true)
            {
            int layerMask_rot = (1 << LayerMask.NameToLayer("Rotation"));
            Collider2D hit_rot = Physics2D.OverlapCircle(this.transform.position, 0.1f, layerMask_rot);

            if (hit_rot!=null && rot_out)
            {
                moving = false;
                rot_out = false;
                yield break;
            }

            //int layerMask = ((1 << LayerMask.NameToLayer("Rail"))|1<<LayerMask.NameToLayer("Canon"));
            int layerMask = ((1 << LayerMask.NameToLayer("Rail")));
                Collider2D hit = Physics2D.OverlapCircle(this.transform.position + direction, 0.1f, layerMask);
                //int layerMask2 = (1 << LayerMask.NameToLayer("Canon"));
                //Collider2D hit2 = Physics2D.OverlapCircle(this.transform.position + 2 * direction, 0.1f, layerMask2);

                if (hit == null)
                {
                
                    moving = false;
                    yield break;
                }



                else if (hit.CompareTag("Rail"))
                {
                    target = this.transform.position + 2 * (direction);
                    Collider2D hit2 = Physics2D.OverlapCircle(target, 0.1f);
                if (hit2.CompareTag("Canon") || hit2.CompareTag("Bomb"))
                    {

                        moving = false;
                        yield break;
                    }

                    else
                    {


                    rot_out = true;
                    WaitForEndOfFrame wait = new WaitForEndOfFrame();
                        while (this.transform.position != target)
                        {
                            transform.position = Vector3.MoveTowards(this.transform.position, target, 3.2f*Time.deltaTime);
                            yield return wait;
                        }
                    }
                
            }
            
        }


        //Vector3 direction = drag_direction().normalized * 1.2f;

        //while (true)
        //{
        //    int layerMask = (1 << LayerMask.NameToLayer("Rail")) | (1 << LayerMask.NameToLayer("Canon"));
        //    Collider2D hit = Physics2D.OverlapCircle(this.transform.position + direction, 0.3f, layerMask);

        //    if (hit == null)
        //    {
        //        Debug.Log(this.transform.position);
        //        yield break;
        //    }
        //    else if (hit.CompareTag("Canon"))
        //    {
        //        Debug.Log("canon");
        //        Debug.Log(this.transform.position);
        //    }
        //    else if (hit.CompareTag("Rail"))
        //    {
        //        WaitForEndOfFrame wait = new WaitForEndOfFrame();
        //        target = this.transform.position + (2 * direction *(2/3));
        //        while (this.transform.position != target)
        //        {
        //            transform.position = Vector3.MoveTowards(this.transform.position, target, 0.06f);
        //            yield return wait;
        //        }
        //    }
        //}

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Fire") && Fire.isActivated)
        {
            if (possible_shot > 0 && !moving)
            {

                if (fire_move.velocity.x < 0 && inPutFire[0] || fire_move.velocity.x > 0 && inPutFire[2] || fire_move.velocity.y > 0 && inPutFire[1] || fire_move.velocity.y < 0 && inPutFire[3])
                {
                    Correct_direction();
                    
                }
                else
                {

                    fire.SendMessage("Case_lose");
                }
            }
            else
            {

                fire.SendMessage("Case_lose");

                Debug.Log("Game Over");
            }
        }
        else if (other.gameObject.CompareTag("Clockwise") && Fire.Game_start)
        {
            StartCoroutine(clockwise(true));

            //transform.Rotate(new Vector3(0f, 0f, -90f));
            change_canon_direction(1);
            //canon_should_stop = true;

        }
        else if (other.gameObject.CompareTag("Counter_Clockwise")&& Fire.Game_start)
        {
            StartCoroutine(clockwise(false));
            //    transform.Rotate(new Vector3(0f, 0f, 90f));
        change_canon_direction(0);
        //    //canon_should_stop = true;
        }
    }
    IEnumerator clockwise(bool clock)
    {
        float count = 0;
        WaitForEndOfFrame wait = new WaitForEndOfFrame();


        if (clock)
        {
            Vector3 vec = this.transform.rotation.eulerAngles;
            vec.z = vec.z - 90f;
            //Mathf.RoundToInt(vec.z);

            Quaternion To = Quaternion.Euler(vec);


            while (count<90)
            {
                count += Time.deltaTime*170;
                this.transform.eulerAngles += Time.deltaTime*new Vector3(0.0f, 0.0f, -170f);
                
                    //Quaternion.Slerp(this.transform.rotation, To, 0.3f);
                
                yield return wait;
            }
            this.transform.rotation = To;

            yield break;

        }
        else
        {
            Debug.Log("1");
            Vector3 vec = this.transform.rotation.eulerAngles;
            vec.z = vec.z + 90f;
            //Mathf.RoundToInt(vec.z);

            Quaternion To = Quaternion.Euler(vec);


            while (count < 90)
            {
                count += Time.deltaTime * 170;
                this.transform.eulerAngles += Time.deltaTime * new Vector3(0.0f, 0.0f, +170f);

                //Quaternion.Slerp(this.transform.rotation, To, 0.3f);

                yield return wait;
            }
            this.transform.rotation = To;

            yield break;

        }
    }

    

    //void OnTriggerStay2D(Collider2D other)
    //{
    //    if (other.gameObject.CompareTag("Clockwise") || other.gameObject.CompareTag("Counter_Clockwise"))
    //    {

    //    }
    //    if (other.CompareTag("Rail"))
    //    {
    //        i += 1;
    //        Debug.Log("Rail_Master");

    //        if (i >= 35)
    //        {
    //            canon_move.AddForce(new Vector2(-1f, 0f) * speed);
    //        }
    //        Debug.Log(i);

    //    }
    //}

    int input_direction_check()
    {
        int i = 0;
        for (; i < 3; ++i)
        {
            if (inPutFire[i])
            {
                break;
            }
        }
        return i;
    }
    int output_direction_check()
    {
        int i = 0;
        for (; i < 3; ++i)
        {
            if (outPutFire[i])
            {
                break;
            }
        }
        return i;
    }
    
    // 회전장치 만났을 때
    void change_canon_direction(int clockwise)
    {
        int input_direction = input_direction_check();
        int output_direction = output_direction_check();
        if (clockwise==1)
        {
            inPutFire[input_direction] = false;
            outPutFire[output_direction] = false;
            if (input_direction == 3) { inPutFire[0] = true; }
            else { inPutFire[input_direction + 1] = true; }
            if (output_direction == 3) { outPutFire[0] = true; }
            else { outPutFire[output_direction + 1] = true; }
        }
        else
        {
            inPutFire[input_direction] = false;
            outPutFire[output_direction] = false;
            if (input_direction == 0) { inPutFire[3] = true; }
            else { inPutFire[input_direction - 1] = true; }
            if (output_direction == 0) { outPutFire[3] = true; }
            else { outPutFire[output_direction - 1] = true; }
        }
    }

    //불꽃 만났을 때
    void change_fire_direction()
    {
        


        int output_dirction = output_direction_check();
        
        output_dirction = -Mathf.RoundToInt((output_dirction + 3) * 90);
        fire.transform.rotation= Quaternion.Euler(new Vector3(0f,0f,output_dirction));

    }


    void Correct_direction()
    {
        if (outPutFire[0])
        {
            fire_move.Sleep();
            fire_move.position = this.transform.position;
            fire_move.AddForce(new Vector2(-1f, 0f) * Fire.fire_speed*Time.deltaTime);
        }
        else if (outPutFire[1])
        {
            fire_move.Sleep();
            fire_move.position = this.transform.position;
            fire_move.AddForce(new Vector2(0f, 1f) * Fire.fire_speed * Time.deltaTime);
        }
        else if (outPutFire[2])
        {
            fire_move.Sleep();
            fire_move.position = this.transform.position;
            fire_move.AddForce(new Vector2(1f, 0f) * Fire.fire_speed * Time.deltaTime);
        }
        else
        {
            fire_move.Sleep();
            fire_move.position = this.transform.position;
            fire_move.AddForce(new Vector2(0f, -1f) * Fire.fire_speed * Time.deltaTime);
        }

        possible_shot -= 1;
        sprite_renderer.sprite = Canon_[possible_shot];
        change_fire_direction();
        SoundManager.instance.Shot();
    }
    
    //레일이동시키기
    //void Moving_on_rail(Vector2 rail_pos)
    //{
    //    Vector2 moving_dirction = new Vector2((rail_pos.x - this.transform.position.x),(rail_pos.y-this.transform.position.y));
    //    float x = (moving_dirction.x>0)? moving_dirction.x : -moving_dirction.x ;
    //    float y= (moving_dirction.y > 0) ? moving_dirction.y : -moving_dirction.y;
    //    if (x > y)
    //    {
    //        canon_move.AddForce(new Vector2(0f, moving_dirction.normalized.y) * canon_speed);
    //    }
    //    else
    //    {
    //        canon_move.AddForce(new Vector2(moving_dirction.normalized.x, 0f) * canon_speed);
    //    }
    //}

    Vector2 drag_direction()
    {
        
        Vector3 offset = new Vector3(mouse_up.x-mouse_down.x,mouse_up.y-mouse_down.y,0f);
        float x = (offset.x > 0) ? offset.x : -offset.x;
        float y = (offset.y > 0) ? offset.y : -offset.y;
        if (x > y)
        {
            return new Vector3(offset.x,0f,0f);
        }
        else
        {
            return new Vector3(0f, offset.y,0f);
        }
    }
}

