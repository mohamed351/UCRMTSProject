using UCRDemo.DTOS;
using static UCRDemo.Services.UCRService;

namespace UCRDemo.Services
{
    public interface IUCRService
    {
        Task<AuthicationResponseDTO> Authication(AuthicationType authicationType);
    }
}
