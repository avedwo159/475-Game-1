using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public GameManager gameManager;

    public float time = 0.0f;
    public Text timer;

    private int finishes = 0;
    private int checkFinishes = 1;
    private float bestTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        finishes = gameManager.getFinish();

        if (finishes == checkFinishes)
        {
            if (time < bestTime || bestTime == 0.0f)
            {
                bestTime = time;
            }
            
            time = 0.0f;
            checkFinishes++;
        }


        timer.text = "Timer: " + time.ToString() + "\nBest Time: " + bestTime.ToString() + "\nStreak: " + finishes.ToString();

    }
}
