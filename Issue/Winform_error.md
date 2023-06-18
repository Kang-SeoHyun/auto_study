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