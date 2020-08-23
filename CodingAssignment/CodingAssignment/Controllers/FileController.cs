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
        public DataFileModel Get(int? id)
        {
            return _fileManger.GetData(id);
        }

        [HttpPost]
        public ActionResult Post(DataModel model)
        {

            try
            {
                _fileManger.Insert(model);
                return Ok();
            }
            catch(Exception ex)
            {
                return new JsonResult(ex.Message);
            }            
        }

        [HttpPut]
        public ActionResult Put(DataModel model)
        {
            try
            {
                _fileManger.Update(model);
                return Ok();
            }
            catch(Exception ex)
            {
                return new JsonResult(ex.Message);
            }
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            try
            {
                _fileManger.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message);
            }
        }
    }
}
