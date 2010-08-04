using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using Client.ServiceReference;
using System.ServiceModel;


namespace Client
{
    
    public partial class ProgressForm : Form
    {
        ProgressFileInfo progressFileInfo;
        
        long CountFileDownloadBytesPred = 0;// количество скачанных байт каждого файла

        //--------------------------------------------------------------------------------
        public ProgressForm(ProgressFileInfo progressFileInfo)
        {
            InitializeComponent();
            this.Activate();
            this.progressFileInfo = progressFileInfo;
            timerUpdateData.Enabled = true;
        }
        //--------------------------------------------------------------------------------


        //--------------------------------------------------------------------------------
        public ProgressForm()
        {
            InitializeComponent();
        }
        //--------------------------------------------------------------------------------


        //таймер обновления данных синхронизации
        private void timerUpdateData_Tick(object sender, EventArgs e)
        {
            this.Show();
            string action = "Downloading";
            switch (progressFileInfo.Action)
            {
                case FileStatus.Upload:
                    action = "Отправка файла";
                    break;
                case FileStatus.Delete:
                    action = "Deleting";
                    break;
                case FileStatus.Download:
                    action = "Получение файла";
                    break;
            }

           



            labelSinchType.Text = action;
            labelFileName.Text = progressFileInfo.File.Name; // Название файла
            labelPath.Text = progressFileInfo.File.Path; // Директория

            labelFileSize.Text = GetFormatedSizeString(progressFileInfo.ProgressBytes) + "/" + GetFormatedSizeString(progressFileInfo.File.Size); // Размер 
            labelSpeed.Text = GetFormatedSizeString(GetCurrentSpeed())+ "/с"; // Скорость
            progressBar.Value = progressFileInfo.ProgressProcent;
        }
        //--------------------------------------------------------------------------------


        private string GetFormatedSizeString(long size)
        {
            float fileSize = (float)size / 1024.0f;
            string suffix = "KБайт";

            if (fileSize > 1000.0f)
            {
                fileSize /= 1024.0f;
                suffix = "MБайт";
            }
            return string.Format("{0:0.0} {1}", fileSize, suffix);
        }

        // возвращает текущую скорость скачивания
        private long GetCurrentSpeed() 
        {
            long downloadedBytes = progressFileInfo.ProgressBytes - CountFileDownloadBytesPred;
            CountFileDownloadBytesPred = progressFileInfo.ProgressBytes;
            return downloadedBytes * (1000/timerUpdateData.Interval);
            
        }
        //--------------------------------------------------------------------------------


   


    

    


    }
}
