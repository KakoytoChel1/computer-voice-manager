using System;
using System.Collections.Generic;
using System.Windows.Input;
using System.Windows;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Voice_Manager.Models;
using Voice_Manager.Models.DataBaseItemsAndLogic;
using System.Windows.Controls;
using Microsoft.Win32;
using System.Diagnostics;
using Vosk;
using NAudio.Wave;
using Newtonsoft.Json;
using System.Configuration;

namespace Voice_Manager.ViewModels
{
    public class MainViewModel: INotifyPropertyChanged
    {
        OpenFileDialog? fileDialog;
        bool IsRecording = false;

        public ObservableCollection<MessageBase> messageList { get; set; }

        public ObservableCollection<File> fileItems { get; set; }

        public ObservableCollection<Site> siteItems { get; set; }

        public ObservableCollection<Answer> answerItems { get; set; }

        public static VoskRecognizer rec;
        public WaveInEvent waveIn;


        public MainViewModel()
        {
            NavIndex1 = 0;
            string modelLanguage;

            messageList = new ObservableCollection<MessageBase>();

            VoiceSpeakIndication = "Transparent";
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            TrayIsChecked = Convert.ToBoolean(config.AppSettings.Settings["HideWhenClose"].Value);
            UserName = config.AppSettings.Settings["UserName"].Value;

            modelLanguage = config.AppSettings.Settings["SelectedLang"].Value;

            if (modelLanguage == "Ukranian")
                SelectedLanguage = 0;
            else if (modelLanguage == "English")
                SelectedLanguage = 1;
            else if (modelLanguage == "Russian")
                SelectedLanguage = 2;

            if (!string.IsNullOrWhiteSpace(UserName))
            {
                messageList.Add(new AssistantMessage($"Hello {UserName}, i'm happy you're here!"));
            }
            else
            {
                messageList.Add(new AssistantMessage("Hello, i don't know who're you, but i'm happy you are here!"));
            }

            fileItems = new ObservableCollection<File>(DataBaseLogic.GetFilesData());

            siteItems = new ObservableCollection<Site>(DataBaseLogic.GetSitesData());

            answerItems = new ObservableCollection<Answer>(DataBaseLogic.GetAnswersData());

            waveIn = new WaveInEvent
            {
                DeviceNumber = 0,
                WaveFormat = new WaveFormat(rate: 16000, bits: 16, channels: 1)
            };
            if (!string.IsNullOrEmpty(modelLanguage))
            {
                Model model = new Model(modelLanguage);
                rec = new VoskRecognizer(model, 16000.0f);
            }
            waveIn.DataAvailable += WaveInOnDataAvailable;

        }

        private void WaveInOnDataAvailable(object? sender, WaveInEventArgs e)
        {
            try
            {
                Application.Current.Dispatcher.Invoke(new Action(() =>
                {
                    try
                    {
                        if (rec.AcceptWaveform(e.Buffer, e.Buffer.Length))
                        {
                            Dictionary<string, string>? value = JsonConvert.DeserializeObject<Dictionary<string, string>>(rec.Result());
                            var result = value["text"];
                            if (!string.IsNullOrWhiteSpace(result))
                            {
                                TextMessage = result;
                                messageList.Add(new MyMessage(result));
                                CompareAndExecute(result);
                            }
                        }
                        else
                        {
                            Dictionary<string, string>? value = JsonConvert.DeserializeObject<Dictionary<string, string>>(rec.PartialResult());
                            TextMessage = value["partial"];
                        }
                    }
                    catch (Exception) { }
                }));
            }
            catch (Exception) { }
        }

        //the color is #32cd32(light green) or transparent
        private string? _voiceSpeakIndication;
        public string? VoiceSpeakIndication
        {
            get { return _voiceSpeakIndication; }
            set { _voiceSpeakIndication = value; OnPropertyChanged("VoiceSpeakIndication"); }
        }

