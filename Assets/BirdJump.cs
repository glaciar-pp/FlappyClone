using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BirdJump : MonoBehaviour
{
    //점프 기능을 위해 불러옴
    Rigidbody2D rb;
    //점프 강도 조절을 위한 변수
    public float jumpPower;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Update 입니다.");
        //마우스 왼쪽 버튼을 눌렀을 때
        if (Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector2.up * jumpPower;// (0,3)   
        }
    }
    //콜라이더 충돌 시 이벤트 발생-> 게임오버 씬으로 이동
    private void OnCollisionEnter2D(Collision2D other) {
        SceneManager.LoadScene("GameOverScene");
    }
}
