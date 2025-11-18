using Programming.API.Attiribute;
using Programming.API.Security;
using Programming.DAL;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;

namespace Programming.API.Controllers
{

    //WebApiConfig üzerinden-[ApiExceptionAttiribute]
    [APIAuthorizeAttiribute(Roles = "A")]
    public class LanguagesController : ApiController
    {
        // GET: Languages
        LanguagesDAL languagesDAL = new LanguagesDAL();

        public IHttpActionResult GetSearchByName(string name)
        {
            return Ok("Name : " + User.Identity.Name);
        }

        //Yukarıdaki gibi Get attirbute vermeden [HttpGet] şeklinde çağırabiliriz.
        [HttpGet]
        public IHttpActionResult SearchBySurname(string surname)
        {
            return Ok("Surname : " + surname);
        }


        [ResponseType(typeof(IEnumerable<Languages>))] 
        //Adı ne olursa olsun get isteği geldiğinde bu methodu çalıştıracak
        public IHttpActionResult Get()
        {
            var languages = languagesDAL.GetAllLanguages();
            return Ok(languages);
            //Uzun yazılan format.
            //Request.CreateResponse(HttpStatusCode.OK, languages);
        }
        [ResponseType(typeof(Languages))]

        public IHttpActionResult Get(int id)
        {
                var language = languagesDAL.GetLanguagesById(id);
                if (language == null)
                {
                    return NotFound();
                }
                return Ok();
        }

        [ResponseType(typeof(Languages))]
        public IHttpActionResult Post(Languages language)
        {
            if (ModelState.IsValid)
            {
                var createdLanguage = languagesDAL.CreateLanguage(language);
                return CreatedAtRoute("DefaultApi", new { id = createdLanguage.Id }, createdLanguage);
            }
            else
            {
                return BadRequest(ModelState);
            }   
        }
        [ResponseType(typeof(Languages))]
        public IHttpActionResult Put(int id, Languages language)
        {
            //Id ye ait kayıt yok ise
            //Language modeli doğrulanmadıysa
            //OK
            if (languagesDAL.IsThereAnyLanguage(id) == false)
            {
                return NotFound();
            }
            else if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            else
            {
                //languagesDAL.UpdateLanguage(id, language)
                return Ok(languagesDAL.UpdateLanguage(id, language));
            }
        }
        public IHttpActionResult Delete(int id)
        {
            if (languagesDAL.IsThereAnyLanguage(id) == false)
            {
                return NotFound();

            }
            else
            {
                languagesDAL.DeleteLanguage(id);
                return Ok();
            }
        }
    }
}