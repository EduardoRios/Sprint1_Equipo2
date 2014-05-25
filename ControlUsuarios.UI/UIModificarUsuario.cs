using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Krisa.Datos;
using Krisa.ControlUsuarios;

namespace Krisa.ControlUsuarios.UI
{
    public partial class UIModificarUsuario : Form
    {
        GestorUsuario gestorUsuario;

        public UIModificarUsuario()
        {
            InitializeComponent();
            gestorUsuario = new GestorUsuario();
        }

        /// <summary>
        /// Accion del boton Modificar contraseña de Usuario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModificar_Click(object sender, EventArgs e)
        {
            //string usuario = txtUsuario.Text;
            //string passActual = txtPass.Text;
            //string passNueva = txtNuevoPass.Text;
            //gestorUsuario.ModificarUsuario(usuario, passActual, passNueva);

            Usuario usuario = new Usuario();
            usuario.Nombre = txtUsuario.Text;
            usuario.Contrasena = txtPass.Text;
            string nuevoPass = txtNuevoPass.Text;
            gestorUsuario.ModificarUsuario(usuario, nuevoPass);
        }

        /// <summary>
        /// Accion del boton Cancelar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Validacion del campo no vacio de la contraseña de usuario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPass_Validating(object sender, CancelEventArgs e)
        {
            if (txtPass.Text.Trim() == "")
            {
                errorModificarUsuario.SetError(txtPass, "Valor no puede ser nulo");
                txtPass.BackColor = Color.LightSkyBlue;
                e.Cancel = true;
                return;
            }
            errorModificarUsuario.Clear();
            txtPass.BackColor = Color.White;
        }

        /// <summary>
        /// Validacion del campo no vacio y longitud minima de nueva contraseña de 8 caracteres.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNuevoPass_Validating(object sender, CancelEventArgs e)
        {
            if (txtNuevoPass.Text.Trim() == "")
            {
                errorModificarUsuario.SetError(txtNuevoPass, "Valor no puede ser nulo");
                txtNuevoPass.BackColor = Color.LightSkyBlue;
                e.Cancel = true;
                return;
            }
            if (txtNuevoPass.Text.Length < 8)
            {
                errorModificarUsuario.SetError(txtNuevoPass, "La longitud minima es de 8 caracteres");
                txtNuevoPass.BackColor = Color.LightSkyBlue;
                e.Cancel = true;
                return;
            }
            errorModificarUsuario.Clear();
            txtNuevoPass.BackColor = Color.White;
        }

        /// <summary>
        /// Validacion de campo de confirmacion de nueva contraseña.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtConfirmar_Validating(object sender, CancelEventArgs e)
        {
            if (txtConfirmar.Text.Trim() == "")
            {
                errorModificarUsuario.SetError(txtPass, "Valor no puede ser nulo");
                txtConfirmar.BackColor = Color.LightSkyBlue;
                e.Cancel = true;
                return;
            }
            if (txtNuevoPass.Text != txtConfirmar.Text)
            {
                errorModificarUsuario.SetError(txtConfirmar, "La contraseña no coincide");
                txtConfirmar.BackColor = Color.LightSkyBlue;
                e.Cancel = true;
                return;
            }
            errorModificarUsuario.Clear();
            txtConfirmar.BackColor = Color.White;
        }
    }
}
