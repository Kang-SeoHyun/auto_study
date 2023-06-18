# 1주차

1. MS-Dos는 마이크로 소프트에서 만든 운영체제
2. 이를 기반으로 Windows가 만들어졌다.
3. 그래서 cmd파일을 열면 실행되는 명령프롬프트(CLI)를 도스창이라고도 한다.
	* UNIX 운영체제의 커멘드창은 터미널인거 알쥬~
4.  cmd.ExcuteSccalar는 리턴값이 object형식이라 (int) 로 캐스팅 안됨!
5. 티베로에서 컬럼명은 대소문자까지 똑같이 써줘야함! (아마도,, 안맞춰줬더니 오류남ㅜ)
	* ```sql
		SELECT 컬럼1, 컬럼2, ... FROM 테이블명 WHERE 조건; 
		```
6. 티베로스튜디오 사용할때는 조건에 값부분 ''로 감싸주기
	* ```sql
		SELECT COUNT(*) FROM MEMBERS WHERE USERID = 'kangsii';
		```
7. OleDbCommand.ExecuteNonQuery() 메서드는 주로 INSERT, UPDATE, DELETE 문과 같은 작업에 사용됨.
	* (int)로 캐스팅 됨.
8. SELECT 문을 실행할 때는 ExecuteScalar() 또는 ExecuteReader() 메서드를 사용해야 함.
	* 4번에서 말했듯 
	```cs
		int count = Convert.ToInt32(cmd.ExecuteScalar());
	``` 
	이렇게 해줘야 함
9. C#에서 반환되는 값의 형식을 확인하는 방법
	* ```cs
		object result = cmd.ExecuteScalar();
		Type resultType = result.GetType();
		Console.WriteLine(resultType)
		```
10. Application.Exit(); // 프로그램 종료 코드
11. 데이터베이스 다 설계해야 코드 짤 수 있다..