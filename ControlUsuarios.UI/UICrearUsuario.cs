using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Krisa.ControlUsuarios;
using Krisa.Datos;

namespace Krisa.ControlUsuarios.UI
{
    public partial class UICrearUsuario : Form
    {
        GestorUsuario gestorUsuario;

        public UICrearUsuario()
        {
            InitializeComponent();
            gestorUsuario = new GestorUsuario();
        }

        /// <summary>
        /// Accion del boton Guardar Usuario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario usuario = new Usuario();
                usuario.Nombre = txtUsuario.Text;
                usuario.NombreCompleto = txtNombreCompleto.Text;
                usuario.Contrasena = txtPass.Text;
                usuario.Activo = true;

                gestorUsuario.AgregarUsuario(usuario);

                txtUsuario.Text = "";
                txtNombreCompleto.Text = "";
                txtPass.Text = "";
                txtPassConfirmacion.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Accion del Metodo Cancelar 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Validacion de campo vacio en el Nombre de Usuario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUsuario_Validating(object sender, CancelEventArgs e)
        {
            if (txtUsuario.Text.Trim() == "")
            {
                errorCrearUsuario.SetError(txtUsuario, "Valor no puede ser nulo");
                txtUsuario.BackColor = Color.LightSkyBlue;
                e.Cancel = true;
                return;
            }
            errorCrearUsuario.Clear();
            txtUsuario.BackColor = Color.White;
        }

        /// <summary>
        /// Validacion de campo vacio y que acepte solo letras del Nombre Completo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNombreCompleto_Validating(object sender, CancelEventArgs e)
        {
            if (txtNombreCompleto.Text.Trim() == "")
            {
                errorCrearUsuario.SetError(txtNombreCompleto, "Valor no puede ser nulo");
                txtNombreCompleto.BackColor = Color.LightSkyBlue;
                e.Cancel = true;
                return;
            }
            if (Regex.IsMatch(txtNombreCompleto.Text, "[0-9]"))
            {
                errorCrearUsuario.SetError(txtNombreCompleto, "No se pueden ingresar Numeros");
                txtNombreCompleto.BackColor = Color.LightSkyBlue;
                e.Cancel = true;
                return;
            }
            errorCrearUsuario.Clear();
            txtNombreCompleto.BackColor = Color.White;
        }

        /// <summary>
        /// Validacion de la confirmacion de la contraseña. Campo no vacio.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPassConfirmacion_Validating(object sender, CancelEventArgs e)
        {
            if (txtPassConfirmacion.Text.Trim() == "")
            {
                errorCrearUsuario.SetError(txtPassConfirmacion, "Valor no puede ser nulo");
                txtPassConfirmacion.BackColor = Color.LightSkyBlue;
                e.Cancel = true;
                return;
            }
            if (txtPass.Text != txtPassConfirmacion.Text)
            {
                errorCrearUsuario.SetError(txtPassConfirmacion, "La contraseña no coincide");
                txtPassConfirmacion.BackColor = Color.LightSkyBlue;
                e.Cancel = true;
                return;
            }
            errorCrearUsuario.Clear();
            txtPassConfirmacion.BackColor = Color.White;
        }

        /// <summary>
        /// Validacion de la contraseña no vacio. Longitud minima de 8 caracteres.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPass_Validating(object sender, CancelEventArgs e)
        {
            if (txtPass.Text.Trim() == "")
            {
                errorCrearUsuario.SetError(txtPass, "Valor no puede ser nulo");
                txtPass.BackColor = Color.LightSkyBlue;
                e.Cancel = true;
                return;
            }
            if (txtPass.Text.Length < 8)
            {
                errorCrearUsuario.SetError(txtPass, "La longitud minima es de 8 caracteres");
                txtPass.BackColor = Color.LightSkyBlue;
                e.Cancel = true;
                return;
            }
            errorCrearUsuario.Clear();
            txtPass.BackColor = Color.White;
        }
    }
}
