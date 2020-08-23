using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CodingAssignment.Models;
using CodingAssignment.Services.Interfaces;
using Newtonsoft.Json;

namespace CodingAssignment.Services
{
    public class FileManagerService: IFileManagerService
    {
        string filePath = "./AppData/DataFile.json";

        public DataFileModel GetData(int? id)
        {
            var data = JsonConvert.DeserializeObject<DataFileModel>(File.ReadAllText(filePath));
            if (id.HasValue)
            {
                data.Data = data.Data.Where(x => x.Id == id).ToList();
            }
            return data;
        }


        public bool Insert(DataModel model)
        {
            var data = GetData(null);
            //model.Id = data.Data.OrderByDescending(x => x.Id).First().Id + 1;
            if (data.Data.Select(x => x.Id).Contains(model.Id))
            {
                throw new Exception("ID " + model.Id + " already exists!");
            }
            data.Data.Add(model);

            File.WriteAllText(filePath, JsonConvert.SerializeObject(data));
            return true;

        }

        public bool Update(DataModel model)
        {
            var data = GetData(null);

            if (data.Data.Select(x => x.Id).Contains(model.Id))
            {
                data.Data.Where(x => x.Id == model.Id).SetValue(c => c.Value = model.Value);
                File.WriteAllText(filePath, JsonConvert.SerializeObject(data));
                return true;
            }
            
            throw new Exception("ID " + model.Id + " does not exist. nothing updated");
        }

        public bool Delete(int id)
        {
            var data = GetData(null);

            DataModel dataModel;
            try
            {
                dataModel = data.Data.Where(x => x.Id == id).First();
            }
            catch
            {
                throw new Exception("Id " + id + " not found!");
            }

            data.Data.Remove(dataModel);
            File.WriteAllText(filePath, JsonConvert.SerializeObject(data));

            return true;
        }

    }
}
