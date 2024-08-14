using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AsistenciaSys
{
    /* NOTE: This form is a base for the EnrollmentForm and the VerificationForm,
		All changes in the CaptureForm will be reflected in all its derived forms.
	*/
    delegate void Function();

    public partial class CaptureForm : Form, DPFP.Capture.EventHandler
	{
        private Timer clearImageTimer;
        public CaptureForm()
		{
			InitializeComponent();
            this.Resize += new EventHandler(CaptureForm_Resize);

            // Inicializar el Timer
            clearImageTimer = new Timer();
            clearImageTimer.Interval = 5000; // 5 segundos
            clearImageTimer.Tick += ClearImageTimer_Tick;
        }

		protected virtual void Init()
		{
            try
            {
                Capturer = new DPFP.Capture.Capture();				// Create a capture operation.

                if ( null != Capturer )
                    Capturer.EventHandler = this;					// Subscribe for capturing events.
                else
                    SetPrompt("No se pudo iniciar la operación de captura");
            }
            catch
            {               
                MessageBox.Show("No se pudo iniciar la operación de captura", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);            
            }
		}

		protected virtual void Process(DPFP.Sample Sample)
		{
			// Draw fingerprint sample image.
			DrawPicture(ConvertSampleToBitmap(Sample));
		}

		protected void Start()
		{
            if (null != Capturer)
            {
                try
                {
                    Capturer.StartCapture();
                    SetPrompt("Escanea tu huella usando el lector");
                }
                catch
                {
                    SetPrompt("No se puede iniciar la captura");
                }
            }
		}

		protected void Stop()
		{
            if (null != Capturer)
            {
                try
                {
                    Capturer.StopCapture();
                }
                catch
                {
                    SetPrompt("No se puede terminar la captura");
                }
            }
		}
		
	#region Form Event Handlers:

		string _origen = string.Empty;
		private void CaptureForm_Load(object sender, EventArgs e)
		{
			int alingY = (this.ClientSize.Height - Picture.Height) / 2;

            labelMenssage.Left = (this.ClientSize.Width - labelMenssage.Width) / 2;
            labelMenssage.Top = alingY - 100;

            Picture.Left = (this.ClientSize.Width - Picture.Width) / 2;
			Picture.Top = alingY - 80;

            CloseButton.Left = (this.ClientSize.Width - CloseButton.Width) / 2;
            CloseButton.Top = alingY + 110;

            if (_origen == "Registrar")
            {
                // Acción específica para Form1
            }
            else if (_origen == "Verificar")
            {
                // Acción específica para Form3
            }

            Init();
			Start();												// Start capture operation.
		}

        private void CaptureForm_Resize(object sender, EventArgs e)
        {
            int alingY = (this.ClientSize.Height - Picture.Height) / 2;

            labelMenssage.Left = (this.ClientSize.Width - labelMenssage.Width) / 2;
            labelMenssage.Top = alingY - 100;

            Picture.Left = (this.ClientSize.Width - Picture.Width) / 2;
            Picture.Top = alingY - 80;

            CloseButton.Left = (this.ClientSize.Width - CloseButton.Width) / 2;
            CloseButton.Top = alingY + 110;
        }

        private void CaptureForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			Stop();
		}
	#endregion

	#region EventHandler Members:

		public void OnComplete(object Capture, string ReaderSerialNumber, DPFP.Sample Sample)
		{
			MakeReport("La muestra ha sido capturada");
			SetPrompt("Escanea tu misma huella otra vez");
            Process(Sample);
		}

		public void OnFingerGone(object Capture, string ReaderSerialNumber)
		{
			//MakeReport("La huella fue removida del lector");
		}

		public void OnFingerTouch(object Capture, string ReaderSerialNumber)
		{
			//MakeReport("El lector fue tocado");
		}

		public void OnReaderConnect(object Capture, string ReaderSerialNumber)
		{
            ChangeMessageAction("Lector de Huellas Conectado");
            MakeReport("El Lector de huellas ha sido conectado");
		}

		public void OnReaderDisconnect(object Capture, string ReaderSerialNumber)
		{
            ChangeMessageAction("Lector de Huellas Desconectado");
            MakeReport("El Lector de huellas ha sido desconectado");
		}

		public void OnSampleQuality(object Capture, string ReaderSerialNumber, DPFP.Capture.CaptureFeedback CaptureFeedback)
		{
			if (CaptureFeedback == DPFP.Capture.CaptureFeedback.Good)
				MakeReport("La calidad de la muestra es BUENA");
			else
				MakeReport("La calidad de la muestra es MALA");
		}
	#endregion

		protected Bitmap ConvertSampleToBitmap(DPFP.Sample Sample)
		{
			DPFP.Capture.SampleConversion Convertor = new DPFP.Capture.SampleConversion();	// Create a sample convertor.
			Bitmap bitmap = null;												            // TODO: the size doesn't matter
			Convertor.ConvertToPicture(Sample, ref bitmap);									// TODO: return bitmap as a result
			return bitmap;
		}

		protected DPFP.FeatureSet ExtractFeatures(DPFP.Sample Sample, DPFP.Processing.DataPurpose Purpose)
		{
			DPFP.Processing.FeatureExtraction Extractor = new DPFP.Processing.FeatureExtraction();	// Create a feature extractor
			DPFP.Capture.CaptureFeedback feedback = DPFP.Capture.CaptureFeedback.None;
			DPFP.FeatureSet features = new DPFP.FeatureSet();
			Extractor.CreateFeatureSet(Sample, Purpose, ref feedback, ref features);			// TODO: return features as a result?
			if (feedback == DPFP.Capture.CaptureFeedback.Good)
				return features;
			else
				return null;
		}

		protected void SetStatus(string status)
		{
			this.Invoke(new Function(delegate() {
				StatusLine.Text = status;
			}));
		}

		protected void SetPrompt(string prompt)
		{
			this.Invoke(new Function(delegate() {
				Prompt.Text = prompt;
			}));
		}
		protected void MakeReport(string message)
		{
			this.Invoke(new Function(delegate() {
				StatusText.AppendText(message + "\r\n");
			}));
		}

		private void DrawPicture(Bitmap bitmap)
		{
			this.Invoke(new Function(delegate() {
				Picture.Image = new Bitmap(bitmap, Picture.Size);   // fit the image into the picture box
                clearImageTimer.Start();
            }));
		}

        private void ClearImageTimer_Tick(object sender, EventArgs e)
        {
            this.Invoke(new Action(() => {
                // Vacía la imagen del PictureBox
                Picture.Image = null;

                // Detiene el Timer
                clearImageTimer.Stop();
            }));
        }

        private DPFP.Capture.Capture Capturer;

        //Cambiar texto de mensaje
        private void ChangeMessageAction(string message)
        {
            if (this.InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    ChangeMessageAction(message);
                });
            }
            else
            {
				labelMenssage.Text = message;
                labelMenssage.Left = (this.ClientSize.Width - labelMenssage.Width) / 2;
            }
        }
    }
}