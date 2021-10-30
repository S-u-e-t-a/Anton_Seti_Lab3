using Lab3SetiUI.Service;
using Microsoft.Win32;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using Lab3Seti;
using System;
using System.Windows;

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

        public string VerHorParityResult
        {
            get { return verHorParityResult; }
            set
            {
                verHorParityResult = value;
                OnPropertyChanged();
            }
        }

        public string CRC32Result
        {
            get { return crc32result; }
            set
            {
                crc32result = value;
                OnPropertyChanged();
            }
        }

        public string Polynome
        {
            get { return polynome; }
            set 
            { 
                polynome = value;
                OnPropertyChanged();
            }
        }

        public int DegreePolynome
        {
            get { return degreePolynome; }
            set 
            { 
                degreePolynome = value;
                OnPropertyChanged();
            }
        }


        #endregion

        #region Fields
        private char[] _inputText;

        private string parityResult;
        private string verHorParityResult;
        private string crc32result;

        private string polynome;
        private int degreePolynome;

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
                }));

            }
        }

        private RelayCommand startCommand;

        public RelayCommand StartCommand
        {
            get
            {
                return startCommand ?? (startCommand = new RelayCommand(o =>
                {
                    if (!IsPolynomeCorrect())
                    {
                        MessageBox.Show("Полином указан неверно, проверьте корректность ввода", "Ошибка",
                            MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    else if ((_inputText is null) || string.IsNullOrEmpty(_inputText.ToString()))
                    {
                        MessageBox.Show("Не выбран файл для расчета контрольных сумм", "Ошибка",
                            MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    else
                    {                        
                        ParityResult = Parity.MakeMessage(_inputText).ToString();

                        uint[] ctrlSumVer;
                        uint[] ctrlSumHor;
                        VerHorParity.VertAndHorizontParityControlSum(_inputText, out ctrlSumVer, out ctrlSumHor);
                        VerHorParityResult = string.Join("", ctrlSumVer) + Environment.NewLine;
                        VerHorParityResult += string.Join("", ctrlSumHor);

                        uint crcCtrlSum;
                        CRCRefactoring.CRC32(_inputText, out crcCtrlSum, DegreePolynome, uint.Parse(Polynome));
                        CRC32Result = Convert.ToString(crcCtrlSum, 16).ToString().ToUpper();
                    }

                }));
            }

        }


        #endregion

        #region Functions

        private bool IsPolynomeCorrect()
        {    
            uint t;
            return uint.TryParse(Polynome, out t); // работает только если полином в 10 системе счисления
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
