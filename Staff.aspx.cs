using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Staff : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (User.Identity.IsAuthenticated == false)
        {
            Response.Redirect("~/Login.aspx");
        }
    }

    protected void Novi_Click(object sender, EventArgs e)
    {
        if (User.Identity.Name == "sef")
        {
            int br = 0;
            OleDbConnection konekcija = new OleDbConnection(ConfigurationManager.ConnectionStrings["konekcijaNaBazu"].ConnectionString);
            try
            {
                konekcija.Open();
                OleDbCommand upit1 = new OleDbCommand("SELECT * FROM staff WHERE ime=@ime AND pass=@pass AND pozicija=@pozicija", konekcija);
                upit1.Parameters.AddWithValue("@ime", Ime.Text);
                upit1.Parameters.AddWithValue("@pass", Pass.Text);
                upit1.Parameters.AddWithValue("@pozicija", "radnik");

                OleDbDataReader podatci1 = upit1.ExecuteReader();
                while (podatci1.Read())
                {
                    br++;
                }
                podatci1.Close();
                if (br == 0)
                {
                    OleDbCommand upit2 = new OleDbCommand("INSERT INTO staff VALUES(@ime,@pass,@pozicija)", konekcija);
                    upit2.Parameters.AddWithValue("@ime", Ime.Text);
                    upit2.Parameters.AddWithValue("@pass", Pass.Text);
                    upit2.Parameters.AddWithValue("@pozicija", "radnik");
                    OleDbDataReader podatci2 = upit2.ExecuteReader();
                    while (podatci2.Read())
                    {

                    }
                    podatci2.Close();
                }
            }
            catch { }
            finally
            {
                konekcija.Close();
                GridView1.DataBind();
                if (br == 0) Label1.Text = Ime.Text+" dodan";
                else Label1.Text = Ime.Text + " vec postoji";
            }
        }
    }

    protected void Otkaz_Click(object sender, EventArgs e)
    {
        if (User.Identity.Name == "sef")
        {
            int br = 0;
            OleDbConnection konekcija = new OleDbConnection(ConfigurationManager.ConnectionStrings["konekcijaNaBazu"].ConnectionString);
            try
            {
                konekcija.Open();
                OleDbCommand upit1 = new OleDbCommand("SELECT * FROM staff WHERE ime=@ime AND pass=@pass AND pozicija=@pozicija", konekcija);
                upit1.Parameters.AddWithValue("@ime", Ime.Text);
                upit1.Parameters.AddWithValue("@pass", Pass.Text);
                upit1.Parameters.AddWithValue("@pozicija", "radnik");

                OleDbDataReader podatci1 = upit1.ExecuteReader();
                while (podatci1.Read())
                {
                    br++;
                }
                podatci1.Close();
                if (br == 1)
                {
                    OleDbCommand upit2 = new OleDbCommand("DELETE FROM staff WHERE ime=@ime AND pass=@pass AND pozicija=@pozicija", konekcija);
                    upit2.Parameters.AddWithValue("@ime", Ime.Text);
                    upit2.Parameters.AddWithValue("@pass", Pass.Text);
                    upit2.Parameters.AddWithValue("@pozicija", "radnik");
                    OleDbDataReader podatci2 = upit2.ExecuteReader();
                    while (podatci2.Read())
                    {

                    }
                    podatci2.Close();

                }
            }
            catch { }
            finally
            {
                konekcija.Close();
                GridView1.DataBind();
                if (br == 1) Label1.Text =Ime.Text+" obrisan";
                else Label1.Text =  Ime.Text+" ne postoji" ;
            }
        }
    }
}