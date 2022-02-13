using ContactsWebAPI.EfStuff.DbModel;
using ContactsWebAPI.EfStuff.Repository;
using ContactsWebAPI.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Http;

namespace ContactsWebAPI.Controllers
{
    public class ApiDataController : ApiController
    {
        private AuthorRepository _authorRepository;
        private TextRepository _textRepository;
        private PhotoRepository _photoRepository;
        private ILogger<ApiDataController> _logger;

        public ApiDataController
            (
            AuthorRepository authorRepository,
            TextRepository textRepository,
            PhotoRepository photoRepository,
            ILogger<ApiDataController> logger
            )
        {
            _authorRepository = authorRepository;
            _textRepository = textRepository;
            _photoRepository = photoRepository;
            _logger = logger;
        }

        [HttpGet]
        public DataViewModel GetAllInfo() => new DataViewModel
        {
            Authors = _authorRepository.GetAll(),
            Texts = _textRepository.GetAll(),
            Photos = _photoRepository.GetAll(),
        };
        [HttpGet]
        public List<Photo> GetPhotos() => _photoRepository.GetAll();
        [HttpGet]
        public Photo GetPhoto(long id) => _photoRepository.Get(id);
        [HttpPut]
        public void ChangePhoto(Photo photo) => _photoRepository.Save(photo);
        [HttpGet]
        public StringBuilder GetTexts()
        {
            var ListOfTexts = _textRepository.GetAll();
            //before your loop
            var csv = new StringBuilder();

            //in your loop
            try
            {
                foreach (var text in ListOfTexts)
                {
                    var first = text.Name;
                    var second = text.Content;
                    //Suggestion made by KyleMit
                    var newLine = string.Format("{0},{1}", first, second);
                    csv.AppendLine(newLine);

                }
                return csv;
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Can't Converted in csv text | exception: {ex}");
                return null;
            }
        }
        [HttpPut]
        public void SetRatingPhoto(long id, int rate)
        {
            if (rate > 0 && rate <= 5)
            {
                var photo = _photoRepository.Get(id);
                photo.Rating = rate;
                _photoRepository.Save(photo);
            }
        }
        [HttpPost]
        public void AddText(Text text)
        {
            if (!(_authorRepository.Get(text.Author.Id) is null))
            {
                _textRepository.Save(text);
            }
        }
    }
}
