using ClassMiAccesoBD;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web.UI;

namespace WebPruebaAcceso {
    public partial class WebForm1 : System.Web.UI.Page {
        private ClassAccesoSQL objAcceso = null;

        protected void Page_Load(object sender, EventArgs e) {
            if (IsPostBack == false) {
                objAcceso = new ClassAccesoSQL(
                    @"Data Source=DESKTOP-20LP090; Initial Catalog=BDTIENDA; Integrated Security=true;");
                Session["OBJACCESO"] = objAcceso;
            } else {
                objAcceso = (ClassAccesoSQL)Session["OBJACCESO"];
            }
        }

        protected void Button1_Click(object sender, EventArgs e) {
            SqlConnection temp = null;
            string m = "";
            temp = objAcceso.AbrirConexion(ref m);
            string limpio = "";
            limpio = Quitacomillas(m);
            //TextBox1.Text = m;
            if (temp != null) {
                //Page.ClientScript.RegisterStartupScript(
                //this.GetType(), "conexion", "msgbox('Correcto'," + m + ",'success')",true);
                Page.ClientScript.RegisterStartupScript(
                 GetType(), "messg3B", "msgbox3('Correcto','" + m + "','success')", true);
                temp.Dispose();
                temp.Close();
            } else {
                //Page.ClientScript.RegisterStartupScript(
                //this.GetType(), "conexion", "msgbox('Incorrecto'," + m + ",'error')", true);
                Page.ClientScript.RegisterStartupScript(
               GetType(), "messg3B", "msgbox3(`Incorrecto`,`" + m + "`,`error`)", true);
            }
            TextBox1.Text = m;
            TextBox2.Text = limpio;
        }

        private string Quitacomillas(string entrada) {
            StringBuilder cad = new StringBuilder();
            int w = 1;
            foreach (char j in entrada) {
                if (w <= 80) {
                    if ((j != '"') && (j != '\'') && (j != '\\') &&
                        (j != '-') && (j != '-')) {
                        cad.Append(j);
                    } else {
                        cad.Append(" ");
                    }

                    w++;
                }

            }
            return cad.ToString();
        }

        protected void btnConsultaDataReader_Click(object sender, EventArgs e) {
            SqlDataReader caja = null;
            SqlConnection cnab = null;
            string m = "";
            cnab = objAcceso.AbrirConexion(ref m);
            if (cnab != null) {
                //Page.ClientScript.RegisterStartupScript(
                 //GetType(), "messg3B", "msgbox3('Correcto','" + m + "','success')", true);

                caja = objAcceso.ConsultarReader("select * from EMPLEADO", cnab, ref m);
                if (caja != null) {
                    //la consulta es correcta y se nuestrab los datos
                    ListBox1.Items.Clear();
                    while (caja.Read()) {
                        ListBox1.Items.Add(caja[0] + " " + caja["NOMBRE"]);
                    }
                } else {
                    Page.ClientScript.RegisterStartupScript(
                    GetType(), "messg77", "msgbox3(`Incorrecto`,`" + m + "`,`error`)", true);
                }

                cnab.Close();
                cnab.Dispose();

            } else {
                Page.ClientScript.RegisterStartupScript(
                GetType(), "messg3B", "msgbox3(`Incorrecto`,`" + m + "`,`error`)", true);
            }
        }

        protected void btnConsultaDataSet_Click(object sender, EventArgs e) {
            DataSet contenedor = null;
            //SqlDataReader caja = null;
            SqlConnection cnab = null;
            string m = "";
            cnab = objAcceso.AbrirConexion(ref m);
            if (cnab != null) {
                Page.ClientScript.RegisterStartupScript(
                 GetType(), "messg3B", "msgbox3('Correcto','" + m + "','success')", true);

                contenedor = objAcceso.ConsultaDS("select * from EMPLEADO", cnab, ref m);
                cnab.Close();
                cnab.Dispose();
                if (contenedor != null) {
                    //la consulta es correcta y se nuestrab los datos
                    GridView1.DataSource = contenedor.Tables[0];
                    GridView1.DataBind();
                    Session["Tabla1"] = contenedor;

                } else {
                    Page.ClientScript.RegisterStartupScript(
                    GetType(), "messg77", "msgbox3(`Incorrecto`,`" + m + "`,`error`)", true);
                }



            } else {
                Page.ClientScript.RegisterStartupScript(
                GetType(), "messg88", "msgbox3(`Incorrecto`,`" + m + "`,`error`)", true);
            }
        }

