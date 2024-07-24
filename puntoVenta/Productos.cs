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
	public partial class Productos : Form
	{
		public Productos()
		{
			InitializeComponent();
		}

		private void btnAgregar_Click(object sender, EventArgs e)
		{
			string nombre = tbNombre.Text;
			if (string.IsNullOrWhiteSpace(nombre))
			{
				MessageBox.Show("Por favor ingrese un nombre válido para el producto.");
				return;
			}

			decimal precio;
			if (!decimal.TryParse(tbPrecio.Text, out precio))
			{
				MessageBox.Show("Por favor ingrese un precio válido para el producto.");
				return;
			}

			int cantidad = (int)nudCantidad.Value;

			OperacionesSQL conexion = new OperacionesSQL();
			conexion.AgregarProducto(nombre, precio, cantidad);

			MessageBox.Show("Producto guardado correctamente.");
		}

		private void btnRegresar_Click(object sender, EventArgs e)
		{
			// Cerrar el formulario actual (Interfaz de productos)
			this.Close();
		}
	}
}
