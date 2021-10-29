using Lab3SetiUI.Service;
using Microsoft.Win32;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using Lab3Seti;

namespace Lab3SetiUI.ViewModel
{
    class MainWindowVM : INotifyPropertyChanged
    {
        #region Properties
        public string ParityResult
        {
            get { return parityResult; }
            set 
            { 
                parityResult = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Fields
        private char[] _inputText;

        private string parityResult;        

        #endregion

        #region Commands

        private RelayCommand readFile;

        public RelayCommand ReadFile
        {
            get
            {
                return readFile ?? (readFile = new RelayCommand(o =>
                {
                    var dlg = new OpenFileDialog();
                    dlg.DefaultExt = ".txt";
                    var result = dlg.ShowDialog();
                    if (result == true)
                    {
                        var data = File.ReadAllText(dlg.FileName);
                        _inputText = data.ToCharArray();
                    }
                    ParityResult = Parity.MakeMessage(_inputText).ToString(); // вынести в command на нажатие кнопки

                }));

            }
        }

        #endregion

        #region PropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }

        #endregion
    }
}
