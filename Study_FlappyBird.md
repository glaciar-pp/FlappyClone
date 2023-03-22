# FlappyBird 클론코딩 
클론코딩을 하면서 정리하는게 좋을 것 같은 부분을 기재해두었다.
우선 각 오브젝트별로 정리하였다.   
※ 좌측 Hierarchy 형태 목록은 줄여서 리스트라고 적었다.   

**공통(common)**   
▶ 모바일게임이므로, 비율 9 : 16으로 설정함    
▶ 모든 각각의 오브젝트의 경우 Order in Layer 순서에 따라 뒤로 밀려서 제대로 보이지 않을 수 있기 때문에 우선순위를 맞춰주는 과정이 필요함.   
▶ 만들어가는 동안 진행사항을 재생 기능으로 볼 수 있는데, 재생한 상태로 작업을 할 경우 온전히 적용되지 않으니 꼭 확인 후 정지한 뒤에 적용할 것.   
▶ Text의 경우 비율에 따라 상당히 작아지는 경우가 있는데 이 경우엔 비율 조절이 필요함
해당하는 canvas - Inspector - Canvas Scaler - UI Scale Mode - Scale with Screen Size 로 변경   
그 뒤 기종에 맞는 비율을 검색해서 넣어주면 사이즈에 따라 나타나게 된다.   
Text 오브젝트 자체에서도 text Component - Best fit 설정을 통해 사이즈 조절이 가능함   

**배경 (BackGround)**   
별도 설정 없음.   
   
**땅(Ground)**   
**땅을 하나의 물체로 만들고자 할 때**  
새와 충돌이 필요한 부분으로, 물체로 만들어주었다.   
▶오브젝트 물체화(충돌 감지): Box Collider 2D   
   
**땅이 방향에 따라 움직이는 느낌을 주고자 할 때**   
Sprite renfderer-Draw mode-Tiled 적용하여 이미지를 늘려도 규칙성 있게 설정해줌   
이후 Animation 기능에서 움직이고자 하는 방향으로 땅을 잡고 움직여 녹화해준다.
움직이는 속도는 시간을 조정으로 조절할 수 있고, 속도가 불균일하다면 구간 전체 선택 후 우클릭-Both Tangents-Linear 설정을 해주면 균일화된다.   
   
**새(Bird)**   
**새 자체에 애니메이션 효과를 주고자 할 때**   
오브젝트에 Animation 부여. 넣고자 하는 애니메이션 화면에 해당하는 준비된 오브젝트를 전부 선택한 뒤 Animation창에 넣으면 임의 간격으로 들어가게 된다.
움직이는 속도는 시간을 조정으로 조절할 수 있고, 
**새를 하나의 물체로 만들고 중력을 적용하고자 할 때**   
해당 오브젝트를 리스트에서 클릭한 뒤 Inspector에 Add Component-Physics 2D 클릭   
▶중력: Rigidbody2D   
▶오브젝트 물체화(충돌 감지): Capsule Collider 2D

**새가 점프하는 기능을 구현하고자 할 때**   
해당 파일은 코드가 상대적으로 길기 때문에 전문을 앞서 넣음   
```
//마우스 왼쪽 버튼을 눌렀을 때
        if (Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector2.up * jumpPower;// (0,3)   
        }
```   
Rigidbody2D 에서 velocity 사용, Vector2.up을 사용해 마우스 클릭 시 위로 움직이는 기능을 넣어줄 수 있는데, 점프 높이는 변수 선언을 통해 유니티에서 조절할 수 있는 public 변수를 넣어주었다.

**새를 점프시킬 때마다 사운드가 출력되도록 할때**   
원하는 Audio 파일 준비(혹시 준비한 파일이 .m4a인 경우는 유니티에서 지원하지 않으므로 변환 필수) 후 Assets에 추가한다.   
리스트의 bird - add Component - Audio Source를 생성한다.   
`※참고로 Play On Awake 가 기본으로 체크되어 있는데, 등장 시 오디오 재생이란 뜻이기 때문에 점프 이벤트 시에 재생하려는 목적과 맞지 않으므로 체크를 해제해준다.`   
AudioClip에 원하는 사운드를 넣어준 뒤, BirdJump.cs에 해당 부분을 추가한다.

