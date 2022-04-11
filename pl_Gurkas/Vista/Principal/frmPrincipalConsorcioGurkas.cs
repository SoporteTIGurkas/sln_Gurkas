using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pl_Gurkas.Vista.Principal
{
    public partial class frmPrincipalConsorcioGurkas : Form
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
        public frmPrincipalConsorcioGurkas()
        {
            InitializeComponent();
        }
        public void obtenerip_nombre()
        {
            string strHostName = string.Empty;
            // Obteniendo la dirección IP de la máquina local…
            // Primero obtenga el nombre de host de la máquina local.
            strHostName = Dns.GetHostName();
            // Luego, usando el nombre de host, obtenga la lista de direcciones IP.
            IPAddress[] hostIPs = Dns.GetHostAddresses(strHostName);
            for (int i = 0; i < hostIPs.Length; i++)
            {
                ipuser = "Direccion IP: " + hostIPs[i].ToString();

            }
            nombrepc = "Nombre de la computadora: " + strHostName;
        }

        public void perfiles()
        {
            int nivel = _codrol;
            if (nivel == 1)
            {
                recursosHumanosToolStripMenuItem.Enabled = true;
                centroDeControlToolStripMenuItem.Enabled = true;
                operacionesToolStripMenuItem.Enabled = true;
                comercialToolStripMenuItem.Enabled = true;
                logisticaToolStripMenuItem.Enabled = true;
                planillaToolStripMenuItem.Enabled = true;
                contabilidadToolStripMenuItem.Enabled = true;
                sucamecToolStripMenuItem.Enabled = true;
                administradorToolStripMenuItem.Enabled = true;
            }
            if (nivel == 2)
            {
                centroDeControlToolStripMenuItem.Enabled = false;
                operacionesToolStripMenuItem.Enabled = false;
                comercialToolStripMenuItem.Enabled = false;
                logisticaToolStripMenuItem.Enabled = false;
                planillaToolStripMenuItem.Enabled = false;
                contabilidadToolStripMenuItem.Enabled = false;
                sucamecToolStripMenuItem.Enabled = false;
                administradorToolStripMenuItem.Enabled = false;
            }
            if (nivel == 3)
            {
                recursosHumanosToolStripMenuItem.Enabled = false;
                //centroDeControlToolStripMenuItem.Enabled = false;
                operacionesToolStripMenuItem.Enabled = false;
                comercialToolStripMenuItem.Enabled = false;
                logisticaToolStripMenuItem.Enabled = false;
                planillaToolStripMenuItem.Enabled = false;
                contabilidadToolStripMenuItem.Enabled = false;
                sucamecToolStripMenuItem.Enabled = false;
                administradorToolStripMenuItem.Enabled = false;
            }
            if (nivel == 4)
            {
                recursosHumanosToolStripMenuItem.Enabled = false;
                centroDeControlToolStripMenuItem.Enabled = false;
                //operacionesToolStripMenuItem.Enabled = false;
                comercialToolStripMenuItem.Enabled = false;
                logisticaToolStripMenuItem.Enabled = false;
                planillaToolStripMenuItem.Enabled = false;
                contabilidadToolStripMenuItem.Enabled = false;
                sucamecToolStripMenuItem.Enabled = false;
                administradorToolStripMenuItem.Enabled = false;
            }
            if (nivel == 5)
            {
                recursosHumanosToolStripMenuItem.Enabled = false;
                centroDeControlToolStripMenuItem.Enabled = false;
                operacionesToolStripMenuItem.Enabled = false;
                // comercialToolStripMenuItem.Enabled = false;
                logisticaToolStripMenuItem.Enabled = false;
                planillaToolStripMenuItem.Enabled = false;
                contabilidadToolStripMenuItem.Enabled = false;
                sucamecToolStripMenuItem.Enabled = false;
                administradorToolStripMenuItem.Enabled = false;
            }
            if (nivel == 6)
            {
                recursosHumanosToolStripMenuItem.Enabled = false;
                centroDeControlToolStripMenuItem.Enabled = false;
                operacionesToolStripMenuItem.Enabled = false;
                comercialToolStripMenuItem.Enabled = false;
                // logisticaToolStripMenuItem.Enabled = false;
                planillaToolStripMenuItem.Enabled = false;
                contabilidadToolStripMenuItem.Enabled = false;
                sucamecToolStripMenuItem.Enabled = false;
                administradorToolStripMenuItem.Enabled = false;
            }
            if (nivel == 7)
            {
                recursosHumanosToolStripMenuItem.Enabled = false;
                centroDeControlToolStripMenuItem.Enabled = false;
                operacionesToolStripMenuItem.Enabled = false;
                comercialToolStripMenuItem.Enabled = false;
                logisticaToolStripMenuItem.Enabled = false;
                //planillaToolStripMenuItem.Enabled = false;
                contabilidadToolStripMenuItem.Enabled = false;
                sucamecToolStripMenuItem.Enabled = false;
                administradorToolStripMenuItem.Enabled = false;
            }
            if (nivel == 8)
            {
                recursosHumanosToolStripMenuItem.Enabled = false;
                centroDeControlToolStripMenuItem.Enabled = false;
                operacionesToolStripMenuItem.Enabled = false;
                comercialToolStripMenuItem.Enabled = false;
                logisticaToolStripMenuItem.Enabled = false;
                planillaToolStripMenuItem.Enabled = false;
                //contabilidadToolStripMenuItem.Enabled = false;
                sucamecToolStripMenuItem.Enabled = false;
                administradorToolStripMenuItem.Enabled = false;
            }
            if (nivel == 9)
            {
                recursosHumanosToolStripMenuItem.Enabled = false;
                centroDeControlToolStripMenuItem.Enabled = false;
                operacionesToolStripMenuItem.Enabled = false;
                comercialToolStripMenuItem.Enabled = false;
                logisticaToolStripMenuItem.Enabled = false;
                planillaToolStripMenuItem.Enabled = false;
                contabilidadToolStripMenuItem.Enabled = false;
                //sucamecToolStripMenuItem.Enabled = false;
                administradorToolStripMenuItem.Enabled = false;
            }
        }
        private void frmPrincipalConsorcioGurkas_Load(object sender, EventArgs e)
        {
            lblempresanombre.Text = _nombreempresa;
            lblperfil.Text = _perfil;
            lblusuario.Text = _usuario;
            IsMdiContainer = true;
            perfiles();
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

        private void vercionToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            const string titulo = "Cerrar Sesión";
            const string mensaje = "Estas seguro que deseas Cerrar Sesión";
            var resutlado = MessageBox.Show(mensaje, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (resutlado == DialogResult.Yes)
            {
                DateTime fecha = DateTime.Now;
                obtenerip_nombre();
                //  string username = tsNombre.Text;
                //   string detalle = "Cerrar Sesion";
                // registrar.RegistrarLogin(fecha, nombrepc, username, ipuser, detalle);
                this.Close();
                Vista.frmLogin objLogin = new Vista.frmLogin();
                objLogin.Show();
            }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            const string titulo = "Exit";
            const string mensaje = "Estas seguro que deseas Cerrar el Sistema";
            var resutlado = MessageBox.Show(mensaje, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (resutlado == DialogResult.Yes)
            {
                DateTime fecha = DateTime.Now;
                obtenerip_nombre();
                //string username = tsNombre.Text;
                //  string detalle = "Cerrar el Sistema";
                //  registrar.RegistrarLogin(fecha, nombrepc, username, ipuser, detalle);
                Application.Exit();
            }
        }

        private void registroDePersonalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.RRHH.frmRegistroDatosPersonal());
        }

        private void registroDeDatosFamiliaresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.RRHH.frmRegistroDatosFamiliarez());
        }

        private void registroDeDatosLaboralesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.RRHH.frmRegistrarDatosLaboralesRRHH());
        }

        private void reporteGeneralToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.RRHH.ReportesRRHH.frmReporteGenrenalPersonal());
        }

        private void personalPorUnidadToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.RRHH.ReportesRRHH.frmPersonalPorUnidad());
        }

        private void personalPorSedeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.RRHH.ReportesRRHH.frmPersonalPorSede());
        }

        private void personalPorEdadToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.RRHH.ReportesRRHH.frmPersonalPorEdad());
        }

        private void personalPorEmpresaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.RRHH.ReportesRRHH.frmPersonalPorEmpresa());
        }

        private void personalPorEstaturaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.RRHH.ReportesRRHH.frmEstaturaPersonal());
        }

        private void personalPorTurnoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.RRHH.ReportesRRHH.frmTurnoEmpleado());
        }

        private void personalPorFechaInicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.RRHH.ReportesRRHH.frmPersonalPorFechaIngreso());
        }

        private void asistenciaDePersonalToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.RRHH.ReportesRRHH.frmAsistenciaPersonaIndividual());
        }

        private void asistenciaGeneralDePersoanalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.RRHH.ReportesRRHH.frmAsistenciaGneralPersonal());
        }

        private void asistenciaPorUnidadToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.RRHH.ReportesRRHH.frmAsistenciaPersonalPorUnidad());
        }

        private void asistenciaPorSedeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.RRHH.ReportesRRHH.frmAsistenciaGeneralPersonalPorSede());
        }

        private void asistenciaDePersonalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.CentroControl.frmAsistenciaPersonal());
        }

        private void cantidadDeAsistencaiDeCadaSedeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.CentroControl.ReporteCentroControl.frmConsultaDeCantidadDeAsistenciaDeCadaSede());
        }

        private void marcacionPorFechaYTurnoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.CentroControl.ReporteCentroControl.frmReportedeMarcacionpoFecahYturno());
        }

        private void consultaDeAsistenciaPorPersonalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.CentroControl.ReporteCentroControl.fmrConsultaDeAsistenciaPorPersonal());
        }

        private void asistenciaGeneralDelPersonalDetalladoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.CentroControl.ReporteCentroControl.frmAsistenciaDetalladoPorEmpleado());
        }

        private void asistenciaDePersonalPorDiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.CentroControl.ReporteAsistencia.frmPersonalsistenciaporDia());
        }

        private void personalSinMarcacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.CentroControl.ReporteAsistencia.frmPersonalSinMarcacion());
        }

        private void asistenciaDePersonalToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.CentroControl.ReporteAsistencia.frmAsistenciadePersonal());
        }

        private void asistenciaDePersonalDetalladoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.CentroControl.ReporteAsistencia.frmAsistenciaDePersonalDetallado());
        }

        private void activarUnidadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Operaciones.Unidad.frmActivarUnidad());
        }

        private void activarSedeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Operaciones.Sede.frmSede());
        }

        private void consultaDeAsistenciaPorPersonalToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Operaciones.ReporteOperaciones.frmConsultadeAsistenciaPersonal());
        }

        private void crearUnidadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Comercial.frmCreacionUnidad());
        }

        private void creacionDeSedeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Comercial.frmCreacionSedes());
        }

        private void asistenciaDePersonalToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Comercial.ReporteComercial.frmAsistenciaPersonal());
        }

        private void asistenciaDePersonalDetalladoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Comercial.ReporteComercial.frmAsistenciaPersonalDetallado());
        }

        private void consultaDeAsistenciaPorPersonalToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Comercial.ReporteComercial.frmConusltaAsistenciaPersonal());
        }

        private void detalleDeEmpleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Comercial.ReporteComercial.frmDetalleEmpleado());
        }

        private void registroDeDatosLaboralesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Planilla.frmRegistrarDatosLaborales());
        }

        private void actualizarDatosLaboralesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Planilla.frmActualizarDatosLaboralesPlanilla());
        }

        private void actualizarComisionAFPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Planilla.AFP.frmActualizarComisionAFP());
        }

        private void reporteDeAsistenciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Planilla.ReportePlanilla.frmReporteAsistenciaPersonal());
        }

        private void reporteDeDatosGeneralesDePlanillaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Planilla.ReportePlanilla.frmDatosGeneralesPlanilla());
        }

        private void historialEmpleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Planilla.ReportePlanilla.frmHistorialDatosEmpleado());
        }

        private void bajasDeEmpleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Planilla.ReportePlanilla.frmBajasPersonal());
        }

        private void calculoPorDiasLaboradosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Planilla.frmPlataformaCalculoPlanilla());
        }

        private void cargaDeAsistenciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Planilla.CargaDeDatos.frmCargaDeDatosAsistencia());
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

        private void modificarAsistenciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Administrador.frmCorreccionAsistencia());
        }

        private void archivoPLAMEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Planilla.Plame.frmPlataformaPlame());
        }

        private void calculoDeVacacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Planilla.frmCalculoDeVacaciones());
        }

        private void calculoDeOtrasLicenciasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Planilla.frmCalculoDeOtrasLicencia());
        }

        private void calculoDeDescansoMedicoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Planilla.frmCalculoDeDescansoMedico());
        }

        private void historialDePlanillaPorDiasLaboradosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Planilla.HistorialPlanilla.frmHistorialPlanillaDiasLaborados());
        }

        private void historialDePlanillaDeVacacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Planilla.HistorialPlanilla.frmHistorialPlanillaVacaciones());
        }

        private void historialDePlanillaDeOtrasLicenciasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Planilla.HistorialPlanilla.frmHistorialOtrasLicencias());
        }

        private void historialDePlanillaDeDescansoMedicoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Planilla.HistorialPlanilla.frmHistorialDescansoMedico());
        }

        private void datosPersonalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Sucamec.frmPersonalConsulta());
        }

        private void reporteGeneralToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.RRHH.ReportesRRHH.frmReporteGenrenalPersonal());
        }

        private void reportePorUnidadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.RRHH.ReportesRRHH.frmPersonalPorUnidad());
        }

        private void personalPorSedeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.RRHH.ReportesRRHH.frmPersonalPorSede());
        }

        private void personalPorEdadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.RRHH.ReportesRRHH.frmPersonalPorEdad());
        }

        private void personalPorEmpresaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.RRHH.ReportesRRHH.frmPersonalPorEmpresa());
        }

        private void personalPorEstaturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.RRHH.ReportesRRHH.frmEstaturaPersonal());
        }

        private void personalPorTurnoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.RRHH.ReportesRRHH.frmTurnoEmpleado());
        }

        private void personalPorFechaIngresoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.RRHH.ReportesRRHH.frmPersonalPorFechaIngreso());
        }

        private void asistenciaDePersonalToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.RRHH.ReportesRRHH.frmAsistenciaPersonaIndividual());
        }

        private void asistenciaGeneralDePersonalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.RRHH.ReportesRRHH.frmAsistenciaGneralPersonal());
        }

        private void asistenciaPorUnidadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.RRHH.ReportesRRHH.frmAsistenciaPersonalPorUnidad());
        }

        private void asistenciaPorSedeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.RRHH.ReportesRRHH.frmAsistenciaGeneralPersonalPorSede());
        }

        private void codigoYEstadoPersonalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Logistica.Reporte.frmReportePersonal());
        }

        private void bajaDePersonalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Planilla.ReportePlanilla.frmBajasPersonal());
        }

        private void reporteDeBajaDePersonalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Planilla.ReportePlanilla.frmBajasPersonal());
        }

        private void reporteDeAsistenciaPorPersonalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Operaciones.ReporteOperaciones.frmConsultadeAsistenciaPersonal());
        }

        private void marcacionPorFechaYTurnoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.CentroControl.ReporteCentroControl.frmReportedeMarcacionpoFecahYturno());
        }

        private void consultaDeAsistenciaPorPersonalToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.CentroControl.ReporteCentroControl.fmrConsultaDeAsistenciaPorPersonal());
        }

        private void bloqueosDePersonalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.CentroControl.CargaDeDatos.frmBloqueosPersonal());
        }

        private void personalSinMarcacionToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.CentroControl.ReporteAsistencia.frmPersonalSinMarcacion());
        }

        private void estadoDePersonalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Operaciones.ReporteOperaciones.frmEstadoPersonal());
        }

        private void listaDePersonalBloqueosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Planilla.Bloqueos.frmCuadroDeBloqueos());
        }

        private void reportePorTurnoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Planilla.ReportePlanilla.frmPagoTurnosEmpleados());
        }

        private void reporteDeBloqueosDePersonalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.CentroControl.ReporteCentroControl.frmBloqueosPersonal());
        }

        private void estadoPersonalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new RRHH.frmActualizarEstadoPersonal());
        }

        private void sueldoPersonalUnidadSueldoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Planilla.SueldoEmpleado.frmSueldoEmpleado());
        }
    }
}
