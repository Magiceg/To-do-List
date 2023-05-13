using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using To_do_List.Models;
using To_do_List.Services;

namespace To_do_List
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly string PATH = $"{Environment.CurrentDirectory}\\todoDateList.json";//this variable stores the path to the file
        private BindingList<ToDoModels> _toDoList;
        private FileService _fileIOService;

        public MainWindow()
        {
            InitializeComponent();
        }
        // to store previously created tasks
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            _fileIOService = new FileService(PATH);
            try
            {
                _toDoList = _fileIOService.LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Close();
            }
            

            TodoList.ItemsSource = _toDoList;
            //when updating the list, the event will be called 
            _toDoList.ListChanged += _toDoDateList_ListChanged;
        }
        // to save data to the hard disk
        private void _toDoDateList_ListChanged(object sender, ListChangedEventArgs e)
        {
            // 
            if(e.ListChangedType == ListChangedType.ItemAdded || e.ListChangedType == ListChangedType.ItemChanged || e.ListChangedType == ListChangedType.ItemDeleted)
            {
                try
                {
                    _fileIOService.SaveData(sender);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    Close();
                }
            }
        }
    }
}
