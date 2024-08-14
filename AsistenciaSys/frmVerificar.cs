using DPFP.Verification;
using DPFP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AsistenciaSys.Models;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Contexts;
using Newtonsoft.Json;
using System.Net.Http;
using Microsoft.Win32;
using Org.BouncyCastle.Utilities;

namespace AsistenciaSys
{
    public partial class frmVerificar : CaptureForm
    {
        private DPFP.Template Template;
        private DPFP.Verification.Verification Verificator;
        List<StudentDB> listStudent = new List<StudentDB>();

        private int timeClose = 10000;
        private string connectionString = "Server=localhost;Database=comunidadsalsera;User=root;Password=imaGT123*;";

        //private string api = "https://8xkndwdyhj.execute-api.us-west-2.amazonaws.com/prod/"; //PROD
        private string api = "https://5hr9wi6twa.execute-api.us-east-1.amazonaws.com/dev/"; //DEV
        protected override void Init()
        {
            base.Init();
            base.Text = "Registrar Asistencia";
            // Crear un verificador de plantilla de huellas dactilares
            Verificator = new DPFP.Verification.Verification();     
            UpdateStatus(0);
        }

        private bool status = true;
        protected override async void Process(DPFP.Sample Sample)
        {
            base.Process(Sample);

            // Procese la muestra y cree un conjunto de funciones para fines de inscripción.
            DPFP.FeatureSet features = ExtractFeatures(Sample, DPFP.Processing.DataPurpose.Verification);

            // Verifica la calidad de la muestra y comienza la verificación si es buena.
            // TODO: pasar a una tarea separada
            if (features != null)
            {
                // Compare el conjunto de funciones con nuestra plantilla
                DPFP.Verification.Verification.Result result = new DPFP.Verification.Verification.Result();

                DPFP.Template template = new DPFP.Template();
                Stream stream;

                if (status == true)
                {
                    bool studentFound = false;

                    foreach (var std in listStudent)
                    {
                        stream = new MemoryStream(std.studentFingerprint);
                        template = new DPFP.Template(stream);

                        Verificator.Verify(features, template, ref result);
                        UpdateStatus(result.FARAchieved);
                        if (result.Verified)
                        {
                            // Registrar Asistencia en IMA
                            await SetAssistStudentAPI(std.studentCode, std.studentName);
                            studentFound = true;
                            break;
                        }
                    }

                    if (!studentFound)
                    {
                        ShowPopup(
                            "Error",
                            "error_mini.png",
                            "A ocurrido un error.",
                            "No se encontro un estudiante con la huella colocada.",
                            "",
                            timeClose
                        );
                    }
                }
            }
        }

        public void Verify(DPFP.Template template)
        {
            Template = template;
            ShowDialog();
        }
        private void UpdateStatus(int FAR)
        {
            //Mostrar el valor de "tasa de aceptación falsa"
            SetStatus(String.Format("Tasa de aceptación falsa (FAR) = {0}", FAR));
        }

        public frmVerificar()
        {
            InitializeComponent();
            GetStudentFingerprintDB();
            this.Resize += new EventHandler(FrmVerificar_Resize);
        }

        private async void FrmVerificar_Load(object sender, EventArgs e)
        {
            //Obtener lista de huellas de los usuarios
            loadingAction(true);
            await GetStudentFingerprintDB();
            loading.Left = (this.ClientSize.Width - loading.Width) / 2;
            loading.Top = ((this.ClientSize.Height - loading.Height) / 2) - 60;
            loadingAction(false);
        }

        private void FrmVerificar_Resize(object sender, EventArgs e)
        {
            loading.Left = (this.ClientSize.Width - loading.Width) / 2; ;
            loading.Top = ((this.ClientSize.Height - loading.Height) / 2) - 60;
        }

        //Consultar a DB
        private async Task<bool> GetStudentFingerprintDB()
        {
            
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    await conn.OpenAsync();

                    string query = "SELECT studentCode, studentName, studentFingerprint FROM student";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataReader reader = (MySqlDataReader)await cmd.ExecuteReaderAsync())

