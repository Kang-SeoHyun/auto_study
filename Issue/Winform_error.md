# winform 문제

1. home.cs에서 디자이너 보기 기능 사라짐,, 아이콘도 Program.cs처럼 C#으로 뜸 
	* ![image](https://github.com/Kang-SeoHyun/Kang-SeoHyun/assets/77817094/0e51ea70-aae5-4179-b4d3-2d80dd1ccdb9)
	* DB connect 코드를 넣고 싶었는데 'public partial class home : Form' 이놈보다 먼저 넣었더니 문제 생긴거였음! 뒤에 넣어주니 해결!
	* ``` cs 
		namespace tibero_test
		{
			// 여기에 썼더니 생긴 문제
			// public class LoginManager {}
    		public partial class home : Form {}
			public class LoginManager {}
		}
		```
2. 로그인 끝나고 데이터 베이스 연결한 거 끊으려고 아래 코드 넣었는데 아예 프로그램이 끝남.
	 ```cs
		protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            loginManager.Close_Db_Connect();
        }
	```
	* 찾아보니❗ base.OnClosed(e); 는 호출될 때 부모 클래스의 OnClosed 동작을 수행하고, 이는 폼이 닫힐 때 필요한 정리 작업 등을 수행하기 위한 것이다.
	* 반면❗ this.Close(); 메서드는 폼을 닫고 해당 폼의 종료 이벤트만 발생시킴. 그냥 단순히 사용자가 해당 폼을 더 이상 볼 수 없게 함.
	* ``` txt
		정리 : base.OnClosed(e)는 부모 클래스의 OnClosed 메서드를 호출하여 부모 클래스에서 정의한 폼 닫힘 동작을 수행하고, this.Close()는 현재 폼을 닫는 동작을 수행함.
	  ```