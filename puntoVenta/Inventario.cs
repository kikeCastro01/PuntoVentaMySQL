using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace puntoVenta
{
	public partial class Inventario : Form
	{
		private OperacionesSQL conexion;
		private List<string> nombresProductos;
		public Inventario()
		{
			InitializeComponent();
			conexion = new OperacionesSQL();
			nombresProductos = new List<string>();
			LlenarComboBoxProductos();
			MostrarDatosProductos();
		}
		private void LlenarComboBoxProductos()
		{
			// Llena la lista de nombres de productos desde la base de datos
			nombresProductos = conexion.ObtenerNombresProductos();

			// Agrega los nombres de productos al ComboBox
			cbProductos.DataSource = nombresProductos;
			cbProductos2.DataSource = nombresProductos;
		}

		private void MostrarDatosProductos()
		{
			dgvProductos.DataSource = conexion.ObtenerProductos();
		}

		private void btnComprar_Click(object sender, EventArgs e)
		{
			//if (cbProductos.SelectedItem != null)
			//{
			//	string nombreProducto = cbProductos.SelectedItem.ToString();
			//	int cantidadComprada = (int)nudCantidad.Value;

			//	// Llamada al método para actualizar la cantidad del producto
			//	conexion.ActualizarCantidadProducto(nombreProducto, cantidadComprada);

			//	MessageBox.Show("Venta realizada con éxito.");
			//}
			//else
			//{
			//	MessageBox.Show("Por favor, seleccione un producto.");
			//}

			string nombreProducto = cbProductos.SelectedItem.ToString();
			int cantidadDeseada = (int)nudCantidad.Value;


			if (conexion.ObtenerYVerificarStock(nombreProducto, cantidadDeseada))
			{
				// Realizar la venta
				conexion.ActualizarCantidadProducto(nombreProducto, cantidadDeseada);
				MessageBox.Show("Venta realizada exitosamente");
			}
			else
			{
				MessageBox.Show("No hay suficiente stock disponible o el stock es cero");
			}

		}

		private void Inventario_Load(object sender, EventArgs e)
		{
			cbProductos.DataSource = conexion.ObtenerNombresProductos();

		}

		private void btnRegresar_Click(object sender, EventArgs e)
		{
			// Cerrar el formulario actual (Interfaz de productos)
			this.Close();
		}

		private void btnActualizar_Click(object sender, EventArgs e)
		{
			MostrarDatosProductos();
		}

		private void btnAgregar_Click(object sender, EventArgs e)
		{
			if (cbProductos2.SelectedItem != null)
			{
				string nombreProducto = cbProductos2.SelectedItem.ToString();
				int cantidadAgregada = (int)nudCantidad2.Value;

				// Llamada al método para actualizar la cantidad del producto
				conexion.AgregarCantidadProducto(nombreProducto, cantidadAgregada);

				MessageBox.Show("Stock agregado con éxito.");
			}
			else
			{
				MessageBox.Show("Por favor, seleccione un producto.");
			}
		}
	}
}
