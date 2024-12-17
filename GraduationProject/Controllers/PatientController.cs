using AutoMapper;
using GraduationProject.Data;
using GraduationProject.DTO;
using GraduationProject.Models.Domain;
using GraduationProject.Repositores;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GraduationProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientRepository patientrepo;
        private readonly IMapper mapper;


        public PatientController(IPatientRepository patientrepo, IMapper mapper)
        {
            this.patientrepo = patientrepo;
            this.mapper = mapper;
           
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int pageNumber = 1, int pageSize = 1000)
        {
            var patients = await patientrepo.GetAll(pageNumber, pageSize);
            return Ok(patients);
        }

        [HttpGet]
        [Route("ById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var patient = await patientrepo.GetById(id);
            return Ok(patient);
        }

        [HttpGet]
        [Route("ByName/{name}")]
        public async Task<IActionResult> GetByName(string name)
        {
            var patient = await patientrepo.GetByName(name);
            return Ok(patient);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddPatientDto addPatientDto)
        {
            var patientmodel = mapper.Map<Patient>(addPatientDto);
            await patientrepo.Create(patientmodel);

            var patientdto = mapper.Map<PatientDto>(patientmodel);
            return Ok(patientdto);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var patientmodel = await patientrepo.Delete(id);
            if (patientmodel == null)
            {
                return NotFound(new { Message = "Patient not found" });
            }

            var patientdto = mapper.Map<PatientDto>(patientmodel);
            return Ok("Patient deleted successfully");
        }

        [HttpGet]
        [Route("{patientid}/medical-staff")]
        public async Task<IActionResult> GetAllMedicalStaffForPatient(int patientid)
        {
            var medicalStaffmodel = await patientrepo.GetMedicalStaffForPatient(patientid);

            if (medicalStaffmodel == null || !medicalStaffmodel.Any())
            {
                return NotFound("No medical staff found for the patient!");
            }

            var medicalStaffdto = mapper.Map<List<GetAllMedicalStaffForPateintDto>>(medicalStaffmodel);
            return Ok(medicalStaffdto); 
        }

        [HttpGet]
        [Route("{id}/Gurdians")]
        public async Task<IActionResult> GetAllGurdiansForPatient(int id)
        {
            var gurdiansmodel = await patientrepo.GetAllGuardiansForPateint(id);
            if(gurdiansmodel == null || !gurdiansmodel.Any())
            {
                return NotFound("No Gurdian founded for the patient!");
            }

            var gurdiandto = mapper.Map<List<GetAllGuardiansDto>>(gurdiansmodel);
            return Ok(gurdiandto);  
        }

        [HttpGet]
        [Route("{id}/Medical-History")]
        public async Task<IActionResult> GetMedicalHistoryForPatient(int id)
        {
            var medicalhistorymodel = await patientrepo.GetMedicalHistoryDtoForPateint(id);
            if(medicalhistorymodel == null)
            {
                return NotFound("No medical history founded for the patient!");
            }
            var medicalhistorydto = mapper.Map<GetMedicalHistoryDto>(medicalhistorymodel);    
            return Ok(medicalhistorydto);   
        }

        [HttpGet]
        [Route("{id}/Reports")]
        public async Task<IActionResult> GetAllReportsForPatient(int id)
        {
            var reportModel = await patientrepo.GetReportsForPatient(id);

            if (reportModel == null || !reportModel.Any())
            {
                return NotFound("No reports found for the patient!");
            }

            // Map the list of report models to a list of DTOs
            var reportsDto = mapper.Map<List<GetAllReportsDto>>(reportModel);

            return Ok(reportsDto);
        }


        [HttpGet]
        [Route("{id}/details")]
        public async Task<IActionResult> GetAllDetailsForPatient(int id)
        {
            var patientdetails = await patientrepo.GetPatientDetails(id);
            if(patientdetails == null)
            {
                return NotFound($"Patient with id {id} not founded!");
            }

            return Ok(patientdetails);
        }

    }
}
