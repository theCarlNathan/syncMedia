using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodingAssignment.Models;
using CodingAssignment.Services;
using CodingAssignment.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CodingAssignment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FileController : ControllerBase
    {

        private IFileManagerService _fileManger;

        public FileController(IFileManagerService fileManager)
        {
            _fileManger = fileManager;
        }

        [HttpGet]
        public DataFileModel Get()
        {
            return _fileManger.GetData();
            //throw new NotImplementedException();
        }

        [HttpPost]
        public DataFileModel Post(DataModel model)
        {
            //Not yet implemented 
            throw new NotImplementedException();
        }

        [HttpPut]
        public DataFileModel Put(DataModel model, int id)
        {
            //Not yet implemented 
            throw new NotImplementedException();
        }

        [HttpDelete]
        public DataFileModel Delete(int id)
        {
            //Not yet implemented 
            throw new NotImplementedException();
        }
    }
}
