﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_4
{
    public partial class Form1 : Form
    {
    //This initializes the data tables
        DataTable dtColleges = null;
        DataTable dtMajors = null;
        DataTable dtCourse = null, dtTerms = null;
        DataTable dtStudents = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Exits the application
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //On form load this will set the form height and width. Will also show the first screen and populate the data tables.
            this.Height = 640;
            this.Width = 670;
            showMainMenu();
            pnlStudent.BackColor = System.Drawing.SystemColors.Control;
            pnlGrades.BackColor = System.Drawing.SystemColors.Control;
            PopulateCollegeDropDown();
            PopulateCourseGradeTerm();
            PopulateStudentDropDown();

        }

        private void showMainMenu()
        {
            //Shows the main menu page and hides the other pages
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Visible = true;
            pnlStudent.Visible = false;
            pnlGrades.Visible = false;
        }

        private void showStudentMenu()
        {
            //Shows the Student Menu page and hides the other pages.
            pnlStudent.Dock = DockStyle.Fill;
            pnlStudent.Visible = true;
            pnlMain.Visible = false;
            pnlGrades.Visible = false;
        }

        private void showGradeMenu()
        {
            //Shows the grade menu page and hides the other pages
            pnlGrades.Dock = DockStyle.Fill;
            pnlGrades.Visible = true;
            pnlStudent.Visible = false;
            pnlMain.Visible = false;
        }

        private void mainMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Runs the main menu method
            showMainMenu();
        }

        private void studentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Runs the student menu method
            showStudentMenu();
            RefreshStudentDGV();
        }

        private void gradesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Runs the grade menu method
            showGradeMenu();
            PopulateStudentDropDown();
            RefreshGradeDGV();
        }

        private void PopulateCollegeDropDown()
        {
            //Calls upon the walton database to gather information and display a list of colleges offered at the school
            Walton_DB.FillDataTable_ViaSql(ref dtColleges, "SELECT CollegeID, College FROM tbl_Colleges order by College");
            
            foreach (DataRow dr in dtColleges.Rows)
            {
                cboCollege.Items.Add(dr["College"]);
            }
        }

        private void PopulateMajorDropDown()
        {
            //Calls upon the walton database to get a list of majors offered at the school
            cboMajor.Items.Clear();
            Walton_DB.FillDataTable_ViaSql(ref dtMajors, "SELECT MajorID, Major FROM tbl_Majors where CollegeID = " + dtColleges.Select("College = '" + cboCollege.Text + "'")[0]["CollegeID"].ToString());
            if (dtMajors != null && dtMajors.Rows.Count > 0)
            {
                foreach (DataRow dr in dtMajors.Rows)
                {
                    cboMajor.Items.Add(dr["Major"]);
                }
            }
        }

        private void cboCollege_SelectedIndexChanged(object sender, EventArgs e)
        {
            //If there are no majors selected, it will populate
            if (cboCollege.SelectedIndex != -1)
            {
                PopulateMajorDropDown();
            }
        }

        private void RefreshStudentDGV()
        {
            //Updates the grid with the student information
            DataTable dtStudents = null;
            Walton_DB.FillDataTable_ViaSql(ref dtStudents, "SELECT tbl_Students.StudentID, tbl_Students.StudentName, tbl_Colleges.College, tbl_Majors.Major FROM tbl_Students INNER JOIN tbl_Colleges ON tbl_Students.StudentCollege = tbl_Colleges.CollegeID INNER JOIN tbl_Majors ON tbl_Students.StudentMajor = tbl_Majors.MajorID");

            if(dtStudents != null && dtStudents.Rows.Count > 0)
            {
                dgbStudents.DataSource = dtStudents;
                dgbStudents.Refresh();
            }
        }

        private void PopulateStudentDropDown()
        {
            //Calls upon the walton database to populate the student table with student names
            Walton_DB.FillDataTable_ViaSql(ref dtStudents, "SELECT StudentID, StudentName FROM tbl_Students order by StudentName");
            if (dtStudents != null && dtStudents.Rows.Count > 0)
            {
                foreach (DataRow dr in dtStudents.Rows)
                {
                    cboStudent.Items.Add(dr["StudentName"]);
                }
            }
        }

        private void PopulateCourseGradeTerm()
        {
            //Adds the corresponding grade to the class
            cboGrade.Items.Add("A");
            cboGrade.Items.Add("B");
            cboGrade.Items.Add("C");
            cboGrade.Items.Add("D");
            cboGrade.Items.Add("F");
            Walton_DB.FillDataTable_ViaSql(ref dtCourse, "SELECT CourseID, Course FROM tbl_Courses order by Course");
            if(dtCourse != null && dtCourse.Rows.Count > 0)
            {
                foreach (DataRow dr in dtCourse.Rows)
                {
                    cboCourse.Items.Add(dr["Course"]);
                }
            }
            Walton_DB.FillDataTable_ViaSql(ref dtTerms, "SELECT TermID, Term FROM tbl_Terms order by Term");
            if (dtTerms != null && dtTerms.Rows.Count > 0)
            {
                foreach (DataRow dr in dtTerms.Rows)
                {
                    cboTerm.Items.Add(dr["Term"]);
                }
            }
        }

        private void RefreshGradeDGV()
        {
            //Refreshes and updates the grades
            DataTable dtStudents = null;
            Walton_DB.FillDataTable_ViaSql(ref dtStudents, "SELECT tbl_Students.StudentName, tbl_Courses.Course, tbl_Terms.Term, tbl_Grades.Grade FROM tbl_Grades INNER JOIN tbl_Students ON tbl_Grades.Student = tbl_Students.StudentID INNER JOIN tbl_Courses ON tbl_Grades.Course = tbl_Courses.CourseID INNER JOIN tbl_Terms ON tbl_Grades.Term = tbl_Terms.TermID");

            if (dtStudents != null && dtStudents.Rows.Count > 0)
            {
                dgbGrades.DataSource = dtStudents;
                dgbGrades.Refresh();
            }
        }

        private void btnAddGrade_Click(object sender, EventArgs e)
        {
            //Adds the grade to the class for that particular student
            if (cboStudent.SelectedIndex == -1)
            {
                MessageBox.Show("You must select a student.");
                return;
            }
            if(cboCourse.SelectedIndex == -1)
            {
                MessageBox.Show("You must select a course.");
                return;
            }
            if(cboGrade.SelectedIndex == -1)
            {
                MessageBox.Show("You must select a gradet.");
                return;
            }
            if(cboTerm.SelectedIndex == -1)
            {
                MessageBox.Show("You must select a term.");
                return;
            }
            
            string StudentID = dtStudents.Select("StudentName = '" + cboStudent.Text + "'")[0]["StudentID"].ToString();
            string CourseID = dtCourse.Select("Course = '" + cboCourse.Text + "'")[0]["CourseID"].ToString();
            string TermID = dtTerms.Select("Term = '" + cboTerm.Text + "'")[0]["TermID"].ToString(); ;
            if(Walton_DB.ExecSqlString("INSERT INTO tbl_Grades (Student, Course, Term, Grade) VALUES (" + StudentID.ToString() + "," + CourseID.ToString() + "," + TermID.ToString() + ",'" + cboGrade.Text + "')"))
            {
                MessageBox.Show("Student added!");
                PopulateStudentDropDown();
                RefreshGradeDGV();
            }
            else
            {
                MessageBox.Show("Database Error - please try again!");
            }

        }

        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            //Adds a student to the table
            if(txtName.Text == "")
            {
                MessageBox.Show("Please enter a name.");
                return;
            }

            if (cboCollege.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a college.");
                return;
            }

            if(cboMajor.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a major.");
                return;
            }
            string CollegeID = dtColleges.Select("College = '" + cboCollege.Text + "'")[0]["CollegeID"].ToString();
            string MajorID = dtMajors.Select("Major = '" + cboMajor.Text + "'")[0]["MajorID"].ToString();
            if (Walton_DB.ExecSqlString("INSERT INTO tbl_Students (StudentName, StudentCollege, StudentMajor) VALUES ('" 
                + txtName.Text.Trim() + "'," + CollegeID.ToString() + "," + MajorID.ToString() + ")"))
            {
                MessageBox.Show("Student " + txtName.Text + " was added to the database." +
                    System.Environment.NewLine + "College: " + cboCollege.Text + "(" + CollegeID + ")" +
                    System.Environment.NewLine + "Major: " + cboMajor.Text + "(" + MajorID + ")");
                txtName.Text = "";
                cboCollege.SelectedIndex = -1;
                cboMajor.SelectedIndex = -1;
                RefreshStudentDGV();
            }
            else
            {
                MessageBox.Show("Database Error - please try again!");
            }
        }
    }
}
