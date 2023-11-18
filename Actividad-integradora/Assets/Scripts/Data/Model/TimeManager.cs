using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//MonoBehaviour allows the script to be attached to a game object 
//without creating an object that uses resources
public class TimeManager : MonoBehaviour
{
    //Public Variables
    //Action variables start events on the game  
    public static Action OnMinuteChanged;
    public static Action OnHourChanged;
    public static int Minute{get; private set;}
    public static int Hour{get; private set;}
    private float minuteToRealTime = 0.5f;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        Minute = 0;
        Hour = 0;
        timer = minuteToRealTime;
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Minute++;
            //Lauch an event when the minute changes
            OnMinuteChanged?.Invoke();
            if(Minute >= 60)
            {
                Hour++;
                //Lauch an event when the hour changes
                OnHourChanged?.Invoke();
                Minute = 0;
            }
            timer = minuteToRealTime;
        }
        
    }
}
