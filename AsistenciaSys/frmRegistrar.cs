using AsistenciaSys.Models;
using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using DPUruNet;
using MySql.Data.MySqlClient;

namespace AsistenciaSys
{
    public partial class frmRegistrar : Form
    {
        private DPFP.Template Template;

        private int timeClose = 10000;
        private string connectionString = "Server=localhost;Database=comunidadsalsera;User=root;Password=imaGT123*;";

        //private string api = "https://8xkndwdyhj.execute-api.us-west-2.amazonaws.com/prod/"; //PROD
        private string api = "https://5hr9wi6twa.execute-api.us-east-1.amazonaws.com/dev/"; //DEV

        private static readonly HttpClient client = new HttpClient();
        private int pageSize = 15;
        private int totalPage = 0;
        private int storeCode = 1; //PROD 4 // DEV 1
        private int currentPage = 1;
        private Student selected_student = new Student();

        public frmRegistrar()
        {
            InitializeComponent(); 
        }
        private async void frmRegistrar_Load(object sender, EventArgs e)
        {
            loadingAction(true);

            //Definir estructura de la tabla
            SetColumnInDataGrid();

            //Dar estilos a la tabla
            this.dataGridViewStudents.CellClick += DataGridViewStudent_CellClick;
            this.dataGridViewStudents.CellMouseEnter += new DataGridViewCellEventHandler(this.DataGridViewStudent_CellMouseEnter);
            this.dataGridViewStudents.CellMouseLeave += new DataGridViewCellEventHandler(this.DataGridViewStudent_CellMouseLeave);
            this.dataGridViewStudents.RowPrePaint += new DataGridViewRowPrePaintEventHandler(this.DataGridViewStudents_RowPrePaint);

            //Listar usuarios
            await GetStudentData(1);

            loadingAction(false);
        }

        private void SetColumnInDataGrid()
        {
            // Definir las columnas del DataGridView
            dataGridViewStudents.Columns.Clear();
            dataGridViewStudents.ColumnCount = 7; // Número de columnas

            // Definir el nombre de las columnas
            dataGridViewStudents.Columns[0].Name = "Codigo";
            dataGridViewStudents.Columns[1].Name = "Nombre";
            dataGridViewStudents.Columns[2].Name = "Telefono";
            dataGridViewStudents.Columns[3].Name = "studentFingerprint";
            dataGridViewStudents.Columns[4].Name = "Tiene Huella";
            dataGridViewStudents.Columns[5].Name = "status";
            dataGridViewStudents.Columns[6].Name = "Estado";

            //Ocultar columnas
            dataGridViewStudents.Columns[0].Visible = false;
            dataGridViewStudents.Columns["studentFingerprint"].Visible = false;
            dataGridViewStudents.Columns["status"].Visible = false;

            // Ajustar adicionales a las columnas
            //dataGridViewStudents.Columns["Codigo"].Width = 200;
            //dataGridViewStudents.Columns["Telefono"].DefaultCellStyle.Format = "dd/MM/yyyy";
        }

        private void DataGridViewStudents_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        //cambiar color de la fila si no cumple x condicion
        {

            foreach (DataGridViewRow row in dataGridViewStudents.Rows)
            {
                if (row.Cells["studentFingerprint"].Value != null && row.Cells["status"].Value != null)
                {
                    if (row.Cells["studentFingerprint"].Value.ToString() == "1" || row.Cells["status"].Value.ToString() == "0")
                    {
                        row.DefaultCellStyle.ForeColor = Color.Maroon; //Fondo: BackColor
                    }
                }
            }
        }

        private void DataGridViewStudent_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        // Este es el manejador del evento CellMouseEnter
        {
            // Verifica que el índice de la fila sea válido
            if (e.RowIndex >= 0)
            {
                dataGridViewStudents.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightBlue;
            }
        }

