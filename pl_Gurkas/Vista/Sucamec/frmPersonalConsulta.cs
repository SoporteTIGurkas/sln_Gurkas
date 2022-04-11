using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pl_Gurkas.Vista.Sucamec
{
    public partial class frmPersonalConsulta : Form
    {
        Datos.Conexiondbo conexion = new Datos.Conexiondbo();
        Datos.LlenadoDatosSucamec Llenadocbo = new Datos.LlenadoDatosSucamec();

        public frmPersonalConsulta()
        {
            InitializeComponent();
        }
        private void LLenadoComboBox()
        {
            Llenadocbo.ObtenerEmpresaSucamec_2(cboEmpresa);
            Llenadocbo.ObtenerTipoDocumentoSucamec(cboTipoDocIdentEmp);
            Llenadocbo.ObtenerTipoSexoSucamec(cboSexoEmp);
            Llenadocbo.ObtenerBreveteSucamec(cboBrevete);
            Llenadocbo.ObtenerNacionalidadSucamec(cboNacionalidad);
            Llenadocbo.ObtenerHorasLaboralesSucamec(cboHorasLaborales);
            Llenadocbo.ObtenerEstadoCivilSucamec(cboEstadoCivilEmp);
            Llenadocbo.ObtenerGradoInstruccionSucamec(cboGradoInstruccionEmp);
            Llenadocbo.ObtenerEstadoPersonalSucamec(cboEstadoEmp);
            Llenadocbo.ObtenerPuestoSucamec(cboCargoLaboral);
            Llenadocbo.ObtenerTipoContratoSucamec(cboTipoContratoEmp);
            Llenadocbo.ObtenerTurnoSucamec(cboTurnoEmp);
            Llenadocbo.ObtenerTallaSucamec(cboTallaPrenda);
            Llenadocbo.ObtenerEstadoArmadoSucamec(cboArmado);
            Llenadocbo.ObtenerDepartamentoSucamec(cboDepartamento);
            Llenadocbo.ObtenerUnidadSucamec(cboUnidad);
            Llenadocbo.ObtenerPersonalSucamec(cboempleadoActivo);
        }

        private void frmPersonalConsulta_Load(object sender, EventArgs e)
        {
            LLenadoComboBox();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string codEmpleado = cboempleadoActivo.SelectedValue.ToString();

                SqlCommand comando = new SqlCommand("SELECT * FROM V_DetallePersonal WHERE Cod_empleado = '" + codEmpleado + "'", conexion.conexionBD());

                SqlDataReader recorre = comando.ExecuteReader();
                while (recorre.Read())
                {
                    txtCodEmpleado.Text = recorre["Cod_empleado"].ToString();
                    txtNombreEmp.Text = recorre["NOMBRE_EMPLEADO"].ToString();
                    txtApPaternoEmp.Text = recorre["APELLIDO_PATERNO"].ToString();
                    txtApMateEmp.Text = recorre["APELLIDO_MATERNO"].ToString();
                    txtEdadEmp.Text = recorre["EDAD_EMPLEADO"].ToString();
                    cboTipoDocIdentEmp.SelectedIndex = Convert.ToInt32(recorre["ID_TIPO_DOCT"].ToString());
                    txtNumDocIdentEmpl.Text = recorre["DOCT_IDENT"].ToString();
                    cboSexoEmp.SelectedIndex = Convert.ToInt32(recorre["Id_sexo"].ToString());
                    dtpCaducacion.Text = (recorre["FECHA_CADUCIDAD_DOC_IDENTIDAD"].ToString());
                    dtpEmicion.Text = (recorre["FECHA_EMISION_DOC_IDENTIDAD"].ToString());
                    dtpNacimiento.Text = (recorre["FECHA_NACIMIENTO_EMPLEADO"].ToString());
                    cboBrevete.SelectedIndex = Convert.ToInt32(recorre["ID_TIPO_BREVETE"].ToString());
                    txtNumBrevete.Text = recorre["NUM_BREVETE"].ToString();
                    cboNacionalidad.SelectedIndex = Convert.ToInt32(recorre["ID_NACIONALIDAD"].ToString());
                    txtDomicilio.Text = recorre["DIRECCION_PERSONAL"].ToString();
                    txtTelefono.Text = recorre["TELEFONO"].ToString();
                    txtCelular.Text = recorre["Celular"].ToString();
                    txtCorreo.Text = recorre["Correo"].ToString();
                    cboGradoInstruccionEmp.SelectedIndex = Convert.ToInt32(recorre["ID_GRADO_INSTRUCCION"].ToString());
                    cboEstadoCivilEmp.SelectedIndex = Convert.ToInt32(recorre["ID_ESTADO_CIVIL"].ToString());
                    cboCargoLaboral.SelectedIndex = Convert.ToInt32(recorre["ID_PUESTO"].ToString());
                    cboEmpresa.SelectedIndex = Convert.ToInt32(recorre["ID_EMPRESA"].ToString());
                    cboTipoContratoEmp.SelectedIndex = Convert.ToInt32(recorre["ID_TIPO_CONTRATO"].ToString());
                    dtpFechaInicio.Text = (recorre["FECHA_INICIO_CONTRATO"].ToString());
                    dtpFechaFin.Text = (recorre["FECHA_FIN_CONTRATO"].ToString());
                    string unidad = recorre["Razon_social"].ToString();
                    cboUnidad.SelectedIndex = cboUnidad.FindStringExact(unidad);
                    string sede = recorre["Nombre_sede"].ToString();
                    cboSede.SelectedIndex = cboSede.FindStringExact(sede);
                    cboEstadoEmp.SelectedIndex = Convert.ToInt32(recorre["ID_ESTADO_PERSONAL"].ToString());
                    cboTurnoEmp.SelectedIndex = Convert.ToInt32(recorre["ID_TURNO_EMPLEADO"].ToString());
                    cboTallaPrenda.SelectedIndex = Convert.ToInt32(recorre["ID_TALLA_PRENDA"].ToString());
                    txtTallaPantalonEmp.Text = recorre["Talla_pantalon"].ToString();
                    txtTallaCalzadoEmp.Text = recorre["Talla_zapato"].ToString();
                    txtEstaturaEmp.Text = recorre["ESTATURA_PERSONAL"].ToString();
                    cboHorasLaborales.SelectedIndex = Convert.ToInt32(recorre["ID_HORAS_LABORALES"].ToString());
                    txtCodUbigeo.Text = recorre["COD_UBIGEO"].ToString();
                    cboDepartamento.SelectedValue = recorre["Cod_Departamento"].ToString();
                    cboProvincia.SelectedValue = recorre["Cod_Provincia"].ToString();
                    cboDis.SelectedValue = recorre["Cod_Distrito"].ToString();

                    cboArmado.SelectedIndex = Convert.ToInt32(recorre["ID_ESTADO_ARMADO"].ToString());
                    dtpFinicioLaboral.Text = (recorre["FECHA_INICIO_LABORAL"].ToString());
                    dtpFechaFinLaboral.Text = (recorre["FECHA_FIN_LABORAL"].ToString());
                    dtpFechaActivacion.Text = (recorre["FECHA_ACTIVACION_PERSONAL"].ToString());
                    dtpUltimoDestaque.Text = (recorre["FECHA_DESTAQUE_PERSONAL"].ToString());
                }

            }
            catch (Exception err)
            {
                MessageBox.Show("No se encontro ningun registro \n\n" + err, "ERROR");
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            const string titulo = "Cerrar Registro de Personal";
            const string mensaje = "Estas seguro que deseas cerra el Registro de Personal";
            var resutlado = MessageBox.Show(mensaje, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (resutlado == DialogResult.Yes)
            {
                //  DateTime fecha = DateTime.Now;
                //  obtenerip_nombre();
                // string username = Code.nivelUser._nombre;
                // string detalle = "Cerrar Registro de Personal";
                // string cod_buscado = "Cerro el registro de Personal";
                // registrar.RegistrarRRHH(fecha, nombrepc, username, ipuser, cod_buscado, detalle);
                this.Close();
            }
        }

        private void cboUnidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboUnidad.SelectedValue.ToString() != null)
            {
                string cod_unidad = cboUnidad.SelectedValue.ToString();
                Llenadocbo.ObtenerSedeSucamec(cboSede, cod_unidad);
            }
        }

        private void cboDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboDepartamento.SelectedValue.ToString() != null)
            {
                string Cod_Departamento = cboDepartamento.SelectedValue.ToString();
                Llenadocbo.ObtenerProvinciaSucamec(cboProvincia, Cod_Departamento);
            }
        }

        private void cboProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProvincia.SelectedValue.ToString() != null)
            {
                string Cod_Provincia = cboProvincia.SelectedValue.ToString();
                Llenadocbo.ObtenerDistritosSucamec(cboDis, Cod_Provincia);
            }
        }
    }
}
