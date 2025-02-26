using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScoreItem
{

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

    //gameover scene calls this to get score
    public static int getScore()
    {
        return Score;
    }

    public static void setScore(int n)
    {
        Score = n;
    }

}
