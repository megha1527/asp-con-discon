using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace demo
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridView1.SelectedRow;
            txtName.Text = row.Cells[2].Text;
            liClass.SelectedValue = row.Cells[3].Text;
            txtEmail.Text = row.Cells[4].Text;
            string gen = row.Cells[6].Text;
            if (gen == male.Text)
                male.Checked = true;
            else if (gen == female.Text)
                female.Checked = true;
            string[] hobAr = row.Cells[7].Text.Split(',');
            foreach (string ar in hobAr)
            {
                if (ar.Trim() == ho1.Text)
                    ho1.Checked = true;
                if (ar.Trim() == ho2.Text)
                    ho2.Checked = true;
                if (ar.Trim() == ho3.Text)
                    ho3.Checked = true;
            }
        }

        protected void subBtn_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["apnacon"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            string gen = "";
            if (male.Checked)
                gen = "Male";
            else if (female.Checked)
                gen = "Female";
            string hob = "";
            if (ho1.Checked)
                hob = "Music";
            if (ho2.Checked)
                hob += ",Sleeping";
            if (ho3.Checked)
                hob += ",Coding";
            /***************** FOR CONNECTED ENVIRONMENT **************************
             * *
             *
             * 
             */
            //cmd.CommandText = "insert into student (Name,Class,Email,Pass,Gender,Hobbies) values ('" + txtName.Text +
            //                  "','" + liClass.SelectedValue + "','" + txtEmail.Text + "','" + txtPass.Text + "','" +
            //                  gen + "','" + hob + "')";
            //cmd.CommandType = CommandType.Text;
            //cmd.Connection = con;
            //cmd.ExecuteNonQuery();
            /***********************
             *
             ***************************FOR DISCONNECTED ENVIRONMENT**************************
             *
             */
            SqlDataAdapter da = new SqlDataAdapter("Select * from student",con);
            DataSet ds = new DataSet();
            da.Fill(ds, "student");
            DataRow dr = ds.Tables[0].NewRow();
            dr["Name"] = txtName.Text;
            dr["Class"] = liClass.SelectedValue;
            dr["Email"] = txtEmail.Text;
            dr["Pass"] = txtPass.Text;
            dr["Gender"] = gen;
            dr["Hobbies"] = hob;
            ds.Tables[0].Rows.Add(dr);
            SqlCommandBuilder scm = new SqlCommandBuilder(da);
            da.InsertCommand = scm.GetInsertCommand();
            da.Update(ds,"student");
            GridView1.DataBind();
            con.Close();
            clearAll();

        }

        
        protected void clrBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebForm1.aspx");
        }

        protected void updBtn_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["apnacon"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            string gen = "";
            if (male.Checked)
                gen = "Male";
            else if (female.Checked)
                gen = "Female";
            string hob = "";
            if (ho1.Checked)
                hob = "Music";
            if (ho2.Checked)
                hob += ",Sleeping";
            if (ho3.Checked)
                hob += ",Coding";
            /***************** FOR CONNECTED ENVIRONMENT **************************
             * *
             *
             * 
             */


            //cmd.CommandText = "update student set Name='" + txtName.Text +
            //                  "',Class='" + liClass.SelectedValue + "',Email='" + txtEmail.Text + "',Pass='" +
            //                  txtPass.Text + "',Gender='" +
            //                  gen + "',Hobbies='" + hob + "' where Id = "+GridView1.SelectedRow.Cells[1].Text ;
            ////cmd.CommandType = CommandType.Text;
            //cmd.Connection = con;
            //cmd.ExecuteNonQuery();

            /***********************
            *
            ***************************FOR DISCONNECTED ENVIRONMENT**************************
            *
            */
            SqlDataAdapter da = new SqlDataAdapter("Select * from student", con);
            DataSet ds = new DataSet();
            da.Fill(ds, "student");
            ds.Tables[0].Rows[GridView1.SelectedIndex]["Id"] = GridView1.SelectedRow.Cells[1].Text;
            ds.Tables[0].Rows[GridView1.SelectedIndex]["Name"] = txtName.Text;
            ds.Tables[0].Rows[GridView1.SelectedIndex]["Class"] = liClass.SelectedValue;
            ds.Tables[0].Rows[GridView1.SelectedIndex]["Email"] = txtEmail.Text;
            ds.Tables[0].Rows[GridView1.SelectedIndex]["Pass"] = txtPass.Text;
            ds.Tables[0].Rows[GridView1.SelectedIndex]["Gender"] = gen;
            ds.Tables[0].Rows[GridView1.SelectedIndex]["Hobbies"] = hob;
            SqlCommandBuilder scm = new SqlCommandBuilder(da);
            da.UpdateCommand = scm.GetUpdateCommand();
            da.Update(ds, "student");
            GridView1.DataBind();
            con.Close();
            clearAll();

        }
        protected void clearAll()
        {
            txtName.Text = "";
            txtConfirm.Text = "";
            txtEmail.Text = "";
            txtPass.Text = "";
            liClass.SelectedValue = "Select Class";
            male.Checked = false;
            female.Checked = false;
            ho1.Checked = false;
            ho2.Checked = false;
            ho3.Checked = false;
        }

        protected void delBtn_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["apnacon"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            /***************** FOR CONNECTED ENVIRONMENT **************************
             * *
             *
             * 
             */


            //cmd.Connection = con;
            //cmd.CommandText = "delete from student where Id = " + id;
            //cmd.ExecuteNonQuery();

            /***********************
            *
            ***************************FOR DISCONNECTED ENVIRONMENT**************************
            *
            */
            SqlDataAdapter da = new SqlDataAdapter("Select * from student", con);
            DataSet ds = new DataSet();
            da.Fill(ds, "student");
            DataRow dr = ds.Tables[0].Rows[GridView1.SelectedIndex];
            dr.Delete();
            SqlCommandBuilder scm = new SqlCommandBuilder(da);
            da.DeleteCommand = scm.GetDeleteCommand();
            da.Update(ds, "student");
            con.Close();
            GridView1.DataBind();
            clearAll();
        }
    }
}