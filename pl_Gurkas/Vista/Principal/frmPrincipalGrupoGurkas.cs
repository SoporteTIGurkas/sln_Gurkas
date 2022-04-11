using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pl_Gurkas.Vista.Principal
{
    public partial class frmPrincipalGrupoGurkas : Form
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
        Datos.Conexiondbo conexion = new Datos.Conexiondbo();
        Datos.AuditoriaModulos modulo = new Datos.AuditoriaModulos();

        Vista.ControlVistaFormulario controlvistaformulario = new Vista.ControlVistaFormulario();
        public frmPrincipalGrupoGurkas()
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

        private void frmPrincipalGrupoGurkas_Load(object sender, EventArgs e)
        {
            lblempresanombre.Text = _nombreempresa;
            lblperfil.Text = _perfil;
            lblusuario.Text = _usuario;
            IsMdiContainer = true;
            perfiles();
        }

        private void autorModulo(string modulo)
        {
            string hora = DateTime.Now.ToString("hh:mm:ss tt");
            string _nombre = Datos.DatosUsuario._usuario;
            SqlCommand comando2 = new SqlCommand("sp_insertarHistorialModulo", conexion.conexionBD());
            comando2.CommandType = CommandType.StoredProcedure;
            comando2.Parameters.AddWithValue("@Usuario", _nombre);
            comando2.Parameters.AddWithValue("@Modulo", modulo);
            comando2.Parameters.AddWithValue("@hora ", hora);
            comando2.ExecuteNonQuery();
        }
        private void registroDePersonalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.RRHH.frmRegistroDatosPersonal());
            modulo.auditoria("Recursos Humanos","Personal","Registro de Datos Personales RRHH","");
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

                modulo.auditoria("Archivos","Salir del Sistema por Completo","", "");

                Application.Exit();
            }
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

                modulo.auditoria("Archivos","Cerrar Sesión Sistema","", "");

                this.Close();
                Vista.frmLogin objLogin = new Vista.frmLogin();
                objLogin.Show();
            }
        }
        private void crearUnidadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Comercial.frmCreacionUnidad());
            modulo.auditoria("Comercial", "Unidad", "Creacion de Unidad", "");
        }

        private void creacionDeSedeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Comercial.frmCreacionSedes());
            modulo.auditoria("Comercial", "Sede", "Creacion de Sede", "");
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

        private void asistenciaDePersonalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.CentroControl.frmAsistenciaPersonal());
            modulo.auditoria("Modulo de Centro de Control", "Tareaje de Personal","","");
        }
        private void personalPorSedeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.RRHH.ReportesRRHH.frmPersonalPorSede());
            modulo.auditoria("Recursos Humanos","Modulo de Reporte", "Reporte de Personal","Personal Por Sede");
        }

        private void personalPorEdadToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.RRHH.ReportesRRHH.frmPersonalPorEdad());
            modulo.auditoria("Recursos Humanos","Modulo de Reporte", "Reporte de Personal","Personal Por Edad");
        }

        private void personalPorEmpresaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.RRHH.ReportesRRHH.frmPersonalPorEmpresa());
            modulo.auditoria("Recursos Humanos","Modulo de Reporte","Reporte de Personal"," / Personal Por Empresa");
        }

        private void personalPorEstaturaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.RRHH.ReportesRRHH.frmEstaturaPersonal());
            modulo.auditoria("Recursos Humanos","Modulo de Reporte","Reporte de Personal","Personal Por Estatura");
        }

        private void personalPorTurnoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.RRHH.ReportesRRHH.frmTurnoEmpleado());
            modulo.auditoria("Recursos Humanos","Modulo de Reporte","Reporte de Personal","Personal Por Turno");
        }

        private void personalPorFechaInicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.RRHH.ReportesRRHH.frmPersonalPorFechaIngreso());
            modulo.auditoria("Recursos Humanos","Modulo de Reporte","Reporte de Personal","Personal Por Fecha Ingreso");
        }

        private void asistenciaDePersonalToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.RRHH.ReportesRRHH.frmAsistenciaPersonaIndividual());
            modulo.auditoria("Recursos Humanos","Modulo de Reporte","Reporte de Asistencia de Personal","Asistencia de Personal");
        }

        private void asistenciaGeneralDePersoanalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.RRHH.ReportesRRHH.frmAsistenciaGneralPersonal());
            modulo.auditoria("Recursos Humanos","Modulo de Reporte","Reporte de Asistencia de Personal","Asistencia de General de Personal");
        }

        private void asistenciaPorSedeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.RRHH.ReportesRRHH.frmAsistenciaGeneralPersonalPorSede());
            modulo.auditoria("Recursos Humanos","Modulo de Reporte","Reporte de Asistencia de Personal","Asistencia por Sede");
        }

        private void asistenciaPorUnidadToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.RRHH.ReportesRRHH.frmAsistenciaPersonalPorUnidad());
            modulo.auditoria("Recursos Humanos","Modulo de Reporte","Reporte de Asistencia de Personal","Asistencia de Personal");
        }

        private void personalPorUnidadToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.RRHH.ReportesRRHH.frmPersonalPorUnidad());
            modulo.auditoria("Recursos Humanos","Modulo de Reporte","Reporte de Personal","Personal Por Unidad");
        }

        private void reporteGeneralToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.RRHH.ReportesRRHH.frmReporteGenrenalPersonal());
            modulo.auditoria("Recursos Humanos","Modulo de Reporte","Reporte General","");
        }

        private void activarUnidadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Operaciones.Unidad.frmActivarUnidad());
            modulo.auditoria("Operaciones", "Unidad", "Activar Unidad", "");
        }

        private void registroDeDatosFamiliaresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.RRHH.frmRegistroDatosFamiliarez());
            modulo.auditoria("Recursos Humanos","Personal","Registro de Datos Familiares RRHH","");
        }

        private void registroDeDatosLaboralesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.RRHH.frmRegistrarDatosLaboralesRRHH());
            modulo.auditoria("Recursos Humanos", "Personal", "Registro de Datos Laborales RRHH","");
        }

        private void registroDeDatosLaboralesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Planilla.frmRegistrarDatosLaborales());
        }

        private void moverPersonalEntreEmpresaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.RRHH.frmMoverEmpresa());
            modulo.auditoria("Recursos Humanos","Mover Personal Entre Empresa","","");
        }

        private void actualizarComisionAFPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Planilla.AFP.frmActualizarComisionAFP());
        }

        private void reporteDeAsistenciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Planilla.ReportePlanilla.frmReporteAsistenciaPersonal());
        }

        private void calculoPorDiasLaboradosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Planilla.frmPlataformaCalculoPlanilla());
        }

        private void cargaDeAsistenciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Planilla.CargaDeDatos.frmCargaDeDatosAsistencia());
        }

        private void cantidadDeAsistencaiDeCadaSedeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new  Vista.CentroControl.ReporteCentroControl.frmConsultaDeCantidadDeAsistenciaDeCadaSede());
            modulo.auditoria("Centro de Control","Reportes - C. CONTROL","Cantidad de Asistencia de Cada Sede","");
        }

        private void marcacionPorFechaYTurnoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.CentroControl.ReporteCentroControl.frmReportedeMarcacionpoFecahYturno());
            modulo.auditoria("Centro de Control","Reportes - C. CONTROL","Marcacion por Fecha y Turno","");
        }

        private void consultaDeAsistenciaPorPersonalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.CentroControl.ReporteCentroControl.fmrConsultaDeAsistenciaPorPersonal());
            modulo.auditoria("Centro de Control","Reportes - C. CONTROL","Consulta de Asistencia por personal","");
        }

        private void asistenciaGeneralDelPersonalDetalladoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.CentroControl.ReporteCentroControl.frmAsistenciaDetalladoPorEmpleado());
            modulo.auditoria("Centro de Control","Reportes - C. CONTROL","Asistencia General del Personal Detallado","");
        }

        private void asistenciaDePersonalPorDiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.CentroControl.ReporteAsistencia.frmPersonalsistenciaporDia());
            modulo.auditoria("Centro de Control","Reporte Asistencia","Asistencia de Personal por Dia","");
        }

        private void personalSinMarcacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.CentroControl.ReporteAsistencia.frmPersonalSinMarcacion());
            modulo.auditoria("Centro de Control","Reporte Asistencia","Personal sin Marcacion","");
        }

        private void asistenciaDePersonalToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.CentroControl.ReporteAsistencia.frmAsistenciadePersonal());
            modulo.auditoria("Centro de Control","Reporte Asistencia","Asistencia de Personal","");
        }

        private void asistenciaDePersonalDetalladoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.CentroControl.ReporteAsistencia.frmAsistenciaDePersonalDetallado());
            modulo.auditoria("Centro de Control","Reporte Asistencia","Asistencia de Personal Detallado","");
        }

        private void activarSedeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Operaciones.Sede.frmSede());
            modulo.auditoria("Operaciones", "Sede", "Activar Sede", "");
        }

        private void consultaDeAsistenciaPorPersonalToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Operaciones.ReporteOperaciones.frmConsultadeAsistenciaPersonal());
            modulo.auditoria("Operaciones", "Reporte", "Consulta de Asistencia por Personal", "");
        }

        private void asistenciaDePersonalToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Comercial.ReporteComercial.frmAsistenciaPersonal());
            modulo.auditoria("Comercial", "Reporte", "Asistencia de Personal", "");
        }

        private void asistenciaDePersonalDetalladoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Comercial.ReporteComercial.frmAsistenciaPersonalDetallado());
            modulo.auditoria("Comercial", "Reporte", "Asistencia de Personal Detallado", "");
        }

        private void consultaDeAsistenciaPorPersonalToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Comercial.ReporteComercial.frmConusltaAsistenciaPersonal());
            modulo.auditoria("Comercial", "Reporte", "Consulta de Asistencia por Personal", "");
        }

        private void detalleDeEmpleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Comercial.ReporteComercial.frmDetalleEmpleado());
            modulo.auditoria("Comercial", "Reporte", "Detalle de Empleados", "");
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

        private void actualizarDatosLaboralesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Planilla.frmActualizarDatosLaboralesPlanilla());
        }

        private void historialEmpleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Planilla.ReportePlanilla.frmHistorialDatosEmpleado());
        }

        private void reporteDeDatosGeneralesDePlanillaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Planilla.ReportePlanilla.frmDatosGeneralesPlanilla());
        }

        private void bajasDeEmpleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Planilla.ReportePlanilla.frmBajasPersonal());
        }

        private void modificarAsistenciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Administrador.frmCorreccionAsistencia());
        }

        private void vercionToolStripMenuItem_Click(object sender, EventArgs e)
        {

            modulo.auditoria("Archivos","Comprobar la vercion del sistema  Gurkas","","");
        }

        private void reporteContraseñaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void historialDePlanillaPorDiasLaboradosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Planilla.HistorialPlanilla.frmHistorialPlanillaDiasLaborados());
        }

        private void calculoDeVacacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Planilla.frmCalculoDeVacaciones());
        }

        private void calcularToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Planilla.frmCalculoDeOtrasLicencia());
        }

        private void calculoDeDescansoMedicoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Planilla.frmCalculoDeDescansoMedico());
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

        private void archivoPLAMEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Planilla.Plame.frmPlataformaPlame());
        }

        private void boletaDePagoIndividualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Planilla.frmBoletaPago());
        }

        private void cardarBoletasPlameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Planilla.datosplame.xmlPlame());
        }

        private void estadoDelPersonalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new RRHH.frmActualizarEstadoPersonal());
            modulo.auditoria("Recursos Humanos","Modulo de Estado de Personal","","");
        }

        private void codigoYEstadoPersonalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Logistica.Reporte.frmReportePersonal());
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.RRHH.ReportesRRHH.frmReporteGenrenalPersonal());
            modulo.auditoria("Sucamec","Reportes","Reporte General", "");
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.RRHH.ReportesRRHH.frmPersonalPorUnidad());
            modulo.auditoria("Sucamec","Reportes","Reporte de Personal", "Personal por Unidad");
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.RRHH.ReportesRRHH.frmPersonalPorSede());
            modulo.auditoria("Sucamec", "Reportes","Reporte de Personal", "Personal por Sede");
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.RRHH.ReportesRRHH.frmPersonalPorEdad());
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.RRHH.ReportesRRHH.frmPersonalPorEmpresa());
            modulo.auditoria("Sucamec", "Reportes", "Reporte de Personal", "Personal por Empresa");
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.RRHH.ReportesRRHH.frmEstaturaPersonal());
            modulo.auditoria("Sucamec", "Reportes", "Reporte de Personal", "Personal por Estatura");
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.RRHH.ReportesRRHH.frmTurnoEmpleado());
            modulo.auditoria("Sucamec", "Reportes", "Reporte de Personal", "Personal por Turno");
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.RRHH.ReportesRRHH.frmPersonalPorFechaIngreso());
            modulo.auditoria("Sucamec", "Reportes", "Reporte de Personal", "Personal por Fecha Ingreso");
        }

        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.RRHH.ReportesRRHH.frmAsistenciaPersonaIndividual());
            modulo.auditoria("Sucamec", "Reportes", "Reporte de Asistencia de Personal", "Asistencia de Personal");
        }

        private void toolStripMenuItem13_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.RRHH.ReportesRRHH.frmAsistenciaGneralPersonal());
            modulo.auditoria("Sucamec", "Reportes", "Reporte de Asistencia de Personal", "Asistencia General de Personal");
        }

        private void toolStripMenuItem14_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.RRHH.ReportesRRHH.frmAsistenciaPersonalPorUnidad());
            modulo.auditoria("Sucamec", "Reportes", "Reporte de Asistencia de Personal", "Asistencia por Unidad");
        }

        private void toolStripMenuItem15_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.RRHH.ReportesRRHH.frmAsistenciaGeneralPersonalPorSede());
            modulo.auditoria("Sucamec", "Reportes", "Reporte de Asistencia de Personal", "Asistencia por Sede");

        }

        private void bajaDePersonalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Planilla.ReportePlanilla.frmBajasPersonal());
            modulo.auditoria("Recursos Humanos","Modulo de Reporte","Reporte de Baja de Personal","");
        }

        private void datosPersonalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Sucamec.frmPersonalConsulta());
            modulo.auditoria("Sucamec", "Datos Personal", "", "");
        }

        private void toolStripMenuItem16_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Planilla.ReportePlanilla.frmBajasPersonal());
            modulo.auditoria("Sucamec", "Reportes", "Reporte de Asistencia de Personal", "Reporte de Baja de Personal");
        }

        private void reporteDeAsistenciaPorPersonalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Operaciones.ReporteOperaciones.frmConsultadeAsistenciaPersonal());
            modulo.auditoria("Sucamec", "Reporte de Asistencia por Personal", "", "");
        }

        private void bloqueosDePersonalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.CentroControl.CargaDeDatos.frmBloqueosPersonal());
            modulo.auditoria("Centro de Control","Bloqueos de Personal","Carga de Bloqueos de Personal","");
        }

        private void marcacionPorFechaYTurnoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.CentroControl.ReporteCentroControl.frmReportedeMarcacionpoFecahYturno());
        }

        private void consultaDeAsistenciaPorPersonalToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.CentroControl.ReporteCentroControl.fmrConsultaDeAsistenciaPorPersonal());
        }

        private void personalSinMarcacionToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.CentroControl.ReporteAsistencia.frmPersonalSinMarcacion());
            modulo.auditoria("Operaciones", "Reporte", "Personal sin Marcacion", "");
        }

        private void estadoDePersonalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Operaciones.ReporteOperaciones.frmEstadoPersonal());
            modulo.auditoria("Operaciones", "Reporte", "Estado de Personal", "");
        }

        private void listaDePersonalBloqueosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Planilla.Bloqueos.frmCuadroDeBloqueos());
        }

        private void reporteDeTurnoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Planilla.ReportePlanilla.frmPagoTurnosEmpleados());
        }

        private void reporteDeBloqueosDePersonalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.CentroControl.ReporteCentroControl.frmBloqueosPersonal());
            modulo.auditoria("Centro de Control","Bloqueos de Personal","Reporte de Bloqueos de Personal","");
        }

        private void generarArchivoDeAsistenciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Andorid.frmAsistenciAndroid());
        }

        private void sueldoPersonalUnidadSueldoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Planilla.SueldoEmpleado.frmSueldoEmpleado());
        }

        private void cargaMasivaDeDatosLaboralesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.RRHH.CargaDatos.frmCargaDatosIngresantesPlanillas());
            modulo.auditoria("Recursos Humanos","Carga Masiva de los Datos Laborales","","");
        }

        private void cargaDeDatosCTSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Planilla.CTS.frmCargaDeDatosCTS());
        }

        private void nuevaEntradaDeProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Logistica.entrada.frmEntradaProducto());
        }

        private void buscarSalidaDeProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Logistica.entrada.frmBuscarEntradaProducto());
        }

        private void historialDeSalidaDeProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Logistica.entrada.HistorialEntradaProducto());
        }

        private void nuevaSalidaDeProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Logistica.salida.frmSalidaDeProducto());
        }

        private void buscarSalidaDeProductoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Logistica.salida.frmBuscarSalidaProducto());
        }

        private void historialDeSalidaDeProductoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Logistica.salida.frmHistorialSalidaProducto());
        }

        private void nuevoProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Logistica.producto.frmNuevoProducto());
        }

        private void registrarProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Logistica.Proveedores.frmRegistrarProveedor());
        }

        private void calculoDeCTSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Planilla.CTS.frmCalculoCTS());
        }

        private void cargaDeDatosGratificacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Planilla.GRATIFICACION.frmGuardarGrati());
        }

        private void calculoGratificacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Planilla.GRATIFICACION.frmCalculoGrati());
        }

        private void historialDePlanillaDeCTSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Planilla.HistorialPlanilla.frmHistorialCTS());
        }

        private void historialDePlanillaDeGratificacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Planilla.HistorialPlanilla.frmHistorialGrati());
        }

        private void cargaDeBloqueosDePersonalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.CentroControl.CargaDeDatos.frmBloqueosPersonal());
        }

        private void activarModoAdministradorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlvistaformulario.ControlVista(this, new Vista.Administrador.frmContrasena());
            modulo.auditoria("Administrador", "Activar Modo Administrador","", "");
        }
    }
}
