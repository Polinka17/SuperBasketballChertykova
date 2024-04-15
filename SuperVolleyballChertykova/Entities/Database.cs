using System.Data;
using MySql.Data.MySqlClient;

namespace SuperVolleyball.Entities;

public class Database
{
    private MySqlConnection _connection =
        new MySqlConnection(@"server=10.10.1.24; database=pro1_22;port=3306;User Id=user01;password=user01pro");

    public void OpenConnection()
    {
        if (_connection.State == ConnectionState.Closed)
        {
            _connection.Open();
        }
    }
    
    public void CloseConnection()
    {
        if (_connection.State == ConnectionState.Open)
        {
            _connection.Close();
        }
    }

    public MySqlConnection GetConnection()
    {
        return _connection;
    }
}