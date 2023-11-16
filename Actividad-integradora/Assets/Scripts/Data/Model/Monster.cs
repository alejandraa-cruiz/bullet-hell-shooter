using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public void OnEnable()
    {
        TimeManager.OnMinuteChanged += TimeCheck;
    }

    public void OnDisable()
    {
        TimeManager.OnMinuteChanged -= TimeCheck;
    }

    private void TimeCheck()
    {
    
        //Start corrutine every 5 minutes
        if((TimeManager.Minute%5) == 0)
        {
            //Coroutine is a function that can be paused and resumed
            //Coroutine return a IEnumerator and need to use yield before return
            //Async code
            StartCoroutine(MoveMonster());
        }
        
    }

   private IEnumerator MoveMonster()
    {
        transform.position = new Vector3(5f,3f,-6.3f);
        Vector3 targetPos = new Vector3(-5f,3f,-6.3f);

        Vector3 currentPos = transform.position;

        float timeElapsed = 0;
        float timeToMove = 4;

        while(timeElapsed < timeToMove){
            transform.position = Vector3.Lerp(currentPos,targetPos,timeElapsed/timeToMove);
            timeElapsed += Time.deltaTime;
            yield return null;
        } 

    }
}
