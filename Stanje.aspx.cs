using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data;

public partial class Stanje : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (User.Identity.IsAuthenticated == false)
        {
            Response.Redirect("~/Login.aspx");
        }
    }

    protected void Dodaj_Click(object sender, EventArgs e)
    {
        String kol = 0.ToString();
        int kolicina = 0;
        OleDbConnection konekcija = new OleDbConnection(ConfigurationManager.ConnectionStrings["konekcijaNaBazu"].ConnectionString);
        try
        {
            konekcija.Open();
            kolicina = int.Parse(Kolicina.Text);
            OleDbCommand upit1 = new OleDbCommand("SELECT kolicina FROM proizvod WHERE naziv=@naziv AND kategorija=@kategorija AND lokacija=@lokacija", konekcija);
            upit1.Parameters.AddWithValue("@naziv", Naziv.Text);
            upit1.Parameters.AddWithValue("@kategorija", Kategorija.SelectedItem.Text);
            upit1.Parameters.AddWithValue("@lokacija", Lokacija.SelectedItem.Text);

            OleDbDataReader podatci1 = upit1.ExecuteReader();
            while (podatci1.Read())
            {
                kol = podatci1.GetString(0);
                kol = (int.Parse(kol) + kolicina).ToString();
            }
            podatci1.Close();
            if (kol == "0")
            {
                kol = kolicina.ToString();
                OleDbCommand upit2 = new OleDbCommand("INSERT INTO proizvod VALUES(@naziv,@kategorija,@lokacija,@kol)", konekcija);
                upit2.Parameters.AddWithValue("@naziv", Naziv.Text);
                upit2.Parameters.AddWithValue("@kategorija", Kategorija.SelectedItem.Text);
                upit2.Parameters.AddWithValue("@lokacija", Lokacija.SelectedItem.Text);
                upit2.Parameters.AddWithValue("@kol", kol);
                OleDbDataReader podatci2 = upit2.ExecuteReader();
                while (podatci2.Read())
                {

                }
                podatci2.Close();
            }
            else
            {

                OleDbCommand upit = new OleDbCommand("UPDATE proizvod SET kolicina=@kol WHERE naziv=@naziv AND kategorija=@kategorija AND lokacija=@lokacija", konekcija);
                upit.Parameters.AddWithValue("@kol", kol);
                upit.Parameters.AddWithValue("@naziv", Naziv.Text);
                upit.Parameters.AddWithValue("@kategorija", Kategorija.SelectedItem.Text);
                upit.Parameters.AddWithValue("@lokacija", Lokacija.SelectedItem.Text);
                OleDbDataReader podatci = upit.ExecuteReader();

                while (podatci.Read())
                {

                }

                podatci.Close();

            }
        }
        catch { }
        finally
        {
            konekcija.Close();
            GridView1.DataBind();
            Label1.Text = "dodano:" + Naziv.Text + "->" + kolicina + " u:" + Lokacija.SelectedItem.Text;
        }
    }

    protected void Salji_Click(object sender, EventArgs e)
    {
        int pom = 0;
        String kol = 0.ToString();
        int kolicina = 0;
        int br = 0;
        OleDbConnection konekcija = new OleDbConnection(ConfigurationManager.ConnectionStrings["konekcijaNaBazu"].ConnectionString);
        try
        {
            konekcija.Open();

            kolicina = int.Parse(Kolicina.Text);

            OleDbCommand upit1 = new OleDbCommand("SELECT kolicina FROM proizvod WHERE naziv=@naziv AND kategorija=@kategorija AND lokacija=@lokacija", konekcija);
            upit1.Parameters.AddWithValue("@naziv", Naziv.Text);
            upit1.Parameters.AddWithValue("@kategorija", Kategorija.SelectedItem.Text);
            upit1.Parameters.AddWithValue("@lokacija", Lokacija.SelectedItem.Text);

            OleDbDataReader podatci1 = upit1.ExecuteReader();
            while (podatci1.Read())
            {
                br++;
                kol = podatci1.GetString(0);
                kol = (int.Parse(kol) - kolicina).ToString();
                pom = int.Parse(kol);
                if (pom < 0)
                {
                    kol = 0.ToString();
                }
            }
            podatci1.Close();
            if (kol == "0")
            {
                kol = kolicina.ToString();
                OleDbCommand upit2 = new OleDbCommand("DELETE FROM proizvod WHERE naziv=@naziv AND kategorija=@kategorija AND lokacija=@lokacija", konekcija);
                upit2.Parameters.AddWithValue("@naziv", Naziv.Text);
                upit2.Parameters.AddWithValue("@kategorija", Kategorija.SelectedItem.Text);
                upit2.Parameters.AddWithValue("@lokacija", Lokacija.SelectedItem.Text);
                OleDbDataReader podatci2 = upit2.ExecuteReader();
                while (podatci2.Read())
                {

                }
                podatci2.Close();
            }
            else
            {

                OleDbCommand upit = new OleDbCommand("UPDATE proizvod SET kolicina=@kol WHERE naziv=@naziv AND kategorija=@kategorija AND lokacija=@lokacija", konekcija);
                upit.Parameters.AddWithValue("@kol", kol);
                upit.Parameters.AddWithValue("@naziv", Naziv.Text);
                upit.Parameters.AddWithValue("@kategorija", Kategorija.SelectedItem.Text);
                upit.Parameters.AddWithValue("@lokacija", Lokacija.SelectedItem.Text);
                OleDbDataReader podatci = upit.ExecuteReader();

                while (podatci.Read())
                {

                }

                podatci.Close();

            }
        }
        catch { }
        finally
        {
            konekcija.Close();
            GridView1.DataBind();
            if (br > 0)
            {
                if (pom >= 0)
                    Label1.Text = "poslano:" + Naziv.Text + "->" + (kolicina - pom) + " sa:" + Lokacija.SelectedItem.Text;
                else
                {
                    pom = 0 - pom;
                    Label1.Text = "poslano:" + Naziv.Text + "->" + (kolicina - pom) + " sa:" + Lokacija.SelectedItem.Text + ", manjak:" + pom;
                }
            }
            else Label1.Text = "ne postoji " + Naziv.Text + " na adresi " + Lokacija.SelectedItem.Text;
        }
    }



    protected void CheckBoxList1_SelectedIndexChanged(object sender, EventArgs e)
    {
    /*    OleDbConnection konekcija = new OleDbConnection(ConfigurationManager.ConnectionStrings["konekcijaNaBazu"].ConnectionString);
        
        string query = "SELECT * FROM proizvod";
            string condition = string.Empty;
            foreach (ListItem item in CheckBoxList1.Items)
            {
                condition += item.Selected ? string.Format("'{0}',", item.Value) : string.Empty;
            }
            if (!string.IsNullOrEmpty(condition))
            {
                condition = string.Format(" WHERE Kategorija IN ({0})", condition.Substring(0, condition.Length - 1));
            }
            OleDbDataAdapter adapter = new OleDbDataAdapter(query+condition, konekcija);
            DataSet ds = new DataSet();
        
                
        try
        {
            konekcija.Open();
            adapter.Fill(ds);
            konekcija.Close();
            GridView1.DataSource = ds;
            GridView1.DataBind();

        }
        catch { }
        finally
        {
        }*/
    }
}

        //http://www.aspsnippets.com/Articles/Filter-GridView-using-CheckBoxList-CheckBoxes-in-ASPNet.aspx