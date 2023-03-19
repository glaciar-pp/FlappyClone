using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakePipe : MonoBehaviour
{
    //파이프 생성을 위한 변수 선언
    public GameObject pipe;
    //유니티 내에서도 생성 시간 조절할 수 있도록 변수 선언
    public float timeDiff;
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
        if (timer > timeDiff)
        {
            GameObject newPipe = Instantiate(pipe);
            newPipe.transform.position = new Vector3(0, Random.Range(0f, 4.5f), 0);
            timer = 0;
            //생성되었던 파이프가 쌓이지 않고 사라지도록 함
            Destroy(newPipe, 10.0f);
        }
       
    }
}
 