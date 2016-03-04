using UnityEngine;
using System.Collections;
using System.Timers;

public class PlayerControl : MonoBehaviour {

    public GameObject ShotRight;
    public GameObject ShotLeft;
    public GameObject LoseText;
    public GameObject WinBlock;
    public GameObject Player;
    public Transform LoseTextPos;
    public Transform ShotSpawnRight;
    public Transform ShotSpawnLeft;
    public float fireRate;
    public static int sh = 2;
    public static int ShotsOnScreen;
    public float currentheight;
    public float previousheight;
    //public bool isjump = false;
    public bool colly = false;
    public bool isFall = false;
    public float speed = 4f;
    //public static Rigidbody rb;
    //public float fallMove;
    //Timer xtimer = new Timer();
    //Timer ytimer = new Timer();
    

    private float nextFire;

    // Use this for initialization
    void Start ()
    {
        /* xtimer.Interval = 1000;
         xtimer.Enabled = true;
         xtimer.Elapsed += JumpDone;*/

        previousheight = (transform.position.y - 1);
    }

	//Called Every Frame
	void Update () {

        Movement();
        Shooting();
        NoShots();
        ShotsOnScreen = (GameObject.FindGameObjectsWithTag("Shot").Length);
        DetectFall();
    }

    //is the player falling?
    void DetectFall()
    {
        currentheight = transform.position.y;

        if (currentheight < previousheight)
        {
            isFall = true;

            //Debug.Log(transform.position.y);
            //Debug.Log("prev " + previousheight);
        }
    }

    //Player Out of Shots
    void NoShots()
    {
        if(sh <= 0 && ShotsOnScreen < 1)
        {
            if (Win.Enemies > 0)
            {
                Destroy(gameObject);
                Instantiate(LoseText, LoseTextPos.position, LoseTextPos.rotation);
            }
            else
            {
                SceneFade.sceneEnd = true;
            }
        }
    }
    //Player Shooting
    void Shooting()
    {
        if (Input.GetKey(KeyCode.RightArrow) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(ShotRight, ShotSpawnRight.position, ShotSpawnRight.rotation);
            sh--;
            ShotsOnScreen = (GameObject.FindGameObjectsWithTag("Shot").Length);
        }
        if (Input.GetKey(KeyCode.LeftArrow) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(ShotLeft, ShotSpawnLeft.position, ShotSpawnLeft.rotation);
            sh--;
            ShotsOnScreen = (GameObject.FindGameObjectsWithTag("Shot").Length);
        }

    }
    //Player Movement
    void Movement()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            //speed++;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            //speed++;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            previousheight = (transform.position.y - 1);

            if (colly == false && isFall == false)
            {
                transform.Translate(Vector3.up * 15f * Time.deltaTime);
                //xtimer.Start();
            }
            /*if (isFall == true)
            {
                Debug.Log(previousheight);
            }*/
            
        }
    }

    /*void JumpDone(object source, ElapsedEventArgs e)
    {
        
    }*/

    //when Player collides with enemies
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Disappointment")
        {
            Destroy(gameObject);

            Instantiate(LoseText, LoseTextPos.position, LoseTextPos.rotation);
        }
        //when player collides with Blocker and Floor
        if (col.gameObject.tag == "Border")
        {
            colly = true;
        }
         if (col.gameObject.tag == "Floor")
        {
            colly = false;
            isFall = false;
            previousheight = (transform.position.y - 1);
            //Debug.Log("wow, you touched the ground");
        }
    }

}

