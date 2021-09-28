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
        public CourseService(ICourseRepository courseRepository , IMedaitorHandler bus)
        {
            _courseRepository = courseRepository;
            _bus = bus;
        }

        public void Create(CourseViewModel courseViewModel)
        {
            var createCourseCommand = new CreateCourseCommand(
                courseViewModel.Name,
                courseViewModel.Decsription,
                courseViewModel.ImageUrl
            );

            _bus.SendCommand(createCourseCommand);
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
