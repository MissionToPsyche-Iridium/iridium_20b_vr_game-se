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
        switch (n)
        {
            case 0:
                ResearchScore++;
                break;
            case 1:
                IronScore++;
                break;
            case 2:
                NickelScore++;
                break;
            case 3:
                SilverScore++;
                break;
            case 5:
                GoldScore++;
                break;
            default:
                break;
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

    public static void resetScores()
    {
        Score = 0;
        GoldScore = 0;
        SilverScore = 0;
        IronScore = 0;
        NickelScore = 0;
        ResearchScore = 0;
    }

}