        private void DataGridViewStudent_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        // Este es el manejador del evento CellMouseLeave
        {
            // Verifica que el índice de la fila sea válido
            if (e.RowIndex >= 0)
            {
                dataGridViewStudents.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White; // Cambia a tu color original
            }
        }

        private void DataGridViewStudent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verificar que no se haya hecho clic en el encabezado
            if (e.RowIndex >= 0)
            {
                // Obtener la fila seleccionada
                DataGridViewRow selectedRow = dataGridViewStudents.Rows[e.RowIndex];

                // Verificar si la columna studentFingerprint es igual a 0
                if (Convert.ToInt32(selectedRow.Cells["studentFingerprint"].Value) == 0)
                {
                    Font btnCapturarHuellaFont = btnCapturarHuella.Font;
                    Font newBtnCapturarHuellaFont = new Font(btnCapturarHuellaFont.FontFamily, btnCapturarHuellaFont.Size, FontStyle.Bold);
                    btnCapturarHuella.Font = newBtnCapturarHuellaFont;
                    btnCapturarHuella.Enabled = true;

                    //dataGridViewStudents.Enabled = false;
                    selected_student.studentCode = (int)selectedRow.Cells["Codigo"].Value;
                    selected_student.studentName = selectedRow.Cells["Nombre"].Value.ToString();
                    txtNombre.Text = selectedRow.Cells["Nombre"].Value.ToString();
                }
            }
        }

