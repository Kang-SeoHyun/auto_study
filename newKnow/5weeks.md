# 5주차

1. Exception은 모든 예외의 기본 클래스이므로, 어떤 종류의 예외가 발생하더라도 catch (Exception ex) 블록에서 해당 예외를 처리할 수 있다.
2. 구체적인 예외 클래스(예: SocketException, InvalidOperationException 등)에 대한 catch 블록을 추가하여 각각의 예외 유형에 맞는 예외 처리 로직을 구현하는 것이 좋음.
	* SocketException은 소켓 통신과 관련된 예외
	* InvalidOperationException은 메서드나 객체의 상태에 대한 잘못된 조작을 나타내는 예외
3. sql문 리마인드
	``` sql
	SELECT c.RoomName, m.Content AS LastMessage, m.UserName AS CreatorName
	FROM CHATROOM c
	JOIN MEMBERS m ON m.UserId = c.RegId
	-- MESSAGE 테이블을 이용하여 각 방별로 가장 최근의 대화의 시간을 가져옵니다.
	LEFT JOIN (
    SELECT RoomName, MAX(RegTime) AS MaxRegTime
    FROM MESSAGE
    GROUP BY RoomName
	) m1 ON c.RoomName = m1.RoomName
	-- MESSAGE 테이블과 조인하여 해당 방의 최근 대화 내용을 가져옵니다.
	LEFT JOIN MESSAGE m ON m.RoomName = m1.RoomName AND m.RegTime = m1.MaxRegTime
	-- 입력한 유저가 속한 팀원이 생성한 방들만 선택합니다.
	WHERE c.RegId IN (
	    SELECT UserId
    	FROM MEMBERS
    	WHERE TeamName = (
        	SELECT TeamName
        	FROM MEMBERS
        	WHERE UserId = ?
    	)
	)
	-- 그룹화하여 중복 방 이름을 제거하고, 대화 내용과 생성자 이름을 가져옵니다.
	GROUP BY c.RoomName, m.Content, m.UserName
	-- 최근 대화 시간을 기준으로 내림차순으로 정렬합니다.
	ORDER BY c.RegTime DESC;
	```
4. 티베로는 동시 접속자 수에 제한을 둔다. 따라서 동시 접속자 수가 초과되면 추가 접속 시도가 거부되는 듯..
	* 5개 예상됨.
	* 라이센스 제약사항, 하드웨어 성능 및 용량을 고려해서 수행했어야함.
5. 서버만 데이터베이스 접근 가능해야 한다는 것을 배움..
6. 딕셔너리는 중복키를 저장하지않는다.
7. thread를 사용하지 않으면 한순간 하나의 클라이언트에게만 서비스를 제공할 수 있다.