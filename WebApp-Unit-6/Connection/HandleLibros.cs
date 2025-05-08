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
    public bool DeleteLibro(Libro libro)
    {
      /*
      SqlCommand command = new SqlCommand();
      armarParametrosLibrosELiminar(ref command, libro);
      DataAccess dataAccess = new DataAccess();
      int filasAfectadas = dataAccess.executeNoQuery(command, "spEliminarLibro");
      if (filasAfectadas == 1)
        return true;
      else
        return false;
      */
      using (SqlCommand command = new SqlCommand())
      {
        armarParametrosLibrosELiminar(command, libro);
        DataAccess dataAccess = new DataAccess();
        int filasAfectadas = dataAccess.executeNoQuery(command, "spEliminarLibro");
        return filasAfectadas == 1;
      }

    }
    private DataTable getDataTable(string nombreTabla ,string querySql )
    {
      /*
        DataSet dataSet = new DataSet();
        DataAccess dataAccess = new DataAccess();
        SqlDataAdapter dataAdapter = dataAccess.getAdapter(querySql);
        dataAdapter.Fill(dataSet, nombreTabla);
        return dataSet.Tables[nombreTabla];
      */
      DataAccess dataAccess = new DataAccess();
      using (SqlDataAdapter adapter = dataAccess.getAdapter(querySql))
      {
        if (adapter == null) 
            throw new Exception("Error al obtener el adaptador de datos.");

        DataSet dataSet = new DataSet();
        adapter.Fill(dataSet, nombreTabla);
        return dataSet.Tables[nombreTabla];
      }
    }
    //private void armarParametrosLibrosELiminar(ref SqlCommand command , Libro libro)
    private void armarParametrosLibrosELiminar(SqlCommand command, Libro libro)
    {
      SqlParameter parameter = new SqlParameter();
      parameter = command.Parameters.Add("@IdLibro", SqlDbType.Int);
      parameter.Value = libro.IdLibro;
      /*
      command.Parameters.Add(new SqlParameter("@IdLibro", SqlDbType.Int) 
      { 
        Value = libro.IdLibro
      });
      */
    }
   }
}