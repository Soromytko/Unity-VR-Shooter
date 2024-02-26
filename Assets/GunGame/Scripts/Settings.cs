using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Settings
{
    public static readonly string BastScoreFieldName = "VR-Shooter-BestScore";
    public static readonly string GameDurationFieldName = "VR-Shooter-GameDuration";
    public static readonly string GameSpeedFieldName = "VR-Shooter-GameSpeed";

    public static int BestScore
    {
        get => PlayerPrefs.GetInt(BastScoreFieldName, 0);
        set => PlayerPrefs.SetInt(BastScoreFieldName, value);
    }

    public static float GameDuration
    {
        get => PlayerPrefs.GetFloat(GameDurationFieldName, 30);
        set => PlayerPrefs.SetFloat(GameDurationFieldName, value);
        
    }

    public static float GameSpeed
    {
        get => PlayerPrefs.GetFloat(GameSpeedFieldName, 0.2f);
        set => PlayerPrefs.SetFloat(GameSpeedFieldName, value);
    }
}
