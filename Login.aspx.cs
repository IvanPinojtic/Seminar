using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (User.Identity.IsAuthenticated == true)
        {
            Response.Redirect("Stanje.aspx");
        }
    }

    protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
    {
        OleDbConnection konekcija = new OleDbConnection(ConfigurationManager.ConnectionStrings["konekcijaNaBazu"].ConnectionString);
        try
        {
            konekcija.Open();
            OleDbCommand upit = new OleDbCommand("SELECT * FROM staff WHERE ime=@ime AND pass=@pass", konekcija);
            upit.Parameters.AddWithValue("@ime", Login1.UserName);
            upit.Parameters.AddWithValue("@pass", Login1.Password);
            OleDbDataReader podatci = upit.ExecuteReader();

            while (podatci.Read())
            {
                e.Authenticated = true;
            }

            podatci.Close();

        }
        catch { }
        finally
        {
            konekcija.Close();
        }
    }
}