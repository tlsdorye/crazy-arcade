using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Tiles {

    public class Tile
    {
        public float x;
        public float y;
        public bool isBox;
        public bool isBarrier;

        public Tile(float x, float y, bool isBox, bool isBarrier)
        {
            this.x = x;
            this.y = y;
            this.isBox = isBox;
            this.isBarrier = isBarrier;
        }
    }

    public static Tile[][] arrTile;
    public static float[] posX = {(float)(-6.1), (float)(-5.5), (float)(-4.9), (float)(-4.3),
                            (float)(-3.7), (float)(-3.1), (float)(-2.5), (float)(-1.9),
                            (float)(-1.3), (float)(-0.7), (float)(-0.1), (float)(0.5),
                            (float)(1.1), (float)(1.7), (float)(2.3), (float)(2.9), (float)(3.5)};

    public static float[] posY = {(float)(4.5), (float)(3.9), (float)(3.3), (float)(2.7),
                            (float)(2.1), (float)(1.5), (float)(0.9), (float)(0.3),
                            (float)(-0.3), (float)(-0.9), (float)(-1.5), (float)(-2.1),
                            (float)(-2.7), (float)(-3.3), (float)(-3.9), (float)(-4.5)};

    public static void init()
    {
        if (arrTile != null) return;
        arrTile = new Tile[17][];
        for (int i = 0; i < 17; i++)
        {
            arrTile[i] = new Tile[16];
        }
        for (int i = 0; i < 17; i++)
        {
            for (int j = 0; j < 16; j++)
            {
                arrTile[i][j] = new Tile(posX[i], posY[j], false, false);
            }
        }
        Debug.Log("init finish");
    }

    public static int[] getTile(Vector3 pos)
    {
        int[] ret = new int[2];
        for(int i = 0; i < 17; i++)
        {
            for (int j = 0; j < 16; j++)
            {
                if ((pos.x - 0.2 <= arrTile[i][j].x && arrTile[i][j].x <= pos.x + 0.2)  &&
                     pos.y - 0.2 <= arrTile[i][j].y && arrTile[i][j].y <= pos.y + 0.2)
                {
                    ret[0] = i;
                    ret[1] = j;
                    return ret;
                }
            }
        }
        ret[0] = -1;
        ret[1] = -1;
        return ret;
    }

    public static void setIsBox(int i, int j, bool value)
    {
        arrTile[i][j].isBox = value;
    }

    public static bool getIsBox(int i, int j)
    {
        return arrTile[i][j].isBox;
    }

    public static void setIsBarrier(int i, int j, bool value)
    {
        arrTile[i][j].isBarrier = value;
    }

    public static bool getIsBarrier(int i, int j)
    {
        return arrTile[i][j].isBarrier;
    }
}
