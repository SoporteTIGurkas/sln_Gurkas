﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pl_Gurkas.Vista.Principal
{
    public partial class frmPrincialAdministrador : Form
    {
        public int _idempresa;
        public string _nombreempresa;
        public string _usuario;
        public string _perfil;
        public int _codrol;
        string ipuser = "";
        string nombrepc = "";
        string result = "";
        int estado = 0;
        Vista.ControlVistaFormulario controlvistaformulario = new Vista.ControlVistaFormulario();
        public frmPrincialAdministrador()
        {
            InitializeComponent();
        }

        private void crearUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Administrador.frmCreacionUsuario());
        }

        private void editarUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Administrador.frmActualizarEmpleado());
        }

        private void cambioContraseñaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Administrador.frmCambioContraseña());
        }

        private void asignarUnidadToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Administrador.frmAsignarUnidadUsuario());
        }

        private void reporteContraseñaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void modificarAsistenciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Administrador.frmCorreccionAsistencia());
        }

        private void generarArchivoDeAsistenciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Andorid.frmAsistenciAndroid());
        }

        private void frmPrincialAdministrador_Load(object sender, EventArgs e)
        {
            lblempresanombre.Text = Datos.DatosUsuario._nombreempresa;
            lblperfil.Text = Datos.DatosUsuario._perfil;
            lblusuario.Text = Datos.DatosUsuario._usuario;
            IsMdiContainer = true;
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            const string titulo = "Cerrar El modo Administrador";
            const string mensaje = "Estas seguro que deseas  El modo Administrador";
            var resutlado = MessageBox.Show(mensaje, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (resutlado == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void conexionAhInternetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Uri Url = new System.Uri("http://www.google.com/");
            System.Net.WebRequest WebRequest;
            WebRequest = System.Net.WebRequest.Create(Url);
            System.Net.WebResponse objResp;
            try
            {
                DateTime fecha = DateTime.Now;
                String anio = Convert.ToString(fecha.Year);
                objResp = WebRequest.GetResponse();
                result = "Su dispositivo está correctamente conectado a internet " + " Copyright © " + anio;
                estado = 1;
                objResp.Close();
                WebRequest = null;
                MessageBox.Show(result, "Conexion Exitosa");
            }
            catch (Exception ex)
            {
                result = "Error al intentar conectarse a internet ";
                estado = 2;
                WebRequest = null;
                MessageBox.Show(result, "Sin Conexion");
            }
        }

        private void conexionAlServidorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ping Pings = new Ping();
            int timeout = 10;

            if (Pings.Send("26.11.117.148", timeout).Status == IPStatus.Success)
            {
                DateTime fecha = DateTime.Now;
                String anio = Convert.ToString(fecha.Year);
                result = "Su dispositivo está correctamente conectado  al servidor " + " Copyright © " + anio;
                estado = 1;
                MessageBox.Show(result, "Conexion Exitosa");
            }
            else
            {
                result = "Error al intentar conectarse al sistema \n Verificar la conexion de la red VPN";
                estado = 2;
                MessageBox.Show(result, "Sin Conexion");
            }
        }
    }
}
