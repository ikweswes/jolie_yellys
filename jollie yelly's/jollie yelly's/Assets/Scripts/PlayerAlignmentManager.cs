using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerAlignmentManager
{
    static float Killer = 0;
    static float Explorer = 0;
    static float Socializer = 0;
    static float Achiever = 0;

    public enum PlayerType
    {
        KILLER = 1,
        EXPLORER = 2,
        SOCIALIZER = 3,
        ACHIEVER = 4
    }

    public static void AddPoints(PlayerType playerType, int amount)
    {
        switch ((int)playerType)
        {
            case (1):
                {
                    Killer += amount;
                    break;
                }
            case (2):
                {
                    Explorer += amount;
                    break;
                }
            case (3):
                {
                    Socializer += amount;
                    break;
                }
            case (4):
                {
                    Achiever += amount;
                    break;
                }
        }
    }
}
