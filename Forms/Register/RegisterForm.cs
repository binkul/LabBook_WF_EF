using LabBook_WF_EF.EntityModels;
using LabBook_WF_EF.Forms.Login;
using LabBook_WF_EF.Security;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace LabBook_WF_EF.Forms.Register
{
    public partial class RegisterForm : Form
    {
        private readonly LoginForm _loginForm;
        private readonly LabBookContext _context;

        public RegisterForm(LoginForm loginForm, LabBookContext contex)
        {
            _loginForm = loginForm;
            _context = contex;
            InitializeComponent();
        }

        private void PanelBlack_Paint(object sender, PaintEventArgs e)
        {
            int radius = 60;

            Rectangle corner = new Rectangle(0, 0, radius, radius);
            GraphicsPath path = new GraphicsPath();
            path.AddLine(0, 0, 0, 0);
            corner.X = PanelBlack.Width - 2 - radius;
            path.AddArc(corner, 270, 90);
            corner.Y = PanelBlack.Height - 5 - radius;
            path.AddLine(PanelBlack.Width - 2, PanelBlack.Height - 5, radius, PanelBlack.Height - 5);
            corner.X = 0;
            path.AddArc(corner, 90, 90);
            path.CloseFigure();

            Color color = Color.FromArgb(255, 46, 49, 55);

            e.Graphics.FillPath(new SolidBrush(color), path);
            e.Graphics.DrawPath(new Pen(color), path);

            Pen linePen = new Pen(Color.White)
            {
                Width = 1
            };
            int y_pos = LblLoging.Top + LblLoging.Height + 5;
            int x_pos = TxtName.Left;
            e.Graphics.DrawLine(linePen, new Point(x_pos, y_pos), new Point(x_pos + TxtName.Width, y_pos));
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            if (CheckEmtpyFields() && CheckPasswordAndRepeat() && ExistUser())
            {
                User user = new User
                {
                    Name = TxtName.Text,
                    Surname = TxtSurname.Text,
                    EMail = TxtEmail.Text,
                    Login = TxtLogin.Text,
                    Password = Encrypt.MD5Encrypt(TxtPassword.Text),
                    Permission = "user",
                    Identifier = TxtName.Text.ToUpper().Substring(0, 1) + TxtSurname.Text.ToUpper().Substring(0, 1),
                    Active = false,
                    Date = DateTime.Today
                };

                _ = _context.Users.Add(user);
                _ = _context.SaveChanges();

                Close();
            }

        }

        private bool CheckEmtpyFields()
        {
            bool result = true;

            if (string.IsNullOrEmpty(TxtName.Text))
            {
                MessageBox.Show("Pole 'Imie' nie może byc puste. Podaj imie.", "Puste pole", MessageBoxButtons.OK, MessageBoxIcon.Error);
                result = false;
            }
            else if (string.IsNullOrEmpty(TxtSurname.Text))
            {
                MessageBox.Show("Pole 'Nazwisko' nie może byc puste. Podaj nazwisko.", "Puste pole", MessageBoxButtons.OK, MessageBoxIcon.Error);
                result = false;
            }
            else if (string.IsNullOrEmpty(TxtEmail.Text))
            {
                MessageBox.Show("Pole 'E-mail' nie może byc puste. Podaj email.", "Puste pole", MessageBoxButtons.OK, MessageBoxIcon.Error);
                result = false;
            }
            else if (string.IsNullOrEmpty(TxtLogin.Text))
            {
                MessageBox.Show("Pole 'Login' nie może byc puste. Podaj login.", "Puste pole", MessageBoxButtons.OK, MessageBoxIcon.Error);
                result = false;
            }
            else if (string.IsNullOrEmpty(TxtPassword.Text))
            {
                MessageBox.Show("Pole 'Hasło' nie może byc puste. Podaj hasło.", "Puste pole", MessageBoxButtons.OK, MessageBoxIcon.Error);
                result = false;
            }
            else if (string.IsNullOrEmpty(TxtRepeatPassword.Text))
            {
                MessageBox.Show("Pole 'Powtórz hasło' nie może byc puste. Powtórz hasło.", "Puste pole", MessageBoxButtons.OK, MessageBoxIcon.Error);
                result = false;
            }

            return result;
        }

        private bool CheckPasswordAndRepeat()
        {
            if (TxtPassword.Text != TxtRepeatPassword.Text)
            {
                MessageBox.Show("Pole 'Hasło' i pole 'Powtórz hasło' muszą być identyczne. Podaj jeszcze raz hasło i powtórz je.", "Błąd hasła", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
                return true;
        }

        private bool ExistUser()
        {
            bool log = _context.Users
                .Where(x => x.Login.Equals(TxtLogin))
                .Any();


            if (log)
            {
                MessageBox.Show("Użytkownik o loginie '" + TxtLogin.Text + "' istnieje już bazie. Zmień login.", "Zły login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
                return true;
        }

        private void RegisterForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _loginForm.Show();
        }
    }
}
