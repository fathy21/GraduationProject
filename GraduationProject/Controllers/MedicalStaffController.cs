using AutoMapper;
using GraduationProject.DTO;
using GraduationProject.Models.Domain;
using GraduationProject.Repositores;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace GraduationProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalStaffController : ControllerBase
    {
        private readonly IMedicalStaffRepository _medicalStaffrepo;
        private readonly IMapper _mapper;

        public MedicalStaffController(IMedicalStaffRepository medicalStaffrepo , IMapper mapper)
        {
            _medicalStaffrepo = medicalStaffrepo;
            _mapper = mapper;
        }

        [HttpGet]   
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _medicalStaffrepo.GetAllAsync());    
        }

        [HttpGet]
        [Route("ByName/{name}")]
        public async Task<IActionResult> GetByName(string name)
        {
            var medicalStaff = await _medicalStaffrepo.GetByName(name);
            return Ok(medicalStaff);
        }

        [HttpGet]
        [Route("ById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var medicalStaff = await _medicalStaffrepo.GetById(id);
            return Ok(medicalStaff);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddMedicalStaffDto addMedicalStaffDto)
        {
            // Map AddMedicalStaffDto to MedicalStaff domain model
            var medicalStaffModel = _mapper.Map<MedicalStaff>(addMedicalStaffDto);
            await _medicalStaffrepo.Create(medicalStaffModel);

            // Map MedicalStaff domain model to MedicalStaffDto for the response
            var medicalStaffDto = _mapper.Map<MedicalStaffDto>(medicalStaffModel);
            return Ok(medicalStaffDto);
        }

        [HttpDelete]
        [Route("DeleteById/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var medicalStaffModel = await _medicalStaffrepo.Delete(id);
            if (medicalStaffModel == null)
            {
                return NotFound(new { Message = "medicalStaff not found" });
            }

            var medicalStaffdto = _mapper.Map<MedicalStaffDto>(medicalStaffModel);
            return Ok("medicalStaff deleted successfully");
        }

        [HttpPut]
        [Route("UpateById/{id}")]
        public async Task<IActionResult> Update([FromRoute] int id , UpdateMedicalStaffDto updateMedicalStaffDto)
        {
            var medicalStaffModel = _mapper.Map<MedicalStaff>(updateMedicalStaffDto);
            medicalStaffModel = await _medicalStaffrepo.Update(id, medicalStaffModel);
            if (medicalStaffModel == null)
            {
                return NotFound();
            }

            var medicalStaffdto = _mapper.Map<MedicalStaffDto>(medicalStaffModel);
            return Ok(medicalStaffdto);
        }

        [HttpGet]
        [Route("{staffid}/patients")]
        public async Task<IActionResult> GetPatientForMedicalStaff(int staffid)
        {
            var medicalstaff = await _medicalStaffrepo.GetPatientForMedicalStaff(staffid);
            
            if(medicalstaff  == null)
            {
                return NotFound($"Medical staff with ID {staffid} not found.");
            }

            if (medicalstaff.Patient == null)
            {
                return NotFound($"No patient is associated with medical staff ID {staffid}.");
            }

            var patientsdto = _mapper.Map<GetPatientByMedicalStaff>(medicalstaff.Patient);
            return Ok(patientsdto);
        }

        [HttpGet]
        [Route("{staffid}/notifications")]
        public async Task<IActionResult> GetAllNotificationForMedicalStaff(int staffid)
        {
            var medicalstaff = await _medicalStaffrepo.GetAllNotificationForMedicalStaff(staffid);
            if(medicalstaff == null || !medicalstaff.Any())
            {
                return NotFound($"notifications for medical staff with ID {staffid} not found ");
            }

            var medicalstaffdto = _mapper.Map<List<GetAllNotificationForMedicalStaffDto>>(medicalstaff);
            return Ok(medicalstaffdto);
        }

        [HttpGet]
        [Route("{staffid}/emerginces")]
        public async Task<IActionResult> GetAllEmergencyForMedicalStaff (int staffid)
        {
            var medicalstaff = await _medicalStaffrepo.GetAllEmergencyForMedicalStaff(staffid);
            if (medicalstaff == null || !medicalstaff.Any())
            {
                return NotFound($"emerginces for medical staff with ID {staffid} not found ");
            }

            var medicalstaffdto = _mapper.Map<List<GetAllEmergencyForMedicalStaffDto>>(medicalstaff);
            return Ok(medicalstaffdto);
        }
    }
}
