# Tibero 설치 후 

### 1. 설치문서에 있는 것처럼 테스트 데이터베이스를 생성하려 하였으나 실패하였습니다. 
주어진 SQL문 :
```sql
create database "tibero"
user sys identified by tibero
maxinstances 8
maxdatafiles 100
character set MSWIN949
logfile group 1 'log001.log'
size 100M,
group 2 'log002.log'
size 100M,
group 3 'log003.log'
size 100M
maxloggroups 255
maxlogmembers 8
noarchivelog
datafile 'system001.dtf'
size 100M
autoextend on next 100M
maxsize unlimited
default temporary tablespace TEMP
tempfile 'temp001.dtf'
size 100M
autoextend on next 100M
maxsize unlimited
extent management local autoallocate
undo tablespace UNDO
datafile 'undo001.dtf'
size 100M
autoextend on next 100M
maxsize unlimited
extent management local autoallocate;
```
**2번째 줄 : user sys identified by "6615" 했을 경우**
-> "6615" : 설정해둔 password  
![image](https://github.com/Kang-SeoHyun/Kang-SeoHyun/assets/77817094/29073af8-fac9-4915-9936-e3955afcad42)   

**2번째 줄 : 그대로 user sys identified by tibero 한 경우**  
![image](https://github.com/Kang-SeoHyun/Kang-SeoHyun/assets/77817094/ab0ba12d-e0d9-47a8-a4c2-382c319053ec)  
 

### 2. 참조하던 블로그를 따라 windows 서비스로 등록하는 과정에서 "CreateService failed" 문제가 발생하였습니다.
![image](https://github.com/Kang-SeoHyun/Kang-SeoHyun/assets/77817094/a0d60568-7481-4d00-82fc-075a3c66a5b8)  
![image](https://github.com/Kang-SeoHyun/Kang-SeoHyun/assets/77817094/38275de3-5fda-4780-9016-4fad20c63789)  

### 하지만 [제어판->관리도구->서비스] 에 제대로 있는 것으로 확인이 되었습니다.  
![image](https://github.com/Kang-SeoHyun/Kang-SeoHyun/assets/77817094/e8dc193f-f74d-412d-b509-cb97258c54c1)  
![image](https://github.com/Kang-SeoHyun/Kang-SeoHyun/assets/77817094/57a99b86-dc71-4f38-b74f-76c04fe019de)   
## ❓이후 이 부분에서 문제가 발생할 경우가 있을까요..?


# Tibero Studio 연결 에러  
### 90401은 관리자cmd 들어가서 [tbdown -> tbboot] 재실행 후 해결하였으나
![image](https://github.com/Kang-SeoHyun/Kang-SeoHyun/assets/77817094/f3600940-d3a0-428c-b10b-08f0f15d8058)   
![image](https://github.com/Kang-SeoHyun/Kang-SeoHyun/assets/77817094/375bcd99-442e-4be5-9a1b-82f3bfdde54d)  

### 12020 오류가 계속 나왔습니다.  
![image](https://github.com/Kang-SeoHyun/Kang-SeoHyun/assets/77817094/b796a50e-1e04-435a-a6f8-2dc161f354a4)   

### 하지만 계속해서 메세지가 뜨다가 [윈도우 서비스 등록 시도] 이후 갑자기 해결되었습니다..  
![image](https://github.com/Kang-SeoHyun/Kang-SeoHyun/assets/77817094/c1891133-ec20-4e25-806e-d3a0c2578e9b) 

## ❓서비스 등록 부분에서도 조금 문제가 있었어서 제대로 해결이 된 것인지 모르겠습니다.

### 또한 티베로 스튜디오에서의 [Unable to execute SQL statement]문제는 해결되었지만 여전히 CLI환경에서는 문제가 있습니다.  
![image](https://github.com/Kang-SeoHyun/Kang-SeoHyun/assets/77817094/f85bf49c-c693-4808-9ffd-91e2ee32c8ae)

## 티베로 데이터 참조 안될때!
https://yaraba.tistory.com/346  
이 사람 따라서 침착하게 했는데 안됨. -> conn.Open() 이 부분  
* 보니까 드라이버를 제대로 참조 못하는 것 같음.
```
해결 방법 : 프로젝트에서 오른쪽 마우스 눌러서 속성에서 빌드에서
플랫폼 대상을 any cpu였나 여기에서 나는 64비트로 다운받아줬으니까 X64로 변경함.
꺄악 그랫더니 됨! 
```