using Microsoft.AspNetCore.Mvc;
using VisitAPI.Models;
using VisitAPI.Data;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace VisitAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LabRequestController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly HttpClient _client;

        public LabRequestController(ApplicationDbContext context)
        {
            _context = context;
            _client = new HttpClient();
        }

        [HttpPost("PostToLIMS")]
        public async Task<IActionResult> PostToLIMS([FromBody] LabRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.LabRequests.Add(request);
            await _context.SaveChangesAsync();

            // Prepare payload for LIMS
            var json = JsonSerializer.Serialize(request);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            _client.DefaultRequestHeaders.Add("x-api-key", "YOUR_API_KEY");

            var response = await _client.PostAsync("http://157.230.183.65:5050/v1/labRequest/post", content);

            if (response.IsSuccessStatusCode)
                return Ok(await response.Content.ReadAsStringAsync());

            return StatusCode((int)response.StatusCode, await response.Content.ReadAsStringAsync());
        }
    }
}
