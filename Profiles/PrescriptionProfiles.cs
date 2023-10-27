using AutoMapper;
using MediPortal_Prescriptions.Models;
using MediPortal_Prescriptions.Models.Dtos;

namespace MediPortal_Prescriptions.Profiles
{
    public class PrescriptionProfiles:Profile
    {
        public PrescriptionProfiles()
        {
            CreateMap<Prescription,PrescriptionRequestDto>().ReverseMap();
            CreateMap<Prescription,PrescriptionDto>().ReverseMap();
        }
    }
}
