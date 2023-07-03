using System.Drawing;
using System.Windows.Forms;

namespace chatClient
{
    internal class Mouse
    {
        private bool isDragging;
        private Point lastMousePosition;
        private Form form;

        public Mouse(Form form)
        {
            this.form = form;
            this.form.MouseDown += Form_MouseDown;
            this.form.MouseMove += Form_MouseMove;
            this.form.MouseUp += Form_MouseUp;
        }
        private void Form_MouseDown(object sender, MouseEventArgs e)
        {
            // 왼쪽 마우스 버튼을 눌렀을 때 폼 이동 시작
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                lastMousePosition = e.Location;
            }
        }

        private void Form_MouseMove(object sender, MouseEventArgs e)
        {
            // 폼 이동 중일 때 마우스 위치에 따라 폼 이동
            if (isDragging)
            {
                int deltaX = e.Location.X - lastMousePosition.X;
                int deltaY = e.Location.Y - lastMousePosition.Y;
                form.Location = new Point(form.Location.X + deltaX, form.Location.Y + deltaY);
            }
        }

        private void Form_MouseUp(object sender, MouseEventArgs e)
        {
            // 왼쪽 마우스 버튼을 놓았을 때 폼 이동 종료
            if (e.Button == MouseButtons.Left)
            {
                isDragging = false;
            }
        }
    }
}
