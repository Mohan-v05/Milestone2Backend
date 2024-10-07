using MaxFitGym.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MaxFitGym.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public MemberController(IMemberRepository memberRepository, IWebHostEnvironment webHostEnvironment)
        {
            _memberRepository = memberRepository;
            _webHostEnvironment = webHostEnvironment;
        }
    }
}
