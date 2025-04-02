using LeadManagementAPI.Domain.Entities;
using System.Threading.Tasks;

namespace LeadManagementAPI.Application.Interfaces
{
    public interface ILeadService
    {
        Task<Lead> ChangeStatusAsync(int id, string newStatus);
    }
}
