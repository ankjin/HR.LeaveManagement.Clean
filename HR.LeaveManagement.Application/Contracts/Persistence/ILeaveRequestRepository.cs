using HR.LeaveManagement.Domain;

namespace HR.LeaveManagement.Application.Contracts.Persistence
{
    public interface ILeaveRequestRepository : IGenericRepository<LeaveRequest>
    {
        ValueTask<LeaveRequest> GetLeaveRequestWithDetails(int id);
        ValueTask<List<LeaveRequest>> GetLeaveRequestWithDetails();
        ValueTask<List<LeaveRequest>> GetLeaveRequestWithDetails(string userId);
    }
}