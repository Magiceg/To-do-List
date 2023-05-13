using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using To_do_List.Models;

namespace To_do_List.Services
{
    internal class FileService
    {
        private readonly string PATH; //variable for saving data    
        public FileService(string text)
        {
            PATH = text;
        }
        //to read data from the hard disk 
        public BindingList<ToDoModels> LoadData()
        {
            //checking for the existence of a file  
            var fileExists = File.Exists(PATH);
            if(!fileExists)
            {
                //If the file doesn't exist
                File.CreateText(PATH).Dispose();
                return new BindingList<ToDoModels>();
            }
            //reading from a file is being performed 
            using (var reader = File.OpenText(PATH))
            {
                var fileText = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<BindingList<ToDoModels>>(fileText);
            }  
        }
        //save data for the hard disk 
        public void SaveData(object toDoModels)
        {
            //freeing up resources for writing data to a file 
            using (StreamWriter sw = File.CreateText(PATH))
            {
                string output = JsonConvert.SerializeObject(toDoModels);
                sw.Write(output);
            }

        }
    }
}
