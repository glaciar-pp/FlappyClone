using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreUp : MonoBehaviour
{
    //트리거 이벤트 설정 시엔 start, Update 필요없음
   private void OnTriggerEnter2D(Collider2D other) {
    //Score에서 선언한 변수 호출, 점수 더해주기, Score.score+=1; 도 사용가능
    Score.score++;
   }
}
