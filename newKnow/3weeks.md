# 3주차

1. 2개의 컴퓨터에서 데이터를 주고받을때 가장 자주 사용되는 방식이 소켓을 이용한 방식
2. C#도 소켓을 사용하기 위한 간편한 라이브러리를 제공함.
3. 서버 = 계속 켜져있는 컴퓨터
	* 켜진채로 클라이언트 접속 대기(Listen)
	* 클라이언트는 필요할 때 서버로 Connect 신호보내면 서버에서 Accept 
4. 소켓 서버 알기쉽게!
	```
	🥽c기준으로 - #include <sys/socket.h> 🥽
	소켓은 전화기다. 일단 전화기를 사야지? 소켓을 생성한다! - int socket() - fd, -1
	전화하려면 번호가 있어야지? 생성한 소켓에 Ip주소와 포트번호를 부여한다! - int bind() - 0, -1
	이제 전화기를 케이블에 연결시켜야겠지? 소켓을 연결요청이 가능한 상태가 되게 한다! - int listen() - 0, -1
	전화가 오면 수화기를 들 줄 알아야지? 소켓이 연결요청을 수락하게 해야함! - int accept() - fd, -1
	```
5. 소켓 클라이언트 알기쉽게!
	```
	🥽c기준으로 - #include <sys/socket.h> 🥽
	소켓은 전화기다. 일단 전화기를 사야지? 소켓을 생성한다! - int socket() - fd, -1
	전화기, 케이블 연결 다 되었으면 전화를 걸 줄 알아야겠지? 소켓 연결 요청 - int connect() - 0, -1
	```
6. TCP 전송특성 때문에 전송크기가 클 때 오류가 발생할 수 있다는 점 고려하기
	* 클라이언트에서 엄청 큰 데이터를 보내면 시간이 오래 걸릴텐데 서버는 언제까지고 기다릴 수 없다.
7. 에코 클라이언트의 해결책
	* 사이즈 정해서 read 여러번 반복하기.
8. 서버와 클라이언트의 구현과정에서 만들어지는 약속을 어플리케이션 프로토콜이라고 한다.
9. Tcp에는 슬라이딩 윈도우라는 프로토콜이 존재한다.
	* 소켓끼리 소통하면서 데이터를 송수신하기 때문에 버퍼가 넘쳐서 데이터가 소멸되는 일이 Tcp에서는 일어나지 않는다.
10. Tcp 소켓의 연결 설정 과정 - Three-way handshaking
	```
	TCP 소켓은 총 세번의 대화를 주고 받는다.
	A 악수1 : 야 소켓B 나 데이터보내야되니까 연결하자 - [SYN] SEQ(동기화메시지): 1000, ACK(응답메시지): -
		* 처음 연결요청에 사용되는 메세지 - 동기화 메세지
	B 악수2 : 오키 나 준비됐어 언제든 보내 - [SYN+ACK] SEQ: 2000, ACK: 1001
		* 데이터 전송을 위한 2000동기화 메세지와 1000번을 잘받았다는 응답으로 1001메세지
	A 악수3 : 요청들어줘서 감사링 - [ACK] SEQ: 1001, ACK: 2001
		* 앞서 보낸 패킷의 동기화메세지가 1000이었으니 1001번 동기화 메세지보내고 2000번 잘 받았다는 응답으로 2001번 메세지줘!
	```
	* 이렇듯 송수신에 사용되는 패킷에 번호를 부여하고 상대방에게 알림으로써 데이터의 손실을 막는다.
11. TCP 소켓의 연결 종료 과정 - Four-way handshaking
	```
	Tcp에서 연결을 뚝 끊어버리면 상대방이 전송할 데이터가 남아있을 때 문제가 된다.
	A 악수1 : 연결 끊자 이제 - [FIN] SEQ: 5000, ACK: -
	B 악수2 : 아그래? 잠시만! - [ACK] SEQ: 7500, ACK: 5001
	B 악수3 : hey 나 마무리 했당. 이제 끊자 - [FIN] SEQ: 7501, ACK: 5001
	A 악수4 : 오키오키 즐거웠다~ - [ACK] SEQ: 5001, ACK: 7502
	```
	* TCP 흐름제어에 대한 더 자세한 건 열혈 TCP/IP 프로그래밍 책 136쪽부터 읽어보기!
12. .NET 에서는 포그라운드 스레드와 백그라운드 스레드로 스레드를 구분함.
13. Foreground Threads
	* 메인 애플리케이션 스레드와 동일한 우선순위
	* 포그라운드 스레드가 실행 중일 때는 애플리케이션이 종료되지 않는다. 
14. Background Threads
	* 백그라운드 스레드는 메인스레드의 종료와 독립적으로 실행
	* 메인 애플리케이션 스레드가 종료되면 백그라운드 스레드는 실행 중이더라도 애플리케이션이 자동으로 종료됨.
	* 즉, 메인 애플리케이션 스레드가 종료될 때 해당 백그라운드 스레드도 함께 종료되도록 함.

15. this.listView1.FullRowSelect = true;
	* 이거 해야지 listview 클릭할 수 있음.