**파이프(Pipe)**   
**파이프 프리팹(prefab)화**   
건축용어이기도 한 프리팹은 재사용이 잦은 오브젝트를 사용하기 편하게 설정해두는 과정이다.   
해당 게임에서는 파이프가 프리팹이 필요한 오브젝트이기에 설정 진행되었다.   
리스트에서 우클릭-Create Empty 만들어준 뒤 이름 설정(Pipe).   
파이프에 해당하는 이미지를 넣으면 프리팹 오브젝트가 된다. 파란 상자와 글씨로 바뀌기 때문에 알아보기 편하다.   
`※본인의 경우 PipeGenerator에 프리팹 파이프가 제대로 적용되지 않는 문제가 있었는데, 해당 코딩 댓글을 찾아보니 리스트에서 오브젝트 끌어다 넣는 부분이 영상으로 설명되어있어 따라했는데 되지 않을 경우, 하단 Assets에 있는 프리팹 원본을 드래그 해서 넣어주면 정상작동 한다는 댓글을 보았다.   
따라해보았더니 진짜로 영상과 같은 결과가 반영되었고, 해당 부분 원인은 설명되어있지 않았기에 조금 아쉽지만 혹여 정상 작동하지 않으면 해당 방법을 시도해보자.`
   
**파이프를 움직여오도록 만들고자 할 때**   
리스트에서 우클릭-Create Empty 만들어준 뒤 이름 설정(PipeGenerator).   
Add Component-스크립트를 생성해준다.

**파이프 사이 점수와 연계하여 인식되는 영역을 설정할 때**   
▶오브젝트 물체화(충돌 감지): Box Collider 2D 부여 후 Is Trigger를 부여하면 충돌은 하지 않되, 이벤트를 인식하는 영역으로서 설정이 가능해진다.   

★ 리스트의 파이프는 이제 삭제해도 된다. PipeGenerator 기능이 있고 리스트에서 삭제하여도 Assets에서는 사라지지 않고 잘 들어있기 때문에 리스트 파이프를 삭제하여도 여전히 잘 생성됨을 확인하였다.   

**점수**
**게임 진행에 따른 점수가 카운트 되는 기능을 넣을 때**   

`※해당 기능만 넣으면 점수 기능이 온전히 구현되지않는 사항이 있음   
→ start 시 score 0 선언, 현재 점수 기능 추가`   
**결과에 현재 점수를 보이도록 할 때**   
GameOverScene - 리스트 중 panel - score 항목에 CurrentScore 스크립트 생성   
```
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentScore : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Text>().text = "Score: " + Score.score.ToString();
    }
}
```
결과에 점수를 받아오게 됨.   

**천장(스크린 맨 위)에 새가 부딪히면 점수가 오르지 않고 게임오버 되도록 할 때**   
PlayScene - 리스트에서 Create Empty 생성후 Upside로 이름 변경.   
Box Collider 2D 부여 후 Transform에서 위치 조정(0, 8, 0) 및 자체 속성에서 Size 스크린에 맞는 사이즈로 조정(x: 7.15)   

**버튼**   
**게임오버 시, 리플레이가 가능한 버튼을 만들 때(리플레이 기능 생성)**   
리스트에서 Create Empty 생성 후 Reply로 이름변경. 동일한 이름으로 스크립트를 생성한다.
스크립트에서 PlayScene 으로 돌아가는 기능만이 필요하므로 간단하게 코드를 작성해준다.
```
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Replay : MonoBehaviour
{
    public void ReplayGame()
    {
        SceneManager.LoadScene("PlayScene");
    }
}   
```   
그 뒤 프로그램으로 유니티로 돌아와 버튼에 onClick()이벤트 부분에 Replay넣어준 뒤, No Function 부분 클릭을 통해 원하는 코드를 불러올 수 있다. 이 중 작성했던 ReplayGame 을 지정해주면 버튼은 해당 기능을 구현한다.

`※ 버튼 Replay 스크립트 생성까지 마치고 재생을 했는데, 버튼이 계속 눌러지지가 않는 문제가 생겼다.   
구글링을 해보고 알 수 있었는데, 잘못생성한 오브젝트를 지우다가 EventSystem 까지 같이 날아가서 이벤트가 발생해도 작동을 할수가 없는...어이없는 실수를 했다.   
다시 추가해주니 버튼이 작동함을 확인할 수 있었다.`    