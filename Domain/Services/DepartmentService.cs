using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Repositories;

namespace Domain.Services
{
    public class DepartmentService
    {
        private readonly DepartmentRepository _departmentRepository;

        public DepartmentService(DepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<IEnumerable<Department>> GetAllDepartments() => await _departmentRepository.GetDepartments();
        public async Task<Department> GetDepurtment(int departmentId) => await _departmentRepository.Get(departmentId);
    }
}