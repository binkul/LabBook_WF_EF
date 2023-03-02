using LabBook_WF_EF.Dto;
using LabBook_WF_EF.EntityModels;
using LabBook_WF_EF.Forms.Register;
using LabBook_WF_EF.Security;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace LabBook_WF_EF.Forms.Login
{
    public partial class LoginForm : Form
    {
        private readonly string _loginPath = @"\Data\login.txt";
        private LabBookContext _contex = new LabBookContext();
        private List<string> _logins;
        public UserDto UserDto;


        public LoginForm()
        {
            InitializeComponent();
        }

        private void PanelBlack_Paint(object sender, PaintEventArgs e)
        {
            int radius = 60;

            Rectangle corner = new Rectangle(0, 0, radius, radius);
            GraphicsPath path = new GraphicsPath();
            path.AddLine(0, 0, 0, 0); // path.AddArc(corner, 180, 90);
            corner.X = PanelBlack.Width - 2 - radius;
            path.AddArc(corner, 270, 90);
            corner.Y = PanelBlack.Height - 5 - radius;
            path.AddLine(PanelBlack.Width - 2, PanelBlack.Height - 5, radius, PanelBlack.Height - 5); // path.AddArc(corner, 0, 90);
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
            int x_pos = TxtPassword.Left;
            e.Graphics.DrawLine(linePen, new Point(x_pos, y_pos), new Point(x_pos + TxtPassword.Width, y_pos));

            y_pos = BtnSubmit.Top + BtnSubmit.Height + 20;
            e.Graphics.DrawLine(linePen, new Point(x_pos, y_pos), new Point(x_pos + TxtPassword.Width, y_pos));
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            _logins = GetLogins();
            CmbLogin.DataSource = _logins;
        }

        private List<string> GetLogins()
        {
            List<string> logins = new List<string>();
            if (File.Exists(Environment.CurrentDirectory + _loginPath))
            {
                StreamReader file = new StreamReader(Environment.CurrentDirectory + _loginPath);
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    logins.Add(line);
                }
                file.Close();
            }
            return logins;
        }

        private void SaveLogins()
        {
            string login = CmbLogin.Text;
            string file = Environment.CurrentDirectory + _loginPath;

            _logins.Sort();
            _logins.Remove(login);
            if (!_logins.Contains(login))
            {
                _logins.Insert(0, login);
            }

            if (!Directory.Exists(Path.GetDirectoryName(file)))
                Directory.CreateDirectory(Path.GetDirectoryName(file));

            File.WriteAllLines(Environment.CurrentDirectory + _loginPath, _logins);
        }

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(CmbLogin.Text) || string.IsNullOrEmpty(TxtPassword.Text))
            {
                MessageBox.Show("Pole 'Login' i 'Hasło' nie mogą byc puste.", "Błąd logowania", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string password = Encrypt.MD5Encrypt(TxtPassword.Text);
            List<UserDto> user = _contex.Users
                       .Where(c => c.Login.Equals(CmbLogin.Text))
                       .Where(c => c.Password.Equals(password))
                       .Select(c => new UserDto(c.Id, c.Login, c.Permission, c.Identifier, (bool)c.Active))
                       .ToList();

            if (user.Count() == 0)
            {
                _ = MessageBox.Show("Nieprawidłowy login lub hasło. Spróbuj ponownie",
                    "Błąd logowania", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (user[0].Active)
            {
                UserDto = user.First();

//                QualityForm qualityForm = new QualityForm(user);
//                this.Hide();
//                qualityForm.Show();
            }
            else
            {
                _ = MessageBox.Show("Użytkownik: '" + CmbLogin.Text + "' jest jeszcze nieaktywny. Skontaktuj się z administratorem.",
                    "Brak uprawnień", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


            SaveLogins();
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            using (RegisterForm register = new RegisterForm(this, _contex))
            {
                this.Hide();
                register.ShowDialog();
            }
        }
    }
}
