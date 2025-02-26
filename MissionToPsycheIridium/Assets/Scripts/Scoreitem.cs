using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScoreItem
{


    //static variables that any script can access and modify
    public static int Score = 0;
    public static int GoldScore = 0;
    public static int SilverScore = 0;
    public static int IronScore = 0;
    public static int NickelScore = 0;
    public static int ResearchScore = 0;

    public static void increaseScore(int n)
    {
        Score = Score + n;
    }

    public static void increaseItemQty(int n)
    {
        if (n == 1)
        {
            IronScore++;
        }
        if (n == 2)
        {
            NickelScore++;
        }
        if (n==3)
        {
            SilverScore++;
        }
        if (n == 5)
        {
            GoldScore++;
        }
        if (n == 0)
        {
            ResearchScore++;
        }
    }



    //gameover scene calls this to get static variable score.
    public static int getScore()
    {
        return Score;
    }

    //Called from gamemanager. Updates static variable to current score.
    public static void setScore(int n)
    {
        Score = n;
    }


}
