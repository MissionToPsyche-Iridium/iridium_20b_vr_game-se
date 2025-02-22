using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScoreItem
{

    public static int Score = 0;

    public static void increaseScore(int n)
    {
        Score = Score + n;
    }

    public static int getScore()
    {
        return Score;
    }

    public static void setScore(int n)
    {
        Score = n;
    }

}