        private string? _newFilePath;
        public string? NewFilePath
        {
            get { return _newFilePath; }
            set { _newFilePath = value; OnPropertyChanged("NewFilePath"); }
        }

        private string? _newFileCommand;
        public string? NewFileCommand
        {
            get { return _newFileCommand; }
            set { _newFileCommand = value; OnPropertyChanged("NewFileCommand"); }
        }

        private string? _newSiteUrl;
        public string? NewSiteUrl
        {
            get { return _newSiteUrl; }
            set { _newSiteUrl = value; OnPropertyChanged("NewSiteUrl"); }
        }

        private string? _newSiteCommand;
        public string? NewSiteCommand
        {
            get { return _newSiteCommand; }
            set { _newSiteCommand = value; OnPropertyChanged("NewSiteCommand"); }
        }

        private string? _newAnswer;
        public string? NewAnswer
        {
            get { return _newAnswer; }
            set { _newAnswer = value; OnPropertyChanged("NewAnswer"); }
        }

        private string? _newAnswerCommand;
        public string? NewAnswerCommand
        {
            get { return _newAnswerCommand; }
            set { _newAnswerCommand = value; OnPropertyChanged("NewAnswerCommand"); }
        }

        private bool? _flagtopmost;
        public bool? FlagTopMost
        {
            get { return _flagtopmost; }
            set { _flagtopmost = value; OnPropertyChanged("FlagTopMost"); }
        }

        private File _selectedFileItem;
        public File SelectedFileItem
        {
            get{ return _selectedFileItem; }
            set { _selectedFileItem = value; OnPropertyChanged("SelectedFileItem"); }
        }

        private Site _selectedSiteItem;
        public Site SelectedSiteItem
        {
            get{ return _selectedSiteItem; }
            set { _selectedSiteItem = value; OnPropertyChanged("SelectedSiteItem"); }
        }

        private Answer _selectedAnswerItem;
        public Answer SelectedAnswerItem
        {
            get { return _selectedAnswerItem; }
            set { _selectedAnswerItem = value; OnPropertyChanged("SelectedAnswerItem");}
        }

        //navigation between dialogue, menu and others
        private int _navindex2;
        public int NavIndex2
        {
            get { return _navindex2; }
            set { _navindex2 = value; OnPropertyChanged("NavIndex2"); }
        }

        //navigation between voice button and textbox (button keyboard)
        private int _navindex1;
        public int NavIndex1
        {
            get { return _navindex1; }
            set { _navindex1 = value; OnPropertyChanged("NavIndex1"); }
        }
        //textbox's message
        private string _textMessage;
        public string TextMessage
        {
            get { return _textMessage; }
            set { _textMessage = value; OnPropertyChanged("TextMessage"); }
        }
        //chat's selected index
        private int _chatSelI;
        public int ChatSelI
        {
            get { return _chatSelI; }
            set { _chatSelI = value; OnPropertyChanged("ChatSelI"); }
        }

        private bool _flagMenuButton;
        public bool FlagMenuButton
        {
            get { return _flagMenuButton; }
            set { _flagMenuButton = value; OnPropertyChanged("FlagMenuButton"); }
        }

        private bool _trayIsChecked;
        public bool TrayIsChecked
        {
            get { return _trayIsChecked; }
            set { _trayIsChecked = value; OnPropertyChanged("TrayIsChecked"); }
        }

        private int _selectedLanguage;
        public int SelectedLanguage
        {
            get { return _selectedLanguage; }
            set { _selectedLanguage = value; OnPropertyChanged("SelectedLanguage"); }
        }

        private ComboBoxItem _selectedLanguageItem;
        public ComboBoxItem SelectedLanguageItem
        {
            get { return _selectedLanguageItem; }
            set { _selectedLanguageItem = value; OnPropertyChanged("SelectedLanguageItem"); }
        }

