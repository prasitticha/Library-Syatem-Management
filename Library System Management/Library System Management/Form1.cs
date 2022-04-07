namespace Library_System_Management
{
    public partial class Form1 : Form
    {
        Form2 form2 = new Form2();

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string User = textBoxUser.Text;
            string Password = textBoxPassword.Text;
            /*
            if(textBoxUser.Text == "")
            {
                MessageBox.Show("Please enter your Username or ID");
            }
            */
            if(User == "123456" && Password == "654321")
            {
                form2.Show();
                this.Hide();

                string UserName = "Staff A";

                form2.UserPassword(UserName, User);
                //form2.getPassword(Password);
            }
            else if(User == "456789" && Password == "987654")
            {
                form2.Show();
                //this.Close();
                this.Hide();

                string UserName = "Staff B";

                form2.UserPassword(UserName, User);
            }
            else if(textBoxUser.Text == "" && textBoxPassword.Text == "")
            {
                MessageBox.Show("Please enter your Username or ID");
            }
            else if(textBoxUser.Text == "")
            {
                MessageBox.Show("Please enter your Username");
                textBoxPassword.Text = "";
            }
            else if (textBoxPassword.Text == "")
            {
                MessageBox.Show("Please enter your Password");
                textBoxUser.Text = "";
            }
            else
            {
                //MessageBox.Show("Please enter your Username or ID");
                MessageBox.Show("User & Password", "ERROR");
                textBoxUser.Text = "";
                textBoxPassword.Text = "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}