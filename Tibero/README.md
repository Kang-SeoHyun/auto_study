# 🦎 Tibero 🦎

## 정보
1. 티맥스 소프트에서 개발한 한국산 DB.
2. 오라클과 거의 동일한 호환성을 제공.
	* 실제 오라클을 참고해서 만든 DB임.
	* 오라클 대안으로도 주장되고 있음.
3. 오라클의 절반 가격으로 운영됨.
4. 한국 기업이라면 직접 유지보수도 가능한 장점있음.

## 주요 기능
대용량 데이터를 관리, 안정적 비지니스 연속성 보장
* 분산 데이터베이스 링크
* 데이터 이중화
* 데이터베이스 클러스터
* 병렬 쿼리 처리
* 쿼리 최적화기

## 지원하는 언어
* 절차지향
	* C
* 객체지향
	* C#, Objective-C, Java, Cobol
* 다목적 (절차지향 + 객체지향)
	* C++
* 인터프리터
	* Python, Ruby, Perl, PHP
* 프로시저 기반의 이벤트 기반 프로그래밍 언어
	* Visual Basic

## dll 파일이란?
* Dynamic Linked Library - DLL
* 말그대로 동적 연결 라이브러리
* 정적라이브러리는 컴파일 시점에 main코드와 결합된다하면 얘는 dll파일이 필요할 때 호출한다.
	* 함수의 위치만 갖고있다가 필요시에 호출함.
	* 따라서 실행파일 크기를 줄일 수 있는 장점이 있다.
	* dll파일로 티베로 DB 연결이 가능함!  


#  🦎 Tibero 아키텍쳐 🦎
## Process
티베로 프로세스 특징
1. 서버는 인스턴스와 데이터베이스로 구성됨.  
2. 클라이언트 어플리케이션은 티베로 인터페이스 라이브러리를 이용하여 인스턴스에 접속하고 데이터베이스를 사용하게 됩니다.
3. ps명령어 이용하여 프로세스를 확인할 수 있습니다.
4. 리스너, 워커프로세스, 백그라운드 프로세스 크게 세개로 나눌 수 있다.

워커 프로세스 : tbsvr_wp000 이런 놈  
* 조회가능 명령어 : ps -ef | awk '{if ($8-/tbsvr_wp/ && $8!="awk) print $0}'  
* 클라이언트와 실제로 통신하며 사용자의 SQL요구사항을 처리하는 프로세스임
* 프로세스 갯수는 초기화 파라미터로 조절가능
	* 일단 티베로가 기동된 뒤에는 재기동을 해야만 변경가능.
	* 따라서 시스템환경을 고려하여 적절한 값을 설정해야함.
* 티베로는 효율적인 리소스 관리를 위해 쓰레드 기반으로 작업을 수행.
	* 초기화 파라미터, 맥스세션카운트에서 설정된 갯수만큼 워커쓰레드를 구동함.
	* 맥스 세션카운트 파라미터값은 %TB_HOME%\config\%TB_SID%.tip 파일을 통해 확인가능.
		* 조회가능 명령어 : grep MAX_SESSION_COUNT %TB_HOME%\config\%TB_SID%.tip
		* 그 갯수만큼의 워커쓰레드가 구동됨.
* 워커쓰레드는 클라이언트와 1대 1 통신하며 클라이언트가 주는 sql문을 받습니다.

리스터 프로세스 : 클라이언트의 새로운 접속요청을 받아 이를 워커프로세스에 할당하는 역할
백그라운드 프로세스 : 클라이언트의 작업요청을 받지않고 워크쓰레드나 다른 백그라운드 프로세스의 요청 혹은 정해진 주기에 따라 동작함

## memory
## Database
데이터 파일, 로그파일, 컨트롤파일로 구성 됨.
* 컨트롤 파일 : 데이터베이스의 정보를 저장하고 있음.

## Interface
티베로 데이터베이스를 이용하기 위한 인터페이스

## OLEDB VS ODBC
OLEDB와 ODBC는 모두 데이터베이스에 접속하기 위한 API(응용 프로그램 프로그래밍 인터페이스)임  
그러나 두 API 간에는 몇 가지 중요한 차이점이 있음.  
### 아키텍처
1. OLEDB (Object Linking and Embedding for Databases)
	* OLEDB는 Microsoft가 개발한 데이터 액세스 컴포넌트이며, COM(Component Object Model) 아키텍처를 기반으로 합니다.
	* 객체지향적이고 성능이 우수하며, 다양한 데이터 소스에 접속할 수 있는 유연성을 제공합니다.
