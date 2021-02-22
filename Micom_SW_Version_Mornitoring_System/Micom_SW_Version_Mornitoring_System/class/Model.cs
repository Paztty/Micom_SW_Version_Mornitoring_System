using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Micom_SW_Version_Mornitoring_System
{
    class Model
    {
        // value
        public string MasterData = "";
        public string Name = "";
        public string WritingArea = "";
        public string AssyCode = "";
        public string PBACode = "";
        public string PCBCode = "";

        public bool _2Rom = false;
        public List<ROM> ROMs = new List<ROM>();

        public class ROM
        {
            public string AssyMicomCode = "";
            public string MicomName = "";
            public string Checksum = "";
            public string Version = "";
            public string DateApply = ""; 
        }

        public Model() {
            ROMs.Add(new ROM());
            ROMs.Add(new ROM());
        }
        public void GetData(System.Windows.Forms.DataGridView table, int rowIndex)
        {
            if (rowIndex >= 0)
            {
                MasterData = table[0, rowIndex].Value.ToString();
                Name = table[1, rowIndex].Value.ToString();
                WritingArea = table[2, rowIndex].Value.ToString();
                AssyCode = table[3, rowIndex].Value.ToString();
                PBACode = table[4, rowIndex].Value.ToString();
                PCBCode = table[5, rowIndex].Value.ToString();

                ROMs[0].AssyMicomCode = table[6, rowIndex].Value.ToString();
                ROMs[0].MicomName = table[7, rowIndex].Value.ToString();
                ROMs[0].Checksum = table[8, rowIndex].Value.ToString();
                ROMs[0].Version = table[9, rowIndex].Value.ToString();
                ROMs[0].DateApply = table[10, rowIndex].Value.ToString();

                ROMs[1].AssyMicomCode = table[11, rowIndex].Value.ToString();
                ROMs[1].MicomName = table[12, rowIndex].Value.ToString();
                ROMs[1].Checksum = table[13, rowIndex].Value.ToString();
                ROMs[1].Version = table[14, rowIndex].Value.ToString();
                ROMs[1].DateApply = table[15, rowIndex].Value.ToString();
            }
        }
    }

}
