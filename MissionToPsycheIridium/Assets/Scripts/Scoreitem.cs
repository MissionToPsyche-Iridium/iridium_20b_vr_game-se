using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScoreItem
{


    //static variables that any script can access and modify
    private static int Score = 0;
    private static int GoldScore = 0;
    private static int SilverScore = 0;
    private static int IronScore = 0;
    private static int NickelScore = 0;
    private static int ResearchScore = 0;

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


    public static int getIronQty()
    {
        return IronScore;
    }

    public static int getNickelQty()
    {
        return NickelScore;
    }

    public static int getSilverQty()
    {
        return SilverScore;
    }

    public static int getGoldQty()
    {
        return GoldScore;
    }

    public static int getResearchQty()
    {
        return ResearchScore;
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
