using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Shapes.Interpretation;

namespace ShapeEditor
{
    public class ShapeEditorApp
    {
        private readonly IShapeBuilderLoader builderLoader_;
        private readonly Form mainForm_;

        public ShapeEditorApp(
            IShapeBuilderLoader builderLoader, 
            Form mainForm)
        {
            builderLoader_ = builderLoader;
            mainForm_ = mainForm;
        }

        public void Run()
        {
            LoadPlugins();
            RunMainForm();
        }

        private void LoadPlugins()
        {
            // TODO: inject configuration manager to avoid using static
            var fileNames = (ConfigurationManager.AppSettings["pluginDlls"] ?? "")
                .Split(new[] {';'}, StringSplitOptions.None)
                .Where(path => !String.IsNullOrWhiteSpace(path));
            foreach (string fileName in fileNames)
            {
                LoadPlugins(fileName);
            }
        }

        private void LoadPlugins(string dllFileName)
        {
            // TODO: can be done via UI at runtime
            try
            {
                using (var stream = File.Open(dllFileName, FileMode.Open))
                {
                    // TODO: load plugins for shape loader
                    builderLoader_.Load(stream);
                }
            }
            catch (Exception ex)
            {
                // TODO: log
            }
        }

        private void RunMainForm()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(mainForm_);
        }
    }
}
