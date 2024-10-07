﻿using MaxFitGym.IRepository;
using MaxFitGym.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MaxFitGym.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgramController : ControllerBase
    {
        private readonly IProgramRepository _programRepository;

        public ProgramController(IProgramRepository programRepository)
        {
            _programRepository = programRepository;
        }


        //To Add new Program
        [HttpPost("Add-program")]
        public IActionResult AddProgram(ProgramDTO programDto)
        {
            try
            {
                var programData = _programRepository.AddProgram(programDto);
                return Ok(programData);
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
                    }
        }
        //Get all Programs
        [HttpGet("Get-All-Programs")]

        public IActionResult GetAllCourses()
        {
            var ProgramList = _programRepository.GetAllPrograms();
            return Ok(ProgramList);
        }

        // Get Program By Id
        [HttpGet("Get-Progr-By-ID /{programId}")]

        public IActionResult GetProgramById(int programId)
        {
            try
            {
                var program = _programRepository.GetProgramById(programId);
                return Ok(program);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Update Program
        [HttpPut("Update-Program/{ProgramID}/{TotalFee}")]
        public IActionResult UpdateProgram(int ProgramID, int TotalFee)
        {
            try
            {
                _programRepository.UpdateProgram(ProgramID, TotalFee);
                return Ok("Program Updated Successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Delete Program
        [HttpDelete("Delete-Program/{ProgramId}")]

        public IActionResult DeleteProgram(int ProgramId)
        {
            try
            {
                _programRepository.DeleteProgram(ProgramId);
                return Ok("Program Deleted Successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
