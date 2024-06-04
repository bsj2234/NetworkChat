using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data.MySqlClient;
using System.Data;

public class DatabaseConnect : MonoBehaviour
{
    [SerializeField] private string IN_ip = "127.0.0.1";
    [SerializeField] private string IN_dbId = "root";
    [SerializeField] private string IN_dbPassword = "1234";
    [SerializeField] private string IN_name = "user_info";

    private string _connectString;

    private static MySqlConnection _connection;

    private void Start()
    {
    }

    public void ConnectDb(string ip, string uid, string pwd, string db)
    {

        string _connectString =
        $"server={ip};uid={uid};pwd={pwd},database={db};charset=utf8;";
        try
        {
            _connection = new MySqlConnection(_connectString);
        }
        catch (System.Exception e)
        {
            Debug.LogError(e.ToString() + e.Message);
        }
    }

    private static DataSet SelectRequest(string quary, string tableName)
    {
        try
        {
            _connection.Open();

            MySqlCommand command = new MySqlCommand(quary, _connection);

            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset, tableName);

            _connection.Close()
    private static DataSet SelectRequest(string quary, string tableName)
    {
        try
        {
            _connection.Open();

            MySqlCommand command = new MySqlCommand(quary, _connection);

            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset, tableName);

            _connection.Close();

            return dataset;
        }
        catch (System.Exception e)
        {
            Debug.LogError(e.ToString() + e.Message);
            return null;
        }
    }

            return dataset;
        }
        catch (System.Exception e)
        {
            Debug.LogError(e.ToString() + e.Message);
            return null;
        }
    }

    public bool RequestUpdate(string quary, string tableName)
    {
        return RequestNonquary(quary, tableName);
    }
    public bool RequestInsert(string quary, string tableName)
    {
        return RequestNonquary(quary, tableName);
    }
    private bool RequestNonquary(string quary, string tableName)
    {
        try
        {
            _connection.Open();
            MySqlCommand command = new MySqlCommand(quary, _connection);

            command.ExecuteNonQuery();

            _connection.Close();
            return true;
        }
        catch (System.Exception e)
        {
            Debug.LogError(e.ToString() + e.Message);
            return false;
        }
    }

    public void Disconnect()
    {
        _connection.Close();
    }
}
