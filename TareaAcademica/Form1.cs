using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TareaAcademica.controllers;
using TareaAcademica.entities;

namespace TareaAcademica
{
    public partial class Form1 : Form
    {
        private ProductoController productoController = new ProductoController();

        public Form1()
        {
            InitializeComponent();
        }

        private void MostrarProductosEnDataGrid(Producto[] productos)
        {
            dgProductos.DataSource = null;
            dgProductos.DataSource = productos;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if(tbCodigo.Text == "" || tbNombre.Text == "" || tbDescripcion.Text == "" || tbPrecio.Text == "" || tbCantidad.Text == "")
            {
                MessageBox.Show("Ingrese todos los campos requeridos");
                return;
            }

            Producto producto = new Producto()
            {
                Codigo = tbCodigo.Text,
                Nombre = tbNombre.Text,
                Descripcion = tbDescripcion.Text,
                Precio = double.Parse(tbPrecio.Text),
                Cantidad = double.Parse(tbCantidad.Text),
            };

            productoController.Registrar(producto);

            MostrarProductosEnDataGrid(productoController.Listar());
        }


        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgProductos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione producto a eliminar");
                return;
            }

            String codigo = dgProductos.SelectedRows[0].Cells[0].Value.ToString();

            productoController.Eliminar(codigo);

            MostrarProductosEnDataGrid(productoController.Listar());
        }

        private void btnEliminarTodos_Click(object sender, EventArgs e)
        {
            
        }

        private void btnListar_Click(object sender, EventArgs e)
        {

        }
    }
}
