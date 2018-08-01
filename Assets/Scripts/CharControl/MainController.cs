using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Threading;

public class MainController : NetworkBehaviour
{

    GameObject[] playerNum;
    public static int pNum = 0;
    public static bool isFirst = true;
    public bool isDecrease = false;
    public bool isEnd = false;
    public int waitTime = 0;
    public bool victory = false;

    public Animator animator;
    public float speed = 1.3f;
    public float bubbleSpeed = 0.2f;
    public bool isSetAni = false;

    public Transform BombSpawn;
    public SpriteRenderer sprite;


    public GameObject LOSE;
    public GameObject WIN;


    [SyncVar(hook = "OnChangeIsInBubble")]
    public bool isInBubble = false;

    [SyncVar(hook = "OnChangeIsDied")]
    public bool isDied = false;

    [SyncVar]
    public Color playerColor;
    public int player;

    public float[] posX = {(float)(-6.1), (float)(-5.5), (float)(-4.9), (float)(-4.3),
                            (float)(-3.7), (float)(-3.1), (float)(-2.5), (float)(-1.9),
                            (float)(-1.3), (float)(-0.7), (float)(-0.1), (float)(0.5),
                            (float)(1.1), (float)(1.7), (float)(2.3), (float)(2.9), (float)(3.5)};

    public float[] posYY = {(float)(4.5), (float)(3.9), (float)(3.3), (float)(2.7),
                            (float)(2.1), (float)(1.5), (float)(0.9), (float)(0.3),
                            (float)(-0.3), (float)(-0.9), (float)(-1.5), (float)(-2.1),
                            (float)(-2.7), (float)(-3.3), (float)(-3.9), (float)(-4.5)};

    void OnChangeIsInBubble(bool isInBubble)
    {
        this.isInBubble = isInBubble;
        if (isInBubble)
        {
            switch (player)
            {
                case 1:
                    animator.Play("Bazzi Before Die", -1, 0);
                    break;
                case 2:
                    animator.Play("Marid Before Die", -1, 0);
                    break;
                case 3:
                    animator.Play("Dao Before Die", -1, 0);
                    break;
                case 4:
                    animator.Play("Cappi Before Die", -1, 0);
                    break;
                default:
                    break;

            }
        }
        BoxCollider2D colBox = this.gameObject.GetComponent<BoxCollider2D>();
        colBox.isTrigger = true;
        isInBubble = true;
    }

