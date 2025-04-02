using LeadManagementAPI.Infrastructure.Data;
using LeadManagementAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeadManagementAPI.Domain.Services
{
    public class LeadService
    {
        private readonly ApplicationDbContext _context;

        public LeadService(ApplicationDbContext context)
        {
            _context = context;
        }

        public decimal CalculatePriceToPay(decimal price)
        {
            if (price > 500)
            {
                return price * 0.9m;
            }
            return price;
        }

        public async Task<Lead> ChangeStatusAsync(int id, string newStatus)
        {
            var lead = await _context.Leads.FindAsync(id);
            if (lead == null)
            {
                throw new InvalidOperationException($"Lead with ID {id} not found.");
            }

            var validStatuses = new List<string> { "Invited", "Accepted", "Declined" };
            if (!validStatuses.Contains(newStatus))
            {
                throw new ArgumentException("Invalid status provided.");
            }

            lead.Status = newStatus;
            lead.PriceToPay = newStatus == "Accepted" ? CalculatePriceToPay(lead.Price) : lead.Price;

            _context.Entry(lead).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            // Enviar e-mail se o status for Accepted
            if (newStatus == "Accepted")
            {
                var emailService = new EmailService();
                var subject = $"Lead {lead.FullName} Accepted";
                var body = $"The lead {lead.FullName} has been accepted. Price to pay: {lead.PriceToPay:C}";

                //await emailService.SendEmailAsync("venda@test.com", subject, body); Não enviar
            }

            return lead;
        }



        public async Task<List<Lead>> GetLeadsAsync(string status = "Invited")
        {
            IQueryable<Lead> query = _context.Leads;

            if (!string.IsNullOrEmpty(status))
            {
                query = query.Where(lead => lead.Status == status);
            }

            return await query.ToListAsync();
        }
    }
}
