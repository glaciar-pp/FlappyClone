using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakePipe : MonoBehaviour
{
    //파이프 생성을 위한 변수 선언
    public GameObject pipe;
    //파이프가 균일하게 생성되도록 시간 변수 선언
    float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 1)
        {
            Instantiate(pipe);
            timer = 0;
        }
       
    }
}
 