                        {
                            while (await reader.ReadAsync())
                            {
                                StudentDB student = new StudentDB
                                {
                                    studentCode = reader.GetInt32("studentCode"),
                                    studentName = reader.GetString("studentName"),
                                    studentFingerprint = (byte[])reader["studentFingerprint"]
                                };
                                listStudent.Add(student);
                            }
                        }
                    }
                    return true;
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error al consultar registros: " + ex.Message);
                    return false;
                }
            }
        }

        //Registrar Asistencia
        private async Task<bool> SetAssistStudentAPI(int studentCode, string studentName)
        {
            //Stop();
            status = false;
            loadingAction(true);
            Student studentVerify = new Student()
            {
                studentCode = studentCode
            };
        
            
            string enpoint = "comunidadsalsera-fingerprint/verify";
            string jsonData = JsonConvert.SerializeObject(studentVerify);
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(api);
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync(api + enpoint, content);

                    string responseString = await response.Content.ReadAsStringAsync();
                    var apiResponse = JsonConvert.DeserializeObject<ApiResponseVerify>(responseString);

                    if (response.IsSuccessStatusCode && apiResponse.result)
                    {
                        ShowPopup(
                            "Registro Exitoso",
                            "cheque_mini.png",
                            "¡Gracias por registrar tu asistencia!",
                            $"Nombre del estudiante: {apiResponse.records.studentName} \n Vigencia: {apiResponse.records.paymentDetailEndDate}",
                            apiResponse.records.message,
                            timeClose
                         );
                        //ShowNotificationType2("Success", $"¡Gracias por registrar tu asistencia!\n Nombre: {studentName}\n Horas disponibles:: {apiResponse.records.assistAvailableHours} \n Vigencia: {apiResponse.records.paymentDetailEndDate} \n{apiResponse.records.message}", 10000);
                        loadingAction(false);
                        status = true;
                        return true;
                    }
                    else
                    {
                        string errorMessage = apiResponse.errorMessage ?? "Error desconocido";
                        //ShowNotificationType2("Error", errorMessage, 10000);
                        ShowPopup(
                            "Error",
                            "error_mini.png",
                            "A ocurrido un error.",
                            errorMessage,
                            "",
                            timeClose
                        );
                        loadingAction(false);
                        status = true;
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                //Start();
                status = true;
                loadingAction(false);
                MessageBox.Show("Error: " + ex.Message);
                return false;
            }
        }

        //Mostrar notificaciones
        private void ShowNotificationType1(string title, string message, int duration)
        {
            NotifyIcon notifyIcon = new NotifyIcon();
            notifyIcon.Visible = true;
            notifyIcon.Icon = SystemIcons.Information;
            notifyIcon.BalloonTipTitle = title;
            notifyIcon.BalloonTipText = message;
            notifyIcon.ShowBalloonTip(duration);

            System.Timers.Timer timer = new System.Timers.Timer(duration);
            timer.Elapsed += (sender, e) =>
            {
                notifyIcon.Visible = false;
                notifyIcon.Dispose();
                timer.Stop();
                timer.Dispose();
            };
            timer.Start();
        }

        private void ShowNotificationType2(string title, string message, int duration)
        {
            NotifyIcon notifyIcon = new NotifyIcon
            {
                Visible = true,
                Icon = SystemIcons.Information,
                BalloonTipTitle = title,
                BalloonTipText = message
            };

            notifyIcon.ShowBalloonTip(duration);

            // Utilizar Task.Delay en lugar de System.Timers.Timer para la simplicidad en este caso
            Task.Delay(duration).ContinueWith(t =>
            {
                notifyIcon.Visible = false;
                notifyIcon.Dispose();
            });
        }

        //Mostrar ventana
        private void ShowPopup(string title, string imagePathType, string titleMessage, string messageLine1, string messageLine2, int duration)
        {
            string iconPath = @"Assets\favicon-ima.ico";
            string imagePath = @"Assets\" + imagePathType;
            PopupForm popup = new PopupForm(title, iconPath, imagePath, titleMessage, messageLine1, messageLine2, duration);
            //popup.Show();
            popup.ShowDialog();
        }

        public class PopupForm : Form
        {
            private System.Timers.Timer closeTimer;

            public PopupForm(string title, string iconPath, string imagePath, string titleMessage, string messageLine1, string messageLine2, int duration)
            {
                Icon = new Icon(iconPath);

                // Imagen
                PictureBox pictureBox = new PictureBox()
                {
                    Image = Image.FromFile(imagePath),
                    SizeMode = PictureBoxSizeMode.CenterImage,
                    Height = 110,
                    Dock = DockStyle.Top,
                    Margin = new Padding(20)
                };


                // Estilo del título
                Label titleLabel = new Label()
                {
                    Text = titleMessage,
                    Location = new Point(0,200),
                    Dock = DockStyle.Top,
                    Font = new Font("Arial", 12, FontStyle.Bold),
                    TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
                    Height = 70
                };

                // Estilo del mensaje
                Label messageLabel1 = new Label()
                {
                    Text = messageLine1,
                    Dock = DockStyle.Bottom,
                    Font = new Font("Arial", 18, FontStyle.Regular),
                    TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
                    Height = 110
                };

                Label messageLabel2 = new Label()
                {
                    Text = messageLine2,
                    Dock = DockStyle.Bottom,
                    Font = new Font("Arial", 12, FontStyle.Regular),
                    TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
                    Height = 140
                };

                // Panel de fondo
                Panel backgroundPanel = new Panel()
                {
                    Dock = DockStyle.Fill,
                    BackColor = Color.LightBlue
                };

                // Agregar controles al formulario
                Controls.Add(backgroundPanel);
                backgroundPanel.Controls.Add(pictureBox);
                backgroundPanel.Controls.Add(titleLabel);
                backgroundPanel.Controls.Add(messageLabel1);
                backgroundPanel.Controls.Add(messageLabel2);


                // Configuración del formulario
                Size = new System.Drawing.Size(700, 500);
                StartPosition = FormStartPosition.CenterScreen;

                closeTimer = new System.Timers.Timer(duration);
                closeTimer.Elapsed += (sender, e) => ClosePopup();
                closeTimer.AutoReset = false;
            }


            protected override void OnShown(EventArgs e)
            {
                base.OnShown(e);
                closeTimer.Start();
            }

            private void ClosePopup()
            {
                if (InvokeRequired)
                {
                    Invoke(new Action(ClosePopup));
                }
                else
                {
                    closeTimer.Stop();
                    closeTimer.Dispose();
                    Close();
                    //CloseAction();
                    //this.Close();
                }
            }
        }

        //Activar/Desactivar loader.
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

        //Cerrar formulario
        private void CloseAction()
        {
            if (this.InvokeRequired)
            {
                // Invoca la llamada en el hilo de la UI
                this.Invoke((MethodInvoker)delegate
                {
                    CloseAction();
                });
            }
            else
            {
                this.Close();
            }
        }
    }
}
