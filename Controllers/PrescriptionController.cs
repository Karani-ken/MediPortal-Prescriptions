using AutoMapper;
using MediPortal_Prescriptions.Models;
using MediPortal_Prescriptions.Models.Dtos;
using MediPortal_Prescriptions.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediPortal_Prescriptions.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPrescriptionInterface _prescriptionInterface;
        private readonly ResponseDto _response;
        public PrescriptionController(IMapper mapper, IPrescriptionInterface prescriptionInterface)
        {
            _mapper= mapper;
            _response= new ResponseDto();
            _prescriptionInterface=prescriptionInterface;
        }
        [HttpPost]
        public async Task<ActionResult<ResponseDto>> AddPrescription(PrescriptionRequestDto prescription)
        {
            var newPrescription = _mapper.Map<Prescription>(prescription);
            var res = await _prescriptionInterface.AddPrescription(newPrescription);
            if (string.IsNullOrWhiteSpace(res))
            {
                _response.IsSuccess = false;
                _response.Message = "could not add prescription";
                return BadRequest(_response);
            }

            _response.Message = res;
            return Ok(_response);
        }
        [HttpPut]
        public async Task<ActionResult<ResponseDto>> UpdatePrescription(Guid Id,PrescriptionRequestDto prescription)
        {
            var prescriptions = await _prescriptionInterface.GetPrescriptions();
            var prescriptionToUpdate = prescriptions.FirstOrDefault(p => p.PrescriptionId == Id);
           
            if (prescriptionToUpdate == null)
            {
                _response.IsSuccess = false;
                _response.Message = "could not update prescription";
                return BadRequest(_response);
            }
            var updatedPrescription = _mapper.Map(prescription, prescriptionToUpdate);
            var res = await _prescriptionInterface.EditPrescription(updatedPrescription);
            _response.Message = res;
            return Ok(_response);
        }
        [HttpGet]
        public async Task<ActionResult<ResponseDto>> GetPrescriptions()
        {
            var res = await _prescriptionInterface.GetPrescriptions();
            if (res == null)
            {
                _response.IsSuccess = false;
                _response.Message = "could not fetch";
                return BadRequest(_response);
            }

            _response.obj = res;
            return Ok(_response);
        }
        [HttpDelete]
        public async Task<ActionResult<ResponseDto>> DeletePrescription(Guid Id)
        {
            var prescriptions = await _prescriptionInterface.GetPrescriptions();
            var prescriptionToDelete = prescriptions.FirstOrDefault(p => p.PrescriptionId == Id);

            if (prescriptionToDelete == null)
            {
                _response.IsSuccess = false;
                _response.Message = "could fetch prescription";
                return BadRequest(_response);
            }
           
            var res = await _prescriptionInterface.DeletePrescription(prescriptionToDelete);
            _response.Message = res;
            return Ok(_response);
        }

    }
}
