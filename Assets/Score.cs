using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    //파이프와 반응해야하고, 외부에서도 접근해야하기 때문에 public static이 붙은 변수 선언
    public static int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = score.ToString(); //파이썬은 str(score)로 문자로 변경한다고 함.
        
    }
}
