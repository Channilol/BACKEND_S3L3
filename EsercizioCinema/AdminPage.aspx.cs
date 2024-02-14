using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EsercizioCinema
{
    public partial class AdminPage : System.Web.UI.Page
    {
        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            string connString = ConfigurationManager.ConnectionStrings["connectionToDatabase"].ToString();
            SqlConnection conn = new SqlConnection(connString);

            try
            {
                conn.Open();
                SqlCommand getTickets = new SqlCommand("SELECT (SELECT COUNT(*) FROM ListaBiglietti WHERE Sala = 'nord') AS totNord, (SELECT COUNT(*) FROM ListaBiglietti WHERE Sala = 'nord' AND TipoBiglietto = 'Ridotto') AS totKidsNord, (SELECT COUNT(*) FROM ListaBiglietti WHERE Sala = 'est') AS totEst, (SELECT COUNT(*) FROM ListaBiglietti WHERE Sala = 'est' AND TipoBiglietto = 'Ridotto') AS totKidsEst, (SELECT COUNT(*) FROM ListaBiglietti WHERE Sala = 'sud') AS totSud, (SELECT COUNT(*) FROM ListaBiglietti WHERE Sala = 'sud' AND TipoBiglietto = 'Ridotto') AS totKidsSud", conn);
                SqlDataReader sqlTickets = getTickets.ExecuteReader();
                if (sqlTickets.HasRows)
                {
                    while (sqlTickets.Read())
                    {
                        int totTicketsNord = sqlTickets.GetInt32(0);
                        ticketsNord.Text = $"Biglietti venduti: {totTicketsNord.ToString()}";
                        int totKidsNord = sqlTickets.GetInt32(1);
                        kidsNord.Text = $"Biglietti ridotti venduti: {totKidsNord.ToString()}";
                        int totTicketsEst = sqlTickets.GetInt32(2);
                        ticketsEst.Text = $"Biglietti venduti: {totTicketsEst.ToString()}";
                        int totKidsEst = sqlTickets.GetInt32(3);
                        kidsEst.Text = $"Biglietti ridotti venduti: {totKidsEst.ToString()}";
                        int totTicketsSud = sqlTickets.GetInt32(4);
                        ticketsSud.Text = $"Biglietti venduti: {totTicketsSud.ToString()}";
                        int totKidsSud = sqlTickets.GetInt32(5);
                        kidsSud.Text = $"Biglietti ridotti venduti: {totKidsSud.ToString()}";
                    }
                }
                else
                {
                    ticketsNord.Text = "0";
                }
                sqlTickets.Close();
            }
            catch (Exception ex)
            {
                Response.Write($"{ex}");
            }
            finally
            {
                conn.Close();
            }
        }

        protected void btnBuyTicket_Click(object sender, EventArgs e)
        {
            string connString = ConfigurationManager.ConnectionStrings["connectionToDatabase"].ToString();
            SqlConnection conn = new SqlConnection(connString);

            try
            {
                conn.Open();
                string selectedRadio = (RadioSala.SelectedValue).ToString();
                string isRidotto;
                if (checkRidotto.Checked)
                {
                    isRidotto = "Ridotto";
                }
                else
                {
                    isRidotto = "Intero";
                }
                if (txtName.Text != "" && txtSurname.Text != "" && selectedRadio != "")
                {
                    SqlCommand addTicket = new SqlCommand($"INSERT into ListaBiglietti (Nome, Cognome, Sala, TipoBiglietto) VALUES ('{txtName.Text}', '{txtSurname.Text}', '{selectedRadio}', '{isRidotto}')", conn);
                    int affectedRow = addTicket.ExecuteNonQuery();
                    if (affectedRow > 0)
                    {
                        Response.Write("Biglietto registrato con successo");
                        txtName.Text = "";
                        txtSurname.Text = "";
                        RadioSala.ClearSelection();
                        checkRidotto.Checked = false;
                    }
                    else
                    {
                        Response.Write("Errore nella registrazione del biglietto");
                    }
                }
                else
                {
                    Response.Write("Compila tutti i campi!");
                }
            }
            catch
            {
                Response.Write("Connessione chiusa");
            }
            finally
            {
                conn.Close();
            }
        }
    }
}