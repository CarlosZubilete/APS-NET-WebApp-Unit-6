using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp_Unit_6.Connection
{
  public class Libro
  {
    public Libro() { } // Contructor default
    public Libro(int idLibro, int idTema, string titulo, decimal precio, string autor)
    {
      _idLibro = idLibro;
      _idTema = idTema;
      _tittulo = titulo;
      _precio = precio;
      _autor = autor;
    }
    // Getters an Setter 
    public int IdLibro
    {
      get
      {
        return _idLibro;
      }
      set
      {
        _idLibro = value;
      }
    }
    public int IdTema
    {
      get
      {
        return _idTema;
      }
      set
      {
        _idTema = value;
      }
    }
    public string Titulo
    {
      get
      {
        return _tittulo;
      }
      set
      {
        _tittulo = value;
      }
    }
    public decimal Precio
    {
      get
      {
        return _precio;
      }
      set
      {
        _precio = value;
      }
    }

    public string Autor
    {
      get
      {
        return _autor;
      }
      set
      {
        _autor = value;
      }
    }

    // Privcate:
    private int _idLibro;
    private int _idTema;
    private string _tittulo;
    private decimal _precio;
    private string _autor;
  }
}