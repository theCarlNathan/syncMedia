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
        public DataFileModel GetData()
        {
            var data = JsonConvert.DeserializeObject<DataFileModel>(File.ReadAllText("./AppData/DataFile.json"));

            return data;
        }

        public bool Insert(DataModel model)
        {
            var data = GetData();
            //model.Id = data.Data.OrderByDescending(x => x.Id).First().Id + 1;
            if (data.Data.Select(x => x.Id).Contains(model.Id))
            {
                throw new Exception("ID " + model.Id + " already exists!");
            }
            data.Data.Add(model);

            File.WriteAllText("./AppData/DataFile.json", JsonConvert.SerializeObject(data));
            return true;

        }

        public bool Update(DataModel model, int id)
        {
            var data = GetData();

            data.Data.Where(x => x.Id == id).SetValue(c => c.Value = model.Value);

            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

    }
}
