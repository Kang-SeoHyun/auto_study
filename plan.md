# 설계

## WBS
요약  
![image](https://github.com/Kang-SeoHyun/auto_study/assets/77817094/52b7891b-043d-45a1-9a77-f22d5a5c81c0)

상세  
![image](https://github.com/Kang-SeoHyun/auto_study/assets/77817094/678402fd-000a-417f-a9ed-25d57cd660e4)

## 화면 설계서
https://ovenapp.io/view/LbTnWD6iYdvRVjkvJUlhRVtd6wzwJq9d/

## 아키텍쳐 설계서

## ERD
![image](https://github.com/Kang-SeoHyun/auto_study/assets/77817094/e8a522c8-5c35-4214-9ea5-f7f520d500f3)  

* User
  * 사용자 정보 저장
  * IsLocked : 계정 잠김 정보 – bool 형
  * LoginAttempts : 로그인 시도 횟수
* ChatRoom
  * 채팅방 정보 저장 
* JoinRoom
  * 사용자와 채팅방 간의 관계 정보 저장
* Message
  * 메세지 정보 저장
  *  Timestamp : 작성 시간 저장
  * ImageURL : 사진 전송 이미지 URL

