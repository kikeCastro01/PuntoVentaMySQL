namespace puntoVenta
{
	partial class Form1
	{
		/// <summary>
		/// Variable del diseñador necesaria.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Limpiar los recursos que se estén usando.
		/// </summary>
		/// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Código generado por el Diseñador de Windows Forms

		/// <summary>
		/// Método necesario para admitir el Diseñador. No se puede modificar
		/// el contenido de este método con el editor de código.
		/// </summary>
		private void InitializeComponent()
		{
			this.btnProductos = new System.Windows.Forms.Button();
			this.btnInventario = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnProductos
			// 
			this.btnProductos.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnProductos.Location = new System.Drawing.Point(76, 91);
			this.btnProductos.Name = "btnProductos";
			this.btnProductos.Size = new System.Drawing.Size(135, 67);
			this.btnProductos.TabIndex = 0;
			this.btnProductos.Text = "Productos";
			this.btnProductos.UseVisualStyleBackColor = true;
			this.btnProductos.Click += new System.EventHandler(this.btnProductos_Click);
			// 
			// btnInventario
			// 
			this.btnInventario.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnInventario.Location = new System.Drawing.Point(76, 186);
			this.btnInventario.Name = "btnInventario";
			this.btnInventario.Size = new System.Drawing.Size(135, 67);
			this.btnInventario.TabIndex = 0;
			this.btnInventario.Text = "Inventario";
			this.btnInventario.UseVisualStyleBackColor = true;
			this.btnInventario.Click += new System.EventHandler(this.btnInventario_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(289, 332);
			this.Controls.Add(this.btnInventario);
			this.Controls.Add(this.btnProductos);
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btnProductos;
		private System.Windows.Forms.Button btnInventario;
	}
}

