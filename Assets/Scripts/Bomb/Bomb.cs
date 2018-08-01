using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;

public class BombMgr
{
    static public List<Bomb> bombs = new List<Bomb>();
    static public float TileSize = 1.2f; //<타일크기 가져오기
    static public void CheckColiider(Bomb bomb)
    {
        if (bombs == null
            || bomb == null)
            return;

        int Count = bombs.Count;

        for (int i = 0; i < Count; ++i)
        {
            if (i >= bombs.Count)
                break;

            Vector2 BombLT = new Vector2(bomb.CenterPos.x - (bomb.BombSize * TileSize), bomb.CenterPos.y + (TileSize / 2));
            Vector2 BombRB = new Vector2(bomb.CenterPos.x + (bomb.BombSize * TileSize), bomb.CenterPos.y - (TileSize / 2));

            if (BombLT.x < bombs[i].CenterPos.x
                && BombRB.x > bombs[i].CenterPos.x
                && BombLT.y > bombs[i].CenterPos.y
                && BombRB.y < bombs[i].CenterPos.y)
            {
                bombs[i].Burst();
                //Debug.LogError("!!!!!!");
            }
        }

        for (int i = 0; i < Count; ++i)
        {
            if (i <= bombs.Count)
                break;

            Vector2 BombLT = new Vector2(bomb.CenterPos.x - (TileSize / 2), bomb.CenterPos.y + (bomb.BombSize * TileSize));
            Vector2 BombRB = new Vector2(bomb.CenterPos.x + (TileSize / 2), bomb.CenterPos.y - (bomb.BombSize * TileSize));

            if (BombLT.x < bombs[i].CenterPos.x
                && BombRB.x > bombs[i].CenterPos.x
                && BombLT.y > bombs[i].CenterPos.y
                && BombRB.y < bombs[i].CenterPos.y)
            {
                bombs[i].Burst();
            }
        }
    }
}

public class Bomb : NetworkBehaviour
{
    public List<GameObject> images = new List<GameObject>();
    public List<GameObject> centerImages = new List<GameObject>();
    public GameObject CenterImage = null;
    public FirstBomb _FirstBomb = new FirstBomb();
    public Vector3 CenterPos;
    public Quaternion Quat;
    public int BombSize = 0;
    public int upBombSize = 0;
    public int downBombSize = 0;
    public int leftBombSize = 0;
    public int rightBombSize = 0;
    private bool IsBurst;

    public int[] bombTile;


    //클래스 직속의 속성을 사용 하기 위해서 필요.
    [System.Serializable]
    public class FirstBomb
    {
        /// <물풍선 화력 이미지와 충돌체크를 위한 변수>.
        public Vector3 GetCenterBubblePosition;
        public Vector3 GetUpBubblePosition;
        public Vector3 GetDownBubblePosition;
        public Vector3 GetRightBubblePosition;
        public Vector3 GetLeftBubblePosition;
        public GameObject BombImage;
        public GameObject BomUp_2;
        /// </summary>
    }

    public void CreateBomb(Vector3 pos, Quaternion quat, int bombSize)
    {
        this.gameObject.transform.position = new Vector3(pos.x, pos.y, pos.z);
        CenterPos = pos;
        Quat = quat;
        IsBurst = false;
        StartCoroutine(BusrTimer());
        BombSize = bombSize;
        upBombSize = bombSize;
        downBombSize = bombSize;
        leftBombSize = bombSize;
        rightBombSize = bombSize;
        CenterImage = (GameObject)Instantiate(Resources.Load("FirstPlayerBubble"), this.transform.position, this.transform.rotation);

        NetworkServer.Spawn(CenterImage);

        BombMgr.bombs.Add(this);
    }

    public IEnumerator BusrTimer()
    {
        yield return new WaitForSeconds(2.5f);
        Burst();
    }

    //public void ShowWaterTail()
    //{

    //}

