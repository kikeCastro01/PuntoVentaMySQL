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
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void btnProductos_Click(object sender, EventArgs e)
		{
			// Crear una instancia del formulario de agregar producto
			Productos formAgregarProducto = new Productos();

			// Mostrar el formulario
			formAgregarProducto.ShowDialog();
		}

		private void btnInventario_Click(object sender, EventArgs e)
		{
			// Crear una instancia del formulario de agregar producto
			Inventario formInventario = new Inventario();

			// Mostrar el formulario
			formInventario.ShowDialog();
		}
	}
}