    void OnChangeIsDied(bool isDied)
    {
        this.isDied = isDied;
        if (isDied)
        {
            switch (player)
            {
                case 1:
                    animator.Play("Bazzi Die", -1, 0);
                    break;
                case 2:
                    animator.Play("Marid Die", -1, 0);
                    break;
                case 3:
                    animator.Play("Dao Die", -1, 0);
                    break;
                case 4:
                    animator.Play("Cappi Die", -1, 0);
                    break;
                default:
                    break;

            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (isDied) return;
        if (col.gameObject.tag == "BombWaterU" || col.gameObject.tag == "BombWaterD" || col.gameObject.tag == "BombWaterL" || col.gameObject.tag == "BombWaterR")
        {
            isInBubble = true;
        }
        else if (isInBubble && !isDied)
        {
            isDied = true;
        }
    }

    // Use this for initialization
    void Start()
    {
        isFirst = true;
        playerNum = GameObject.FindGameObjectsWithTag("currPlayer");
        pNum = playerNum.Length;
        Debug.Log("pNum: " + pNum);


        animator = GetComponent<Animator>();
        if (playerColor == Color.red)
        {
            animator.Play("Bazzi Down Idle", -1, 0);
            player = 1;
        }
        if (playerColor == Color.yellow)
        {
            animator.Play("Marid Down Idle", -1, 0);
            player = 2;
        }
        else if (playerColor == Color.blue)
        {
            animator.Play("Dao Down Idle", -1, 0);
            player = 3;
        }
        else if (playerColor == Color.green)
        {
            animator.Play("Cappi Down Idle", -1, 0);
            player = 4;
        }
        Tiles.init();
    }

    // Update is called once per frame
    void Update()
    {
        if (isEnd)
        {
            if (waitTime < 3000) waitTime++;
            else
            {
                if (isLocalPlayer)
                {
                    if (victory)
                    {
                        WIN = GameObject.Find("win");
                        Debug.Log("win transform");
                        Vector3 pos = new Vector3(WIN.transform.position.x - 21.3f, WIN.transform.position.y, WIN.transform.position.z);
                        WIN.transform.SetPositionAndRotation(pos, WIN.transform.rotation);
                    }
                    else
                    {
                        LOSE = GameObject.Find("lose");
                        Debug.Log("lose transform");
                        Vector3 pos = new Vector3(LOSE.transform.position.x - 21f, LOSE.transform.position.y, LOSE.transform.position.z);
                        LOSE.transform.SetPositionAndRotation(pos, LOSE.transform.rotation);
                    }
                }
                this.gameObject.SetActive(false);
            }
        }
        if (isInBubble && isFirst) isFirst = false;
        if (isInBubble && !isDecrease)
        {
            pNum--;
            Debug.Log("pNum: " + pNum);
            isDecrease = true;
        }
        if (!isLocalPlayer)
        {
            return;
        }
        if (!isFirst && !isEnd)
        {
            if (pNum <= 1)
            {
                if (isInBubble)
                {
                    victory = false;
                    isEnd = true;
                }
                else
                {
                    victory = true;
                    isEnd = true;
                }
            }
        }
        if (isInBubble)
        {
            isFirst = false;

            if (Input.GetKey(KeyCode.RightArrow)) this.transform.Translate(bubbleSpeed * Time.deltaTime, 0, 0);

            else if (Input.GetKey(KeyCode.UpArrow)) this.transform.Translate(0, bubbleSpeed * Time.deltaTime, 0);

            else if (Input.GetKey(KeyCode.LeftArrow)) this.transform.Translate(-bubbleSpeed * Time.deltaTime, 0, 0);

            else if (Input.GetKey(KeyCode.DownArrow)) this.transform.Translate(0, -bubbleSpeed * Time.deltaTime, 0);

        }
        else
        {
            if (player == 1)
            {
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    if (isSetAni == false)
                        animator.Play("Bazzi Right Walk", -1, 0);

                    this.transform.Translate(speed * Time.deltaTime, 0, 0);
                    isSetAni = true;
                }

                else if (Input.GetKey(KeyCode.LeftArrow))
                {
                    if (isSetAni == false)
                        animator.Play("Bazzi Left Walk", -1, 0);
                    this.transform.Translate(-speed * Time.deltaTime, 0, 0);
                    isSetAni = true;
                }

                else if (Input.GetKey(KeyCode.UpArrow))
                {
                    if (isSetAni == false)
                        animator.Play("Bazzi Up Walk", -1, 0);
                    this.transform.Translate(0, speed * Time.deltaTime, 0);
                    isSetAni = true;
                }

                else if (Input.GetKey(KeyCode.DownArrow))
                {
                    if (isSetAni == false)
                        animator.Play("Bazzi Down Walk", -1, 0);
                    this.transform.Translate(0, -speed * Time.deltaTime, 0);
                    isSetAni = true;
                }

                if (Input.GetKeyUp(KeyCode.RightArrow))
                {
                    isSetAni = false;
                    animator.Play("Bazzi Right Idle", -1, 0);
                }

                else if (Input.GetKeyUp(KeyCode.LeftArrow))
                {
                    isSetAni = false;
                    animator.Play("Bazzi Left Idle", -1, 0);
                }

                else if (Input.GetKeyUp(KeyCode.UpArrow))
                {
                    isSetAni = false;
                    animator.Play("Bazzi Up Idle", -1, 0);
                }

                else if (Input.GetKeyUp(KeyCode.DownArrow))
                {
                    isSetAni = false;
                    animator.Play("Bazzi Down Idle", -1, 0);
                }
                else if (Input.GetKeyDown(KeyCode.Space))
                {
                    float x = BombSpawn.position.x;
                    float y = BombSpawn.position.y;
                    float absXmin = 100;
                    float absYmin = 100;
                    int Xidx = 0;
                    int Yidx = 0;

                    for (int i = 0; i < 17; i++)
                    {
                        float result = ABS(x, posX[i]);

                        if (absXmin >= result)
                        {
                            absXmin = result;
                            Xidx = i;
                        }
                    }
                    for (int i = 0; i < 16; i++)
                    {
                        float result = ABS(y, posYY[i]);

                        if (absYmin >= result)
                        {
                            absYmin = result;
                            Yidx = i;
                        }
                    }
                    Vector3 pos = new Vector3(posX[Xidx], (float)(posYY[Yidx] + 0.1), BombSpawn.position.z);
                    CmdCreateBomb(pos);
                }
            }
            else if (player == 2)
            {
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    if (isSetAni == false)
                        animator.Play("Marid Right Walk", -1, 0);

                    this.transform.Translate(speed * Time.deltaTime, 0, 0);
                    isSetAni = true;
                }

                else if (Input.GetKey(KeyCode.LeftArrow))
                {
                    if (isSetAni == false)
                        animator.Play("Marid Left Walk", -1, 0);
                    this.transform.Translate(-speed * Time.deltaTime, 0, 0);
                    isSetAni = true;
                }

                else if (Input.GetKey(KeyCode.UpArrow))
                {
                    if (isSetAni == false)
                        animator.Play("Marid Up Walk", -1, 0);
                    this.transform.Translate(0, speed * Time.deltaTime, 0);
                    isSetAni = true;
                }

                else if (Input.GetKey(KeyCode.DownArrow))
                {
                    if (isSetAni == false)
                        animator.Play("Marid Down Walk", -1, 0);
                    this.transform.Translate(0, -speed * Time.deltaTime, 0);
                    isSetAni = true;
                }

                if (Input.GetKeyUp(KeyCode.RightArrow))
                {
                    isSetAni = false;
                    animator.Play("Marid Right Idle", -1, 0);
                }

                else if (Input.GetKeyUp(KeyCode.LeftArrow))
                {
                    isSetAni = false;
                    animator.Play("Marid Left Idle", -1, 0);
                }

                else if (Input.GetKeyUp(KeyCode.UpArrow))
                {
                    isSetAni = false;
                    animator.Play("Marid Up Idle", -1, 0);
                }

                else if (Input.GetKeyUp(KeyCode.DownArrow))
                {
                    isSetAni = false;
                    animator.Play("Marid Down Idle", -1, 0);
                }
                else if (Input.GetKeyDown(KeyCode.Space))
                {
                    float x = BombSpawn.position.x;
                    float y = BombSpawn.position.y;
                    float absXmin = 100;
                    float absYmin = 100;
                    int Xidx = 0;
                    int Yidx = 0;

                    for (int i = 0; i < 17; i++)
                    {
                        float result = ABS(x, posX[i]);

                        if (absXmin >= result)
                        {
                            absXmin = result;
                            Xidx = i;
                        }
                    }
                    for (int i = 0; i < 16; i++)
                    {
                        float result = ABS(y, posYY[i]);

                        if (absYmin >= result)
                        {
                            absYmin = result;
                            Yidx = i;
                        }
                    }
                    Vector3 pos = new Vector3(posX[Xidx], (float)(posYY[Yidx] + 0.1), BombSpawn.position.z);
                    CmdCreateBomb(pos);
                }
            }
            else if (player == 3)
            {
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    if (isSetAni == false)
                        animator.Play("Dao Right Walk", -1, 0);

                    this.transform.Translate(speed * Time.deltaTime, 0, 0);
                    isSetAni = true;
                }

                else if (Input.GetKey(KeyCode.LeftArrow))
                {
                    if (isSetAni == false)
                        animator.Play("Dao Left Walk", -1, 0);
                    this.transform.Translate(-speed * Time.deltaTime, 0, 0);
                    isSetAni = true;
                }

                else if (Input.GetKey(KeyCode.UpArrow))
                {
                    if (isSetAni == false)
                        animator.Play("Dao Up Walk", -1, 0);
                    this.transform.Translate(0, speed * Time.deltaTime, 0);
                    isSetAni = true;
                }

                else if (Input.GetKey(KeyCode.DownArrow))
                {
                    if (isSetAni == false)
                        animator.Play("Dao Down Walk", -1, 0);
                    this.transform.Translate(0, -speed * Time.deltaTime, 0);
                    isSetAni = true;
                }

                if (Input.GetKeyUp(KeyCode.RightArrow))
                {
                    isSetAni = false;
                    animator.Play("Dao Right Idle", -1, 0);
                }

                else if (Input.GetKeyUp(KeyCode.LeftArrow))
                {
                    isSetAni = false;
                    animator.Play("Dao Left Idle", -1, 0);
                }

                else if (Input.GetKeyUp(KeyCode.UpArrow))
                {
                    isSetAni = false;
                    animator.Play("Dao Up Idle", -1, 0);
                }

                else if (Input.GetKeyUp(KeyCode.DownArrow))
                {
                    isSetAni = false;
                    animator.Play("Dao Down Idle", -1, 0);
                }
                else if (Input.GetKeyDown(KeyCode.Space))
                {
                    float x = BombSpawn.position.x;
                    float y = BombSpawn.position.y;
                    float absXmin = 100;
                    float absYmin = 100;
                    int Xidx = 0;
                    int Yidx = 0;

                    for (int i = 0; i < 17; i++)
                    {
                        float result = ABS(x, posX[i]);

                        if (absXmin >= result)
                        {
                            absXmin = result;
                            Xidx = i;
                        }
                    }
                    for (int i = 0; i < 16; i++)
                    {
                        float result = ABS(y, posYY[i]);

                        if (absYmin >= result)
                        {
                            absYmin = result;
                            Yidx = i;
                        }
                    }
                    Vector3 pos = new Vector3(posX[Xidx], (float)(posYY[Yidx] + 0.1), BombSpawn.position.z);
                    CmdCreateBomb(pos);
                }
            }
            else if (player == 4)
            {
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    if (isSetAni == false)
                        animator.Play("Cappi Right Walk", -1, 0);

                    this.transform.Translate(speed * Time.deltaTime, 0, 0);
                    isSetAni = true;
                }

                else if (Input.GetKey(KeyCode.LeftArrow))
                {
                    if (isSetAni == false)
                        animator.Play("Cappi Left Walk", -1, 0);
                    this.transform.Translate(-speed * Time.deltaTime, 0, 0);
                    isSetAni = true;
                }

                else if (Input.GetKey(KeyCode.UpArrow))
                {
                    if (isSetAni == false)
                        animator.Play("Cappi Up Walk", -1, 0);
                    this.transform.Translate(0, speed * Time.deltaTime, 0);
                    isSetAni = true;
                }

                else if (Input.GetKey(KeyCode.DownArrow))
                {
                    if (isSetAni == false)
                        animator.Play("Cappi Down Walk", -1, 0);
                    this.transform.Translate(0, -speed * Time.deltaTime, 0);
                    isSetAni = true;
                }

                if (Input.GetKeyUp(KeyCode.RightArrow))
                {
                    isSetAni = false;
                    animator.Play("Cappi Right Idle", -1, 0);
                }

                else if (Input.GetKeyUp(KeyCode.LeftArrow))
                {
                    isSetAni = false;
                    animator.Play("Cappi Left Idle", -1, 0);
                }

                else if (Input.GetKeyUp(KeyCode.UpArrow))
                {
                    isSetAni = false;
                    animator.Play("Cappi Up Idle", -1, 0);
                }

                else if (Input.GetKeyUp(KeyCode.DownArrow))
                {
                    isSetAni = false;
                    animator.Play("Cappi Down Idle", -1, 0);
                }
                else if (Input.GetKeyDown(KeyCode.Space))
                {
                    float x = BombSpawn.position.x;
                    float y = BombSpawn.position.y;
                    float absXmin = 100;
                    float absYmin = 100;
                    int Xidx = 0;
                    int Yidx = 0;

                    for (int i = 0; i < 17; i++)
                    {
                        float result = ABS(x, posX[i]);

                        if (absXmin >= result)
                        {
                            absXmin = result;
                            Xidx = i;
                        }
                    }
                    for (int i = 0; i < 16; i++)
                    {
                        float result = ABS(y, posYY[i]);

                        if (absYmin >= result)
                        {
                            absYmin = result;
                            Yidx = i;
                        }
                    }
                    Vector3 pos = new Vector3(posX[Xidx], (float)(posYY[Yidx] + 0.1), BombSpawn.position.z);
                    CmdCreateBomb(pos);
                }
            }
        }

    }

    float ABS(float a, float b)
    {
        float c = a - b;
        if (c < 0) return -c;
        return c;
    }


    [Command]
    void CmdCreateBomb(Vector3 pos)
    {
        if (FirstPlayerInfo.iSetBuubleCount < FirstPlayerInfo.iBubbleCount)
        {
            GameObject bombObj = (GameObject)GameObject.Instantiate(Resources.Load("Bomb"));
            sprite = bombObj.GetComponent<SpriteRenderer>();
            if (sprite)
            {
                sprite.sortingOrder = 1;
            }
            Bomb bomb = bombObj.GetComponent<Bomb>();
            if (bomb == null)
                return;

            //bomb.CreateBomb(this.gameObject.transform.position,


            //Vector3 pos = new Vector3(BombSpawn.position.x + 1, BombSpawn.position.y + 1, BombSpawn.position.z);

            bomb.CreateBomb(pos,
                this.gameObject.transform.rotation, 7); // FirstPlayerInfo.iBubbleLengthCount
            FirstPlayerInfo.iSetBuubleCount += 1;

            NetworkServer.Spawn(bombObj);

            Destroy(bombObj, 3.1f);
        }
    }
}