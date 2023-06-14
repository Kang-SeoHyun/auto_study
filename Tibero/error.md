## 티베로

### 1. 티베로 설치과정에서 문제 생김.
![image](https://github.com/Kang-SeoHyun/Kang-SeoHyun/assets/77817094/a0d60568-7481-4d00-82fc-075a3c66a5b8)  
![image](https://github.com/Kang-SeoHyun/Kang-SeoHyun/assets/77817094/38275de3-5fda-4780-9016-4fad20c63789)  

### 2. 근데 제어판에는 제대로 있음.  
![image](https://github.com/Kang-SeoHyun/Kang-SeoHyun/assets/77817094/e8dc193f-f74d-412d-b509-cb97258c54c1)  
![image](https://github.com/Kang-SeoHyun/Kang-SeoHyun/assets/77817094/57a99b86-dc71-4f38-b74f-76c04fe019de)  
> 어떻게 된 것인가..

## 티베로 스튜디오 
### 1. 설치과정 오류  
> 설치문제: 자바 환경변수 1.8로 설정 후 해결  
 
### 2. 티베로 스튜디오 연결안됨,,  
![image](https://github.com/Kang-SeoHyun/Kang-SeoHyun/assets/77817094/f3600940-d3a0-428c-b10b-08f0f15d8058)   
![image](https://github.com/Kang-SeoHyun/Kang-SeoHyun/assets/77817094/375bcd99-442e-4be5-9a1b-82f3bfdde54d)  
> 관리자도스창 들어가서 tbdown -> tbboot 실행한 뒤 하니까 해결!

### 3. 계속 나오던 오류  
![image](https://github.com/Kang-SeoHyun/Kang-SeoHyun/assets/77817094/b796a50e-1e04-435a-a6f8-2dc161f354a4)  
![image](https://github.com/Kang-SeoHyun/Kang-SeoHyun/assets/77817094/c1891133-ec20-4e25-806e-d3a0c2578e9b)  
> 음,, 분명 안되었는데 갑자기 해결..
> > 바뀐것은 저 티베로 설치과정에서 문제생김 저것을 하였다는 것 정도..?

### 4. 설치문서에 있는 것처럼 데이터베이스 생성하려 하였으나 실패  
![image](https://github.com/Kang-SeoHyun/Kang-SeoHyun/assets/77817094/ab0ba12d-e0d9-47a8-a4c2-382c319053ec)  

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