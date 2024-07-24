using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace puntoVenta
{
	public class OperacionesSQL
	{
		private string cadenaConexion;
		public string errorMessage = "";

		public OperacionesSQL()
		{
			cadenaConexion = @"Server=127.0.0.1;Port=3306;Database=posDB;Uid=Enrique;Pwd=12345;SSL Mode=None;AllowPublicKeyRetrieval=true";
		}

		public class Producto
		{
			public int ID { get; set; }
			public string Nombre { get; set; }
			public decimal Precio { get; set; }
			public int Cantidad { get; set; }
		}

		public List<string> ObtenerNombresProductos()
		{
			List<string> nombresProductos = new List<string>();

			string consulta = "SELECT nombre FROM Productos";

			try
			{
				using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
				{
					conexion.Open();
					MySqlCommand comando = new MySqlCommand(consulta, conexion);
					using (MySqlDataReader reader = comando.ExecuteReader())
					{
						while (reader.Read())
						{
							nombresProductos.Add(reader.GetString("nombre"));
						}
					}
				}
			}
			catch (MySqlException ex)
			{
				errorMessage = ex.Message;
			}

			return nombresProductos;
		}

		public void ActualizarCantidadProducto(string nombreProducto, int cantidadComprada)
		{
			string consulta = "UPDATE Productos SET cantidad = cantidad - @cantidadComprada WHERE nombre = @nombreProducto";
			errorMessage = "";

			try
			{
				using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
				{
					conexion.Open();
					MySqlCommand comando = new MySqlCommand(consulta, conexion);
					comando.Parameters.AddWithValue("@cantidadComprada", cantidadComprada);
					comando.Parameters.AddWithValue("@nombreProducto", nombreProducto);
					comando.ExecuteNonQuery();
				}
			}
			catch (MySqlException ex)
			{
				errorMessage = ex.Message;
			}
		}

		public int ObtenerCantidadDisponible(string nombreProducto)
		{
			int cantidadDisponible = 0;

			string consulta = "SELECT cantidad FROM Productos WHERE nombre = @nombreProducto";

			try
			{
				using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
				{
					conexion.Open();
					MySqlCommand comando = new MySqlCommand(consulta, conexion);
					comando.Parameters.AddWithValue("@nombreProducto", nombreProducto);
					object result = comando.ExecuteScalar();
					if (result != null)
					{
						cantidadDisponible = Convert.ToInt32(result);
					}
				}
			}
			catch (MySqlException ex)
			{
				errorMessage = ex.Message;
			}

			return cantidadDisponible;
		}

		public bool ObtenerYVerificarStock(string nombreProducto, int cantidadDeseada)
		{
			int cantidadDisponible = ObtenerCantidadDisponible(nombreProducto);

			if (cantidadDisponible >= cantidadDeseada && cantidadDisponible > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		public bool VerificarStockSuficiente(string nombreProducto, int cantidadDeseada)
		{
			int cantidadDisponible = ObtenerCantidadDisponible(nombreProducto);

			return cantidadDisponible >= cantidadDeseada;
		}

		public void AgregarCantidadProducto(string nombreProducto, int cantidadAgregada)
		{
			string consulta = "UPDATE Productos SET cantidad = cantidad + @cantidadAgregada WHERE nombre = @nombreProducto";
			errorMessage = "";

			try
			{
				using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
				{
					conexion.Open();
					MySqlCommand comando = new MySqlCommand(consulta, conexion);
					comando.Parameters.AddWithValue("@cantidadAgregada", cantidadAgregada);
					comando.Parameters.AddWithValue("@nombreProducto", nombreProducto);
					comando.ExecuteNonQuery();
				}
			}
			catch (MySqlException ex)
			{
				errorMessage = ex.Message;
			}
		}

		public List<Producto> ObtenerProductos()
		{
			List<Producto> productos = new List<Producto>();

			string consulta = "SELECT * FROM Productos";

			try
			{
				using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
				{
					conexion.Open();
					MySqlCommand comando = new MySqlCommand(consulta, conexion);
					using (MySqlDataReader reader = comando.ExecuteReader())
					{
						while (reader.Read())
						{
							Producto producto = new Producto();
							producto.ID = reader.GetInt32("productoID");
							producto.Nombre = reader.GetString("nombre");
							producto.Precio = reader.GetDecimal("precio");
							producto.Cantidad = reader.GetInt32("cantidad");
							productos.Add(producto);
						}
					}
				}
			}
			catch (MySqlException ex)
			{
				errorMessage = ex.Message;
			}

			return productos;
		}

		public void AgregarProducto(string nombre, decimal precio, int cantidad)
		{
			string consulta = "INSERT INTO Productos (nombre, precio, cantidad) VALUES (@nombre, @precio, @cantidad)";
			errorMessage = "";

			try
			{
				using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
				{
					conexion.Open();
					MySqlCommand comando = new MySqlCommand(consulta, conexion);
					comando.Parameters.AddWithValue("@nombre", nombre);
					comando.Parameters.AddWithValue("@precio", precio);
					comando.Parameters.AddWithValue("@cantidad", cantidad);
					comando.ExecuteNonQuery();
				}
			}
			catch (MySqlException ex)
			{
				errorMessage = ex.Message;
			}
		}
	}
}
