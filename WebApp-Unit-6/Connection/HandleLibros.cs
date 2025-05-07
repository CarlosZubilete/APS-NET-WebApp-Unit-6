using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace WebApp_Unit_6.Connection
{
  public class HandleLibros
  {
    public HandleLibros() { } // Default Constructor.

    public DataTable getAllBooks()
    {
      return getDataTable("Libros", "SELECT * FROM Libros");
    }
    
  
    private DataTable getDataTable(string nombreTabla ,string querySql )
    {
      DataSet dataSet = new DataSet();
      DataAccess dataAccess = new DataAccess();
      SqlDataAdapter dataAdapter = dataAccess.getAdapter(querySql);
      dataAdapter.Fill(dataSet, nombreTabla);
      return dataSet.Tables[nombreTabla];
    }
  }
}