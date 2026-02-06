using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuickStart.WepApi.Context;
using QuickStart.WepApi.Entity;

namespace QuickStart.WepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly QuickStartContext _context;


        public TestimonialController(QuickStartContext context)
        {
            _context = context;

        }
        [HttpGet]

        public IActionResult GetAll()
        {
            var value = _context.testimonials.ToList();
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateTestimonial(Testimonial testimonial)
        {
            _context.testimonials.Add(testimonial);
            _context.SaveChanges();
            return Ok("Ekleme İşlemi Başarılı");
        }
        [HttpPut]

        public IActionResult UpdateTestimonial(Testimonial testimonial)
        {

            _context.testimonials.Update(testimonial);
            _context.SaveChanges();
            return Ok("Güncelle İşlemi Gerçekleşti");

        }

        [HttpDelete]
        public IActionResult DeleteTestimonial(int id)
        {
            var value = _context.testimonials.Find(id);

            if (value == null)
            {
                return NotFound("Kayıt Bulunumadı");

            }
            _context.testimonials.Remove(value);
            _context.SaveChanges();
            return Ok("Başarıyla Silindi");
        }
    }
}