    public void checkWhereBoxIs(int[] centerpos)
    {
        for (int i = 1; i <= BombSize; ++i)
        {
            if (centerpos[1] - i > -1)
            {
                if (Tiles.getIsBox(centerpos[0], centerpos[1] - i))
                {
                    upBombSize = i;
                    Tiles.setIsBox(centerpos[0], centerpos[1] - i, false);
                    break;
                }
                else if(Tiles.getIsBarrier(centerpos[0], centerpos[1] - i))
                {
                    upBombSize = i - 1;
                    break;
                }
            }
            else
            {
                upBombSize = i - 1;
                break;
            }
        }

        for (int i = 1; i <= BombSize; ++i)
        {
            if (centerpos[1] + i < 16)
            {
                if (Tiles.getIsBox(centerpos[0], centerpos[1] + i))
                {
                    downBombSize = i;
                    Tiles.setIsBox(centerpos[0], centerpos[1] + i, false);
                    break;
                }
                else if (Tiles.getIsBarrier(centerpos[0], centerpos[1] + i))
                {
                    downBombSize = i - 1;
                    break;
                }
            }
            else
            {
                downBombSize = i - 1;
                break;
            }
        }

        for (int i = 1; i <= BombSize; ++i)
        {
            if (centerpos[0] - i > -1)
            {
                if (Tiles.getIsBox(centerpos[0] - i, centerpos[1]))
                {
                    leftBombSize = i;
                    Tiles.setIsBox(centerpos[0] - i, centerpos[1], false);
                    break;
                }
                else if (Tiles.getIsBarrier(centerpos[0] - i, centerpos[1]))
                {
                    leftBombSize = i - 1;
                    break;
                }
            }
            else
            {
                leftBombSize = i - 1;
                break;
            }
        }

        for (int i = 1; i <= BombSize; ++i)
        {
            if (centerpos[0] + i < 17)
            {
                if (Tiles.getIsBox(centerpos[0] + i, centerpos[1]))
                {
                    rightBombSize = i;
                    Tiles.setIsBox(centerpos[0] + i, centerpos[1], false);
                    break;
                }
                else if (Tiles.getIsBarrier(centerpos[0] + i, centerpos[1]))
                {
                    rightBombSize = i - 1;
                    break;
                }
            }
            else
            {
                rightBombSize = i - 1;
                break;
            }

        }
    }


