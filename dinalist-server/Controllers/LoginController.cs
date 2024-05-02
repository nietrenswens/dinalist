using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class LoginController : ControllerBase
{
    private readonly ILoginService _loginService;

    public LoginController(ILoginService loginService)
    {
        _loginService = loginService;
    }


    [HttpPost]
    public async Task<ActionResult<LoginResponse>> LoginAsync([FromBody] LoginRequest request)
    {
        LoginResponse? response = await _loginService.LoginAsync(request);
        if (response == null) return Unauthorized();
        return Ok(response);
    }

    [HttpPost("istokenvalid")]
    public ActionResult<TokenVerificationResponse> VerifyToken([FromBody] TokenRequest request)
    {
        bool isValid = _loginService.IsTokenValid(request);
        return Ok(new TokenVerificationResponse(isValid));
    }

}