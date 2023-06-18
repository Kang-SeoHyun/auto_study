using System;
using Tibero.DbAccess;
using System.Data.OleDb;

namespace LoginApp
{
    public class LoginManager
    {
        private OleDbConnection connection;

        public LoginManager()
        {
            // Tibero 데이터베이스 연결 문자열 설정
            string connectionString = "Provider=tbprov.Tbprov.6; Data Source=데이터베이스주소; User ID=사용자이름; Password=비밀번호;";

            // 데이터베이스 연결
            connection = new OleDbConnection(connectionString);
            connection.Open();
        }

        public bool AuthenticateUser(string username, string password)
        {
            // 로그인 정보 확인을 위한 쿼리 작성
            string query = "SELECT COUNT(*) FROM 회원정보테이블 WHERE 아이디 = @Username AND 비밀번호 = @Password";

            // 쿼리 실행을 위한 커맨드 객체 생성
            OleDbCommand command = new OleDbCommand(query, connection);
            command.Parameters.AddWithValue("@Username", username);
            command.Parameters.AddWithValue("@Password", password);

            // 쿼리 실행 결과 확인
            int count = (int)command.ExecuteScalar();

            // 결과가 1 이상인 경우 인증 성공
            return count > 0;
        }

        public void CloseConnection()
        {
            // 데이터베이스 연결 닫기
            connection.Close();
        }
    }

    public class LoginForm : Form
    {
        private LoginManager loginManager;
        private TextBox usernameTextBox;
        private TextBox passwordTextBox;
        private Button loginButton;

        public LoginForm()
        {
            loginManager = new LoginManager();

            // 로그인 폼 디자인 요소 초기화 코드

            // 로그인 버튼 클릭 이벤트 핸들러 등록
            loginButton.Click += LoginButton_Click;
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            string username = usernameTextBox.Text;
            string password = passwordTextBox.Text;

            // 사용자 인증 시도
            bool isAuthenticated = loginManager.AuthenticateUser(username, password);

            if (isAuthenticated)
            {
                MessageBox.Show("로그인 성공!");
                // 로그인 성공한 경우 다음 화면으로 이동하거나 작업 수행
            }
            else
            {
                MessageBox.Show("아이디 또는 비밀번호가 올바르지 않습니다.");
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            // 폼이 닫힐 때 데이터베이스 연결 종료
            loginManager.CloseConnection();
        }
    }
}
