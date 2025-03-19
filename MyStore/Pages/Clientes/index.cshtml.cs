using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using System.Diagnostics;

namespace MyStore.Pages.Clientes
{
    public class IndexModel : PageModel
    {
        public List<ClientInfo> listClients = new List<ClientInfo>();
        public void OnGet()
        {
            try
            {
                String ConnectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=mystore;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";

                using (SqlConnection connection = new SqlConnection(ConnectionString)) {

                    connection.Open();

                    String sql = "SELECT * FROM clients";


                }
            }
            catch (Exception ex)
            {

            }
        }
    }

    public class ClientInfo {

        public string Id;
        public string name;
        public string email;
        public string phone;
        public string address;

    }

}