    public void Burst()
    {
        if (IsBurst == true)
            return;

        IsBurst = true;
        //물풍선의 중심을 기준으로 퍼져나갈 물줄기를 위하여 받아온다.
        _FirstBomb.GetCenterBubblePosition = _FirstBomb.GetUpBubblePosition = _FirstBomb.GetDownBubblePosition =
                _FirstBomb.GetRightBubblePosition = _FirstBomb.GetLeftBubblePosition = CenterPos;

        GameObject bombCenter = (GameObject)GameObject.Instantiate(Resources.Load("bombwater_center1"), _FirstBomb.GetCenterBubblePosition, Quat);
        NetworkServer.Spawn(bombCenter);
        GameObject.Destroy(bombCenter, 0.3f);

        Vector3 tempPos = new Vector3(CenterPos.x, CenterPos.y - 0.1f, CenterPos.z);

        bombTile = Tiles.getTile(tempPos);
        checkWhereBoxIs(bombTile);

        for (int i = 1; i <= upBombSize; ++i)
        {
            _FirstBomb.GetCenterBubblePosition = _FirstBomb.GetUpBubblePosition = _FirstBomb.GetDownBubblePosition =
             _FirstBomb.GetRightBubblePosition = _FirstBomb.GetLeftBubblePosition = CenterPos;

            _FirstBomb.GetUpBubblePosition.y += (i * 0.6f);
            GameObject bombUp = (GameObject)GameObject.Instantiate(Resources.Load("bombwater_up"), _FirstBomb.GetUpBubblePosition, Quat);
            Rigidbody2D rb2 = bombUp.AddComponent<Rigidbody2D>();
            BoxCollider2D col2 = bombUp.AddComponent<BoxCollider2D>();

            if (col2)
            {
                col2.isTrigger = true;
                col2.size = new Vector2(col2.size.x * 0.7f, col2.size.y * 0.5f);
                col2.offset = new Vector2(0, -0.1f);
            }
            else
            {
                Debug.Log("Nothing is here");
            }
            rb2.gravityScale = 0;
            bombUp.tag = "BombWaterU";
            NetworkServer.Spawn(bombUp);
            GameObject.Destroy(bombUp, 0.6f);
            _FirstBomb.GetUpBubblePosition.y = 0.0f;

            if (upBombSize == i)
            {
                _FirstBomb.GetCenterBubblePosition = _FirstBomb.GetUpBubblePosition = _FirstBomb.GetDownBubblePosition =
           _FirstBomb.GetRightBubblePosition = _FirstBomb.GetLeftBubblePosition = CenterPos;

                _FirstBomb.GetUpBubblePosition.y += (i * 0.6f);
                bombUp = (GameObject)GameObject.Instantiate(Resources.Load("bombwater_upend"), _FirstBomb.GetUpBubblePosition, Quat);
                Rigidbody2D rb4 = bombUp.AddComponent<Rigidbody2D>();
                BoxCollider2D col4 = bombUp.AddComponent<BoxCollider2D>();
                if (col4)
                {
                    col4.isTrigger = true;
                    col4.size = new Vector2(col4.size.x * 0.7f, col4.size.y * 0.5f);
                    col4.offset = new Vector2(0, -0.1f);
                }
                else
                {
                    Debug.Log("Nothing is here");
                }
                rb4.gravityScale = 0;
                bombUp.tag = "BombWaterU";
                NetworkServer.Spawn(bombUp);
                GameObject.Destroy(bombUp, 0.6f);

            }
        }


        for (int i = 1; i <= downBombSize; ++i)
        {
            _FirstBomb.GetCenterBubblePosition = _FirstBomb.GetUpBubblePosition = _FirstBomb.GetDownBubblePosition =
             _FirstBomb.GetRightBubblePosition = _FirstBomb.GetLeftBubblePosition = CenterPos;

            _FirstBomb.GetDownBubblePosition.y -= (i * 0.6f);
            GameObject bombDown = (GameObject)GameObject.Instantiate(Resources.Load("bombwater_down"), _FirstBomb.GetDownBubblePosition, Quat);
            Rigidbody2D rb1 = bombDown.AddComponent<Rigidbody2D>();
            BoxCollider2D col1 = bombDown.AddComponent<BoxCollider2D>();
            if (col1)
            {
                col1.isTrigger = true;
                col1.size = new Vector2(col1.size.x * 0.7f, col1.size.y * 0.5f);
                col1.offset = new Vector2(0, 0.1f);
            }
            else
            {
                Debug.Log("Nothing is here");
            }
            rb1.gravityScale = 0;
            bombDown.tag = "BombWaterD";
            NetworkServer.Spawn(bombDown);
            GameObject.Destroy(bombDown, 0.6f);
            _FirstBomb.GetDownBubblePosition.y = 0.0f;

            if (downBombSize == i)
            {
                _FirstBomb.GetCenterBubblePosition = _FirstBomb.GetUpBubblePosition = _FirstBomb.GetDownBubblePosition =
           _FirstBomb.GetRightBubblePosition = _FirstBomb.GetLeftBubblePosition = CenterPos;

                _FirstBomb.GetDownBubblePosition.y -= (i * 0.6f);
                bombDown = (GameObject)GameObject.Instantiate(Resources.Load("bombwater_downend"), _FirstBomb.GetDownBubblePosition, Quat);
                Rigidbody2D rb3 = bombDown.AddComponent<Rigidbody2D>();
                BoxCollider2D col3 = bombDown.AddComponent<BoxCollider2D>();
                if (col3)
                {
                    col3.isTrigger = true;
                    col3.size = new Vector2(col3.size.x * 0.7f, col3.size.y * 0.5f);
                    col3.offset = new Vector2(0, 0.1f);
                }
                else
                {
                    Debug.Log("Nothing is here");
                }
                rb3.gravityScale = 0;
                bombDown.tag = "BombWaterD";
                NetworkServer.Spawn(bombDown);
                GameObject.Destroy(bombDown, 0.6f);

            }
        }

        for (int i = 1; i <= leftBombSize; ++i)
        {


            _FirstBomb.GetCenterBubblePosition = _FirstBomb.GetUpBubblePosition = _FirstBomb.GetDownBubblePosition =
           _FirstBomb.GetRightBubblePosition = _FirstBomb.GetLeftBubblePosition = CenterPos;

            _FirstBomb.GetLeftBubblePosition.x -= (i * 0.6f);

            GameObject bombLeft = (GameObject)GameObject.Instantiate(Resources.Load("bombwater_left"), _FirstBomb.GetLeftBubblePosition, Quat);
            Rigidbody2D rb6 = bombLeft.AddComponent<Rigidbody2D>();
            BoxCollider2D col6 = bombLeft.AddComponent<BoxCollider2D>();
            if (col6)
            {
                col6.isTrigger = true;
                col6.size = new Vector2(col6.size.x * 0.5f, col6.size.y * 0.7f);
                col6.offset = new Vector2(0.1f, 0);
            }
            else
            {
                Debug.Log("Nothing is here");
            }
            rb6.gravityScale = 0;
            bombLeft.tag = "BombWaterL";
            NetworkServer.Spawn(bombLeft);
            GameObject.Destroy(bombLeft, 0.6f);

            _FirstBomb.GetDownBubblePosition.x = 0.0f;
            _FirstBomb.GetUpBubblePosition.x = 0.0f;

            if (leftBombSize == i)
            {
                _FirstBomb.GetCenterBubblePosition = _FirstBomb.GetUpBubblePosition = _FirstBomb.GetDownBubblePosition =
           _FirstBomb.GetRightBubblePosition = _FirstBomb.GetLeftBubblePosition = CenterPos;

                _FirstBomb.GetLeftBubblePosition.x -= (i * 0.6f);
                bombLeft = (GameObject)GameObject.Instantiate(Resources.Load("bombwater_leftend"), _FirstBomb.GetLeftBubblePosition, Quat);
                Rigidbody2D rb8 = bombLeft.AddComponent<Rigidbody2D>();
                BoxCollider2D col8 = bombLeft.AddComponent<BoxCollider2D>();
                if (col8)
                {
                    col8.isTrigger = true;
                    col8.size = new Vector2(col6.size.x * 0.5f, col6.size.y * 0.7f);
                    col8.offset = new Vector2(0.1f, 0);
                }
                else
                {
                    Debug.Log("Nothing is here");
                }
                rb8.gravityScale = 0;
                bombLeft.tag = "BombWaterL";
                NetworkServer.Spawn(bombLeft);
                GameObject.Destroy(bombLeft, 0.6f);
            }

        }


        for (int i = 1; i <= rightBombSize; ++i)
        {
            _FirstBomb.GetCenterBubblePosition = _FirstBomb.GetUpBubblePosition = _FirstBomb.GetDownBubblePosition =
           _FirstBomb.GetRightBubblePosition = _FirstBomb.GetLeftBubblePosition = CenterPos;

            _FirstBomb.GetRightBubblePosition.x += (i * 0.6f);

            GameObject bombRight = (GameObject)GameObject.Instantiate(Resources.Load("bombwater_right"), _FirstBomb.GetRightBubblePosition, Quat);
            Rigidbody2D rb5 = bombRight.AddComponent<Rigidbody2D>();
            BoxCollider2D col5 = bombRight.AddComponent<BoxCollider2D>();
            if (col5)
            {
                col5.isTrigger = true;
                col5.size = new Vector2(col5.size.x * 0.5f, col5.size.y * 0.7f);
                col5.offset = new Vector2(-0.1f, 0);
            }
            else
            {
                Debug.Log("Nothing is here");
            }
            rb5.gravityScale = 0;
            bombRight.tag = "BombWaterR";
            NetworkServer.Spawn(bombRight);
            GameObject.Destroy(bombRight, 0.6f);

            _FirstBomb.GetDownBubblePosition.x = 0.0f;
            _FirstBomb.GetUpBubblePosition.x = 0.0f;

            if (rightBombSize == i)
            {
                _FirstBomb.GetCenterBubblePosition = _FirstBomb.GetUpBubblePosition = _FirstBomb.GetDownBubblePosition =
           _FirstBomb.GetRightBubblePosition = _FirstBomb.GetLeftBubblePosition = CenterPos;

                _FirstBomb.GetRightBubblePosition.x += (i * 0.6f);
                bombRight = (GameObject)GameObject.Instantiate(Resources.Load("bombwater_rightend"), _FirstBomb.GetRightBubblePosition, Quat);
                Rigidbody2D rb7 = bombRight.AddComponent<Rigidbody2D>();
                BoxCollider2D col7 = bombRight.AddComponent<BoxCollider2D>();
                if (col7)
                {
                    col7.isTrigger = true;
                    col7.size = new Vector2(col7.size.x * 0.5f, col7.size.y * 0.7f);
                    col7.offset = new Vector2(-0.1f, 0);
                }
                else
                {
                    Debug.Log("Nothing is here");
                }
                rb7.gravityScale = 0;
                bombRight.tag = "BombWaterR";
                NetworkServer.Spawn(bombRight);
                GameObject.Destroy(bombRight, 0.6f);
            }
        }


        BombMgr.bombs.Remove(this);
        BombMgr.CheckColiider(this);
        FirstPlayerInfo.iSetBuubleCount -= 1;
        Destroy(CenterImage);
    }
}