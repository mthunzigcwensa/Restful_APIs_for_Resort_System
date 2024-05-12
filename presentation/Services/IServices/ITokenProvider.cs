using presentation.Models.Dto;

namespace presentation.Services.IServices
{
    public interface ITokenProvider
    {
        void SetToken(TokenDTO tokenDTO);
        TokenDTO? GetToken();
        void ClearToken();
    }
}
