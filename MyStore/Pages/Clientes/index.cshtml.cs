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

                    using (SqlCommand command = new SqlCommand(sql, connection)) {



                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            while (reader.Read())
                            {
                                ClientInfo clientInfo = new ClientInfo();
                                clientInfo.id = "" + reader.GetInt32(0);
                                clientInfo.name = reader.GetString(1);
                                clientInfo.email = reader.GetString(2);
                                clientInfo.phone = reader.GetString(3);
                                clientInfo.address = reader.GetString(4);
                                clientInfo.created_at = reader.GetDateTime(5).ToString();

                                listClients.Add(clientInfo);
                            }


                        }

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: "+ ex.ToString());

            }
        }
    }

    public class ClientInfo {

        public string id;
        public string name;
        public string email;
        public string phone;
        public string address;
        public string created_at;

    }

}
