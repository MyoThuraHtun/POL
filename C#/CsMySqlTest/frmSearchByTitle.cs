﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp5
{
    public partial class frmSearchByTitle : Form
    {
        public frmSearchByTitle()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            String txt = txtPhone.Text.ToString();
            funSearchByTitle(txt, title_selected);
        }
        MySqlDataAdapter adapter2;
        public void funSearchByTitle(String txt, int title)
        {
           
            try
            {
                MySqlConnection con = new MySqlConnection("datasource=localhost;port=3306;username=root");
              // = new MySqlDataAdapter("Select * from student.student_tb where student_phone like '" + txt + "'", con);
                switch (title)
                {
                    case 0: adapter2 = new MySqlDataAdapter("Select * from student.student_tb where student_id like " + txt , con); 
                            break;
                    case 1: adapter2 = new MySqlDataAdapter("Select * from student.student_tb where student_name like '" + txt + "'", con); 
                            break;
                    case 2: adapter2 = new MySqlDataAdapter("Select * from student.student_tb where student_phone like '" + txt + "'", con);
                            break;
                    case 3: adapter2 = new MySqlDataAdapter("Select * from student.student_tb where student_address like '" + txt + "'", con);
                            break;
                    case 4: adapter2 = new MySqlDataAdapter("Select * from student.student_tb where student_gmail like '" + txt + "'", con);
                            break;
                    case 5: adapter2 = new MySqlDataAdapter("Select * from student.student_tb where course like '" + txt + "'", con);
                            break;

                }
               

                con.Open();
                DataSet ds = new DataSet();
                adapter2.Fill(ds, "student_tb");
                dataGridView1.DataSource = ds.Tables[0]; //ds.Tables["user_tb"]; 
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        int title_selected = 0;
      

        private void cboTitle_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            switch (cboTitle.SelectedIndex)
            {
                case 0: title_selected = 0; lblTitle.Text = "Student ID"; break;
                case 1: title_selected = 1; lblTitle.Text = "Student Name"; break;
                case 2: title_selected = 2; lblTitle.Text = "Student Phone"; break;
                case 3: title_selected = 3; lblTitle.Text = "Student Address"; break;
                case 4: title_selected = 4; lblTitle.Text = "Student Gmail"; break;
                case 5: title_selected = 5; lblTitle.Text = "Course"; break;

            }
        }
    }
}
