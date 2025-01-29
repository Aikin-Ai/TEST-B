using Ryujinx.Ava.UI.ViewModels;
using System.Globalization;

namespace Ryujinx.Ava.UI.Models
{
    public class ModModel : BaseModel
    {
        private bool _enabled;

        public bool Enabled
        {
            get => _enabled;
            set
            {
                _enabled = value;
                OnPropertyChanged();
            }
        }

        public bool InSd { get; }
        public string Path { get; }
        public string Name { get; }

        public string FormattedName => 
            InSd && ulong.TryParse(Name, NumberStyles.HexNumber, null, out ulong applicationId)
                ? $"Atmosphère: {System.IO.Path.GetFileNameWithoutExtension(RyujinxApp.MainWindow.ApplicationLibrary.GetNameForApplicationId(applicationId))}"
                : Name;

        public ModModel(string path, string name, bool enabled, bool inSd)
        {
            Path = path;
            Name = name;
            Enabled = enabled;
            InSd = inSd;
        }
    }
}
