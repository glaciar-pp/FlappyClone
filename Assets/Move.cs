using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    // 속도 조절을 위한 변수 선언
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        transform.position += Vector3.left * speed * Time.deltaTime; 
        // (-1, 0, 0), 다만  Vector3.left; 부분을 그냥 쓰게 되면 프레임 환경설정에 따른 속도 차이가 심해짐. 6FPS면 1초에 6m / 3FPS는 1초에 3m
        // 그래서 유니티에서 지원하는 기능인 Time.deltaTime(w지난 프레임이 완료되는데 걸린 시간, FPS보정용으로 사용하는 기능)을 사용해준다.
    }
}