        private string _userName;
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; OnPropertyChanged("UserName"); }
        }

        private ICommand _closeCommand;
        private ICommand _minimizeCommand;
        private ICommand _pinCommand;
        private ICommand _switchcommand1;
        private ICommand _sendMessage;
        private ICommand _menuBackCommand;
        private ICommand _switchToFileControl;
        private ICommand _switchToSiteControl;
        private ICommand _switchToResponseControl;
        private ICommand _switchToArduinoControl;
        private ICommand _switchToAdditionalSettings;
        private ICommand _switchToProfileSettings;
        private ICommand _addNewFileItemCommand;
        private ICommand _deleteFileItemCommand;
        private ICommand _editFileItemCommand;
        private ICommand _getFilePathAdd;
        private ICommand _getFilePathEdit;
        private ICommand _addNewSiteItemCommand;
        private ICommand _deleteSiteItemCommand;
        private ICommand _editSiteItemCommand;
        private ICommand _addNewAnswerItemCommand;
        private ICommand _removeAnswerItemCommand;
        private ICommand _editAnswerItemCommand;
        private ICommand _trayCheckedCommand;
        private ICommand _startVoice;
        private ICommand _saveExtraSettingsCommand;
        public ICommand CloseWindow
        {
            get 
            {
                if (_closeCommand == null)
                {
                    _closeCommand = new RelayCommand(p =>
                    {
                        var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                        MainWindow window = p as MainWindow;

                        if (TrayIsChecked)
                            window.Hide();
                        else
                            window.Close();
                    });
                }

                return _closeCommand;
            }
        }
        public ICommand MinimizeWindow
        {
            get
            {
                if(_minimizeCommand == null)
                {
                    _minimizeCommand = new RelayCommand(p =>
                    {
                        MainWindow window = p as MainWindow;

                        window.WindowState = WindowState.Minimized;
                    });
                }

                return _minimizeCommand;
            }
        }
        public ICommand PinWindow
        {
            get
            {
                if(_pinCommand == null)
                {
                    _pinCommand = new RelayCommand(p =>
                    {
                        MainWindow window = p as MainWindow;

                        if(window.Topmost == false)
                        {
                            window.Topmost = true;
                            FlagTopMost = true;
                        }
                        else
                        {
                            window.Topmost = false;
                            FlagTopMost = false;
                        }
                    });
                }

                return _pinCommand;
            }
        }
        
        //switch between voice button and textbox (button keyboard)
        public ICommand SwitchCommand1
        {
            get
            {
                if (_switchcommand1 == null)
                {
                    _switchcommand1 = new RelayCommand(p =>
                    {
                        NavIndex1 = NavIndex1 == 0 ? 1 : 0;
                    });
                }
                return _switchcommand1;
            }
        }
        public ICommand SendMessage
        {
            get
            {
                if(_sendMessage == null)
                {
                    _sendMessage = new RelayCommand(p =>
                    {
                        if (!string.IsNullOrWhiteSpace(TextMessage))
                        {
                            messageList.Add(new MyMessage(TextMessage));

                            string command = TextMessage.ToLower();

                            CompareAndExecute(command);
                        }

                        TextMessage = String.Empty;
                        ChatSelI = messageList.Count - 1;
                    });
                }
                return _sendMessage;
            }
        }

        public ICommand MenuBackCommand
        {
            get
            {
                if(_menuBackCommand == null)
                {
                    _menuBackCommand = new RelayCommand(p =>
                    {
                        switch (NavIndex2)
                        {
                            //from dialogue page to menu page
                            case 0:
                                NavIndex2 = 1;
                                FlagMenuButton = true;
                                break;
                            //from menu page to dialogue
                            case 1:
                                NavIndex2 = 0;
                                FlagMenuButton = false;
                                break;
                            //from file control list to menu page
                            case 2:
                                NavIndex2 = 1;
                                break;
                            //from site control list to menu page
                            case 3:
                                NavIndex2 = 1;
                                break;
                            //from response control list to menu page
                            case 4:
                                NavIndex2 = 1;
                                break;
                            //from smart house control list to menu page
                            case 5:
                                NavIndex2 = 1;
                                break;
                            //from extra settings to menu
                            case 6:
                                NavIndex2 = 1;
                                break;
                            //from profile to menu
                            case 7:
                                NavIndex2 = 1;
                                break;
                        }
                    });
                }

                return _menuBackCommand;
            }
        }

        public ICommand SwitchToFileControl
        {
            get
            {
                if(_switchToFileControl == null)
                {
                    _switchToFileControl = new RelayCommand(p =>
                    {
                        NavIndex2 = 2;
                    });
                }
                return _switchToFileControl;
            }
        }

        public ICommand SwitchToSiteControl
        {
            get
            {
                if(_switchToSiteControl == null)
                {
                    _switchToSiteControl = new RelayCommand(p =>
                    {
                        NavIndex2 = 3;
                    });
                }
                return _switchToSiteControl;
            }
        }

        public ICommand SwitchToResponseControl
        {
            get
            {
                if(_switchToResponseControl == null)
                {
                    _switchToResponseControl = new RelayCommand(p =>
                    {
                        NavIndex2 = 4;
                    });
                }

                return _switchToResponseControl;
            }
        }

        public ICommand SwitchToArduinoControl
        {
            get
            {
                if(_switchToArduinoControl == null)
                {
                    _switchToArduinoControl = new RelayCommand(p =>
                    {
                        NavIndex2 = 5;
                    });
                }

                return _switchToArduinoControl;
            }
        }

        public ICommand SwitchToAdditionalSettings
        {
            get
            {
                if(_switchToAdditionalSettings == null)
                {
                    _switchToAdditionalSettings = new RelayCommand(p =>
                    {
                        NavIndex2 = 6;
                    });
                }

                return _switchToAdditionalSettings;
            }
        }

        public ICommand SwitchToProfileSettings
        {
            get
            {
                if(_switchToProfileSettings == null)
                {
                    _switchToProfileSettings = new RelayCommand(p =>
                    {
                        NavIndex2 = 7;
                    });
                }

                return _switchToProfileSettings;
            }
        }

        //FileItem's commands
        public ICommand AddNewFileItemCommand
        {
            get
            {
                if(_addNewFileItemCommand == null)
                {
                    _addNewFileItemCommand = new RelayCommand(p =>
                    {
                        if (NewFilePath != null && NewFileCommand != null)
                        {
                            File fileItem = new File { PathToFile = NewFilePath, CommandForFile = NewFileCommand };

                            fileItems.Add(fileItem);
                            DataBaseLogic.AddNewItem(fileItem);

                            NewFilePath = String.Empty;
                            NewFileCommand = String.Empty;
                        }

                    }, (p) => !string.IsNullOrWhiteSpace(NewFilePath) & !string.IsNullOrWhiteSpace(NewFileCommand));
                }

                return _addNewFileItemCommand;
            }
        }

        public ICommand DeleteFileItemCommand
        {
            get
            {
                if(_deleteFileItemCommand == null)
                {
                    _deleteFileItemCommand = new RelayCommand((p) =>
                    {
                        DataBaseLogic.RemoveItem(SelectedFileItem);
                        fileItems.Remove(SelectedFileItem);
                    });
                }

                return _deleteFileItemCommand;
            }
        }

        public ICommand EditFileItemCommand
        {
            get
            {
                if(_editFileItemCommand == null)
                {
                    _editFileItemCommand = new RelayCommand((p) =>
                    {
                        DataBaseLogic.UpdateItem(SelectedFileItem);
                    });
                }

                return _editFileItemCommand;
            }
        }

        public ICommand GetFilePathAdd
        {
            get
            {
                if(_getFilePathAdd == null)
                {
                    _getFilePathAdd = new RelayCommand((p) =>
                    {
                        NewFilePath = GetFilePath();
                    });
                }

                return _getFilePathAdd;
            }
        }

        public ICommand GetFilePathEdit
        {
            get
            {
                if(_getFilePathEdit == null)
                {
                    _getFilePathEdit = new RelayCommand((p) =>
                    {
                        SelectedFileItem.PathToFile = GetFilePath();
                    });
                }

                return _getFilePathEdit;
            }
        }

        //SiteItem's commands
        public ICommand AddNewSiteItemCommand
        {
            get
            {
                if(_addNewSiteItemCommand == null)
                {
                    _addNewSiteItemCommand = new RelayCommand((p) =>
                    {
                        if(NewSiteUrl != null && NewSiteCommand != null)
                        {
                            Site siteItem = new Site { UrlOfSite=NewSiteUrl, CommandForSite=NewSiteCommand};
                            siteItems.Add(siteItem);
                            DataBaseLogic.AddNewItem(siteItem);

                            NewSiteUrl = String.Empty;
                            NewSiteCommand = String.Empty;
                        }
                    }, (p) => !string.IsNullOrWhiteSpace(NewSiteUrl) & !string.IsNullOrWhiteSpace(NewSiteCommand));
                }

                return _addNewSiteItemCommand;
            }
        }

        public ICommand DeleteSiteItemCommand
        {
            get
            {
                if(_deleteSiteItemCommand == null)
                {
                    _deleteSiteItemCommand = new RelayCommand((p) =>
                    {
                        DataBaseLogic.RemoveItem(SelectedSiteItem);
                        siteItems.Remove(SelectedSiteItem);
                    });
                }

                return _deleteSiteItemCommand;
            }
        }

        public ICommand EditSiteItemCommand
        {
            get
            {
                if(_editSiteItemCommand == null)
                {
                    _editSiteItemCommand = new RelayCommand((p) =>
                   {
                       DataBaseLogic.UpdateItem(SelectedSiteItem);
                   });
                }

                return _editSiteItemCommand;
            }
        }

        //AnswerItem's commands
        public ICommand AddNewAnswerItemCommand
        {
            get
            {
                if(_addNewAnswerItemCommand == null)
                {
                    _addNewAnswerItemCommand = new RelayCommand((p) =>
                    {
                        if(NewAnswer != null && NewAnswerCommand != null)
                        {
                            Answer answerItem = new Answer { AssistantAnswer = NewAnswer, AnswerCommand = NewAnswerCommand};
                            answerItems.Add(answerItem);
                            DataBaseLogic.AddNewItem(answerItem);

                            NewAnswer = String.Empty;
                            NewAnswerCommand = String.Empty;
                        }
                    }, (p) => !string.IsNullOrWhiteSpace(NewAnswer) & !string.IsNullOrWhiteSpace(NewAnswerCommand));
                }

                return _addNewAnswerItemCommand;
            }
        }

        public ICommand DeleteAnswerItemCommand
        {
            get
            {
                if(_removeAnswerItemCommand == null)
                {
                    _removeAnswerItemCommand = new RelayCommand((p) =>
                    {
                        DataBaseLogic.RemoveItem(SelectedAnswerItem);
                        answerItems.Remove(SelectedAnswerItem);
                    });
                }

                return _removeAnswerItemCommand;
            }
        }

        public ICommand EditAnswerItemCommand
        {
            get
            {
                if(_editAnswerItemCommand == null)
                {
                    _editAnswerItemCommand = new RelayCommand((p) =>
                    {
                        DataBaseLogic.UpdateItem(SelectedAnswerItem);
                    });
                }

                return _editAnswerItemCommand;
            }
        } 

        public ICommand StartVoice
        {
            get
            {
                if(_startVoice == null)
                {
                    _startVoice = new RelayCommand((p) =>
                    {
                        if (!IsRecording)
                        {
                            waveIn.StartRecording();
                            VoiceSpeakIndication = "#32cd32";
                            IsRecording = true;
                        }
                        else
                        {
                            waveIn.StopRecording();
                            VoiceSpeakIndication = "Transparent";
                            IsRecording = false;
                        }
                    });
                }

                return _startVoice;
            }
        }

        public ICommand TrayCheckedCommand
        {
            get
            {
                if(_trayCheckedCommand == null)
                {
                    _trayCheckedCommand = new RelayCommand((p) =>
                    {
                        SaveToConfig("HideWhenClose", TrayIsChecked.ToString());
                    });
                }

                return _trayCheckedCommand;
            }
        }

        public ICommand SaveExtraSettingsCommand
        {
            get
            {
                if(_saveExtraSettingsCommand == null)
                {
                    _saveExtraSettingsCommand = new RelayCommand((p) =>
                    {
                        SaveToConfig("SelectedLang", SelectedLanguageItem.Content.ToString());
                        SaveToConfig("UserName", UserName);

                        System.Windows.Forms.Application.Restart();
                        Application.Current.Shutdown();
                    });
                }

                return _saveExtraSettingsCommand;
            }
        }

        //other methods
        public string GetFilePath()
        {
            string result = String.Empty;
            fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = false;

            if (fileDialog.ShowDialog() == true)
            {
                result = fileDialog.FileName;
            }
            return result;
        }

        public void CompareAndExecute(string command)
        {
            //string result = String.Empty;
            bool IsFoundFileResult = false;
            bool IsFoundSiteResult = false;
            bool IsFoundAnswerResult = false;

            try
            {
                foreach (var item in fileItems)
                {
                    if (item.CommandForFile.ToLower().Trim() == command)
                    {
                        //result = $"I'm opening the following path: {item.PathToFile}";
                        messageList.Add(new AssistantMessage($"I'm opening the following path: {item.PathToFile}"));
                        Process.Start(new ProcessStartInfo { FileName = item.PathToFile, UseShellExecute = true });
                        IsFoundFileResult = true;

                        if (IsRecording == true)
                        {
                            waveIn.StopRecording();
                            VoiceSpeakIndication = "Transparent";
                            IsRecording = false;
                        }
                    }
                }
                foreach (var item in siteItems)
                {
                    if (item.CommandForSite.ToLower().Trim() == command)
                    {
                        //result = $"I'm opening the following url: {item.UrlOfSite}";
                        messageList.Add(new AssistantMessage($"I'm opening the following url: {item.UrlOfSite}"));
                        Process.Start(new ProcessStartInfo { FileName = item.UrlOfSite, UseShellExecute = true });
                        IsFoundSiteResult = true;

                        if (IsRecording == true)
                        {
                            waveIn.StopRecording();
                            VoiceSpeakIndication = "Transparent";
                            IsRecording = false;
                        }
                    }
                }
                foreach (var item in answerItems)
                {
                    if (item.AnswerCommand.ToLower().Trim() == command)
                    {
                        messageList.Add(new AssistantMessage(item.AssistantAnswer));
                        IsFoundAnswerResult = true;

                        if (IsRecording == true)
                        {
                            waveIn.StopRecording();
                            VoiceSpeakIndication = "Transparent";
                            IsRecording = false;
                        }
                    }
                }
                if (IsFoundFileResult == false && IsFoundSiteResult == false && IsFoundAnswerResult == false)
                {
                    //if no one of these command lists doesn't work, we will be use the following
                    messageList.Add(new AssistantMessage($"Here's what i was able to find on '{command}'"));
                    Process.Start(new ProcessStartInfo { FileName = @$"https://www.google.com/search?q={command}", UseShellExecute = true });

                    if (IsRecording == true)
                    {
                        waveIn.StopRecording();
                        VoiceSpeakIndication = "Transparent";
                        IsRecording = false;
                    }
                }
                ChatSelI = messageList.Count - 1;
                TextMessage = String.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }        

        public void SaveToConfig(string key, string value)
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings[key].Value = value;
            config.Save(ConfigurationSaveMode.Modified);
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