        private async Task<bool> GetStudentData(int pageIndex)
        {
            string endpoint = "comunidadsalsera-student/store/open";
            //string apiUrl = "comunidadsalsera-student/store/open";
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync($"{api}{endpoint}/{storeCode}/{pageIndex}/{pageSize}"); //Store/Page/Size
                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();

                        ApiResponse apiResponse = JsonConvert.DeserializeObject<ApiResponse>(json);

                        // Limpiar el DataGridView antes de agregar nuevas filas
                        dataGridViewStudents.Rows.Clear();

                        foreach (var student in apiResponse.records)
                        {
                            int Codigo = student.studentCode;
                            string name = student.studentName;
                            int status = student.studentStatus;
                            string phone = student.studentPhone;
                            string statusShow = student.studentStatusShow;
                            int studentFingerprint = student.studentFingerprint;
                            string studentFingerprintShow = student.studentFingerprintShow;

                            dataGridViewStudents.Rows.Add(Codigo, name, phone, studentFingerprint, studentFingerprintShow, status, statusShow);
                        }
                        totalPage = (int)Math.Ceiling((decimal)apiResponse.total / (decimal)pageSize);
                        labelNoPage.Text = $"Pag. {pageIndex}/{totalPage}";

                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Error al obtener datos del API.");
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return false;
            }
        }

        private async void btnReload_Click(object sender, EventArgs e)
        {
            loadingAction(true);
            await GetStudentData(currentPage);
            loadingAction(false);
        }

        private async void btnBackPage_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                loadingAction(true);
                currentPage--;
                await GetStudentData(currentPage);
                loadingAction(false);
            }
        }

        private async void btnNextPage_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPage)
            {
                loadingAction(true);
                currentPage++;
                await GetStudentData(currentPage);
                loadingAction(false);
            }
        }

        private void loadingAction(bool status)
        {
            if (this.InvokeRequired)
            {
                // Invoca la llamada en el hilo de la UI
                this.Invoke((MethodInvoker)delegate
                {
                    loadingAction(status);
                });
            }
            else
            {
                loading.Visible = status;
            }
        }

        private void btnCapturarHuella_Click(object sender, EventArgs e)
        {
            CapturarHuella capturar = new CapturarHuella();
            capturar.OnTemplate += this.OnTemplate;
            capturar.ShowDialog();
        }

        private void OnTemplate(DPFP.Template template)
        {
            this.Invoke(new Function(delegate ()
            {
                Template = template;
                btnGuardar.Enabled = (Template != null);
                if (Template != null)
                {
                    //MessageBox.Show("La plantilla de huellas dactilares está lista para la verificación de huellas dactilares.", "Registro de huellas dactilares");
                    //MessageBox.Show("The fingerprint template is ready for fingerprint verification.", "Fingerprint Enrollment");
                    labelHuella.Text = "Huella Capturada!";
                    labelHuella.Visible = true;

                    Font btnGuardarFont = btnGuardar.Font;
                    Font newBtnGuardarFont = new Font(btnGuardarFont.FontFamily, btnGuardarFont.Size, FontStyle.Bold);
                    btnGuardar.Font = newBtnGuardarFont;
                }
                else
                {
                    MessageBox.Show("La lectura de la huella no fue válida. Por favor intenta de nuevo.");
                }
            }));
        }

        private async void btnGuardarHuella_Click(object sender, EventArgs e)
        {
            try
            {
                loadingAction(true);

                byte[] streamHuella = Template.Bytes;
                Student newStudent = new Student()
                {
                    studentCode = selected_student.studentCode,
                    studentName = selected_student.studentName,
                    studentFingerprintByte = streamHuella
                };

                //Consumir API
                await SetStudentFingerprintAPI(newStudent);

                //Guardar en DB
                await SetStudentFingerprintDB(newStudent);

                //Refrescar tabla
                await GetStudentData(currentPage);

                //Notificar
                MessageBox.Show("Se registro la huella de forma exitosa al estudiante: " + newStudent.studentName);

                //Limpiar modelo
                ClearModel();

                loadingAction(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private async Task<bool> SetStudentFingerprintAPI(Student newStudent)
        {
            string enpoint = "comunidadsalsera-student/insert-fingerprint-open";
            string jsonData = JsonConvert.SerializeObject(newStudent);
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(api);
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync(api + enpoint, content);

                    if (response.IsSuccessStatusCode)
                    {
                        //MessageBox.Show("Datos enviados correctamente: " + responseString);
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Error al enviar los datos: " + response.StatusCode);
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return false;
            }
        }

        private async Task<bool> SetStudentFingerprintDB(Student newStudent)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string query = "INSERT INTO student (studentCode, studentName, studentFingerprint, studentCreatedDate) " +
                                    "VALUES (@studentCode, @studentName, @studentFingerprint, NOW())";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@studentCode", newStudent.studentCode);
                        cmd.Parameters.AddWithValue("@studentName", newStudent.studentName);
                        cmd.Parameters.AddWithValue("@studentFingerprint", newStudent.studentFingerprintByte);



                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            //MessageBox.Show("Registro insertado correctamente");
                            return true;
                        }
                        else
                        {
                            //MessageBox.Show("No se pudo insertar el registro");
                            return false;
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error al insertar registro: " + ex.Message);
                    return false;
                }
            }
        }

        private async void ClearModel()
        {
            if (this.InvokeRequired)
            {
                // Invoca la llamada en el hilo de la UI
                this.Invoke((MethodInvoker)delegate
                {
                    ClearModel();
                });
            }
            else
            {
                Template = null;
                selected_student = new Student();
                labelHuella.Text = string.Empty;
                labelHuella.Visible = false;

                btnCapturarHuella.Enabled = false;
                Font btnCapturarHuellaFont = btnCapturarHuella.Font;
                Font newBtnCapturarHuellaFont = new Font(btnCapturarHuellaFont.FontFamily, btnCapturarHuellaFont.Size, FontStyle.Regular);
                btnCapturarHuella.Font = newBtnCapturarHuellaFont;

                btnGuardar.Enabled = false;
                Font btnGuardarFont = btnGuardar.Font;
                Font newBtnGuardarFont = new Font(btnGuardarFont.FontFamily, btnGuardarFont.Size, FontStyle.Regular);
                btnGuardar.Font = newBtnGuardarFont;

                //btnCapturarHuella.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                txtNombre.Text = "Seleccione un estudiante de la tabla...";
            }
        }
    }
}
