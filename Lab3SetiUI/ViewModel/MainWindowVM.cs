﻿using Lab3SetiUI.Service;
using Microsoft.Win32;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using Lab3Seti;
using System;

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

        #endregion

        #region Fields
        private char[] _inputText;

        private string parityResult;
        private string verHorParityResult;
        private string crc32result;

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
                    uint[] ctrlSumVer;
                    uint[] ctrlSumHor;
                    ParityResult = Parity.MakeMessage(_inputText).ToString(); 

                    VerHorParity.VertAndHorizontParityControlSum(_inputText, out ctrlSumVer, out ctrlSumHor);
                    VerHorParityResult = string.Join("", ctrlSumVer) + Environment.NewLine;
                    VerHorParityResult += string.Join("", ctrlSumHor);

                    uint crcCtrlSum;
                    CRCRefactoring.CRC32(_inputText, out crcCtrlSum);
                    CRC32Result = Convert.ToString(crcCtrlSum, 16).ToString().ToUpper();

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
