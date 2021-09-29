using AutoMapper;
using CleanArch.Application.Interfaces;
using CleanArch.Application.ViewModels;
using CleanArch.Domain.Commands;
using CleanArch.Domain.Core.Bus;
using CleanArch.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMedaitorHandler _bus;
        private readonly IMapper _autoMapper;
        public CourseService(ICourseRepository courseRepository , IMedaitorHandler bus, IMapper autoMapper)
        {
            _courseRepository = courseRepository;
            _bus = bus;
            _autoMapper = autoMapper;
        }

        public void Create(CourseViewModel courseViewModel)
        {
            /*var createCourseCommand = new CreateCourseCommand(
                courseViewModel.Name,
                courseViewModel.Decsription,
                courseViewModel.ImageUrl
            );*/
            _bus.SendCommand(_autoMapper.Map<CreateCourseCommand>(courseViewModel));
        }

        public CourseViewModel GetCourses()
        {

            return new CourseViewModel
            {
                Courses = _courseRepository.GetCourses()
            };
        }
    }
}