        protected void btnDatosDataSet_Click(object sender, EventArgs e) {

            DataSet temporal = Session["Tabla1"] as DataSet;
            DataRow registro = null;
            ListBox1.Items.Clear();
            ListBox1.Items.Add("DATOS RECUPERADOS DEL DATATABLE 0");
            /*foreach (DataRow registro in temporal.Tables[0].Rows) {
                ListBox1.Items.Add(registro[0] + " -- " + registro[1]);
            }*/

            for (int w = temporal.Tables[0].Rows.Count - 1; w >= 0; w--) {
                registro = temporal.Tables[0].Rows[w];
                ListBox1.Items.Add(registro[0] + " -- " + registro[1]);
            }


        }

        protected void Button3_Click(object sender, EventArgs e) {
            //declaracion de parámetros
            SqlParameter uno = new SqlParameter("id", SqlDbType.Int);
            SqlParameter dos = new SqlParameter("nombre", SqlDbType.NChar, 50);

            //dando valores a los parametros
            uno.Value = txbID.Text;
            dos.Value = txbNombre.Text;

            //establecer la direccion de los parametros
            uno.Direction = ParameterDirection.Input;
            dos.Direction = ParameterDirection.Input;

            string sentencia = "Insert into EMPLEADO values(@id,@nombre);";
            //TextBox2.Text = sentencia;
            SqlConnection t = null;
            string m = "";
            bool resp = false;
            t = objAcceso.AbrirConexion(ref m);


            //objAcceso.ModificaBDInsegura(sentencia, t, ref m);
            resp = objAcceso.InsertaEmpleadoconPar(sentencia, t, ref m, uno, dos);

            if (resp) {
                Page.ClientScript.RegisterStartupScript(
                GetType(), "messg3B5", "msgbox3('Correcto','" + m + "','success')", true);
                TextBox2.Text = m;

            } else {
                Page.ClientScript.RegisterStartupScript(
                GetType(), "messg3B85", "msgbox3(`Incorrrecto`,`" + m + "`,`error`)", true);
                //TextBox2.Text = m;


            }

        }

        protected void btnProd_Click(object sender, EventArgs e) {

            SqlParameter[] misparametros = new SqlParameter[4];

            misparametros[0] = new SqlParameter("Idprod", SqlDbType.Int);
            misparametros[0].Value = txbIdprod.Text;
            misparametros[0].Direction = ParameterDirection.Input;

            misparametros[1] = new SqlParameter {
                ParameterName = "Descri",
                SqlDbType = SqlDbType.NVarChar,
                Size = 50,
                Direction = ParameterDirection.Input,
                Value = txbDescProd.Text
            };

            misparametros[2] = new SqlParameter {
                ParameterName = "Cate",
                SqlDbType = SqlDbType.NVarChar,
                Size = 15,
                Direction = ParameterDirection.Input,
                Value = txbCategoProd.Text
            };

            misparametros[3] = new SqlParameter {
                ParameterName = "Precio",
                SqlDbType = SqlDbType.Float,
                Direction = ParameterDirection.Input,
                Value = txbPrecProd.Text
            };

            string sentencia = "Insert into Productos values(@Idprod, @Descri, @Cate, @Precio);";
            //TextBox2.Text = sentencia;
            SqlConnection t = null;
            string m = "";
            bool resp = false;
            t = objAcceso.AbrirConexion(ref m);


            //objAcceso.ModificaBDInsegura(sentencia, t, ref m);
            resp = objAcceso.ModificaBDunPocoMasSegura(sentencia, t, ref m, misparametros);

            if (resp) {
                Page.ClientScript.RegisterStartupScript(
                GetType(), "messg3B5", "msgbox3('Correcto','" + m + "','success')", true);
                TextBox2.Text = m;

            } else {
                Page.ClientScript.RegisterStartupScript(
                GetType(), "messg3B85", "msgbox3(`Incorrrecto`,`" + m + "`,`error`)", true);
                //TextBox2.Text = m;


            }
        }
    }
}