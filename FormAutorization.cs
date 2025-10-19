using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.model;

namespace WindowsFormsApp1
{
    public partial class FormAutorization : Form
    {
        public FormAutorization()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        public static Users Enter_User;
        private void button1_Click(object sender, EventArgs e)
        {
            Enter_User = null;
            Model1 model1 = new Model1();
            // поиск пользователя по логину и паролю
            Enter_User = model1.Users.FirstOrDefault(x => x.Login == textBox1.Text && x.Password == textBox2.Text);

            if (Enter_User != null)
            {
                switch (Enter_User.RoleID) // переход по формам в зависимости от роли
                {
                    case 1:
                        FormManager formManager = new FormManager();
                        formManager.ShowDialog();
                        break;
                    case 2:
                        FormSeller formSeller = new FormSeller();
                        formSeller.ShowDialog();
                        break;
                    case 3:
                        FormDirector formDirector = new FormDirector();
                        formDirector.ShowDialog();
                        break;
                    default:
                        throw new Exception("Роль не найдена!");
                }
            }
        }
    }
}