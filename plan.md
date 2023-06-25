# 설계

## WBS
요약  
![image](https://github.com/Kang-SeoHyun/auto_study/assets/77817094/52b7891b-043d-45a1-9a77-f22d5a5c81c0)

상세  
![image](https://github.com/Kang-SeoHyun/auto_study/assets/77817094/8e458eda-c272-4785-962e-bf96f1908bc2)

## 화면 설계서
https://ovenapp.io/view/LbTnWD6iYdvRVjkvJUlhRVtd6wzwJq9d/

## 아키텍쳐 설계서
![image](https://github.com/Kang-SeoHyun/auto_study/assets/77817094/24740a91-6574-4193-93d3-8511f4cb8319)

## ERD
![image](https://github.com/Kang-SeoHyun/auto_study/assets/77817094/a5aaf6bc-56dd-44bd-8ab3-617b7274a880)  


* MEMBERS
  * 사용자 정보 저장
  * IsLocked : 계정 잠김 정보
  * LoginAttempts : 로그인 시도 횟수
* ChatRoom
  * 채팅방 정보 저장 
* JoinRoom
  * 사용자와 채팅방 간의 관계 정보 저장
* Message
  * 메세지 정보 저장
  * IsDeleted : 메세지 삭제 정보

