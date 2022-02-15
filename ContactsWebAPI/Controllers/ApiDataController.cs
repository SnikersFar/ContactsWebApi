using AutoMapper;
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
        private IMapper _mapper;
        public ApiDataController
            (
            AuthorRepository authorRepository,
            TextRepository textRepository,
            PhotoRepository photoRepository,
            ILogger<ApiDataController> logger, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _textRepository = textRepository;
            _photoRepository = photoRepository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public List<AuthorViewModel> GetAllInfo() => _mapper.Map<List<AuthorViewModel>>(_authorRepository.GetAll());
        [HttpGet]
        public List<PhotoViewModel> GetPhotos() => _mapper.Map<List<PhotoViewModel>>(_photoRepository.GetAll());
        [HttpGet]
        public PhotoViewModel GetPhoto(long id) => _mapper.Map<PhotoViewModel>(_photoRepository.Get(id));
        [HttpPut]
        public void ChangePhoto(PhotoViewModel photo)
        {
            var newPhoto = new Photo()
            {
                Id = photo.Id,
                Author = _authorRepository.Get(photo.AutrhorId),
                SizeOfPhoto = photo.SizeOfPhoto,
                Cost = photo.Cost,
                CountOfBuying = photo.CountOfBuying,
                Name = photo.Name,
                Rating = photo.Rating,
                UrlContent = photo.UrlContent,
            };
            _photoRepository.Save(newPhoto);
        }
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
        public void AddText(TextViewModel text)
        {
            if (!(_authorRepository.Get(text.AutrhorId) is null))
            {
                var NewPhoto = new Text()
                {
                    Author = _authorRepository.Get(text.AutrhorId),
                    Content = text.Content,
                    Size = text.Size,
                    Cost = text.Cost,
                    CountOfBuying = text.CountOfBuying,
                    DateCreate = text.DateCreate,
                    Name = text.Name,
                    Rating = text.Rating,
                };
                _textRepository.Save(NewPhoto);
            }
        }
    }
}
