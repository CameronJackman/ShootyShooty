using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GameMan : MonoBehaviour
{
    public float points;

    private float timeElap = 0f;

    public TMP_Text TimeElapTxt,
                    pointsTxt;

    [HideInInspector] public bool isVr;

    public float shotsFiredAmt, shotsHitAmt;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TimeElapsed();

        PointUpdates();
    }


    void TimeElapsed()
    {
        timeElap += Time.deltaTime;

        TimeSpan timeSpan = TimeSpan.FromSeconds(timeElap);

        string formattedTime = timeSpan.ToString(@"hh\:mm\:ss");

        TimeElapTxt.text = formattedTime;
    }

    void PointUpdates()
    {
        string formattedPoints = points.ToString("000000");

        pointsTxt.text = formattedPoints;
    }
}