2. ODBC (Open Database Connectivity)
	* ODBC는 Microsoft가 개발한 데이터 액세스 API입니다.
	* ODBC는 C 언어를 기반으로 하며, 공통 인터페이스를 통해 다양한 데이터 소스에 접속할 수 있도록 설계되었습니다.

### 지원 데이터 소스
1. OLEDB
	* OLEDB는 다양한 데이터 소스에 접속할 수 있는 범용 데이터 액세스 API입니다.
	* OLEDB는 관계형 데이터베이스, 파일 기반 데이터, 전자 메일, 엑셀 등 다양한 데이터 소스 유형을 지원합니다.
2. ODBC
	* ODBC는 주로 관계형 데이터베이스에 대한 액세스를 위해 설계되었습니다.
	* ODBC는 주로 SQL 기반의 데이터베이스에 접속하는 데 사용됩니다.

### 드라이버
1. OLEDB
	* OLEDB 드라이버는 개별 데이터 소스에 따라 제조업체가 제공합니다. 
	* 각 데이터베이스 제조업체는 OLEDB에 대한 고유한 드라이버를 제공합니다.
2. ODBC
	* ODBC 드라이버도 각 데이터베이스 제조업체에서 제공됩니다.
	* ODBC 드라이버는 데이터베이스 제조업체의 표준 인터페이스를 따르며, 애플리케이션이 데이터베이스에 독립적으로 액세스할 수 있도록 합니다.

## Tibero OLE DB 연동
> OLE DB를 사용하는 인터페이스에 대하여 연동하는 방법을 설명한다. 해당 인터페이스를 사용하는 서버에 미리 Tibero OLE DB가 설치되어야 한다.

## ADO(ActiveX Data Objects)
> Microsoft사에서 개발한 데이터베이스 연동용 인터페이스로 ADO 컴포넌트를 사용해 데이터페이스에 접근 후 여러 작업을 할 수 있다.  
> > 첨부 문서(OLE DB 사용자가이드) 47page 참고!
* 데이터베이스에 접근하기 위한 COM 객체들의 모음이다.
* 사용자의 프로그래밍 언어와 OLE DB사이를 연결하는 계층이다.
* Windows 운영체제를 설치할 때 자동으로 설치된다.
* ASP, PHP, VB 등의 환경에서 사용 가능하다.
* 사용자가 복잡한 OLE DB API 대신 ADO의 단순화된 API로 용이하게 개발이 가능하다.
* 각종 Script 언어와 연동되어 있으므로 다양한 환경에서의 개발이 가능하다.

# 티베로 드라이버 설치 참고 자료
1. https://technet.tmaxsoft.com/upload/download/online/tibero/pver-20160406-000002/tibero_cli/chapter_tbcli_odbc.html
	* 공식문서
2. https://plzhoney.tistory.com/35
```txt
사용자 DSN
c:window\SysWOW64\odbcad32 실행하면 확인가능
내가 추가한 DNS는 
위치 : 127.0.0.1
사용자 : sys
암호 : 6615
포트 : 8629
DB이름 : tibero
이렇게 함~! (사진 참고)
```
![image](https://github.com/Kang-SeoHyun/Kang-SeoHyun/assets/77817094/c246c5c7-fac3-4ff5-aaa9-293c1fb5a9ca)

## 드라이버 간략 설명
```
내 티베로 드라이버는 C:\Database\Tibero 에 해뒀음
글고 %TB_HOME%\bin 에서 regsvr32 tbprov6.dll 하면 dll 등록되드라
이미 등록은 했음
```

## 티베로 DB 64bit 설치 후  ODBC 64bit 설치 절차
> 아마도,,

1. 티베로 64bit Server 설치
2. ODBC 드라이브 설치
	* tbodbc_driver_installer_6_64.exe -i C:\Windows\SysWOW64
	* tbodbc_driver_installer_5_64.exe -i C:\Windows\system32
3. 레지스트리 등록 C:\Windows\SysWOW64
	* regsvr32 msdtb6.dll
	* regsvr32 tbprov6.dll

## 티베로 데이터 참조 안될때!
> 장하다 강서현~!
```
https://yaraba.tistory.com/346  
이 사람 따라서 침착하게 했는데 안되었어 근데 conn.Open() 이부분이 안되는겨
그래서 보니까 드라이버를 제대로 참조 못하는거같은거야
그래서 프로젝트에서 오른쪽 마우스 눌러서 속성에서 빌드에서
플랫폼대상을 any cpu였나 여기에서 나는 64비트로 다운받아줬으니까 X64로 변경했돠 꺄갹 그랫더니 됨! 
```