using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data.MySqlClient;

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
        _connectString =
        $"server={IN_ip};uid={1};pwd={2},database={3};charset=utf8;";
    }

    public void ConnectDb()
    {
        try
        {
            _connection = new MySqlConnection(_connectString);
        }
        catch (System.Exception e)
        {
            Debug.LogError(e.ToString() + e.Message);
        }
    }
}
