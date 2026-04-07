using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class statsTracking : MonoBehaviour
{
    public TMP_Text accuracyTxt, scoreTxt;

    private GameMan gameManager;

    private float accuracy;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindAnyObjectByType<GameMan>();
    }

    // Update is called once per frame
    void Update()
    {
        PointUpdates();

        accuracyUpdates();
    }

    void PointUpdates()
    {
        string formattedPoints = gameManager.points.ToString("000000");

        scoreTxt.text = formattedPoints;
    }

    void accuracyUpdates()
    {
        accuracy = Mathf.Round((gameManager.shotsHitAmt / gameManager.shotsFiredAmt) * 100);

        accuracyTxt.text = accuracy+"%";
    }
}
