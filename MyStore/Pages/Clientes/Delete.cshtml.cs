using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace MyStore.Pages.Clientes
{
    public class DeleteModel : PageModel
    {
        public ClientInfo clientInfo = new ClientInfo();
        public String errorMessage = "";
        public String successMessage = "";
        public void OnDelete()
        {
            try
            {
                String ConnectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=mystore;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";

                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {

                    connection.Open();

                    String sql = "DELTE FROM  clients " +
                        "WHERE id =@id;";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {



                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            command.Parameters.AddWithValue("@id", clientInfo.id);

                            command.ExecuteNonQuery();
                        }

                    }
                }

                Response.Redirect("/Clients/Index");
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }
        }
    }
}
