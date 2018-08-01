using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxInfo : MonoBehaviour
{
    public static void isBoxInit()
    {
        Tiles.init();
        Tiles.setIsBox(0, 0, true);
        Tiles.setIsBox(3, 0, true);
        Tiles.setIsBox(7, 0, true);
        Tiles.setIsBox(8, 0, true);
        Tiles.setIsBox(9, 0, true);
        Tiles.setIsBox(13, 0, true);
        Tiles.setIsBox(16, 0, true);

        Tiles.setIsBox(0, 1, true);
        Tiles.setIsBox(4, 1, true);
        Tiles.setIsBox(5, 1, true);
        Tiles.setIsBox(6, 1, true);
        Tiles.setIsBox(8, 1, true);
        Tiles.setIsBox(10, 1, true);
        Tiles.setIsBox(11, 1, true);
        Tiles.setIsBox(12, 1, true);
        Tiles.setIsBox(16, 1, true);

        Tiles.setIsBox(0, 2, true);
        Tiles.setIsBox(1, 2, true);
        Tiles.setIsBox(3, 2, true);
        Tiles.setIsBox(7, 2, true);
        Tiles.setIsBox(9, 2, true);
        Tiles.setIsBox(13, 2, true);
        Tiles.setIsBox(15, 2, true);
        Tiles.setIsBox(16, 2, true);

        Tiles.setIsBox(0, 3, true);
        Tiles.setIsBox(2, 3, true);
        Tiles.setIsBox(4, 3, true);
        Tiles.setIsBox(5, 3, true);
        Tiles.setIsBox(6, 3, true);
        Tiles.setIsBox(8, 3, true);
        Tiles.setIsBox(10, 3, true);
        Tiles.setIsBox(11, 3, true);
        Tiles.setIsBox(12, 3, true);
        Tiles.setIsBox(14, 3, true);
        Tiles.setIsBox(16, 3, true);

        Tiles.setIsBox(0, 4, true);
        Tiles.setIsBox(2, 4, true);
        Tiles.setIsBox(4, 4, true);
        Tiles.setIsBox(5, 4, true);
        Tiles.setIsBox(6, 4, true);
        Tiles.setIsBox(7, 4, true);
        Tiles.setIsBox(9, 4, true);
        Tiles.setIsBox(10, 4, true);
        Tiles.setIsBox(11, 4, true);
        Tiles.setIsBox(12, 4, true);
        Tiles.setIsBox(14, 4, true);
        Tiles.setIsBox(16, 4, true);

        Tiles.setIsBox(1, 5, true);
        Tiles.setIsBox(3, 5, true);
        Tiles.setIsBox(4, 5, true);
        Tiles.setIsBox(5, 5, true);
        Tiles.setIsBox(6, 5, true);
        Tiles.setIsBox(7, 5, true);
        Tiles.setIsBox(8, 5, true);
        Tiles.setIsBox(9, 5, true);
        Tiles.setIsBox(10, 5, true);
        Tiles.setIsBox(11, 5, true);
        Tiles.setIsBox(12, 5, true);
        Tiles.setIsBox(13, 5, true);
        Tiles.setIsBox(15, 5, true);

        Tiles.setIsBox(1, 6, true);
        Tiles.setIsBox(3, 6, true);
        Tiles.setIsBox(4, 6, true);
        Tiles.setIsBox(5, 6, true);
        Tiles.setIsBox(6, 6, true);
        Tiles.setIsBox(7, 6, true);
        Tiles.setIsBox(8, 6, true);
        Tiles.setIsBox(9, 6, true);
        Tiles.setIsBox(10, 6, true);
        Tiles.setIsBox(11, 6, true);
        Tiles.setIsBox(12, 6, true);
        Tiles.setIsBox(13, 6, true);
        Tiles.setIsBox(15, 6, true);

        Tiles.setIsBox(1, 7, true);
        Tiles.setIsBox(3, 7, true);
        Tiles.setIsBox(4, 7, true);
        Tiles.setIsBox(5, 7, true);
        Tiles.setIsBox(6, 7, true);
        Tiles.setIsBox(10, 7, true);
        Tiles.setIsBox(11, 7, true);
        Tiles.setIsBox(12, 7, true);
        Tiles.setIsBox(13, 7, true);
        Tiles.setIsBox(15, 7, true);

        Tiles.setIsBox(0, 8, true);
        Tiles.setIsBox(2, 8, true);
        Tiles.setIsBox(4, 8, true);
        Tiles.setIsBox(5, 8, true);
        Tiles.setIsBox(6, 8, true);
        Tiles.setIsBox(10, 8, true);
        Tiles.setIsBox(11, 8, true);
        Tiles.setIsBox(12, 8, true);
        Tiles.setIsBox(14, 8, true);
        Tiles.setIsBox(16, 8, true);

        Tiles.setIsBox(0, 9, true);
        Tiles.setIsBox(2, 9, true);
        Tiles.setIsBox(4, 9, true);
        Tiles.setIsBox(5, 9, true);
        Tiles.setIsBox(6, 9, true);
        Tiles.setIsBox(7, 9, true);
        Tiles.setIsBox(8, 9, true);
        Tiles.setIsBox(9, 9, true);
        Tiles.setIsBox(10, 9, true);
        Tiles.setIsBox(11, 9, true);
        Tiles.setIsBox(12, 9, true);
        Tiles.setIsBox(14, 9, true);
        Tiles.setIsBox(16, 9, true);

        Tiles.setIsBox(0, 10, true);
        Tiles.setIsBox(1, 10, true);
        Tiles.setIsBox(3, 10, true);
        Tiles.setIsBox(5, 10, true);
        Tiles.setIsBox(6, 10, true);
        Tiles.setIsBox(7, 10, true);
        Tiles.setIsBox(8, 10, true);
        Tiles.setIsBox(9, 10, true);
        Tiles.setIsBox(10, 10, true);
        Tiles.setIsBox(11, 10, true);
        Tiles.setIsBox(13, 10, true);
        Tiles.setIsBox(15, 10, true);
        Tiles.setIsBox(16, 10, true);

        Tiles.setIsBox(0, 11, true);
        Tiles.setIsBox(1, 11, true);
        Tiles.setIsBox(2, 11, true);
        Tiles.setIsBox(4, 11, true);
        Tiles.setIsBox(6, 11, true);
        Tiles.setIsBox(7, 11, true);
        Tiles.setIsBox(8, 11, true);
        Tiles.setIsBox(9, 11, true);
        Tiles.setIsBox(10, 11, true);
        Tiles.setIsBox(12, 11, true);
        Tiles.setIsBox(14, 11, true);
        Tiles.setIsBox(15, 11, true);
        Tiles.setIsBox(16, 11, true);

        Tiles.setIsBox(0, 12, true);
        Tiles.setIsBox(1, 12, true);
        Tiles.setIsBox(2, 12, true);
        Tiles.setIsBox(3, 12, true);
        Tiles.setIsBox(5, 12, true);
        Tiles.setIsBox(7, 12, true);
        Tiles.setIsBox(8, 12, true);
        Tiles.setIsBox(9, 12, true);
        Tiles.setIsBox(11, 12, true);
        Tiles.setIsBox(13, 12, true);
        Tiles.setIsBox(14, 12, true);
        Tiles.setIsBox(15, 12, true);
        Tiles.setIsBox(16, 12, true);

        Tiles.setIsBox(0, 13, true);
        Tiles.setIsBox(1, 13, true);
        Tiles.setIsBox(3, 13, true);
        Tiles.setIsBox(4, 13, true);
        Tiles.setIsBox(6, 13, true);
        Tiles.setIsBox(8, 13, true);
        Tiles.setIsBox(10, 13, true);
        Tiles.setIsBox(12, 13, true);
        Tiles.setIsBox(13, 13, true);
        Tiles.setIsBox(15, 13, true);
        Tiles.setIsBox(16, 13, true);

        Tiles.setIsBox(0, 14, true);
        Tiles.setIsBox(3, 14, true);
        Tiles.setIsBox(4, 14, true);
        Tiles.setIsBox(5, 14, true);
        Tiles.setIsBox(7, 14, true);
        Tiles.setIsBox(9, 14, true);
        Tiles.setIsBox(11, 14, true);
        Tiles.setIsBox(12, 14, true);
        Tiles.setIsBox(13, 14, true);
        Tiles.setIsBox(16, 14, true);

        Tiles.setIsBox(0, 15, true);
        Tiles.setIsBox(3, 15, true);
        Tiles.setIsBox(4, 15, true);
        Tiles.setIsBox(5, 15, true);
        Tiles.setIsBox(6, 15, true);
        Tiles.setIsBox(8, 15, true);
        Tiles.setIsBox(10, 15, true);
        Tiles.setIsBox(11, 15, true);
        Tiles.setIsBox(12, 15, true);
        Tiles.setIsBox(13, 15, true);
        Tiles.setIsBox(16, 15, true);


        Tiles.setIsBarrier(1, 1, true);
        Tiles.setIsBarrier(15, 1, true);
        Tiles.setIsBarrier(1, 14, true);
        Tiles.setIsBarrier(15, 14, true);
        Tiles.setIsBarrier(7, 7, true);
        Tiles.setIsBarrier(8, 7, true);
        Tiles.setIsBarrier(9, 7, true);
        Tiles.setIsBarrier(7, 8, true);
        Tiles.setIsBarrier(8, 8, true);
        Tiles.setIsBarrier(9, 8, true);

    }
}
