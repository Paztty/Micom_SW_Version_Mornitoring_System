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
        public string MasterData { get; set; } = "";
        public string Name { get; set; } = "";
        public string WritingArea { get; set; } = "";
        public string AssyCode { get; set; } = "";
        public string PBACode { get; set; } = "";
        public string PCBCode { get; set; } = "";

        public bool _2Rom = false;
        public List<ROM> ROMs { get; set; } = new List<ROM>();

        public class ROM
        {
            public string AssyMicomCode { get; set; } = "";
            public string MicomName { get; set; } = "";
            public string Checksum { get; set; } = "";
            public string Version { get; set; } = "";
            public string DateApply { get; set; } = ""; 
        }

        public Model() {
            ROMs.Add(new ROM());
            ROMs.Add(new ROM());
        }
        public void GetData(System.Windows.Forms.DataGridView table, int rowIndex)
        {
            if (rowIndex >= 0 && rowIndex < table.Rows.Count)
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

    class EEPROM
    {
        public string KeyCode = "";
        public string Company = "";
        public string KitCode = "";
        public string MainPCBAssyCode = "";
        public string MainPCBCode = "";
        public string SubPCBAssyCode = "";
        public string SubPCBCode = "";
        public string EEPROMOption = "";
        public string EEPROMAssyCode = "";
        public string EEPROMPacket = "";

        public EEPROM() { }
        public void GetData(System.Windows.Forms.DataGridView table, int rowIndex)
        {
             KeyCode =          table[0, rowIndex].Value.ToString();
             Company =          table[1, rowIndex].Value.ToString();
             KitCode =          table[2, rowIndex].Value.ToString();
             MainPCBAssyCode =  table[3, rowIndex].Value.ToString();
             MainPCBCode =      table[4, rowIndex].Value.ToString();
             SubPCBAssyCode =   table[5, rowIndex].Value.ToString();
             SubPCBCode =       table[6, rowIndex].Value.ToString();
             EEPROMOption =     table[7, rowIndex].Value.ToString();
             EEPROMAssyCode =   table[8, rowIndex].Value.ToString();
             EEPROMPacket =     table[9, rowIndex].Value.ToString();
        }

    }
}
