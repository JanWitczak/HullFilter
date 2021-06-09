using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;
using HarmonyLib;
using System.Collections;

namespace HullFilter
{
    public class HullFilter : AuroraPatch.Patch
    {
        public override string Description => "Filter hulls displayed in Class Design window.";
        public override IEnumerable<string> Dependencies => new[] { "Lib" };
        
        private static DataTable Hulls;
        private static List<String> DisabledHulls;

        private static Lib.Lib lib;
        protected override void Loaded(Harmony harmony)
        {
            if (Hulls == null)
            {
                ReadDatabase();
                DisabledHulls = Deserialize<List<String>>("DisabledHulls");
                if (DisabledHulls == default(List<String>)) DisabledHulls = new List<string>();
                foreach (DataRow hull in Hulls.Rows)
                {
                    if (DisabledHulls.Contains((string)hull["Description"])) hull["Active"] = false;
                }
                Hulls.AcceptChanges();
            }
            lib = GetDependency<Lib.Lib>("Lib");
            lib.RegisterEventHandler(Lib.AuroraType.ClassDesignForm, "Shown", GetType().GetMethod("ClassDesignFormShown", AccessTools.all));
        }
        protected override void ChangeSettings()
        {
            if (Hulls == null)
            {
                ReadDatabase();
                DisabledHulls = Deserialize<List<String>>("DisabledHulls");
                if (DisabledHulls == default(List<String>)) DisabledHulls = new List<string>();
                foreach (DataRow hull in Hulls.Rows)
                {
                    if (DisabledHulls.Contains((string)hull["Description"])) hull["Active"] = false;
                }
                Hulls.AcceptChanges();
            }
            HullSettings dialogue = new HullSettings(ref Hulls);
            if (dialogue.ShowDialog() == DialogResult.OK)
            { 
                Hulls.AcceptChanges();
                DisabledHulls.Clear();
                foreach (DataRow hull in Hulls.Rows)
                {
                    if (!(bool)hull["Active"]) DisabledHulls.Add((string)hull["Description"]);
                }
                Serialize("DisabledHulls", DisabledHulls);
            }
            else Hulls.RejectChanges();
        }
        public static void ReadDatabase()
        {
            Hulls = new DataTable();
            Hulls.Columns.AddRange(new DataColumn[] {
                    new DataColumn("Active", typeof(bool)),
                    new DataColumn("Index", typeof(int)),
                    new DataColumn("Description", typeof(String)),
                    new DataColumn("Abbreviation", typeof(String))});
            using (SQLiteConnection db = new SQLiteConnection("Data Source = .\\AuroraDB.db; Version = 3; Read Only=True"))
            {
                db.Open();
                SQLiteCommand command = db.CreateCommand();
                command.CommandText = @"SELECT Description, HullAbbr FROM FCT_HullDescription";
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    DataRow row;
                    while (reader.Read())
                    {
                        row = Hulls.NewRow();
                        row["Active"] = true;
                        row["Description"] = reader["Description"];
                        row["Abbreviation"] = reader["HullAbbr"];
                        Hulls.Rows.Add(row);
                    }
                }

            }
            Hulls.DefaultView.Sort = "Description asc";
            Hulls = Hulls.DefaultView.ToTable();
            int index = 0;
            foreach (DataRow hull in Hulls.Rows)
            {
                hull["Index"] = index;
                index++;
            }
        }
        private static void ClassDesignFormShown(object sender, EventArgs e)
        {
            Form ClassDesignForm = lib.GetOpenForms().Where(f => f.GetType() == lib.SignatureManager.Get(Lib.AuroraType.ClassDesignForm)).First();
            object AuroraHullList = ((ComboBox)ClassDesignForm.Controls.Find("cboHullDescription", true).First()).DataSource;
            IList ModofiedHullList = new List<object>();
            foreach (DataRow hull in Hulls.Rows)
            {
                if ((bool)hull["Active"])
                {
                    ModofiedHullList.Add(((IList)AuroraHullList)[(int)hull["Index"]]);
                }
            }
            ((ComboBox)ClassDesignForm.Controls.Find("cboHullDescription", true).First()).DataSource = ModofiedHullList;
        }
    }
}