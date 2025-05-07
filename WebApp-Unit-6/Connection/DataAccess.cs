using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
// using System.Data.CommandType;

namespace WebApp_Unit_6.Connection
{
  public class DataAccess
  {
    // variable connectingString -> Libreria Data Base.
    private const string _connetingString = @"Data Source=DESKTOP-LFTFVP5\SQLEXPRESS;Initial Catalog=Libreria;Integrated Security=True";
    // Constructor, the same name of this class, not return anything
    public DataAccess() { }

    // getConnction 
    public SqlConnection getConnection()
    {
      SqlConnection connection = new SqlConnection(_connetingString);
      try
      {
        connection.Open();
        return connection; 
      }
      catch(Exception err)
      {
        return null;
      }
    }
    // getAdapter...
    public SqlDataAdapter getAdapter(string querySql)
    {
      SqlDataAdapter dataAdapter;
      try
      {
        dataAdapter = new SqlDataAdapter(querySql,getConnection());
        return dataAdapter;
      }
      catch (Exception err)
      {
        return null;
      }
      
    }

    // execute le procedimiento alamcenado , retorna un entero 
    public int executeNoQuery(SqlCommand command , string querySql)
    {
      int changeRows;
      SqlConnection _connection = getConnection(); 
      SqlCommand _commad = new SqlCommand();
      _commad = command;
      _commad.Connection = _connection;

      _commad.CommandType = CommandType.StoredProcedure; // Indico el tipo de procedimiento
      _commad.CommandText = querySql; // Nombre del procedimiento o query
      changeRows = _commad.ExecuteNonQuery(); // Ejecuto el procedimiento 
      _connection.Close();
      return changeRows;


      /*
        using (SqlConnection _connection = getConnection())
        {
            using (SqlCommand _commad = command)
            {
                _commad.Connection = _connection;
                _commad.CommandType = CommandType.StoredProcedure;
                _commad.CommandText = querySql;
                return _commad.ExecuteNonQuery();
            }
        }

       */
    }
  }
}